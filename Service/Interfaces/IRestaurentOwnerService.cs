using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Module.Dto;
using OnlineFoodDelivery.Utility;

namespace OnlineFoodDelivery.Service.Interfaces
{
    public interface IRestaurentOwnerService
    {

        Task<ServiceResponse<string>> RegisterRestaurentOwnerAsync(RestaurentOwnerDto restaurentOwner);
        Task<ServiceResponse<string>> LoginRestaurentOwnerAsync(LoginDto loginDto);



    }
}
