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
        public CategoryRepository(OnlineFoodDeliveryDB onlineFoodDeliveryDB)
        {
            _Dbcontext = onlineFoodDeliveryDB;
        }

       
        public async  Task<FoodCategory> GetCategoryByCategoryNameAsync(string categoryName)
        {
           return  await _Dbcontext.FoodCategory.FirstOrDefaultAsync(c =>  c.CategoryName == categoryName);
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