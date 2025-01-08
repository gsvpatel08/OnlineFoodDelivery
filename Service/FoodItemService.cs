using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineFoodDelivery.model;
using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Repository;
using OnlineFoodDelivery.Service.Interfaces;
using OnlineFoodDelivery.Utility;

namespace OnlineFoodDelivery.Service
{
    public class FoodItemService : IFoodItemsService
    {

        public readonly IFoodItemRepository _foodItemRepository;
        public readonly IMapper _mapper;

        public FoodItemService(IFoodItemRepository foodItemRepository , IMapper mapper)
        {
            _foodItemRepository = foodItemRepository;
            _mapper = mapper;
        }

        public async  Task<ServiceResponse<string>> RegisterFoodItemAsync(RegisterFoodItemsDto registerFoodItemsDto)
        {
            try { 
            //var FoodItems = new FoodItems
            //{
            //    ItemName = registerFoodItemsDto.ItemName,
            //    Price = registerFoodItemsDto.Price,
            //    Description = registerFoodItemsDto.Description,
            //    AvailabilityStatus = registerFoodItemsDto.AvailabilityStatus,
            //    ImageUrl = registerFoodItemsDto.ImageUrl,
            //    CategoryId = registerFoodItemsDto.CategoryId,
            //    Restaurantid = registerFoodItemsDto.Restaurantid,
            //};
              var fooditems =  _mapper.Map<FoodItems>(registerFoodItemsDto);
             await _foodItemRepository.RegisterFoodItemAsync(fooditems);
           return new ServiceResponse<string>
           {
               Success = true,
               Message = "foodItem add successfully!"

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
