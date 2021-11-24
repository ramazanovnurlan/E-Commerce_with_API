using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_MVC.Areas.Admin.Models.AllMenu
{
    public class ProductDetail
    {
        public Product Product { get; set; }
        public ProductFilter ProductFilter { get; set; }
        public List<Pictures> Pictures { get; set; }




        //

        public List<Color> nese { get; set; }
    }
}
