using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Final_Project.entity;
using System.Text.RegularExpressions;

namespace Final_Project.repository
{
    class SalesOrderDBaccess
    {
        private DataBaseConnecion dbCon;
        private SqlCommand cmd;
        private DataTable dt;
        public SalesOrderDBaccess()
        {
            dbCon = new DataBaseConnecion();
            cmd = new SqlCommand();

        }
        public int createSale_master(SaleMaster SM)
        {
            dbCon.openCon();
            String st = "Pending";
            cmd = new SqlCommand("insert into Sales_master (sale_id,clt_id,sale_date,sale_total,sale_status) values('" + SM.sale_id + "','" + SM.clt_id + "','" + SM.sale_date + "','" + SM.sale_total + "','" + st + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int createSale_details(SaleDetails SD)
        {
            dbCon.openCon();
            cmd = new SqlCommand("insert into Sales_details (sd_id,sale_id,sd_Product,Item_id,DesignId,PSizeId,fabricId,brandId,sd_qty,sd_Product_price) values('" + SD.sd_id + "','" + SD.sale_id + "','" + SD.sd_Product + "','" + SD.Item_id + "','" + SD.DesignId + "','" + SD.PSizeId + "','" + SD.fabricId + "','" + SD.brandId + "','" + SD.sd_qty + "','" + SD.sd_Product_price + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public String GetSDId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) sd_id from Sales_details order by sd_id desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            dbCon.closeCon();
            String SD_Id;
            SD_Id = dr["sd_id"].ToString();
            String abc = (Regex.Match(SD_Id, @"\d+").Value);
            int SDId = Convert.ToInt32(abc);
            SDId++;
            String newSDId = "SD" + SDId;
            return newSDId;
        }
        public String GetSaleId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) sale_id from Sales_master order by sale_id desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            String Sale_Id;
            Sale_Id = dr["sale_id"].ToString();
            dbCon.closeCon();
            String abc = (Regex.Match(Sale_Id, @"\d+").Value);
            int SaleId = Convert.ToInt32(abc);
            SaleId++;
            String newSMId = "SM" + SaleId;
            return newSMId;
        }
        public DataTable getSpecialSalesOrders(String status)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Sales_master where sale_status = '" + status + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getDeliveredSalesOrders(String status)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Sales_master where sale_Deliv_status = '" + status + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getAllSalesOrders()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select sale_id,clt_id,sale_date,sale_total,sale_status from Sales_master", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getSalesOrders()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Sales_master", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getOrdrProducts(String SMid)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select sd_Product,sd_qty,sd_Product_price from Sales_details where sale_id = '" + SMid + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public int UpdateSalesOrderStatus(String SMid, String Status)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Sales_master set sale_status = '" + Status + "' where sale_id = '" + SMid + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public DataTable getItemPrice(Item I)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select Item_id,productPrice from Product where ProductName = '" + I.ProductName + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getBrandPrice(Brand B)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select brandId,brandPrice from Brand where brandName = '" + B.brandName + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getDesignPrice(Design D)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select DesignId,DesignPrice from Design where ItemType = '" + D.ItemType + "' and DesignType = '" + D.DesignType + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getFabricTypePrice(FabricType F)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select fabricId,fabricPrice from FabricType where fabricType = '" + F.fabricType + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getProductSizePrice(ProductSize P)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select PSizeId,sizePrice from ProductSize where ItemType = '" + P.ItemType + "' and ProductSize = '" + P.ProSize + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataSet getSalesReport(String S)
        {
            dbCon.openCon();
            SqlCommand cmd = new SqlCommand(S, dbCon.con);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Sales_master");
            dbCon.closeCon();
            return ds;
        }
        public String findSales(String User, String Pass)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Sales where UserName = '" + User + "' and UserPassword = '" + Pass + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            String username = null;
            if (dt.Rows.Count != 0)
            {
                DataRow dr = dt.Rows[0];
                username = dr["UserName"].ToString();         
            }
            return username;
        }
    }
}
