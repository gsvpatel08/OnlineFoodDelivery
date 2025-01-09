using System.Data.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Module.Dto;
using OnlineFoodDelivery.Repository;
using OnlineFoodDelivery.Service.Interfaces;
using OnlineFoodDelivery.Utility;

namespace OnlineFoodDelivery.Service
{
    public class RestaurentOwnerService : IRestaurentOwnerService

    {
        private readonly IRestaurentOwnerRepo _irestaurentOwnerRepo;
        private readonly IMapper _mapper;
        private readonly JwtHelper _jwtHelper;
        public RestaurentOwnerService(IRestaurentOwnerRepo restaurentOwnerRepo, IMapper mapper, JwtHelper jwtHelper)
        {
            _irestaurentOwnerRepo = restaurentOwnerRepo;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
        }

        public async Task<ServiceResponse<string>> LoginRestaurentOwnerAsync(LoginDto loginDto)
        {
            var restaurentOwner = await _irestaurentOwnerRepo.GetRestaurentOwnerByUsernameAsync(loginDto.Username);
            if (restaurentOwner == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, restaurentOwner.Password))
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "invalide user are incorrct password"
                };
            }
           var token =   _jwtHelper.GenerateToken(user: null ,restaurentOwner : restaurentOwner);
            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Login succesfull",
                Data = token
                
            };
        }
        public async Task<ServiceResponse<string>> RegisterRestaurentOwnerAsync(RestaurentOwnerDto restaurentOwnerDto)
        {

            try
            {
                var existringusername = await _irestaurentOwnerRepo.GetRestaurentOwnerByUsernameAsync(restaurentOwnerDto.UserName);
                var existringEmail = await _irestaurentOwnerRepo.GetRestaurentOwnerByEmailAsync(restaurentOwnerDto.email);

                if (existringusername != null || existringEmail != null)
                {

                    return new ServiceResponse<string>
                    {
                        Success = false,
                        Message = "username are email already exists"
                    };
                }



                var restaurentOwner = _mapper.Map<RestaurentOwner>(restaurentOwnerDto);
                restaurentOwner.Password = BCrypt.Net.BCrypt.HashPassword(restaurentOwnerDto.Password);

                await _irestaurentOwnerRepo.AddRestaurentOwnerAsync(restaurentOwner);

                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = $"Restaurant Member added successfully! <strong>and below showing number is your Owner_id please note done</strong>",
                    Data = restaurentOwner.OwnerID.ToString()
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
    }

}