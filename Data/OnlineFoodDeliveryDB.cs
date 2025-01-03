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
    }

}
