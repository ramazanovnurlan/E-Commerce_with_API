using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models.Admin.AllMenu
{
    public class Picture
    {
        public int ID { get; set; }

        [Required]
        [StringLength(maximumLength: 300, MinimumLength = 2)]
        public string Name { get; set; }


        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
