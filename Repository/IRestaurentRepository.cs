using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.Repository
{
    public interface IRestaurentRepository
    {

        Task AddRestaurantAsync(Restaurant Restaurant);
        Task UpdateRestaurantAsync(Restaurant Restaurant);

        Task<Restaurant> GetRestaurantByIdAsync(int id);

        Task<Restaurant> GetRestaurantByNameAsync (string name);
        Task<Restaurant> GetRestaurantByEmailAsync(string email);
        Task<Restaurant> GetRestaurantByphoneAsync(string phone);


    }
}
