using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Models.Dto;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Utility.Enums;

namespace OnlineFoodDelivery.Repository
{
    public interface IRestaurentRepository
    {

        Task AddRestaurantAsync(Restaurant Restaurant);

        Task UpdateRestaurantRatingsAsync(int restaurantId, RestaurantRatings newRating);

        Task<Restaurant> GetRestaurantByIdAsync(int id);

        Task<Restaurant> GetRestaurantByNameAsync (string name);
        Task<Restaurant> GetRestaurantByEmailAsync(string email);
        Task<Restaurant> GetRestaurantByphoneAsync(string phone);
        //Task<List<Restaurant>> GetRestaurantsByCategoryAsync(string categoryName);
        Task<List<Restaurant>> GetRestaurantsByCategoryNameAsync(string categoryName);

    }
}
