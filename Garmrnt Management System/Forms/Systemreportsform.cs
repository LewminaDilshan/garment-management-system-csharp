using Final_Project.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.Forms
{
    public partial class Systemreportsform : Form
    {
        public Systemreportsform()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=MSI;Initial Catalog=GarmentDB;Persist Security Info=True;User ID=Lewmina;Password=12345");

        private void btn_SalesReport_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }


            string s = "Select * FROM Sales_master";
            SqlCommand cmd = new SqlCommand(s, conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Sales_master");
            SalesReport cr1 = new SalesReport();
            cr1.SetDataSource(ds);
            CrisReport.ReportSource = cr1;
            conn.Close();
            CrisReport.Refresh();
        }

        private void btn_PurchaseReport_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }


            string s = "Select * FROM purchase_master";
            SqlCommand cmd = new SqlCommand(s, conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds, "purchase_master");
            PurchaseReport cr1 = new PurchaseReport();
            cr1.SetDataSource(ds);
            CrisReport.ReportSource = cr1;
            conn.Close();
            CrisReport.Refresh();
        }

        private void btn_clientReport_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }


            string s = "Select * FROM Client";
            SqlCommand cmd = new SqlCommand(s, conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Client");
            ClientReport cr1 = new ClientReport();
            cr1.SetDataSource(ds);
            CrisReport.ReportSource = cr1;
            conn.Close();
            CrisReport.Refresh();
        }

        private void btn_SupReport_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }


            string s = "Select * FROM Supplier";
            SqlCommand cmd = new SqlCommand(s, conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Supplier");
            SupplierReport cr1 = new SupplierReport();
            cr1.SetDataSource(ds);
            CrisReport.ReportSource = cr1;
            conn.Close();
            CrisReport.Refresh();
        }

        private void btn_StockProRep_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }


            string s = "Select * FROM Stock_Product";
            SqlCommand cmd = new SqlCommand(s, conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Stock_Product");
            StockProductDetailsReport cr1 = new StockProductDetailsReport();
            cr1.SetDataSource(ds);
            CrisReport.ReportSource = cr1;
            conn.Close();
            CrisReport.Refresh();
        }

        private void btn_StockMat_Click(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }


            string s = "Select * FROM Stock_Materials";
            SqlCommand cmd = new SqlCommand(s, conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Stock_Materials");
            StockMaterialDetailsReport cr1 = new StockMaterialDetailsReport();
            cr1.SetDataSource(ds);
            CrisReport.ReportSource = cr1;
            conn.Close();
            CrisReport.Refresh();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            MainForm newform = new MainForm();
            newform.Show();
            this.Close();
        }
    }
}
