


using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.model;
using OnlineFoodDelivery.Models.Dto;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Repository;
using OnlineFoodDelivery.Service;
using OnlineFoodDelivery.Utility;
using OnlineFoodDelivery.Utility.ApiResponses;
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

            var token = _jwtHelper.GenerateToken(user: user, restaurentOwner: null);

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

    public async Task<List<ServiceResponse<RestaurentFoodItemListApiResponse>>> GetFoodItemsByRestaurantNameAsync(string restaurantName)
    {

        var response = new List<ServiceResponse<RestaurentFoodItemListApiResponse>>();

        // Fetch all restaurants and food items
        var restaurants = await Task.Run(() => _userRepository.GetAllRestaurantsAsync());
        var foodItems = await Task.Run(() => _userRepository.GetAllFoodItemsAsync());

        var restaurant = restaurants.FirstOrDefault(r => r.RestaurantName == restaurantName);

        if (restaurant == null)
        {
            response.Add(new ServiceResponse<RestaurentFoodItemListApiResponse>
            {
                Success = false,
                Message = "Restaurant not found.",
                Data = null
            });

            return response;
        }

        var filteredFoodItems = foodItems
            .Where(f => f.Restaurantid == restaurant.RestaurantID)
            .Select(f => new RestaurentFoodItemListApiResponse
            {
                RestaurantName = restaurant.RestaurantName,
                RestaurantId = restaurant.RestaurantID,
                ItemName = f.ItemName,
                ItemId = f.ItemID,
                Price = f.Price
            })
            .ToList();

        if (!filteredFoodItems.Any())
        {
            response.Add(new ServiceResponse<RestaurentFoodItemListApiResponse>
            {
                Success = false,
                Message = "No food items found for the given restaurant.",
                Data = null
            });
        }
        else
        {
            response.AddRange(filteredFoodItems.Select(foodItem => new ServiceResponse<RestaurentFoodItemListApiResponse>
            {
                Success = true,
                Message = "Food item retrieved successfully.",
                Data = foodItem
            }));
        }

        return response;
    }

    public async Task<List<ServiceResponse<FoodCategoryResponse>>> GetFoodCategoriesWithItemsAsync()
    {
        var response = new List<ServiceResponse<FoodCategoryResponse>>();

        var foodCategories = await _userRepository.GetFoodCategoriesWithItemsAsync();

        if (foodCategories == null || !foodCategories.Any())
        {
            return new List<ServiceResponse<FoodCategoryResponse>>()
            {
                new ServiceResponse<FoodCategoryResponse>
                {
                    Success = false,
                    Message = "No food categories found.",
                    Data = null
                }
            };
        }

        
        foreach (var category in foodCategories)
        {
            var categoryResponse = new FoodCategoryResponse
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Items = category.FoodItems.Select(item => new FoodItemResponse
                {
                    ItemId = item.ItemID,
                    ItemName = item.ItemName,
                    Price = item.Price
                }).ToList()
            };

            response.Add(new ServiceResponse<FoodCategoryResponse>
            {
                Success = true,
                Message = "Food categories and items retrieved successfully.",
                Data = categoryResponse
            });
        }

        return response;
    }

    public async Task<List<ServiceResponse<string>>> GetAllRestaurantsNamesAsync()
    {
        var response = new List<ServiceResponse<string>>();

        var restaurants = _userRepository.GetAllRestaurantsAsync();

        if (restaurants == null || !restaurants.Any())
        {

            response.Add(new ServiceResponse<string>()
            {

                Success = false,
                Message = "No Restaurants are found",
                Data = null
            });
        }
        else
        {
            foreach (var restaurant in restaurants)
            {
                response.Add(new ServiceResponse<string>
                {

                    Success = true,
                    Message = "Restaurant name retrieved successfully.",
                    Data = restaurant.RestaurantName

                }
                    );

            }

        }
        return response;
    }

    public async Task<ServiceResponse<string>> UpdateUser(UserUpdateDto userUpdateDto)
    {
        var response = await _userRepository.GetUserByIDAsync(userUpdateDto.userID);
        if (response == null)
        {
            return new ServiceResponse<string>()
            {
                Success = false,
                Message = "user is not found!"

            };
        }

        var User = new User
        {
            FullName = userUpdateDto.FullName,
            Email = userUpdateDto.Email,
            Phone = userUpdateDto.Phone,
            Address = userUpdateDto.Address,
            Username = userUpdateDto.Username,
            Password = userUpdateDto.Password,




        };

        return new ServiceResponse<string>
        {

            Success = true,
            Message = "user data updated successfully! your userId is same as previous"

          
        };
} }