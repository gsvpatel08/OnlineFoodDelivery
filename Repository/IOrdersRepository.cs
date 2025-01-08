using OnlineFoodDelivery.Models;

namespace OnlineFoodDelivery.Repository
{
    public interface IOrdersRepository
    {

        Task RegisterOrdersAsync(Orders orders);
        Task UpdateOrdersAsync(Orders orders);
        Task DeleteOrdersAsync(Orders orders);

        Task<Orders> GetOrderByIDAsync(int OrderID);
    }
}
