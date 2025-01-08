using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodDelivery.model.Dto;
using OnlineFoodDelivery.Service.Interfaces;

namespace OnlineFoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        public readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }


        [HttpPost("Addcategory")]
        public async Task<IActionResult> Addcategory(RegisterCategoryDto registerCategoryDto)
        {
             var response = await _categoryService.RegisterCategoryAsync(registerCategoryDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet ("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _categoryService.GetAllFoodCategoriesAsync();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }  
    }
}
