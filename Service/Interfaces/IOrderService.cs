using OnlineFoodDelivery.Models.Dto;
using OnlineFoodDelivery.Utility;

namespace OnlineFoodDelivery.Service.Interfaces
{
    public interface IOrderService
    {
        Task  <ServiceResponse<string>>   RegisterOrdersAsync(RegisterOrderDto registerOrderDto);
        Task<ServiceResponse<string>> DeleteOrderAsync(OrderDeleteDto orderDeleteDto);
    }
}
