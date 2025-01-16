using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineFoodDelivery.Models;
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

        [HttpGet("GetOrderStatus")]
        public async Task<IActionResult> GetOrderStatus(int orderId)

        {
            var response = await _orderService.GetOrderStatusAsync(orderId);
            if (!response.Success)
            {
                return NotFound(response);

            }
            return Ok(response);
        }

        [HttpGet("GetOrdersByRestaurantByID")]
        public async Task<IActionResult> GetOrdersByRestaurantById(int restaurantId)
        {
            if (restaurantId <= 0)
            {
                return BadRequest("A valid Restaurant ID is required.");
            }

           
            var responses = await _orderService.GetOrdersByRestaurantIDAsync(restaurantId);

            if (responses == null || responses.All(r => !r.Success))
            {
                return NotFound(responses?.FirstOrDefault()?.Message ?? "No orders found for the given restaurant ID.");
            }

           
            return Ok(responses);
        }
        }
    }
