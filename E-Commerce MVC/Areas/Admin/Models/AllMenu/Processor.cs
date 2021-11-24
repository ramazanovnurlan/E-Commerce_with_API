using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_MVC.Areas.Admin.Models.AllMenu
{
    public class Processor
    {
        public int ID { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public int SubmenuID { get; set; }
    }
}
