﻿using System.ComponentModel.DataAnnotations;

namespace OnlineFoodDelivery.Models.Dto
{
    public class UserUpdateDto
    {

        public string FullName { get; set; }

        public string Username { get; set; }


        public string Password { get; set; }

        public string Address { get; set; }

  
        public string Phone { get; set; }

    
        public string Email { get; set; }

   
    }
}
