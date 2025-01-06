using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnlineFoodDelivery.Utility.Enums;

namespace OnlineFoodDelivery.Module
{
    public class RestaurantInformations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantID { get; set; }  // Primary Key

        [ForeignKey("RestaurentOwner")]  // This specifies that OwnerID is a foreign key pointing to RestaurentOwner
        public int OwnerID { get; set; } // Foreign Key to RestaurentOwner

        [Required(ErrorMessage = "Restaurant name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Restaurant name must be between 3 and 100 characters.")]
        public string RestaurantName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string RestaurantEmail { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\+?(\d{1,4})?[\s\-]?\(?\d{1,4}?\)?[\s\-]?\d{1,4}[\s\-]?\d{1,4}$", ErrorMessage = "Invalid phone number format.")]
        public string RestaurantPhone { get; set; }

        [Required(ErrorMessage = "Ratings are required.")]
        [Range(1, 5, ErrorMessage = "Ratings must be between 1 and 5.")]
        public int RestaurantRatings { get; set; }  // Assuming Ratings is an integer (1-5)

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Opened date is required.")]
        public DateOnly RestaurantOpenedDate { get; set; }

        [Required(ErrorMessage = "Opening time is required.")]
        public TimeOnly OpeningTime { get; set; }

        [Required(ErrorMessage = "Closing time is required.")]
        public TimeOnly ClosingTime { get; set; }

        // Navigation Property for the relationship with RestaurentOwner
        public RestaurantRatings RestaurentOwner { get; set; }
    }

}

