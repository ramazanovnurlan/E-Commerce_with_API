using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models.Authentication
{
    public class RegisterM
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
