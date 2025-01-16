using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.model;
using OnlineFoodDelivery.Models;
using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.Repository
{
    public class OrdersRepository : IOrdersRepository 
    {

        public readonly  OnlineFoodDeliveryDB _DbContext;

        public OrdersRepository(OnlineFoodDeliveryDB dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task DeleteOrdersAsync(Orders orders)
        {
            _DbContext.Orders.Remove(orders);
            _DbContext.SaveChanges();
        }

        public List<FoodItems> GetAllFoodItems()
        {
            return _DbContext.FoodItems.ToList();
        }

        public List<Orders> GetAllOrders()
        {
            return _DbContext.Orders.ToList();
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _DbContext.Restaurant.ToList();
        }

        public async Task<List<Orders>> GetOdersByRestaurantsNameAsync(string restaurantName)
        {

            return await(from restaurant in _DbContext.Restaurant
                         join order in _DbContext.Orders
                         on restaurant.RestaurantID equals order.RestaurantID 
                         where restaurant.RestaurantName == restaurantName
                         select order).ToListAsync();

        }

        public async Task<Orders> GetOrderById(int orderId)
        {
            return await _DbContext.Orders
                .Include(o => o.foodItems) 
                .FirstOrDefaultAsync(o => o.OrderID == orderId);
        }

        public async Task<Orders> GetOrderByIDAsync(int OrderID)
        {
           return await _DbContext.Orders.FirstOrDefaultAsync(i => i.OrderID == OrderID);
        }

        public  async Task<List<Orders>> GetOrdersByRestaurentIdAsync(int restaurantId)
        {
            return await(from restaurant in _DbContext.Restaurant
                         join order in _DbContext.Orders
                         on restaurant.RestaurantID equals order.RestaurantID
                         where restaurant.RestaurantID == restaurantId
                         select order).ToListAsync();
        }

        public async Task<Orders> GetOrderStatus(string deliverystatus)
        {
          return await _DbContext.Orders.FirstOrDefaultAsync(s => s.DeliveryStatus == deliverystatus);
        }

        public async Task RegisterOrdersAsync(Orders orders)
        {
            await _DbContext.Orders.AddAsync(orders);
             await _DbContext.SaveChangesAsync();
        }

        public Task UpdateOrdersAsync(Orders orders)
        {
            throw new NotImplementedException();
        }
    }
}
