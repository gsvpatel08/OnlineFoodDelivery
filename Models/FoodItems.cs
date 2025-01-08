using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineFoodDelivery.Module;
using OnlineFoodDelivery.Utility.Enums;

namespace OnlineFoodDelivery.model
{
    public class FoodItems
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; } 

        [Required(ErrorMessage = "Item name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Item name length must be between 3 and 20 characters")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(10, 800, ErrorMessage = "Price must be between 10 and 800")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description can't exceed 500 characters")]
        public string Description { get; set; } 

        [Required(ErrorMessage = "Availability status is required")]
        public ItemStatus AvailabilityStatus { get; set; } 

        public string ImageUrl { get; set; } = string.Empty; 

        [Required]
        public int Restaurantid { get; set; }

        [ForeignKey(nameof(Restaurantid))]
        public virtual Restaurant Restaurant { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual FoodCategory FoodCategory { get; set; }
    }
}