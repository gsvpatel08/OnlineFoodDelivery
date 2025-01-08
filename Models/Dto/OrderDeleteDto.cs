using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDelivery.Models.Dto
{
    public class OrderDeleteDto
    {
        [Required (ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "ReasonForCancelation is required")]
        public string ReasonForCancelation { get; set; }

    }
}
