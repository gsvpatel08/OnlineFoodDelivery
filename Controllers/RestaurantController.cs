using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Service.Interfaces;
using OnlineFoodDelivery.Utility;
using OnlineFoodDelivery.Utility.Enums;

namespace OnlineFoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {


        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService service)
        {
            _restaurantService = service;
        }
        [Authorize]
        [HttpPost("AddRestaurant")]
        public async Task<IActionResult> AddRestaurant(RegisterRestaurantDto RegisterRestaurantDto)
        {
            var response = await _restaurantService.AddRestaurantAsync(RegisterRestaurantDto);

            if (response != null)
            {
                return BadRequest(response);
            }
            return Ok();

        }
        //[HttpGet("restaurants/{categoryName}")]
        //public async Task<IActionResult> GetRestaurantsByCategory(string categoryName)
        //{
        //    var response = await _restaurantService.GetRestaurantNamesByCategoryAsync(categoryName);

        //    if (!response.Success)
        //    {
        //        return NotFound(response.Message);
        //    }

        //    return Ok(response.Data);
        //}

        [HttpGet("GetRestaurantsByCategoryName/{categoryName}")]
        public async Task<IActionResult> GetRestaurantsByCategoryName(string categoryName)
        {
            var response = await _restaurantService.GetRestaurantNamesByCategoryNameAsync(categoryName);

            if (!response.Success)
            {
                return NotFound(response.Message);
            }

            return Ok(response.Data);
        }
        [HttpPut("UpdateRating/{restaurantId}")]
        public async Task<IActionResult> UpdateRestaurantRating(int restaurantId, RestaurantRatings newRating)
        {
            var response = await _restaurantService.UpdateRestaurantRatingsAsync(restaurantId, newRating);

            if (!response.Success)
            {
                return NotFound(response.Message);
            }

            return Ok(response.Message);
        }
    }
}