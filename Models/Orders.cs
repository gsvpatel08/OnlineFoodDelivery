using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineFoodDelivery.model;
using OnlineFoodDelivery.Module;

namespace OnlineFoodDelivery.Models
{
    public class Orders
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }


        [Required(ErrorMessage = "UserId is required")]
        //[ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User user { get; set; }



        [Required(ErrorMessage = "RestaureantID is required")]
        //[ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }
        [ForeignKey(nameof(RestaurantID))]
        public Restaurant restaurant { get; set; }



        [Required(ErrorMessage = "ItemID is required")]
        //[ForeignKey("FoodItems")]
        public int ItemID { get; set; }
        [ForeignKey(nameof(ItemID))]
        public FoodItems foodItems  { get; set; }



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
