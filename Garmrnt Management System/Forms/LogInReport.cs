using Final_Project.repository;
using MetroFramework;
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
    public partial class LogInReport : Form
    {
        public LogInReport()
        {
            InitializeComponent();
        }

        private void LogInReport_Load(object sender, EventArgs e)
        {

        }

        private void btn_Log_Click(object sender, EventArgs e)
        {
            try
            {
                LoginDBaccess PD = new LoginDBaccess();
                String emp = "Managing Director";
                if (PD.findEmp(txt_user.Text, txt_pass.Text, emp) == null)
                {
                    MetroMessageBox.Show(this, "\n\nAccess Denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                   
                    ReportForm newform = new ReportForm();
                    newform.Show();
                    this.Hide();
                }
            }
            catch (SqlException)
            {
                MetroMessageBox.Show(this, "\n\nConnecton Failed", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MetroMessageBox.Show(this, "\n\nInvalid Format", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OutOfMemoryException)
            {
                MetroMessageBox.Show(this, "\n\nInsuffisent memory", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "\n\nERROR", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            MainForm newform = new MainForm();
            newform.Show();
            this.Close();
        }
    }
}
