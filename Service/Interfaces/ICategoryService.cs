using OnlineFoodDelivery.model;
using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Utility;

namespace OnlineFoodDelivery.Service.Interfaces
{
    public interface ICategoryService
    {

        Task <ServiceResponse<string>> RegisterCategoryAsync (RegisterCategoryDto registerCategoryDto);

        Task<ServiceResponse<string>> GetAllFoodCategoriesAsync();


    }
}
