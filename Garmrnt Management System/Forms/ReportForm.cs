using Final_Project.entity;
using Final_Project.repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;
using MetroFramework;

namespace Final_Project.Forms
{
    public partial class ReportForm : Form
    {
        List<Panel> listpanel = new List<Panel>();
        int index;
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            listpanel.Add(panel_Display);
            listpanel.Add(panel_SalesReport);
            listpanel.Add(panel_PurReport);
            listpanel.Add(panel_clientReport);
            listpanel.Add(panel_supReport);
            listpanel.Add(panel_stockProduct);
            listpanel.Add(panel_stockMaterials);
            //listpanel.Add(Panel_AppOdr);
            listpanel[index].BringToFront();
            listpanel[index = 0].BringToFront();

            fillSalesChart();
            fillPurChart();
            fillClientChart();
            fillProChart();
            fillMatChart();

            grid_Clientreport.ClearSelection();
            Grid_ItemType.ClearSelection();
            grid_met.ClearSelection();
            grid_product.ClearSelection();
            grid_PurReport.ClearSelection();
            grid_SaleReport.ClearSelection();
        }
        Bitmap bitmap;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
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
        private void CaptureScreen()
        {
            try
            {
                Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            bitmap = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
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

        private void fillSalesChart()
        {
            try
            {
                DateTime date = DateTime.Today.Date;

            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1).AddDays(-1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(-1).AddDays(1);


            var firstDayOfMonth1 = lastDayOfMonth.AddDays(-1);
            var lastDayOfMonth1 = firstDayOfMonth.AddMonths(-2).AddDays(1);


            lb_from.Text = lastDayOfMonth.ToString("dd/MM/yyyy");
            lb_to.Text = firstDayOfMonth.ToString("dd/MM/yyyy");

            ReportDBaccess RD = new ReportDBaccess();
            DateTime d1 = firstDayOfMonth.Date;
            DateTime d2 = lastDayOfMonth.Date;
            DateTime d3 = firstDayOfMonth1.Date;
            DateTime d4 = lastDayOfMonth1.Date;

            grid_SaleReport.DataSource = RD.getSalesReport(d2, d1);
            int total = 0;
            for (int a = 0; a < grid_SaleReport.Rows.Count; a++)
            {
                total += Convert.ToInt32(grid_SaleReport.Rows[a].Cells[3].Value);
            }
            lb_Ntot.Text = total.ToString();
            lb_Thistot.Text = total.ToString();

            int sum = Convert.ToInt32(RD.getSalesReport(d4, d3).Compute("SUM(sale_total)", string.Empty));
            lb_Lasttot.Text = sum.ToString();

            lb_Extot.Text = (Convert.ToInt32(total) + (Convert.ToInt32(total) - Convert.ToInt32(sum))).ToString();


            //grid_SaleReport.DataSource = rows;


            //AddXY value in chart1 in series named as Salary  
            string pMonth = DateTime.Now.AddMonths(-1).ToString("MMMM");
            string pMonth1 = DateTime.Now.AddMonths(-2).ToString("MMMM");
            string pMonth2 = DateTime.Now.ToString("MMMM");
            chart1.Series["Sales"].Points.AddXY(pMonth1, sum.ToString());
            chart1.Series["Sales"].Points.AddXY(pMonth, total.ToString());
            lb_Salelastmonth.Text = pMonth1;
            lb_salesnowmonth.Text = pMonth;
            lb_saleNextmonth.Text = pMonth2;
            //chart title  
            chart1.Titles.Add("Salary Chart");
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
        private void fillPurChart()
        {
            try
            {
                DateTime date = DateTime.Today.Date;

            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1).AddDays(-1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(-1).AddDays(1);


            var firstDayOfMonth1 = lastDayOfMonth.AddDays(-1);
            var lastDayOfMonth1 = firstDayOfMonth.AddMonths(-2).AddDays(1);


            lb_fromdate.Text = lastDayOfMonth.ToString("dd/MM/yyyy");
            lb_todate.Text = firstDayOfMonth.ToString("dd/MM/yyyy");
            
            ReportDBaccess RD = new ReportDBaccess();
            DateTime d1 = firstDayOfMonth.Date;
            DateTime d2 = lastDayOfMonth.Date;
            DateTime d3 = firstDayOfMonth1.Date;
            DateTime d4 = lastDayOfMonth1.Date;

            grid_PurReport.DataSource = RD.getPurchaseReport(d2, d1);
            int total = 0;
            for (int a = 0; a < grid_PurReport.Rows.Count; a++)
            {
                total += Convert.ToInt32(grid_PurReport.Rows[a].Cells[3].Value);
            }
            lb_tot.Text = total.ToString();
            lb_now.Text = total.ToString();

            int sum = Convert.ToInt32(RD.getPurchaseReport(d4, d3).Compute("SUM(pur_total)", string.Empty));
            lb_last.Text = sum.ToString();

            lb_next.Text = (Convert.ToInt32(total) + (Convert.ToInt32(total) - Convert.ToInt32(sum))).ToString();


            //grid_SaleReport.DataSource = rows;

            //AddXY value in chart1 in series named as Salary  
            string pMonth = DateTime.Now.AddMonths(-1).ToString("MMMM");
            string pMonth1 = DateTime.Now.AddMonths(-2).ToString("MMMM");
            string pMonth2 = DateTime.Now.ToString("MMMM");
            chart2.Series["Purchase"].Points.AddXY(pMonth1, sum.ToString());
            chart2.Series["Purchase"].Points.AddXY(pMonth, total.ToString());
            lb_lastmonth.Text = pMonth1;
            lb_nawMonth.Text = pMonth;
            lb_nextMonth.Text = pMonth2;
            //chart title  
            chart2.Titles.Add("Purchase Chart");
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
        private void fillClientChart()
        {
            try
            {
                DateTime date = DateTime.Today.Date;

            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1).AddDays(-1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(-1).AddDays(1);


            var firstDayOfMonth1 = lastDayOfMonth.AddDays(-1);
            var lastDayOfMonth1 = firstDayOfMonth.AddMonths(-2).AddDays(1);


            lb_cltFrom.Text = lastDayOfMonth.ToString("dd/MM/yyyy");
            lb_cltTo.Text = firstDayOfMonth.ToString("dd/MM/yyyy");

            ReportDBaccess RD = new ReportDBaccess();
            DateTime d1 = firstDayOfMonth.Date;
            DateTime d2 = lastDayOfMonth.Date;
            DateTime d3 = firstDayOfMonth1.Date;
            DateTime d4 = lastDayOfMonth1.Date;

            ClientDBaccess CB = new ClientDBaccess();
            grid_Clientreport.DataSource = CB.getAllClients();
            grid_Clientreport.Columns.Add("Order_Placed", "Orders Placed");

            
            int x=0;
            while (x < grid_Clientreport.RowCount - 1)
            {
                grid_Clientreport.Rows[x].Cells["Order_Placed"].Value = RD.getClientcount(grid_Clientreport.Rows[x].Cells[0].Value.ToString(), d2, d1).Rows.Count.ToString();
                x = x + 1;
            }

            int a = 0;
            chart3.Titles.Add("Client Orders");
            while (a < grid_Clientreport.RowCount - 1)
            {
                chart3.Series["Client Orders"].Points.AddXY(grid_Clientreport.Rows[a].Cells[1].Value.ToString(), grid_Clientreport.Rows[a].Cells[5].Value.ToString());
                a = a + 1;
            }

            int total = 0;
            for (int b = 0; b < grid_Clientreport.Rows.Count; b++)
            {
                total += Convert.ToInt32(grid_Clientreport.Rows[b].Cells[5].Value);
            }
            lb_cltTot.Text = total.ToString();
            lb_cltnow.Text = total.ToString();
            int tot = 0;
            for (int b = 0; b < grid_Clientreport.Rows.Count-1; b++)
            {
                int[] y = new int[grid_Clientreport.Rows.Count];
                y[b] = Convert.ToInt32(RD.getClientcount(grid_Clientreport.Rows[b].Cells[0].Value.ToString(), d4, d3).Rows.Count);
                tot = tot + y[b];
            }

            //int sum = Convert.ToInt32(RD.getClientcount(grid_Clientreport.Rows[x].Cells[0].Value.ToString(), d2, d1).Compute("SUM(Order_Placed)", string.Empty));
            lb_cltlast.Text = tot.ToString();

            lb_cltnext.Text = (Convert.ToInt32(total) + (Convert.ToInt32(total) - Convert.ToInt32(tot))).ToString();

            string pMonth = DateTime.Now.AddMonths(-1).ToString("MMMM");
            string pMonth1 = DateTime.Now.AddMonths(-2).ToString("MMMM");
            string pMonth2 = DateTime.Now.ToString("MMMM");
            lb_cltlastmonth.Text = pMonth1;
            lb_cltnowmonrh.Text = pMonth;
            lb_cltNextmonth.Text = pMonth2;
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
        private void fillProChart()
        {
            try
            {
                ReportDBaccess RD = new ReportDBaccess();
            grid_product.DataSource = RD.getAllProduct();

            int a = 0;
            chart4.Titles.Add("Product Stock");
            while (a < grid_product.RowCount - 1)
            {
                chart4.Series["Product Stock"].Points.AddXY(grid_product.Rows[a].Cells[0].Value.ToString(), grid_product.Rows[a].Cells[7].Value.ToString());
                a = a + 1;
            }
            lb_today.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
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
        private void fillMatChart()
        {
            try
            {
                ReportDBaccess RD = new ReportDBaccess();
            grid_met.DataSource = RD.getAllMaterial();

            int a = 0;
            chart5.Titles.Add("Material Stock");
            while (a < grid_met.RowCount - 1)
            {
                chart5.Series["Material Stock"].Points.AddXY(grid_met.Rows[a].Cells[0].Value.ToString(), grid_met.Rows[a].Cells[4].Value.ToString());
                a = a + 1;
            }
            lb_Mattoday.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
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

        private void btn_SalesReport_Click(object sender, EventArgs e)
        {
            listpanel[index = 1].BringToFront();

        }

        private void btn_PurchaseReport_Click(object sender, EventArgs e)
        {
            listpanel[index = 2].BringToFront();

           

          
        }

        private void btn_clientReport_Click(object sender, EventArgs e)
        {
            listpanel[index = 3].BringToFront();
        }

        private void btn_SupReport_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 4].BringToFront();

                DateTime date = DateTime.Today.Date;

                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1).AddDays(-1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(-1).AddDays(1);


                var firstDayOfMonth1 = lastDayOfMonth.AddDays(-1);
                var lastDayOfMonth1 = firstDayOfMonth.AddMonths(-2).AddDays(1);


                lb_supFrom.Text = lastDayOfMonth.ToString("dd/MM/yyyy");
                lb_supTo.Text = firstDayOfMonth.ToString("dd/MM/yyyy");


                

            SupplierDBaccess SA = new SupplierDBaccess();
            grid_IdNameItem.DataSource = SA.getAllSuppliers();

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

        private void grid_IdNameItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SupplierDBaccess SA = new SupplierDBaccess();
            Grid_ItemType.DataSource = SA.getSupplierItems(grid_IdNameItem.CurrentRow.Cells["sup_id"].Value.ToString());
            Grid_ItemType.ClearSelection();
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

        private void btn_StockProRep_Click(object sender, EventArgs e)
        {
            listpanel[index = 5].BringToFront();
            
        }

        private void btn_StockMat_Click(object sender, EventArgs e)
        {
            listpanel[index = 6].BringToFront();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            MainForm newform = new MainForm();
            newform.Show();
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }
    }
}
