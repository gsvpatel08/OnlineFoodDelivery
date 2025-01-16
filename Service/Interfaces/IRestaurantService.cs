using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Models.Dto;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Utility;
using OnlineFoodDelivery.Utility.Enums;

namespace OnlineFoodDelivery.Service.Interfaces
{
    public interface IRestaurantService
    {


        Task<ServiceResponse<string>> AddRestaurantAsync(RegisterRestaurantDto registerRestaurantDto);
        //Task<ServiceResponse<List<string>>> GetRestaurantNamesByCategoryAsync(string categoryName);
        Task<ServiceResponse<List<string>>> GetRestaurantNamesByCategoryNameAsync(string categoryName);

        Task<ServiceResponse<string>> UpdateRestaurantRatingsAsync(int restaurantId, RestaurantRatings newRating);

    }
}
