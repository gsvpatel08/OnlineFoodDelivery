using OnlineFoodDelivery.Models.Dto;
using OnlineFoodDelivery.Utility;

namespace OnlineFoodDelivery.Service.Interfaces
{
    public interface IOrderService
    {
        Task  <ServiceResponse<string>>   RegisterOrdersAsync(PlaceOrderDto registerOrderDto);
        Task<ServiceResponse<string>> DeleteOrderAsync(OrderDeleteDto orderDeleteDto);

       
        
            Task<List<ServiceResponse<string>>> GetOrdersByRestaurantName(string restaurantName);
        }
    }

