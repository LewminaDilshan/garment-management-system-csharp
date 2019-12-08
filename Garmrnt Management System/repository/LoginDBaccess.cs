using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.repository
{
    class LoginDBaccess
    {
        private DataBaseConnecion dbCon;
        private SqlCommand cmd;
        private DataTable dt;
        // DataRow dr = null;
        public LoginDBaccess()
        {
            dbCon = new DataBaseConnecion();
            cmd = new SqlCommand();

        }
        public String findEmp(String User, String Pass, String Post)
        {
            dbCon.openCon();
            SqlDataAdapter da = new SqlDataAdapter("select * from Employee where EmpPost = '" + Post + "' and UserName = '" + User + "' and UserPassword = '" + Pass + "'", dbCon.con);
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
