using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.entity
{
    class SaleMaster
    {
        public String sale_id { get; set; }
        public String clt_id { get; set; }
        public DateTime sale_date { get; set; }
        public int sale_total { get; set; }
        public String sale_deliv_status { get; set; }
    }
}
