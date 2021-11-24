using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models.Admin.AllMenu
{
    public class Product
    {
        public Product()
        {
            Pictures = new HashSet<Picture>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 1000, MinimumLength = 2)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Price { get; set; }

        [Required]
        public string ProductionYear { get; set; }

        [Required]
        public string Battery { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        [StringLength(maximumLength: 200, MinimumLength = 2)]
        public string MainImage { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        //Buna bax!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        //[StringLength(maximumLength: 1000, MinimumLength = 2)]
        //public string Questions { get; set; }

        //[StringLength(maximumLength: 1000, MinimumLength = 2)]
        //public string Answers { get; set; }

        //-------------------------------------------------------------------------------------//

        public int MenuID { get; set; }
        public int SubmenuID { get; set; }

        //-------------------------------------------------------------------------------------//

        //Brand da bir Submenu'ya aid olur(Many To One)

        public int BrandID { get; set; }
        public Brand Brand { get; set; }

        //-------------------------------------------------------------------------------------//

        //Model'lər də bir Product'a aid olur(Many To One)
        public int ColorID { get; set; }
        public Color Color { get; set; }

        public int OpSystemID { get; set; }
        public OpSystem OpSystem { get; set; }

        public int ProcessorID { get; set; }
        public Processor Processor { get; set; }

        public int RAMID { get; set; }
        public RAM RAM { get; set; }

        public int StorageID { get; set; }
        public Storage Storage { get; set; }

        public int SSDID { get; set; }
        public SSD SSD { get; set; }

        public int GraphicsCardID { get; set; }
        public GraphicsCard GraphicsCard { get; set; }

        public int StyleJoinID { get; set; }
        public StyleJoin StyleJoin { get; set; }

        public int FrontCameraID { get; set; }
        public FrontCamera FrontCamera { get; set; }

        public int RearCameraID { get; set; }
        public RearCamera RearCamera { get; set; }
    }
}
