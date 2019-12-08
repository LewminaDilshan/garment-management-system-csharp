using Final_Project.Forms;
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

namespace Final_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        

        private void btn_close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {            
            LogInSalesOrder newform = new LogInSalesOrder();
            newform.Show();
            this.Hide();
        }

        private void btn_purchase_Click(object sender, EventArgs e)
        {
            LogInPurchaseOrder newform = new LogInPurchaseOrder();
            newform.Show();
            this.Hide();
        }

        private void btn_stock_Click(object sender, EventArgs e)
        {
            LoginStock newform = new LoginStock();
            newform.Show();
            this.Hide();
        }
        private void btn_Acc_Click(object sender, EventArgs e)
        {
            LogInAccountant newform = new LogInAccountant();
            newform.Show();
            this.Hide();
        }

        private void btn_Manage_Click(object sender, EventArgs e)
        {
            LogInManagement newform = new LogInManagement();
            newform.Show();
            this.Hide();
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
           

            LogInReport A = new LogInReport();
            A.Show();
            this.Hide();

        }
    }
}
