﻿using Final_Project.Forms;
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

namespace Final_Project
{
    public partial class LogInSalesOrder : Form
    {
        public LogInSalesOrder()
        {
            InitializeComponent();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            MainForm newform = new MainForm();
            newform.Show();
            this.Close();
        }

        private void btn_Log_Click(object sender, EventArgs e)
        {
            try
            {
                LoginDBaccess SD = new LoginDBaccess();
                String emp = "Sales Manager";
                if (SD.findEmp(txt_user.Text,txt_pass.Text, emp) == null)
                {
                    MetroMessageBox.Show(this, "\n\nAccess Denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    
                   
                    SalesOrderForm newform = new SalesOrderForm();
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
    }
}
