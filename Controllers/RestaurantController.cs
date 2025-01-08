using Microsoft.AspNetCore.Mvc;
using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Service.Interfaces;

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
    }
}