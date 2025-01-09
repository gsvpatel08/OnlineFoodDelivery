using OnlineFoodDelivery.model;
using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.Repository
{
   
        public interface IUserRepository
        {
            Task<User> GetUserByUsernameAsync(string username);
            Task<User> GetUserByEmailAsync(string email);
            Task AddUserAsync(User user);
            Task UpdateUserAsync(User user);
            Task SaveChangesAsync();

        
            List<Restaurant> GetAllRestaurantsAsync();
            List<FoodItems> GetAllFoodItemsAsync();

        Task<List<FoodCategory>> GetFoodCategoriesWithItemsAsync();




    }
}

