


using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Repository;
using OnlineFoodDelivery.Service;
using OnlineFoodDelivery.Utility;
using Org.BouncyCastle.Crypto.Generators;
using System.Net.Mail;



public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtHelper _jwtHelper;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, JwtHelper jwtHelper, IEmailService emailService, IMapper mapper)
    {
        _userRepository = userRepository;
        _jwtHelper = jwtHelper;
        _emailService = emailService;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<string>> RegisterAsync(RegisterUserDto registerDto)
    {
        try
        {
            var existingUserName = await _userRepository.GetUserByUsernameAsync(registerDto.Username);
            var existingUsereamil = await _userRepository.GetUserByEmailAsync(registerDto.Email);
            if (existingUserName != null || existingUsereamil != null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Username or eamil already exists"
                };
            }
             var user = _mapper.Map<User>(registerDto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            //var user = new User
            //{
            //    FullName = registerDto.FullName,
            //    Username = registerDto.Username,
            //    Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
            //    Email = registerDto.Email,
            //    Address = registerDto.Address,
            //    Phone = registerDto.Phone,
            //    CreatedDate = DateTime.UtcNow,
            //    DOB = registerDto.DOB
            //};

            await _userRepository.AddUserAsync(user);

            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Registration successful"
            };
        }
        catch (DbUpdateException ex)
        {

            Console.WriteLine($"Database Update Error: {ex.Message}");

            return new ServiceResponse<string>
            {
                Success = false,
                Message = "A database error occurred while registering the user. Please try again later."
            };
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Unexpected Error: {ex.Message}");

            return new ServiceResponse<string>
            {
                Success = false,
                Message = "An unexpected error occurred. Please try again later."
            };
        }
    }

    public async Task<ServiceResponse<string>> LoginAsync(LoginDto loginDto)
    {
        try
        {
            var user = await _userRepository.GetUserByUsernameAsync(loginDto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Invalid credentials"
                };
            }

            var token = _jwtHelper.GenerateToken(user : user,restaurentOwner :null);

            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Login successfully",
                Data = token
            };
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Unexpected Error: {ex.Message}");

            return new ServiceResponse<string>
            {
                Success = false,
                Message = "An unexpected error occurred. Please try again later."
            };
        }
    }
    public async Task<ServiceResponse<string>> ForgotPasswordAsync(string email)
    {
        try
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Email not found",


                };
            }

            var resetToken = _jwtHelper.GenerateResetToken(user);
            await _emailService.SendResetPasswordEmail(user.Email, resetToken);

            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Password reset link sent",
                Data = resetToken
            };
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Unexpected Error: {ex.Message}");

            return new ServiceResponse<string>
            {
                Success = false,
                Message = "An unexpected error occurred. Please try again later."
            };
        }
    }
    public async Task<ServiceResponse<string>> ResetPasswordAsync(string token, string username, string newPassword)
    {
        try
        { // Validate the token
            var isTokenValid = await _jwtHelper.ValidateResetTokenAsync(token);
            if (!isTokenValid)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Invalid token"
                };
            }

            // Retrieve the user by username
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "User not found"
                };
            }

            // Update the user's password
            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveChangesAsync();

            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Password reset successful"
            };
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Unexpected Error: {ex.Message}");

            return new ServiceResponse<string>
            {
                Success = false,
                Message = "An unexpected error occurred. Please try again later."
            };


        }
    }
}