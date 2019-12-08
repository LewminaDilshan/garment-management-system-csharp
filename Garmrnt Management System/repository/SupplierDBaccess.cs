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
    class SupplierDBaccess
    {
        private DataBaseConnecion dbCon;
        private SqlCommand cmd;
        private DataTable dt;

        public SupplierDBaccess()
        {
            dbCon = new DataBaseConnecion();
            cmd = new SqlCommand();

        }
        public int createSupplier(Supplier supplier)
        {
            dbCon.openCon();
            cmd = new SqlCommand("insert into Supplier (sup_id,sup_name,sup_add,sup_email,sup_cont) values('" + supplier.Sup_Id + "','" + supplier.Sup_Name + "','" + supplier.Address + "','" + supplier.Email + "','" + supplier.ContactNo + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int updateSupplier(Supplier supplier)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Supplier set sup_name = '" + supplier.Sup_Name + "', sup_add =  '" + supplier.Address + "', sup_email = '" + supplier.Email + "', sup_cont = '" + supplier.ContactNo + "' where sup_id = '" + supplier.Sup_Id + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int AddSupplierItems(SupplierItems SI)
        {
            dbCon.openCon();
            cmd = new SqlCommand("insert into supplier_items (item_id,sup_id,item_type) values('" + SI.SupItem_Id + "','" + SI.Sup_Id + "','" + SI.ItemType + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;

        }
        public String GetSuppItemId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) item_id from supplier_items order by item_id desc", dbCon.con);
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
        public String GetSupplierId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) sup_id from Supplier order by sup_id desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            String supplierId;
            supplierId = dr["sup_id"].ToString();
            dbCon.closeCon();
            String abc = (Regex.Match(supplierId, @"\d+").Value);
            int supId = Convert.ToInt32(abc);
            supId++;
            String newSupId = "S" + supId;
            return newSupId;
        }
        public DataTable getAllSuppliers()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Supplier", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public SqlDataReader fillCmbSupName()
        {
            String query = "Select sup_name,item_type from Supplier";
            SqlCommand command = new SqlCommand(query, dbCon.con);
            SqlDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }
        public DataTable getSupplierIDNameItem()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select sup_id,sup_name,sup_email from Supplier", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getSupplierItems(String supId)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select item_type from supplier_items where sup_id = '" + supId + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getOrdrSuppliers(String supid)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select sup_name,sup_add,sup_email,sup_cont from Supplier where sup_id = '" + supid + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public int deleteSupplier(String supId)
        {
            dbCon.openCon();
            cmd = new SqlCommand("delete from Supplier where sup_id = '" + supId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int deleteSupplierItems(String supId)
        {
            dbCon.openCon();
            cmd = new SqlCommand("delete from supplier_items where sup_id = '" + supId + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
    }
}
