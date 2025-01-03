using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDelivery.Module
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [MaxLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters long.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [MaxLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [MaxLength(15, ErrorMessage = "Phone number cannot exceed 15 characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }


        public DateTime DOB { get; set; }
    }
}
