using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Final_Project.repository
{
    public class DataBaseConnecion
    {
        public SqlConnection con { get; set; }

        public DataBaseConnecion()
        {
            con = new SqlConnection("Data Source=MSI;Initial Catalog=GarmentDB;User ID=sa;Password=12345");
        }

        public void openCon()
        {
            con.Open();
        }

        public void closeCon()
        {
            con.Close();
        }
    }

}
