using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteProject1.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your Password")]
        public string ConfirmPassword { get; set; }
    }
}