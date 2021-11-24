using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_MVC.Areas.Admin.Models.AllMenu
{
    public class ProductFilter
    {
        public List<Product> Products { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Submenu> Submenus { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Color> Colors { get; set; }
        public List<OpSystem> OpSystems { get; set; }
        public List<Processor> Processors { get; set; }
        public List<RAM> RAMs { get; set; }
        public List<Storage> Storages { get; set; }
        public List<SSD> SSDs { get; set; }
        public List<GraphicsCard> GraphicsCards { get; set; }
        public List<StyleJoin> StyleJoins { get; set; }
        public List<FrontCamera> FrontCameras { get; set; }
        public List<RearCamera> RearCameras { get; set; }
    }
}
