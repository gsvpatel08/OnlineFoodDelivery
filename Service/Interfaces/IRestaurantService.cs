using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Utility;

namespace OnlineFoodDelivery.Service.Interfaces
{
    public interface IRestaurantService 
    {


        Task<ServiceResponse<string>> AddRestaurantAsync( RegisterRestaurantDto registerRestaurantDto );
    }
}
