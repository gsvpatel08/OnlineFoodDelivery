using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFoodDelivery.Module
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

       
        public string Address { get; set; }

    
        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }


        public DateTime DOB { get; set; }
    }
}
