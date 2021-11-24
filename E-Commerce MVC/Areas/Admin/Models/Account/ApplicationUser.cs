using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_MVC.Areas.Admin.Models.Account
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
