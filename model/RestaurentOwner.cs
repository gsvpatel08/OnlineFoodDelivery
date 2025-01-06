using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDelivery.Module
{
    public class RestaurentOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerID { get; set; }

        [Required(ErrorMessage = "Restaurent_OwnerName is required.")]
        [StringLength(40,MinimumLength =3,ErrorMessage = "Restaurent_OwnerName must be grater than 3")]
        public string Restaurent_OwnerName { get; set; }

        [Required(ErrorMessage ="UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string email { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number")]
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime createdDare { get; set; }

    }
}
