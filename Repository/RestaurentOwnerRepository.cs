using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.Repository
{
    public class RestaurentOwnerRepository : IRestaurentOwnerRepo

    {
        public readonly OnlineFoodDeliveryDB _DbContext;
        public RestaurentOwnerRepository(OnlineFoodDeliveryDB Dbcontext)
        {
            _DbContext = Dbcontext;


        }

        public async  Task AddRestaurentOwnerAsync(RestaurentOwner restaurentOwner)
        {
             await _DbContext.RestaurantOwnerInfo.AddAsync(restaurentOwner);
            await _DbContext.SaveChangesAsync();
        }

        public  Task<RestaurentOwner> GetRestaurentOwnerByEmailAsync(string email)
        {
          return   _DbContext.RestaurantOwnerInfo.FirstOrDefaultAsync(e => e.email == email);
            
        }

        public async Task<RestaurentOwner> GetRestaurentOwnerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public  Task<RestaurentOwner> GetRestaurentOwnerByUsernameAsync(string username)
        {
             return  _DbContext.RestaurantOwnerInfo.FirstOrDefaultAsync(u => u.UserName == username);

        }

        public async  Task SavaChangesAsync()
        {
            await _DbContext.SaveChangesAsync();

        }

        public Task UpdateRestaurentOwnerAsync(RestaurentOwner restaurent)
        {
            throw new NotImplementedException();
        }

        
    }
}