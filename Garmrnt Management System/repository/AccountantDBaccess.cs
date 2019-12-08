using Final_Project.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Final_Project.repository
{
    class AccountantDBaccess
    {
        private DataBaseConnecion dbCon;
        private SqlCommand cmd;
        private DataTable dt;
        public AccountantDBaccess()
        {
            dbCon = new DataBaseConnecion();
            cmd = new SqlCommand();
        }

        public String GetItemId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) Item_id from Products order by Item_id desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            dbCon.closeCon();
            String Item_Id;
            Item_Id = dr["Item_id"].ToString();
            String abc = (Regex.Match(Item_Id, @"\d+").Value);
            int ItemId = Convert.ToInt32(abc);
            ItemId++;
            String newItemId = "I" + ItemId;
            return newItemId;
        }
        public DataTable getProduct()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select Item_id,Item_Type,Fabric_Type,Brand,Design,Size,Color,Descriptions from Products", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getNoPriceProduct()
        {
            dbCon.openCon();
            String st = "NO Price";
            SqlDataAdapter da = new SqlDataAdapter("select Item_id,Item_Type,Fabric_Type,Brand,Design,Size,Color,Descriptions,ProPrice_Status from Products where ProPrice_Status = '" + st+"' ", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getSentAccountantProduct()
        {
            dbCon.openCon();
            String st = "Sent To Accountant";
            SqlDataAdapter da = new SqlDataAdapter("select * from Products where ProPrice_Status = '" + st + "' ", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getALLProduct()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Products", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
       /* public int ChangePrice(Item I)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Products set ProCost = '" + I.ProCost + "',MarkupCost = '" + I.MarkupCost + "',SalesPrice = '" + I.SalesPrice + "' where Item_id = '" + I.ItemID + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int updateItem(Item I)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Products set Item_Type = '" + I.ItemType + "', Fabric_Type =  '" + I.FabricType + "', Brand = '" + I.Brand + "', Design = '" + I.Design + "', Size = '" + I.Size + "', Color = '" + I.Color + "', Descriptions = '" + I.Desc + "' where Item_id = '" + I.ItemID + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }*/
        public int ConfirmPriceUpdate(String St, String ID)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Products set ProPrice_Status = '" + St + "' where Item_id = '" + ID + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int removeItem(String ItemId)
        {
            dbCon.openCon();
            cmd = new SqlCommand("delete from Products where Item_id = '" + ItemId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public DataTable getItem(String status)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Product where CurrentStatus = '" + status + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getBrand(String status)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Brand where CurrentStatus = '" + status + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getDesign(String status)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Design where CurrentStatus = '" + status + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getFabricType(String status)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from FabricType where CurrentStatus = '" + status + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getProductSize(String status)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from ProductSize where CurrentStatus = '" + status + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public int updateBrandPrice(Brand B)
        {
            dbCon.openCon();
            String st = "Price Updated";
            cmd = new SqlCommand("update Brand set CurrentStatus = '" + st + "' where brandId = '" + B.brandId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int updateDesignPrice(Design D)
        {
            dbCon.openCon();
            String st = "Price Updated";
            cmd = new SqlCommand("update Design set CurrentStatus = '" + st + "' where DesignId = '" + D.DesignId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int updateSizePrice(ProductSize P)
        {
            dbCon.openCon();
            String st = "Price Updated";
            cmd = new SqlCommand("update ProductSize set CurrentStatus = '" + st + "' where PSizeId = '" + P.PSizeId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int updateItemPrice(Item I)
        {
            dbCon.openCon();
            String st = "Price Updated";
            cmd = new SqlCommand("update Product set CurrentStatus = '" + st + "' where Item_id = '" + I.ItemID + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int updatefabricPrice(FabricType F)
        {
            dbCon.openCon();
            String st = "Price Updated";
            cmd = new SqlCommand("update FabricType set CurrentStatus = '" + st + "' where fabricId = '" + F.fabricId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        /*  public int updatePrice(Item I)
          {
              dbCon.openCon();
              String st = "Sent to Accountant";
              cmd = new SqlCommand("update Products set ProCost = '" + I.ProCost + "', MarkupCost =  '" + I.MarkupCost + "', SalesPrice = '" + I.SalesPrice + "', ProPrice_Status = '" + st + "' where Item_id = '" + I.ItemID + "'", dbCon.con);
              int status = cmd.ExecuteNonQuery();
              dbCon.closeCon();
              return status;
          }
         */
        public String findAcc(String User, String Pass)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Accountant where UserName = '" + User + "' and UserPassword = '" + Pass + "'", dbCon.con);
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
