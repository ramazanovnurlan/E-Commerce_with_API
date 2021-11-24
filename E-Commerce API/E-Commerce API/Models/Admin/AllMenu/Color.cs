using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models.Admin.AllMenu
{
    public class Color
    {
        public Color()
        {
            Products = new HashSet<Product>();
        }

        public int ID { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string Name { get; set; }

        //Color özündə çoxlu sayda Product Model'ləri saxlayır(One To Many)
        //Admin səhifəsinin Product View'sunda Product daxil edəndə, Dropdown Menu'sundan həmin Product'un Color'unu daxil edirik. Dropdown Menu'da hər bir Color'un ID'si var. Çünki Dropdown Menu'sunda olan Color'lar da Color Cədvəlindən ajax vasitəsilə çəkilib Dropdown Menu'na əlavə olunur. Belə olan halda Dropdown Menu'sunda Product'un Color'larını seçəndə həmin Color'un ID T-SQL'də Product cədvəlində ColorID sütuna düşür. 
        public ICollection<Product> Products { get; set; }
    }
}
