using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models.Admin.AllMenu
{
    public class FrontCamera
    {
        public FrontCamera()
        {
            Products = new HashSet<Product>();
        }

        public int ID { get; set; }

        [StringLength(maximumLength: 200, MinimumLength = 2)]
        public string Name { get; set; }

        //FrontCamera özündə çoxlu sayda Product Model'ləri saxlayır(One To Many)
        public ICollection<Product> Products { get; set; }
    }
}
