using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDelivery.Module.Dto
{
    public class ResetPasswordDto
    {
        public string Token { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string NewPassword { get; set; }
        public string Username { get; set; }

    }
}
