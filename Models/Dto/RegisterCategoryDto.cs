using OnlineFoodDelivery.Module;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDelivery.model.Dto
{
    public class RegisterCategoryDto
    {
        [Required(ErrorMessage = "CategoryName can't be null")]
        public string CategoryName { get; set; }


        [Required(ErrorMessage = "CategoryName can't be null")]
        [StringLength (50,ErrorMessage ="Description is should be more than 5 character")]
        public string Description { get; set; } = string.Empty;


        [Required(ErrorMessage = "RestaurantID is required")]
        public int RestaurantID { get; set; }
    }
}
