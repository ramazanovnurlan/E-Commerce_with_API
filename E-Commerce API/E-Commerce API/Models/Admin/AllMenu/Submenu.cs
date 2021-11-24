using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models.Admin.AllMenu
{
    public class Submenu //Computers, Laptops, Phones, TV, T-Shirt, Trousers, Skirt, Kitchen furniture, Bedroom furniture, Watch, Ring, Men Perfumes, Women Perfumes...
    {
        public Submenu()
        {
            Brands = new HashSet<Brand>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }

        //Submenu da bir Menu'ya aid olur(Many To One)
        public int MenuID { get; set; }
        public Menu Menu { get; set; }

        //Submenu özündə çoxlu sayda Brand'ları saxlayır(One To Many)
        public ICollection<Brand> Brands { get; set; }
    }
}
