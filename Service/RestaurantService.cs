using AutoMapper;
using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Models.Dto;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Repository;
using OnlineFoodDelivery.Service.Interfaces;
using OnlineFoodDelivery.Utility;
using OnlineFoodDelivery.Utility.Enums;

namespace OnlineFoodDelivery.Service
{
    public class RestaurantService : IRestaurantService
    {


        private readonly IRestaurentRepository _restaurentRepository;

        private readonly JwtHelper _jwtHelper;

        private readonly IMapper _mapper;

        public RestaurantService(IRestaurentRepository restaurentRepository, JwtHelper jwtHelper, IMapper mapper)
        {
            _restaurentRepository = restaurentRepository;
            _jwtHelper = jwtHelper;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> AddRestaurantAsync(RegisterRestaurantDto registerRestaurantDto)
        {
            var token = await _jwtHelper.ValidateResetTokenAsync(registerRestaurantDto.Token);


            if (!token)
            {
                return new ServiceResponse<string>
                {

                    Success = false,
                    Message = "Invalid Token please enter valid one"

                };


            }

            //var owner =   await _restaurentRepository.GetRestaurantByIdAsync(registerRestaurantDto.OwnerID);
            //  if (owner == null)
            //  {
            //      return new ServiceResponse<string>
            //      {
            //          Success = false,
            //          Message = "Owner_Id is not Exist in database please provide valid one"
            //      };
            //  }

            var restaurent = await _restaurentRepository.GetRestaurantByNameAsync(registerRestaurantDto.RestaurantName);
            if (restaurent != null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "restaurant name is not available please try with different name"
                };
            }
            var restaurant = _mapper.Map<Restaurant>(registerRestaurantDto);
            await _restaurentRepository.AddRestaurantAsync(restaurant);

            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Restaurant details are add successfully! "
            };
        }

        //public  async Task<ServiceResponse<List<string>>> GetRestaurantNamesByCategoryAsync(string categoryName)
        //{
        //    var restaurants = await _restaurentRepository.GetRestaurantsByCategoryAsync(categoryName);
        //    var restaurantNames = restaurants.Select(r => r.RestaurantName).ToList();

        //    if (restaurantNames.Count == 0)
        //    {
        //        return new ServiceResponse<List<string>>
        //        {
        //            Success = false,
        //            Message = "No restaurants found for the given category.",
        //            Data = null
        //        };
        //    }

        //    return new ServiceResponse<List<string>>
        //    {
        //        Success = true,
        //        Data = restaurantNames
        //    };
        //}

        public async Task<ServiceResponse<List<string>>> GetRestaurantNamesByCategoryNameAsync(string categoryName)
        {
            var restaurants = await _restaurentRepository.GetRestaurantsByCategoryNameAsync(categoryName);
            var restaurantNames = restaurants.Select(r => r.RestaurantName).ToList();

            if (restaurantNames.Count == 0)
            {
                return new ServiceResponse<List<string>>
                {
                    Success = false,
                    Message = "No restaurants found for the given category.",
                    Data = null
                };
            }

            return new ServiceResponse<List<string>>
            {
                Success = true,
                Data = restaurantNames
            };
        }

        public async Task<ServiceResponse<string>> UpdateRestaurantRatingsAsync(int restaurantId, RestaurantRatings newRating)
        
            {
                var restaurant = await _restaurentRepository.GetRestaurantByIdAsync(restaurantId);

                if (restaurant == null)
                {
                    return new ServiceResponse<string>
                    {
                        Success = false,
                        Message = "Restaurant not found!"
                    };
                }

                await _restaurentRepository.UpdateRestaurantRatingsAsync(restaurantId, newRating);

                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = "Restaurant rating updated successfully!"
                };
            }
    }
    
    }

