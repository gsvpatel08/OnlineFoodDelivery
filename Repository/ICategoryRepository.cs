using OnlineFoodDelivery.model;
using OnlineFoodDelivery.model.Dto;

namespace OnlineFoodDelivery.Service.Interfaces
{
    public interface ICategoryRepository
    {
        Task RegisterCategoryAsync(FoodCategory foodCategory);
        Task<List<FoodCategory>> GetFoodCategoriesAsync(); 

        Task<FoodCategory> GetCategoryByCategoryNameAsync(string categoryName);
        



    }
}
