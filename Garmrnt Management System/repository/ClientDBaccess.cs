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
    class ClientDBaccess
    {
        private DataBaseConnecion dbCon;
        private SqlCommand cmd;
        private DataTable dt;

        public ClientDBaccess()
        {
            dbCon = new DataBaseConnecion();
            cmd = new SqlCommand();

        }
        public int createClient(Client client)
        {
            dbCon.openCon();
            cmd = new SqlCommand("insert into Client (clt_id,clt_name,clt_add,clt_email,clt_cont) values('" + client.Clt_Id + "','" + client.Clt_Name + "','" + client.Clt_Address + "','" + client.Clt_Email + "','" + client.Clt_ContactNo + "')", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public int updateClient(Client client)
        {
            dbCon.openCon();
            cmd = new SqlCommand("update Client set clt_name = '" + client.Clt_Name + "', clt_add =  '" + client.Clt_Address + "', clt_email = '" + client.Clt_Email + "', clt_cont = '" + client.Clt_ContactNo + "' where clt_id = '" + client.Clt_Id + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
        public String GetClientId()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select top(1) clt_id from Client order by clt_id desc", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            String clientId;
            clientId = dr["clt_id"].ToString();
            dbCon.closeCon();
            String abc = (Regex.Match(clientId, @"\d+").Value);
            int cltId = Convert.ToInt32(abc);
            cltId++;
            String newSupId = "C" + cltId;
            return newSupId;
        }
        public DataTable getAllClients()
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Client", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public DataTable getOrdrClients(String cltid)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select clt_name,clt_add,clt_email,clt_cont from Client where clt_id = '" + cltid + "'", dbCon.con);
            dt = new DataTable();
            da.Fill(dt);
            dbCon.closeCon();
            return dt;
        }
        public int deleteClient(String cltid)
        {
            dbCon.openCon();
            cmd = new SqlCommand("delete from Client where clt_id = '" + cltid + "'", dbCon.con);
            int status = cmd.ExecuteNonQuery();
            dbCon.closeCon();
            return status;
        }
    }
}
