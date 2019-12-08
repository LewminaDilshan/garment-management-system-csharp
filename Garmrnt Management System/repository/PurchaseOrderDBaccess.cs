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
    class PurchaseOrderDBaccess
    {
        private DataBaseConnecion dbCon;
        private SqlCommand cmd;
        private DataTable dt;
        public PurchaseOrderDBaccess()
        {
            dbCon = new DataBaseConnecion();
            cmd = new SqlCommand();
            
        }
        public int createPurOrder_master(PurMaster PM)
        {
            dbCon.openCon();
            String st = "Waiting for Approval";
            int A = 100000;
            cmd = new SqlCommand("insert into purchase_master (pur_id,sup_id,pur_date,pur_status,pur_total) values('" + PM.pur_id + "','" + PM.sup_id + "','" + PM.pur_date + "','" + st + "','"+ A + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int createPurOrder_details(PurDetails PD)
        {
            dbCon.openCon();
            cmd = new SqlCommand("insert into purchase_details (pd_id,pur_id,pd_Item_type,Size,color,pd_qty) values('" + PD.pd_id + "','" + PD.pur_id + "','" + PD.pd_Item_type + "','" + PD.Size + "','" + PD.color + "','" + PD.pd_qty + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public String GetPDId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) pd_id from purchase_details order by pd_id desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            dbCon.closeCon();
            String PD_Id;
            PD_Id = dr["pd_id"].ToString();
            String abc = (Regex.Match(PD_Id, @"\d+").Value);
            int PDId = Convert.ToInt32(abc);
            PDId++;
            String newPDId = "PD" + PDId;
            return newPDId;
        }
        public String GetPurId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) pur_id from purchase_master order by pur_id desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            String Pur_Id;
            Pur_Id = dr["pur_id"].ToString();
            dbCon.closeCon();
            String abc = (Regex.Match(Pur_Id, @"\d+").Value);
            int PurId = Convert.ToInt32(abc);
            PurId++;
            String newPMId = "PM" + PurId;
            return newPMId;
        }
        public DataTable getSpecialPurchaseOrders(String status)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from purchase_master where pur_status = '"+status+"'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getRecievedPurchaseOrders(String status)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from purchase_master where pur_resv_status = '" + status + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getAllPurchaseOrders()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select pur_id,sup_id,pur_date,pur_total,pur_status from purchase_master", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getPurchaseOrders()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from purchase_master", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getOrdrItems(String PMid)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select pd_Item_type,pd_qty,pd_Item_price from purchase_details where pur_id = '" + PMid + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }

        public int UpdatePurchaseOrderStatus(String PMid, String Status)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update purchase_master set pur_status = '" + Status + "' where pur_id = '" + PMid + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int UpdateSalesOrderStatus(String SMid, String Status)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Sales_master set sale_status = '" + Status + "' where sale_id = '" + SMid + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public String findProduction(String User, String Pass)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Production where UserName = '" + User + "' and UserPassword = '" + Pass + "'", dbCon.con);
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
