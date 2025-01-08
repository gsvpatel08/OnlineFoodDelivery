using OnlineFoodDelivery.model;

namespace OnlineFoodDelivery.Repository
{
    public interface IFoodItemRepository
    {

        Task RegisterFoodItemAsync(FoodItems foodItems);
    }
}
