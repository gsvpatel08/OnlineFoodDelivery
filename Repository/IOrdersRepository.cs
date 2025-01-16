using OnlineFoodDelivery.model;
using OnlineFoodDelivery.Models;
using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.Repository
{
    public interface IOrdersRepository
    {

        Task RegisterOrdersAsync(Orders orders);
        Task UpdateOrdersAsync(Orders orders);
        Task DeleteOrdersAsync(Orders orders);

        Task<Orders> GetOrderById(int orderId);

        Task<Orders> GetOrderByIDAsync(int OrderID);
        Task<Orders> GetOrderStatus(string deliverystatus);
        List<Orders> GetAllOrders();
        List<Restaurant> GetAllRestaurants();

        Task<List<Orders>> GetOdersByRestaurantsNameAsync(string restaurantName);
        Task<List<Orders>> GetOrdersByRestaurentIdAsync(int restaurantId);
            




    }
}
