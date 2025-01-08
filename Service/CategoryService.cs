using System.Data.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.model;
using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Service.Interfaces;
using OnlineFoodDelivery.Utility;

namespace OnlineFoodDelivery.Service
{
    public class CategoryService : ICategoryService
    {

        public readonly ICategoryRepository _categoryRepository;
        public readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<string>> GetAllFoodCategoriesAsync()
        {
            var response = await _categoryRepository.GetFoodCategoriesAsync();
            if (response == null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "no data found"
                };
            }
            var categoryNames = string.Join(", ", response.Select(category => category.CategoryName)); return new ServiceResponse<string>
            {
                Success = true,
                Message = "here is your data",
                Data = categoryNames
            };
        }

        public async Task<ServiceResponse<string>> RegisterCategoryAsync(RegisterCategoryDto registerCategoryDto)
        {
            try
            {

               var category =  await _categoryRepository.GetCategoryByCategoryNameAsync(registerCategoryDto.CategoryName);

                if (category != null)
                {
                    return new ServiceResponse<string>
                    {
                        Success = false,
                        Message = "Category already in the list dont allow for duplicate"

                    };
                }
                //var foodCategory = _mapper.Map<FoodCategory>(registerCategoryDto);

             var   FoodCategory = new FoodCategory 
                {
                    CategoryName = registerCategoryDto.CategoryName,
                    Description = registerCategoryDto.Description,
                    RestaurantID = registerCategoryDto.RestaurantID
                };

                await _categoryRepository.RegisterCategoryAsync(FoodCategory);
                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = "Category add successfully!"

                };
            }
            catch (DbUpdateException ex)
            {

                Console.WriteLine($"Database Update Error: {ex.Message}");

                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "A database error occurred while registering the user. Please try again later."
                };
            }

        }
    }
}