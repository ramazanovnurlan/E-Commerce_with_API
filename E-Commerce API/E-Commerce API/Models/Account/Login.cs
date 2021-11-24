using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.RegisterModel
{
    public class Login
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
