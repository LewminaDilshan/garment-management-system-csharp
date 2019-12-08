using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.repository
{
    class ReportDBaccess
    {
        private DataBaseConnecion dbCon;
        private SqlCommand cmd;
        private DataTable dt;
        public ReportDBaccess()
        {
            dbCon = new DataBaseConnecion();
            cmd = new SqlCommand();
        }
        public DataTable getSalesReport(DateTime d1, DateTime d2)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Sales_master.sale_id, Client.clt_name, Sales_master.sale_date, Sales_master.sale_total From Sales_master INNER JOIN Client ON Sales_master.clt_id = Client.clt_id where Sales_master.sale_date between '" + d1 + "' AND '" + d2 + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getPurchaseReport(DateTime d1, DateTime d2)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("SELECT purchase_master.pur_id, Supplier.sup_name, purchase_master.pur_date, purchase_master.pur_total From purchase_master INNER JOIN Supplier ON purchase_master.sup_id = Supplier.sup_id where purchase_master.pur_date between '" + d1 + "' AND '" + d2 + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getClientcount(String Id, DateTime d1, DateTime d2)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * From Sales_master where clt_id = '" + Id + "' and sale_date between '" + d1 + "' AND '" + d2 + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getAllProduct()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select Pro_id,Product_Type,Brand,Design,Size,Color,Fabric_Type,Quantity from Stock_Product", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getAllMaterial()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select Mat_id,Material_Type,Size,Color,Quantity from Stock_Materials", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
    }
}
