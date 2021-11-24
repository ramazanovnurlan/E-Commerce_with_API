using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models.Admin.AllMenu
{
    public class Menu //Electronics, Fashion, Furniture, Accessories, Perfumes, ...
    {
        public Menu()
        {
            Submenus = new HashSet<Submenu>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }

        //Menu özündə çoxlu sayda Submenu'ları saxlayır(One To Many)
        public ICollection<Submenu> Submenus { get; set; }
    }
}
