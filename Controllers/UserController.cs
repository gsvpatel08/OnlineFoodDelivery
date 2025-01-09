using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDelivery.Data;
using OnlineFoodDelivery.Models.Dto;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Module.Dto;
using OnlineFoodDelivery.Service;
using OnlineFoodDelivery.Service.Interfaces;

namespace OnlineFoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto registerDto)
        {
            var response = await _userService.RegisterAsync(registerDto);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var response = await _userService.LoginAsync(loginDto);
            if (!response.Success)
                return Unauthorized(response);

            return Ok(response);
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var response = await _userService.ForgotPasswordAsync(email);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var response = await _userService.ResetPasswordAsync(resetPasswordDto.Token, resetPasswordDto.Username, resetPasswordDto.NewPassword);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetFoodItemsByRestaurantName")]
        public async Task<IActionResult> GetFoodItemsByRestaurantName(string restaurantName)
        {
            if (string.IsNullOrEmpty(restaurantName))
            {
                return BadRequest("Restaurant name is required.");
            }

            var responses = await _userService.GetFoodItemsByRestaurantNameAsync(restaurantName);

            if (responses.All(r => !r.Success))
            {
                return NotFound(responses.First().Message);
            }

            return Ok(responses);
        }

        [HttpGet("GetFoodCategoriesWithItems")]
        public async Task<IActionResult> GetFoodCategoriesWithItems()
        {
            var result = await _userService.GetFoodCategoriesWithItemsAsync();

            if (result.All(r => !r.Success))
            {
                return NotFound(result.First().Message);
                
            }

            return Ok(result.Select(r => r.Data));



        }
        [HttpGet("GetAllRestaurantNames")]
        public async Task<IActionResult> GetAllRestaurantNames()
        {
            var response = await _userService.GetAllRestaurantsNamesAsync();
            if (response.All(r => !r.Success))
            {
                return NotFound(response.First().Message);
            }
            return Ok(response.Select(r => r.Data));
        }



        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var response = await _userService.UpdateUser(userUpdateDto);

            if (response.Success)
            {
                return NotFound(response);

            }
            return Ok(response);
        }
    }  }