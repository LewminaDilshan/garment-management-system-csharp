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
    class ManagementDBaccess
    {
        private DataBaseConnecion dbCon;
        private SqlCommand cmd;
        private DataTable dt;

        public ManagementDBaccess()
        {
            dbCon = new DataBaseConnecion();
            cmd = new SqlCommand();

        }
        public DataTable getBrand()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Brand", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
     
        public DataTable getDesign()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Design", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getDesignType(String Design)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Design where ItemType = '" + Design + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }

        public DataTable getItemType()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from ProductSize", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getSize(String ItemType)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from ProductSize where ItemType = '"+ ItemType + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }

        public DataTable getFType()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from FabricType", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
      
        public DataTable getItem()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Product", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }

        public int createItem(Item I)
        {
            dbCon.openCon();
            cmd = new SqlCommand("insert into Product (Item_id,ProductName,CurrentStatus) values('" + I.ItemID + "','" + I.ProductName + "','" + I.CurrentStatus+ "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int createBrand(Brand B)
        {
            dbCon.openCon();
            cmd = new SqlCommand("insert into Brand (brandId,brandName,CurrentStatus) values('" + B.brandId + "','" + B.brandName + "','" + B.CurrentStatus + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int createDesign(Design D)
        {
            dbCon.openCon();
            cmd = new SqlCommand("insert into Design (DesignId,ItemType,DesignType,CurrentStatus) values('" + D.DesignId + "','" + D.ItemType + "','" + D.DesignType + "','" + D.CurrentStatus + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int createSize(ProductSize P)
        {
            dbCon.openCon();
            cmd = new SqlCommand("insert into ProductSize (PSizeId,ItemType,ProductSize,CurrentStatus) values('" + P.PSizeId + "','" + P.ItemType + "','" + P.ProSize + "','" + P.CurrentStatus + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int createFabrictype(FabricType F)
        {
            dbCon.openCon();
            cmd = new SqlCommand("insert into FabricType (fabricId,fabricType,CurrentStatus) values('" + F.fabricId + "','" + F.fabricType + "','" + F.CurrentStatus + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public String GetItemId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) Item_id from Product order by Item_id desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            dbCon.closeCon();
            String SuppItem_Id;
            SuppItem_Id = dr["item_id"].ToString();
            String abc = (Regex.Match(SuppItem_Id, @"\d+").Value);
            int SupItemId = Convert.ToInt32(abc);
            SupItemId++;
            String newSuppItemId = "I" + SupItemId;
            return newSuppItemId;
        }
        public String GetBrandId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) brandId from Brand order by brandId desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            dbCon.closeCon();
            String SuppItem_Id;
            SuppItem_Id = dr["brandId"].ToString();
            String abc = (Regex.Match(SuppItem_Id, @"\d+").Value);
            int SupItemId = Convert.ToInt32(abc);
            SupItemId++;
            String newBrandId = "B" + SupItemId;
            return newBrandId;
        }
        public String GetDesignId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) DesignId from Design order by DesignId desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            dbCon.closeCon();
            String SuppItem_Id;
            SuppItem_Id = dr["DesignId"].ToString();
            String abc = (Regex.Match(SuppItem_Id, @"\d+").Value);
            int SupItemId = Convert.ToInt32(abc);
            SupItemId++;
            String newDesignId = "D" + SupItemId;
            return newDesignId;
        }
        public String GetSizeId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) PSizeId from ProductSize order by PSizeId desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            dbCon.closeCon();
            String SuppItem_Id;
            SuppItem_Id = dr["PSizeId"].ToString();
            String abc = (Regex.Match(SuppItem_Id, @"\d+").Value);
            int SupItemId = Convert.ToInt32(abc);
            SupItemId++;
            String newSuppItemId = "PS" + SupItemId;
            return newSuppItemId;
        }
        public String GetFtypeId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) fabricId from FabricType order by fabricId desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            dbCon.closeCon();
            String SuppItem_Id;
            SuppItem_Id = dr["fabricId"].ToString();
            String abc = (Regex.Match(SuppItem_Id, @"\d+").Value);
            int SupItemId = Convert.ToInt32(abc);
            SupItemId++;
            String newSuppItemId = "F" + SupItemId;
            return newSuppItemId;
        }
        public int deleteBrand(String brandId)
        {
            dbCon.openCon();
            cmd = new SqlCommand("delete from Brand where brandId = '" + brandId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int deleteDesign(String DesignId)
        {
            dbCon.openCon();
            cmd = new SqlCommand("delete from Design where DesignId = '" + DesignId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int deleteSize(String PSizeId)
        {
            dbCon.openCon();
            cmd = new SqlCommand("delete from ProductSize where PSizeId = '" + PSizeId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int deleteItem(String Item_id)
        {
            dbCon.openCon();
            cmd = new SqlCommand("delete from Product where Item_id = '" + Item_id + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int deleteFtype(String fabricId)
        {
            dbCon.openCon();
            cmd = new SqlCommand("delete from FabricType where fabricId = '" + fabricId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int ChangeBrandPrice(Brand B)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Brand set brandPrice = '" + B.brandPrice + "',CurrentStatus = '" + B.CurrentStatus + "' where brandName = '" + B.brandName + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int ChangeDesignPrice(Design D)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Design set DesignPrice = '" + D.DesignPrice + "',CurrentStatus = '" + D.CurrentStatus + "' where ItemType = '" + D.ItemType + "' and DesignType = '" + D.DesignType + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int ChangeSizePrice(ProductSize P)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update ProductSize set sizePrice = '" + P.sizePrice + "',CurrentStatus = '" + P.CurrentStatus + "' where ItemType = '" + P.ItemType + "' and ProductSize = '" + P.ProSize + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int ChangeFabricPrice(FabricType F)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update FabricType set fabricPrice = '" + F.fabricPrice + "',CurrentStatus = '" + F.CurrentStatus + "' where fabricType = '" + F.fabricType + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int ChangeItemPrice(Item I)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Product set productPrice = '" + I.ProductPrice + "',CurrentStatus = '" + I.CurrentStatus + "' where ProductName = '" + I.ProductName + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public String findMan(String User, String Pass)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Management where UserName = '" + User + "' and UserPassword = '" + Pass + "'", dbCon.con);
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
