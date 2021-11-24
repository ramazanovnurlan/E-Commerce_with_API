using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models.Admin.AllMenu
{
    public class IncomingProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductionYear { get; set; }
        public string MainImage { get; set; }
        public List<string> Pictures { get; set; }

        //------------------------------------------//

        public int SubmenuID { get; set; }
        public int BrandID { get; set; }
        public int ColorID { get; set; }
        public int OpSystemID { get; set; }
        public int ProcessorID { get; set; }
        public int RAMID { get; set; }
        public int StorageID { get; set; }
        public int SSDID { get; set; }
        public int GraphicsCardID { get; set; }
        public int StyleJoinID { get; set; }
        public int FrontCameraID { get; set; }
        public int RearCameraID { get; set; }
        public string Battery { get; set; }
    }
}
