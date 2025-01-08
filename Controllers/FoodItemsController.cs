using Microsoft.AspNetCore.Mvc;
using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Service.Interfaces;

namespace OnlineFoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodItemsController : Controller
    {

        public readonly IFoodItemsService _foodItemsService;

        public FoodItemsController(IFoodItemsService foodItemsService)
        {
            _foodItemsService = foodItemsService;
        }

        [HttpPost("RegisterFoodItem")]
        public async Task<IActionResult> RegisterFoodItem(RegisterFoodItemsDto registerFoodItemsDto0)
        {
            var responce = await _foodItemsService.RegisterFoodItemAsync(registerFoodItemsDto0);

            if (!responce.Success)
            {
                return BadRequest(responce);

            }
            return Ok();
        }
    }
}