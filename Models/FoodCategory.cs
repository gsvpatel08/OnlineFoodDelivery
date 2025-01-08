using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.model
{
    public class FoodCategory 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "CategoryName can't be null")]
        public string CategoryName { get; set; }
        
        [Required]
         public int RestaurantID { get; set; }
        [ForeignKey(nameof(RestaurantID))]
        public Restaurant restaurant01  { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
