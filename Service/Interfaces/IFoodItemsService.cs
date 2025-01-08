using OnlineFoodDelivery.model;
using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Utility;

namespace OnlineFoodDelivery.Service.Interfaces
{
    public interface IFoodItemsService
    {

        Task<ServiceResponse<string>> RegisterFoodItemAsync(RegisterFoodItemsDto registerFoodItemsDto);


    }
}
