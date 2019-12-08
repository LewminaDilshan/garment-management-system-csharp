using Final_Project.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.repository
{
    class StockDBaccess
    {
        private DataBaseConnecion dbCon;
        private SqlCommand cmd;
        private DataTable dt;
       // DataRow dr = null;
        public StockDBaccess()
        {
            dbCon = new DataBaseConnecion();
            cmd = new SqlCommand();
            
        }
        public String GetProductId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) Pro_id from Stock_Product order by Pro_id desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            String productId;
            productId = dr["Pro_id"].ToString();
            dbCon.closeCon();
            String abc = (Regex.Match(productId, @"\d+").Value);
            int ProId = Convert.ToInt32(abc);
            ProId++;
            String newProId = "PRO" + ProId;
            return newProId;
        }
        public int createProduct(StockProduct Pro)
        {
            dbCon.openCon();
            String Status = "Not Damaged";
            cmd = new SqlCommand("insert into Stock_Product (Pro_id,Product_Type,Brand,Design,Size,Color,Fabric_Type,Quantity,Descriptions,Damage_Status) values('" + Pro.ProId + "','" + Pro.ProType + "','" + Pro.Brand + "','" + Pro.Design + "','" + Pro.Size + "','" + Pro.Color + "','" + Pro.FabricType + "','" + Pro.Quantity + "','" + Pro.Description + "','" + Status + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int updateProduct(StockProduct Pro)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Stock_Product set Product_Type = '" + Pro.ProType + "', Size =  '" + Pro.Size + "', Color = '" + Pro.Color + "', Fabric_Type = '" + Pro.FabricType + "', Quantity = '" + Pro.Quantity + "', Descriptions = '" + Pro.Description + "' where Pro_id = '" + Pro.ProId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public DataTable getAllProduct()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Stock_Product", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public int deleteProduct(String ProId)
        {
            dbCon.openCon();
            cmd = new SqlCommand("delete from Stock_Product where Pro_id = '" + ProId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }

        public String GetMaterialId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) Mat_id from Stock_Materials order by Mat_id desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            String materialId;
            materialId = dr["Mat_id"].ToString();
            dbCon.closeCon();
            String abc = (Regex.Match(materialId, @"\d+").Value);
            int MatId = Convert.ToInt32(abc);
            MatId++;
            String newMatId = "MAT" + MatId;
            return newMatId;
        }
        public int createMaterial(StockMaterial Mat)
        {
            dbCon.openCon();
            String Status = "Not Damaged";
            cmd = new SqlCommand("insert into Stock_Materials (Mat_id,Material_Type,Size,Color,Quantity,Descriptions,Damage_Status) values('" + Mat.MatId + "','" + Mat.MaterialType + "','" + Mat.Size + "','" + Mat.Color + "','" + Mat.Quantity + "','" + Mat.Description + "','" + Status + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int updateMaterial(StockMaterial Mat)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Stock_Materials set Material_Type = '" + Mat.MaterialType + "', Size =  '" + Mat.Size + "', Color = '" + Mat.Color + "', Quantity = '" + Mat.Quantity + "', Descriptions = '" + Mat.Description + "' where Mat_id = '" + Mat.MatId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public DataTable getAllMaterial()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Stock_Materials", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public int deleteMaterial(String MatId)
        {
            dbCon.openCon();
            cmd = new SqlCommand("delete from Stock_Materials where Mat_id = '" + MatId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public DataTable getReceivedMet()
        {
            dbCon.openCon();
            String Rec = "Recieved";
            SqlDataAdapter da = new SqlDataAdapter("select * from purchase_details where pd_Item_Status = '"+ Rec + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public int UpdateProductDamageStatus(String PROid, String Status)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Stock_Product set Damage_Status = '" + Status + "' where Pro_id = '" + PROid + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int UpdateMaterialDamageStatus(String MATid, String Status)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Stock_Materials set Damage_Status = '" + Status + "' where Mat_id = '" + MATid + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public DataTable getNotDamagedMaterial()
        {
            dbCon.openCon();
            String Status = "Not Damaged";
            SqlDataAdapter da = new SqlDataAdapter("select * from Stock_Materials where Damage_Status = '" + Status + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getNotDamagedProduct()
        {
            dbCon.openCon();
            String Status = "Not Damaged";
            SqlDataAdapter da = new SqlDataAdapter("select * from Stock_Product where Damage_Status = '" + Status + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public String findStock(String User, String Pass)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Stock where UserName = '" + User + "' and UserPassword = '" + Pass + "'", dbCon.con);
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
