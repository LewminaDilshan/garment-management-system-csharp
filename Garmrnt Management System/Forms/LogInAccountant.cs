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
    public partial class LogInAccountant : Form
    {
        public LogInAccountant()
        {
            InitializeComponent();
        }

        private void btn_Log_Click(object sender, EventArgs e)
        {
            try
            {
                LoginDBaccess AD = new LoginDBaccess();
                String emp = "Accountant";
                if (AD.findEmp(txt_user.Text, txt_pass.Text, emp) == null)
                {
                    MetroMessageBox.Show(this, "\n\nAccess Denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                   
                    Accountant newform = new Accountant();
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
