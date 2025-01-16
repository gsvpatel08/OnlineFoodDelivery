using OnlineFoodDelivery.Models;
using OnlineFoodDelivery.Models.Dto;
using OnlineFoodDelivery.Utility;

namespace OnlineFoodDelivery.Service.Interfaces
{
    public interface IOrderService
    {
            Task  <ServiceResponse<string>>   RegisterOrdersAsync(PlaceOrderDto registerOrderDto);
            Task<ServiceResponse<string>> DeleteOrderAsync(OrderDeleteDto orderDeleteDto);

            Task<ServiceResponse<string>> GetOrderStatusAsync(int Orderid);
            Task<List<ServiceResponse<string>>> GetOrdersByRestaurantName(string restaurantName);
            Task<List<ServiceResponse<string>>> GetOrdersByRestaurantIDAsync(int resttaurentId);
        }
    }

