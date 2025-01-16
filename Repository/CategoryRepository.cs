using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.model;
using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Service.Interfaces;

namespace OnlineFoodDelivery.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly OnlineFoodDeliveryDB _Dbcontext;
        private readonly string _connectionString;
        public CategoryRepository(OnlineFoodDeliveryDB onlineFoodDeliveryDB,IConfiguration configuration)
        {
            _Dbcontext = onlineFoodDeliveryDB;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

      

        public async  Task<FoodCategory> GetRestaurantINCategory(int RestaurantId)
        {
           return  await _Dbcontext.FoodCategory.FirstOrDefaultAsync(c =>  c.RestaurantID == RestaurantId);
        }

        public Task<List<FoodCategory>> GetFoodCategoriesAsync()
        {
            return _Dbcontext.FoodCategory.ToListAsync();
        }

        public async Task RegisterCategoryAsync(FoodCategory foodCategory)

        {
            await _Dbcontext.FoodCategory.AddAsync(foodCategory);
            await _Dbcontext.SaveChangesAsync();

        }
    }
}