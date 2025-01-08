using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.model;

namespace OnlineFoodDelivery.Repository
{
    public class FoodItemRepository : IFoodItemRepository
    {

        public readonly OnlineFoodDeliveryDB  _Dbcontext;

        public FoodItemRepository(OnlineFoodDeliveryDB onlineFoodDeliveryDB)
        {
            _Dbcontext = onlineFoodDeliveryDB;
        }

        public async Task RegisterFoodItemAsync(FoodItems foodItems)
        {

            await _Dbcontext.FoodItems.AddAsync(foodItems);
            await _Dbcontext.SaveChangesAsync();
        }
    }
}
