using OnlineFoodDelivery.Models;
using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.Repository
{
    public interface IOrdersRepository
    {

        Task RegisterOrdersAsync(Orders orders);
        Task UpdateOrdersAsync(Orders orders);
        Task DeleteOrdersAsync(Orders orders);

        Task<Orders> GetOrderByIDAsync(int OrderID);
        List<Orders> GetAllOrders();
        List<Restaurant> GetAllRestaurants();
    }
}
