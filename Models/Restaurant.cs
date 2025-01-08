using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineFoodDelivery.Utility.Enums;

namespace OnlineFoodDelivery.Module
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantID { get; set; }  // Primary Key

        [Required(ErrorMessage ="Token is required")]
        public string Token { get; set; }

        [Required(ErrorMessage = "Restaurant name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Restaurant name must be between 3 and 100 characters.")]
        public string RestaurantName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string RestaurantEmail { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\+?(\d{1,4})?[\s\-]?\(?\d{1,4}?\)?[\s\-]?\d{1,4}[\s\-]?\d{1,4}$", ErrorMessage = "Invalid phone number format.")]
        public string RestaurantPhone { get; set; }




        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Opened date is required.")]
        public DateOnly RestaurantOpenedDate { get; set; }

        [Required(ErrorMessage = "Opening time is required.")]
        public TimeOnly OpeningTime { get; set; }

        [Required(ErrorMessage = "Closing time is required.")]
        public TimeOnly ClosingTime { get; set; }

        [Range(1, 5, ErrorMessage = "Ratings must be between 1 and 5.")]
        public RestaurantRatings restaurantRatings { get; set; }



        [Required]
        public int OwnerID { get; set; }  // This column will store the foreign key

        [ForeignKey(nameof(OwnerID))]  // Maps to RestaurentOwner.OwnerID
        public RestaurentOwner RestaurentOwnerId { get; set; }
    }

}

