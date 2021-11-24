using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_MVC.Areas.Admin.Models.AllMenu
{
    public class SSD
    {
        public int ID { get; set; }
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public int SubmenuID { get; set; }
    }
}
