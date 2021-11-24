using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models.Admin.AllMenu
{
    public class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }

        //Brand da bir Submenu'ya aid olur(Many To One)
        public int SubMenuID { get; set; }
        public Submenu Submenu { get; set; }

        //Brand özündə çoxlu sayda Product'ları saxlayır(One To Many)
        public ICollection<Product> Products { get; set; }
    }
}
