using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.model;
using OnlineFoodDelivery.Models;
using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.Data
{
    public class OnlineFoodDeliveryDB : DbContext
    {
        public OnlineFoodDeliveryDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<RestaurentOwner> RestaurentOwner { get; set; }
        public  DbSet<Restaurant> Restaurant { get; set; } 
        public DbSet<FoodCategory> FoodCategory { get; set; }

        public DbSet<FoodItems> FoodItems { get; set; }

        public DbSet<Orders> Orders { get; set; }



    }

}
