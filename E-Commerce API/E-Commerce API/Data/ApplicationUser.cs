using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string LastName { get; set; }
    }
}
