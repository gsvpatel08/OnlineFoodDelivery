using OnlineFoodDelivery.model;
using OnlineFoodDelivery.Module;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDelivery.Models.Dto
{
    public class RegisterOrderDto
    {

       


        [Required(ErrorMessage = "UserId is required")]
       
        public int UserId { get; set; }
       


        [Required(ErrorMessage = "RestaureantID is required")]
        public int RestaurantID { get; set; }
     



        [Required(ErrorMessage = "ItemID is required")]
        
        public int ItemID { get; set; }




        [Required(ErrorMessage = "TotalPrice is required")]
        public int TotalPrice { get; set; }


        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }


        [Required(ErrorMessage = "DeliveryAddress is required")]
        public string DeliveryAddress { get; set; }

        [Required(ErrorMessage = "PaymentMethod is required")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "PaymentStatus is required")]
        public string PaymentStatus { get; set; }

        [Required(ErrorMessage = "DeliveryStatus is required")]
        public string DeliveryStatus { get; set; }


    }
}
