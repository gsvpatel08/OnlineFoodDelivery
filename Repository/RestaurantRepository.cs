using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.Module;

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

        public Task UpdateRestaurantAsync(Restaurant Restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
