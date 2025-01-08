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

        [HttpPost("RegisterOrder")]
        public async Task<IActionResult> RegisterOrder(RegisterOrderDto registerOrderDto)
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
                return BadRequest(response);
            }
            return Ok();
        }
    }
}