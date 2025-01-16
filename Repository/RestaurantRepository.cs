using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.Models.Dto;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Utility.Enums;

namespace OnlineFoodDelivery.Repository
{
    public class RestaurantRepository : IRestaurentRepository

    {
        private readonly OnlineFoodDeliveryDB _DbContext;

        public RestaurantRepository(OnlineFoodDeliveryDB onlineFoodDeliveryDB)
        { 
        _DbContext = onlineFoodDeliveryDB;
        
        }
       
        public async Task AddRestaurantAsync(Restaurant Restaurant)
        {
            await  _DbContext.Restaurant.AddAsync(Restaurant);
            await _DbContext.SaveChangesAsync();
        }

        public Task<Restaurant> GetRestaurantByEmailAsync(string email)

        { 
            return _DbContext.Restaurant.FirstOrDefaultAsync( e => e.RestaurantEmail == email);
        }

        public Task<Restaurant> GetRestaurantByIdAsync(int id)
        {

            return _DbContext.Restaurant.FirstOrDefaultAsync(i => i.OwnerID == id);
         }

        public Task<Restaurant> GetRestaurantByNameAsync(string name)
        {
            return _DbContext.Restaurant.FirstOrDefaultAsync(n => n.RestaurantName == name);
        }

        public Task<Restaurant> GetRestaurantByphoneAsync(string phone)
        {
            return _DbContext.Restaurant.FirstOrDefaultAsync(p => p.RestaurantPhone == phone);
        }

        //public  async Task<List<Restaurant>> GetRestaurantsByCategoryAsync(string categoryName)
        //{
            
        //        return await _DbContext.Restaurant
        //            .Where(r => r.FoodCategories.Any(fc => fc.CategoryName == categoryName))
        //            .ToListAsync();
            
        //}

        public async Task<List<Restaurant>> GetRestaurantsByCategoryNameAsync(string categoryName)
        {
            var restaurants = await _DbContext.Restaurant
           .FromSqlRaw("EXEC GetRestaurantsByCategory @CategoryName = {0}", categoryName)
           .ToListAsync();

            return restaurants;
        }

        public async Task UpdateRestaurantAsync(Restaurant Restaurant)
        {
             _DbContext.Restaurant.Update(Restaurant);
            await _DbContext.SaveChangesAsync();
        }

        public async Task UpdateRestaurantRatingsAsync(int restaurantId, RestaurantRatings newRating)
        {
            var restaurant = await GetRestaurantByIdAsync(restaurantId);
            if (restaurant != null)
            {
                restaurant.restaurantRatings = newRating;
                await _DbContext.SaveChangesAsync();
            }
        }
    }
}
