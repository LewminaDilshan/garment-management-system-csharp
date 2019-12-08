using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.entity
{
    class StockProduct
    {
        public String ProId { get; set; }
        public String ProType { get; set; }
        public String Brand { get; set; }
        public String Design { get; set; }
        public String Size { get; set; }
        public String Color { get; set; }
        public String FabricType { get; set; }
        public String Quantity { get; set; }
        public String Description { get; set; }
        public String Price { get; set; }
        public String DamageStatus { get; set; }
        public byte[] ProImg { get; set; }
    }
}
