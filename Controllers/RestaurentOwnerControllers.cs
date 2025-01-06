using Microsoft.AspNetCore.Mvc;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Module.Dto;
using OnlineFoodDelivery.Service.Interfaces;
using Org.BouncyCastle.Asn1.Bsi;

namespace OnlineFoodDelivery.Controllers
{
    public class RestaurentOwnerControllers : ControllerBase
    {
        private readonly IRestaurentOwnerService _restaurentOwnerService;
        public RestaurentOwnerControllers(IRestaurentOwnerService restaurentOwnerService)
        {
            _restaurentOwnerService = restaurentOwnerService;
        }

        [HttpPost("RegisterRestaurentOwner")]
        public async Task<IActionResult> RegisterRestaaurentOwner(RestaurentOwnerDto restaurentOwnerDto)
        {
            var response = await _restaurentOwnerService.RegisterRestaurentOwnerAsync(restaurentOwnerDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("LoginRestaurentOwner")]

        public async Task<IActionResult> LoginRestaurentOwner(LoginDto loginDto)
        {
            var response = await _restaurentOwnerService.LoginRestaurentOwnerAsync(loginDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
