using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.Data
{
    public class OnlineFoodDeliveryDB : DbContext
    {
        public OnlineFoodDeliveryDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RestaurentOwner> RestaurantOwnerInfo { get; set; }
        public DbSet<RestaurantInformations> RestaurantDetails { get; set; }



    }

}
