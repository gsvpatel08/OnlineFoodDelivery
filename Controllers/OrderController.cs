using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDelivery.Models.Dto;
using OnlineFoodDelivery.Service.Interfaces;

namespace OnlineFoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        public readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder(PlaceOrderDto registerOrderDto)
        {
            var response = await _orderService.RegisterOrdersAsync(registerOrderDto);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(OrderDeleteDto orderDeleteDto)
        {
            var response = await _orderService.DeleteOrderAsync(orderDeleteDto);
            if (response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetOrdersByRestaurantName")]
        public async Task<IActionResult> GetOrdersByRestaurantName(string restaurantName)
        {
            if (string.IsNullOrEmpty(restaurantName))
            {
                return BadRequest("Restaurant name is required.");
            }

            var responses = await _orderService.GetOrdersByRestaurantName(restaurantName);

            if (responses.All(r => !r.Success))
            {
                return NotFound(responses.First().Message);
            }

            return Ok(responses);
        }
    }
}