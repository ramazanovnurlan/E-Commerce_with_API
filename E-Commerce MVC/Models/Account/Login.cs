using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_MVC.Models.Account
{
    public class Login
    {
        [Required]
        [EmailAddress]
        [StringLength(maximumLength: 50, MinimumLength = 13)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
