using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_MVC.Areas.Admin.Models.AllMenu
{
    public class Product_and_ProductFilter
    {
        public List<Product> Products { get; set; }
        public ProductFilter ProductFilter { get; set; }
        public Submenu Submenu { get; set; }
    }
}
