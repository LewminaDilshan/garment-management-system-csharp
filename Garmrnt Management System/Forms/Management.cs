using Final_Project.entity;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.Forms
{

    public partial class Management : Form
    {
        List<Panel> listpanel = new List<Panel>();
        int index;
        public Management()
        {
            InitializeComponent();
        }

        private void btn_Order_Click(object sender, EventArgs e)
        {
            listpanel[index = 1].BringToFront();
 
            rbn_PurM.Checked = false;
            rbn_SaleM.Checked = false;
            grid_Ordrs.DataSource = null;

            lb_purItem.Visible = false;
            lb_purOrder.Visible = false;
            lb_purSup.Visible = false;
            lb_saleClient.Visible = false;
            lb_saleOrder.Visible = false;
            lb_saleProduct.Visible = false;
            lb_AllSale.Visible = false;
            lb_AllPur.Visible = false;
        }


        private void Management_Load(object sender, EventArgs e)
        {
            listpanel.Add(Panel_Display);
            listpanel.Add(Panel_AllOrdrs);
            listpanel.Add(Panel_CusSup);
            listpanel.Add(panel_stockDetails);
            listpanel.Add(panel_Products);
            listpanel.Add(panel_Prices);
            //listpanel.Add(Panel_AppOdr);
            listpanel[index].BringToFront();
            listpanel[index = 0].BringToFront();
        }

        private void rbn_SaleM_CheckedChanged(object sender, EventArgs e)
        {
            SalesOrderDBaccess SO = new SalesOrderDBaccess();
            String st = "Waiting for Approval";
            grid_Ordrs.DataSource = SO.getSpecialSalesOrders(st);

            grid_Items.DataSource = null;
            grid_SupCus.DataSource = null;
            chk_AllOdrs.Checked = false;

            lb_saleClient.Visible = true;
            lb_saleOrder.Visible = true;
            lb_saleProduct.Visible = true;
            lb_AllSale.Visible = false;
            lb_AllPur.Visible = false;

            lb_purItem.Visible = false;
            lb_purOrder.Visible = false;
            lb_purSup.Visible = false;

        }

        private void rbn_PurM_CheckedChanged(object sender, EventArgs e)
        {
            String status = "Waiting for Approval";
            PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
            grid_Ordrs.DataSource = PO.getSpecialPurchaseOrders(status);

            grid_Items.DataSource = null;
            grid_SupCus.DataSource = null;
            chk_AllOdrs.Checked = false;

            lb_saleClient.Visible = false;
            lb_saleOrder.Visible = false;
            lb_saleProduct.Visible = false;
            lb_AllSale.Visible = false;
            lb_AllPur.Visible = false;

            lb_purItem.Visible = true;
            lb_purOrder.Visible = true;
            lb_purSup.Visible = true;
        }

        private void grid_Ordrs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SalesOrderDBaccess SO = new SalesOrderDBaccess();
            PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
            SupplierDBaccess SA = new SupplierDBaccess();
            ClientDBaccess CA = new ClientDBaccess();
            if (rbn_SaleM.Checked)
            {
                String saleId = grid_Ordrs.CurrentRow.Cells["sale_id"].Value.ToString();
                grid_Items.DataSource = SO.getOrdrProducts(saleId);

                String cltId = grid_Ordrs.CurrentRow.Cells["clt_id"].Value.ToString();
                grid_SupCus.DataSource = CA.getOrdrClients(cltId);
            }
            else if (rbn_PurM.Checked)
            {
                String purId = grid_Ordrs.CurrentRow.Cells["pur_id"].Value.ToString();
                grid_Items.DataSource = PO.getOrdrItems(purId);

                String supId = grid_Ordrs.CurrentRow.Cells["sup_id"].Value.ToString();
                grid_SupCus.DataSource = SA.getOrdrSuppliers(supId);
            }
        }

        private void btn_Approve_Click(object sender, EventArgs e)
        {
            if (grid_Ordrs.SelectedRows.Count < 1)
            {
                MetroMessageBox.Show(this, "\n\nSelect Record From Grid to proceed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SalesOrderDBaccess SO = new SalesOrderDBaccess();
                PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
                String status = "Approved";
                if (rbn_PurM.Checked)
                {
                    String purId = grid_Ordrs.CurrentRow.Cells["pur_id"].Value.ToString();
                    int Status = PO.UpdatePurchaseOrderStatus(purId, status);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nOrder Approved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MetroMessageBox.Show(this, "\n\nFail to Approve", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    String sts = "Pending";
                    grid_Ordrs.DataSource = PO.getSpecialPurchaseOrders(sts);
                    grid_Items.DataSource = null;
                    grid_SupCus.DataSource = null;

                    if (chk_AllOdrs.Checked)
                    {
                        grid_Ordrs.DataSource = PO.getAllPurchaseOrders();
                    }
                }
                else if (rbn_SaleM.Checked)
                {
                    String saleId = grid_Ordrs.CurrentRow.Cells["sale_id"].Value.ToString();
                    int Status = SO.UpdateSalesOrderStatus(saleId, status);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nOrder Approved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MetroMessageBox.Show(this, "\n\nFail to Approve", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    String st = "Waiting for Approval";
                    grid_Ordrs.DataSource = SO.getSpecialSalesOrders(st);
                    grid_Items.DataSource = null;
                    grid_SupCus.DataSource = null;

                    if (chk_AllOdrs.Checked)
                    {
                        grid_Ordrs.DataSource = SO.getAllSalesOrders();
                    }
                }
            }
        }

        private void btn_Reject_Click(object sender, EventArgs e)
        {
            SalesOrderDBaccess SO = new SalesOrderDBaccess();
            PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
            String status = "Rejected";
            if (rbn_PurM.Checked)
            {
                String purId = grid_Ordrs.CurrentRow.Cells["pur_id"].Value.ToString();
                int Status = PO.UpdatePurchaseOrderStatus(purId, status);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nOrder Rejected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MetroMessageBox.Show(this, "\n\nFail to Reject", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                String sts = "Pending";
                grid_Ordrs.DataSource = PO.getSpecialPurchaseOrders(sts);
                grid_Items.DataSource = null;
                grid_SupCus.DataSource = null;

                if (chk_AllOdrs.Checked)
                {
                    grid_Ordrs.DataSource = PO.getAllPurchaseOrders();
                }
            }
            else if (rbn_SaleM.Checked)
            {
                String saleId = grid_Ordrs.CurrentRow.Cells["sale_id"].Value.ToString();
                int Status = SO.UpdateSalesOrderStatus(saleId, status);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nOrder Rejected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MetroMessageBox.Show(this, "\n\nFail to Reject", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                String st = "Waiting for Approval";
                grid_Ordrs.DataSource = SO.getSpecialSalesOrders(st);
                grid_Items.DataSource = null;
                grid_SupCus.DataSource = null;

                if (chk_AllOdrs.Checked)
                {
                    grid_Ordrs.DataSource = SO.getAllSalesOrders();
                }
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            MainForm newform = new MainForm();
            newform.Show();
            this.Close();
        }

        private void chk_AllOdrs_OnChange(object sender, EventArgs e)
        {
            if (rbn_PurM.Checked && chk_AllOdrs.Checked)
            {
                PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
                grid_Ordrs.DataSource = PO.getAllPurchaseOrders();

                grid_Items.DataSource = null;
                grid_SupCus.DataSource = null;

                lb_saleClient.Visible = false;
                lb_saleOrder.Visible = false;
                lb_saleProduct.Visible = false;
                lb_AllSale.Visible = false;
                lb_purOrder.Visible = false;

                lb_AllPur.Visible = true;
                lb_purItem.Visible = true;
                lb_purSup.Visible = true;
            }
            else if (rbn_PurM.Checked && !chk_AllOdrs.Checked)
            {
                String sts = "Pending";
                PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
                grid_Ordrs.DataSource = PO.getSpecialPurchaseOrders(sts);

                grid_Items.DataSource = null;
                grid_SupCus.DataSource = null;

                lb_saleClient.Visible = false;
                lb_saleOrder.Visible = false;
                lb_saleProduct.Visible = false;
                lb_AllSale.Visible = false;
                lb_AllPur.Visible = false;

                lb_purItem.Visible = true;
                lb_purOrder.Visible = true;
                lb_purSup.Visible = true;
            }
            else if (rbn_SaleM.Checked && chk_AllOdrs.Checked)
            {
                SalesOrderDBaccess SO = new SalesOrderDBaccess();
                grid_Ordrs.DataSource = SO.getAllSalesOrders();

                grid_Items.DataSource = null;
                grid_SupCus.DataSource = null;

                lb_saleOrder.Visible = false;
                lb_purSup.Visible = false;
                lb_AllPur.Visible = false;
                lb_purItem.Visible = false;
                lb_purOrder.Visible = false;

                lb_AllSale.Visible = true;
                lb_saleClient.Visible = true;
                lb_saleProduct.Visible = true;
            }
            else if (rbn_SaleM.Checked && !chk_AllOdrs.Checked)
            {
                SalesOrderDBaccess SO = new SalesOrderDBaccess();
                String st = "Waiting for Approval";
                grid_Ordrs.DataSource = SO.getSpecialSalesOrders(st);

                grid_Items.DataSource = null;
                grid_SupCus.DataSource = null;

                lb_AllSale.Visible = false;
                lb_purSup.Visible = false;
                lb_AllPur.Visible = false;
                lb_purItem.Visible = false;
                lb_purOrder.Visible = false;

                lb_saleOrder.Visible = true;
                lb_saleClient.Visible = true;
                lb_saleProduct.Visible = true;
            }
        }

        private void btn_clientsSup_Click(object sender, EventArgs e)
        {
            listpanel[index = 2].BringToFront();

            lb_SupItem.Visible = false;
            txt_SupItem.Visible = false;
           // btn_Ladd.Visible = false;
           // btn_Remove.Visible = false;
            rbn_Client.Checked = true;
            grid_supItems.Visible = false;
            ListBox.Visible = false;

            ClientDBaccess CA = new ClientDBaccess();
            txt_ID.Text = CA.GetClientId();
        }

        private void rbn_Client_CheckedChanged(object sender, EventArgs e)
        {
            ClientDBaccess CA = new ClientDBaccess();
            grid_SupClt.DataSource = CA.getAllClients();
            txt_ID.Text = CA.GetClientId();

            lb_SupID.Visible = false;
            lb_SupName.Visible = false;
            lb_item.Visible = false;
            chk_cut.Visible = false;
            lb_cut.Visible = false;
            chk_But.Visible = false;
            lb_But.Visible = false;
            chk_Lether.Visible = false;
            lb_Lether.Visible = false;
            chk_sew.Visible = false;
            lb_sew.Visible = false;
            chk_Other.Visible = false;
            lb_Other.Visible = false;
            lb_SupItem.Visible = false;
            txt_SupItem.Visible = false;
            btn_Ladd.Visible = false;
            btn_Remove.Visible = false;

            grid_supItems.Visible = false;
            ListBox.Visible = false;

            txt_Name.Text = "";
            txt_Add.Text = "";
            txt_Email.Text = "";
            txt_Contact.Text = "";
            txt_SupItem.Text = "";
       
            if (grid_supItems.Rows.Count > 0)
            {
                grid_supItems.DataSource = null;
            }
            ListBox.Items.Clear();
            chk_But.Checked = false;
            chk_cut.Checked = false;
            chk_Lether.Checked = false;
            chk_sew.Checked = false;
        }

        private void rbn_Supplier_CheckedChanged(object sender, EventArgs e)
        {
            SupplierDBaccess SA = new SupplierDBaccess();
            grid_SupClt.DataSource = SA.getAllSuppliers();
            txt_ID.Text = SA.GetSupplierId();


            lb_SupID.Visible = true;
            lb_SupName.Visible = true;
            lb_item.Visible = true;
            chk_cut.Visible = true;
            lb_cut.Visible = true;
            chk_But.Visible = true;
            lb_But.Visible = true;
            chk_Lether.Visible = true;
            lb_Lether.Visible = true;
            chk_sew.Visible = true;
            lb_sew.Visible = true;
            chk_Other.Visible = true;
            lb_Other.Visible = true;
            grid_SupClt.ClearSelection();
            grid_supItems.Visible = true;
            ListBox.Visible = true;

            if (chk_Other.Checked)
            {
                lb_SupItem.Visible = true;
                txt_SupItem.Visible = true;
                btn_Ladd.Visible = true;
                btn_Remove.Visible = true;
            }

            txt_Name.Text = "";
            txt_Add.Text = "";
            txt_Email.Text = "";
            txt_Contact.Text = "";
            txt_SupItem.Text = "";
        
            if (grid_supItems.Rows.Count > 0)
            {
                grid_supItems.DataSource = null;
            }
            ListBox.Items.Clear();
            chk_But.Checked = false;
            chk_cut.Checked = false;
            chk_Lether.Checked = false;
            chk_sew.Checked = false;
        }

        private void grid_SupClt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ListBox.Items.Clear();
                chk_cut.Checked = false;
                chk_But.Checked = false;
                chk_Lether.Checked = false;
                chk_sew.Checked = false;

            SalesOrderDBaccess SO = new SalesOrderDBaccess();
            SupplierDBaccess SA = new SupplierDBaccess();
            
            if (rbn_Client.Checked)
            {
                txt_ID.Text = grid_SupClt.CurrentRow.Cells["clt_id"].Value.ToString();
                txt_Name.Text = grid_SupClt.CurrentRow.Cells["clt_name"].Value.ToString();
                txt_Add.Text = grid_SupClt.CurrentRow.Cells["clt_add"].Value.ToString();
                txt_Email.Text = grid_SupClt.CurrentRow.Cells["clt_email"].Value.ToString();
                txt_Contact.Text = grid_SupClt.CurrentRow.Cells["clt_cont"].Value.ToString();
            }
            else if (rbn_Supplier.Checked)
            {
                grid_supItems.DataSource = SA.getSupplierItems(grid_SupClt.CurrentRow.Cells["sup_id"].Value.ToString());

                txt_ID.Text = grid_SupClt.CurrentRow.Cells["sup_id"].Value.ToString();
                txt_Name.Text = grid_SupClt.CurrentRow.Cells["sup_name"].Value.ToString();
                txt_Add.Text = grid_SupClt.CurrentRow.Cells["sup_add"].Value.ToString();
                txt_Email.Text = grid_SupClt.CurrentRow.Cells["sup_email"].Value.ToString();
                txt_Contact.Text = grid_SupClt.CurrentRow.Cells["sup_cont"].Value.ToString();               
            }
            for (int i = 0; i < grid_supItems.Rows.Count-1; i++)
            {
                ListBox.Items.Add((grid_supItems.Rows[i].Cells["item_type"].Value).ToString());
            }
            for(int i = 0; i < ListBox.Items.Count; i++)
            {
                if(lb_cut.Text == ListBox.Items[i].ToString())
                   chk_cut.Checked = true;
                if (lb_But.Text == ListBox.Items[i].ToString())
                    chk_But.Checked = true;
                if(lb_Lether.Text == ListBox.Items[i].ToString())
                   chk_Lether.Checked = true;
                if (lb_sew.Text == ListBox.Items[i].ToString())
                    chk_sew.Checked = true;
            }
            
        }

        private void chk_cut_OnChange(object sender, EventArgs e)
        {
            /*
            String chkCut = ""; String chkSew = ""; String chkBut = "";
            String chkLether = "";

            if (chk_cut.Checked)
            {
                chkCut = lb_cut.Text + "/";
            }
            if (chk_sew.Checked)
            {
                chkSew = lb_sew.Text + "/";
            }
            if (chk_But.Checked)
            {
                chkBut = lb_But.Text + "/";
            }
            if (chk_Lether.Checked)
            {
                chkLether = lb_Lether.Text;
            }

            txt_Item.Text = chkCut + chkSew + chkBut + chkLether;

            if (!chk_cut.Checked && !chk_sew.Checked && !chk_But.Checked && !chk_Lether.Checked && grid_SupClt.SelectedRows.Count != 0)
            {
                txt_Item.Text = grid_SupClt.CurrentRow.Cells["item_type"].Value.ToString();
            }*/

            if (chk_cut.Checked)
                ListBox.Items.Add(lb_cut.Text);
            else if(!chk_cut.Checked)
                ListBox.Items.Remove(lb_cut.Text);


        }

        private void chk_But_OnChange(object sender, EventArgs e)
        {/*
            String chkCut = ""; String chkSew = ""; String chkBut = "";
            String chkLether = "";

            if (chk_cut.Checked)
            {
                chkCut = lb_cut.Text + "/";
            }
            if (chk_sew.Checked)
            {
                chkSew = lb_sew.Text + "/";
            }
            if (chk_But.Checked)
            {
                chkBut = lb_But.Text + "/";
            }
            if (chk_Lether.Checked)
            {
                chkLether = lb_Lether.Text;
            }
            txt_Item.Text = chkCut + chkSew + chkBut + chkLether;

            if (!chk_cut.Checked && !chk_sew.Checked && !chk_But.Checked && !chk_Lether.Checked && grid_SupClt.SelectedRows.Count != 0)
            {
                    txt_Item.Text = grid_SupClt.CurrentRow.Cells["item_type"].Value.ToString();
            }*/

            if (chk_But.Checked)
                ListBox.Items.Add(lb_But.Text);
            else if (!chk_But.Checked)
                ListBox.Items.Remove(lb_But.Text);

        }

        private void chk_sew_OnChange(object sender, EventArgs e)
        {/*
            String chkCut = ""; String chkSew = ""; String chkBut = "";
            String chkLether = "";

            if (chk_cut.Checked)
            {
                chkCut = lb_cut.Text + "/";
            }
            if (chk_sew.Checked)
            {
                chkSew = lb_sew.Text + "/";
            }
            if (chk_But.Checked)
            {
                chkBut = lb_But.Text + "/";
            }
            if (chk_Lether.Checked)
            {
                chkLether = lb_Lether.Text;
            }

            txt_Item.Text = chkCut + chkSew + chkBut + chkLether;

            if (!chk_cut.Checked && !chk_sew.Checked && !chk_But.Checked && !chk_Lether.Checked && grid_SupClt.SelectedRows.Count != 0)
            {
                txt_Item.Text = grid_SupClt.CurrentRow.Cells["item_type"].Value.ToString();
            }*/
            if (chk_sew.Checked)
                ListBox.Items.Add(lb_sew.Text);
            else if (!chk_sew.Checked)
                ListBox.Items.Remove(lb_sew.Text);

        }

        private void chk_Lether_OnChange(object sender, EventArgs e)
        {/*
            String chkCut = ""; String chkSew = ""; String chkBut = "";
            String chkLether = "";

            if (chk_cut.Checked)
            {
                chkCut = lb_cut.Text + "/";
            }
            if (chk_sew.Checked)
            {
                chkSew = lb_sew.Text + "/";
            }
            if (chk_But.Checked)
            {
                chkBut = lb_But.Text + "/";
            }
            if (chk_Lether.Checked)
            {
                chkLether = lb_Lether.Text;
            }

            txt_Item.Text = chkCut + chkSew + chkBut + chkLether;

            if (!chk_cut.Checked && !chk_sew.Checked && !chk_But.Checked && !chk_Lether.Checked && grid_SupClt.SelectedRows.Count != 0)
            {
                txt_Item.Text = grid_SupClt.CurrentRow.Cells["item_type"].Value.ToString();
            }*/
            if (chk_Lether.Checked)
            {
                
                ListBox.Items.Add(lb_Lether.Text);

            }
            if (!chk_Lether.Checked)
            {
                ListBox.Items.Remove(lb_Lether.Text);
              

            }
               

            
        }

        private void chk_Other_OnChange(object sender, EventArgs e)
        {
            if (chk_Other.Checked)
            {
                chk_cut.Enabled = false;
                chk_But.Enabled = false;
                chk_sew.Enabled = false;
                chk_Lether.Enabled = false;

                lb_SupItem.Visible = true;
                txt_SupItem.Visible = true;
                btn_Ladd.Visible = true;
                btn_Remove.Visible = true;


            }
            if (!chk_Other.Checked)
            {
                chk_cut.Enabled = true;
                chk_But.Enabled = true;
                chk_sew.Enabled = true;
                chk_Lether.Enabled = true;

                lb_SupItem.Visible = false;
                txt_SupItem.Visible = false;
                btn_Ladd.Visible = false;
                btn_Remove.Visible = false;

            }
        }
        private void txt_SupItem_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txt_SupItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_SupItem.Text) || !Regex.Match(txt_SupItem.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
                {
                    MessageBox.Show("Supply Item Name Can Not Be Blank or Invalid ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (e.KeyChar == 13)
                    {
                        ListBox.Items.Add(txt_SupItem.Text);
                        txt_SupItem.Text = null;
                    }
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

        private void btn_Ladd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_SupItem.Text) || !Regex.Match(txt_SupItem.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
            {
                MessageBox.Show("Supply Item Name Can Not Be Blank or Invalid ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ListBox.Items.Add(txt_SupItem.Text);
                txt_SupItem.Text = null;
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

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (lb_cut.Text == ListBox.SelectedItem.ToString())
            {
                chk_cut.Checked = false;
            }
            if (lb_But.Text == ListBox.SelectedItem.ToString())
            {
                chk_But.Checked = false;
            }
            if (lb_sew.Text == ListBox.SelectedItem.ToString())
            {
                chk_sew.Checked = false;
            }
            if (lb_Lether.Text == ListBox.SelectedItem.ToString())
            {
                chk_Lether.Checked = false;
            }
            

            ListBox.Items.Remove(ListBox.SelectedItem);
        }

        private void btn_clrItems_Click(object sender, EventArgs e)
        {
            ListBox.Items.Clear();
            chk_But.Checked = false;
            chk_cut.Checked = false;
            chk_Lether.Checked = false;
            chk_sew.Checked = false;
        }

        private void btn_stockDetails_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 3].BringToFront();

                StockDBaccess SD = new StockDBaccess();
                grid_ProDetails.DataSource = SD.getAllProduct();
                grid_MatDetails.DataSource = SD.getAllMaterial();
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbn_Client.Checked)
                {
                    if (string.IsNullOrEmpty(txt_Name.Text) || !Regex.Match(txt_Name.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
                    {
                        MessageBox.Show("First Name Can Not Be Blank or Invalid Pattern, Please Check In That Field \nPlease Fill This Way => Pasan ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(txt_Add.Text) || !Regex.Match(txt_Add.Text, @"^([A-Z]|[a-zA-Z]|[0-9])+(|[ ]+|[A-Z]+|[a-z]+|[0-9]+|[.-;-/])*$").Success)
                    {
                        MessageBox.Show("Address Line Can Not Be Blank or Invalid Pattern, Please Check In That Field. \nPlease Fill This Way => No. 50/1/A ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(txt_Email.Text) || !Regex.Match(txt_Email.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$").Success)
                    {
                        MessageBox.Show("Invalid Email, Please Check In That Field \n( Example :- lewmina@gmail.com )", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(txt_Contact.Text) || txt_Contact.Text.Length > 0)
                    {
                        if (!Regex.Match(txt_Contact.Text, "^[0-9]*$").Success || txt_Contact.Text.Length != 10)
                        {
                            MessageBox.Show("Invalid Mobile Number, Please Check In That Field \nPlease Fill This Way => 0766656326 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {

                        Client client = new Client(); // new Client object created and get values to variables
                        client.Clt_Id = txt_ID.Text.ToString();
                        client.Clt_Name = txt_Name.Text.ToString();
                        client.Clt_Address = txt_Add.Text.ToString();
                        client.Clt_Email = txt_Email.Text.ToString();
                        client.Clt_ContactNo = txt_Contact.Text.ToString();

                        ClientDBaccess CA = new ClientDBaccess();
                        int Status = CA.createClient(client);
                        if (Status == 1)
                        {
                            MetroMessageBox.Show(this, "\n\nRecord Added succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MetroMessageBox.Show(this, "\n\nFail to Add", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        grid_SupClt.DataSource = CA.getAllClients();
                        txt_ID.Text = CA.GetClientId();

                        txt_Name.Text = "";
                        txt_Add.Text = "";
                        txt_Email.Text = "";
                        txt_Contact.Text = "";
                        txt_SupItem.Text = "";
                     
                        if (grid_supItems.Rows.Count > 0)
                        {
                            grid_supItems.DataSource = null;
                        }
                        ListBox.Items.Clear();
                        chk_But.Checked = false;
                        chk_cut.Checked = false;
                        chk_Lether.Checked = false;
                        chk_sew.Checked = false;
                    }
                }
                if (rbn_Supplier.Checked)
                {
                    if (string.IsNullOrEmpty(txt_Name.Text) || !Regex.Match(txt_Name.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
                    {
                        MessageBox.Show("First Name Can Not Be Blank or Invalid Pattern, Please Check In That Field \nPlease Fill This Way => Pasan ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(txt_Add.Text) || !Regex.Match(txt_Add.Text, @"^([A-Z]|[a-zA-Z]|[0-9])+(|[ ]+|[A-Z]+|[a-z]+|[0-9]+|[.-;-/])*$").Success)
                    {
                        MessageBox.Show("Address Line Can Not Be Blank or Invalid Pattern, Please Check In That Field. \nPlease Fill This Way => No. 50/1/A ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(txt_Email.Text) || !Regex.Match(txt_Email.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$").Success)
                    {
                        MessageBox.Show("Invalid Email, Please Check In That Field \n( Example :- lewmina@gmail.com )", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(txt_Contact.Text) || !Regex.Match(txt_Contact.Text, "^[0-9]*$").Success || txt_Contact.Text.Length != 10)
                    {
                        MessageBox.Show("Invalid Mobile Number, Please Check In That Field \nPlease Fill This Way => 0766656326 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ListBox.Items.Count == 0)
                    {
                        MessageBox.Show("Please Add Items to List ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        Supplier supplier = new Supplier(); // new supplier object created and get values to variables
                        supplier.Sup_Id = txt_ID.Text.ToString();
                        supplier.Sup_Name = txt_Name.Text.ToString();
                        supplier.Address = txt_Add.Text.ToString();
                        supplier.Email = txt_Email.Text.ToString();
                        supplier.ContactNo = txt_Contact.Text.ToString();

                        SupplierItems suppItem = new SupplierItems();
                        suppItem.Sup_Id = txt_ID.Text.ToString();

                        SupplierDBaccess SA = new SupplierDBaccess();
                        int Status = SA.createSupplier(supplier);
                        if (Status == 1)
                        {
                            MetroMessageBox.Show(this, "\n\nRecord Added succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MetroMessageBox.Show(this, "\n\nFail to Add", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        for (int i = 0; i < ListBox.Items.Count; i++)
                        {
                            suppItem.SupItem_Id = SA.GetSuppItemId();
                            suppItem.ItemType = ListBox.Items[i].ToString();
                            SA.AddSupplierItems(suppItem);
                        }
                        grid_SupClt.DataSource = SA.getAllSuppliers();
                        txt_ID.Text = SA.GetSupplierId();

                        txt_Name.Text = "";
                        txt_Add.Text = "";
                        txt_Email.Text = "";
                        txt_Contact.Text = "";
                        txt_SupItem.Text = "";
                        
                        if (grid_supItems.Rows.Count > 0)
                        {
                            grid_supItems.DataSource = null;
                        }
                        ListBox.Items.Clear();
                        chk_But.Checked = false;
                        chk_cut.Checked = false;
                        chk_Lether.Checked = false;
                        chk_sew.Checked = false;
                    }
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

        private void btn_clr_Click(object sender, EventArgs e)
        {
            txt_Name.Text = "";
            txt_Add.Text = "";
            txt_Email.Text = "";
            txt_Contact.Text = "";
            txt_SupItem.Text = "";
           
            if(grid_supItems.Rows.Count > 0)
            {
                grid_supItems.DataSource = null;
            }    
            ListBox.Items.Clear();
            chk_But.Checked = false;
            chk_cut.Checked = false;
            chk_Lether.Checked = false;
            chk_sew.Checked = false;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbn_Client.Checked)
                {
                    if (string.IsNullOrEmpty(txt_Name.Text) || !Regex.Match(txt_Name.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
                    {
                        MessageBox.Show("First Name Can Not Be Blank or Invalid Pattern, Please Check In That Field \nPlease Fill This Way => Pasan ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(txt_Add.Text) || !Regex.Match(txt_Add.Text, @"^([A-Z]|[a-zA-Z]|[0-9])+(|[ ]+|[A-Z]+|[a-z]+|[0-9]+|[.-;-/])*$").Success)
                    {
                        MessageBox.Show("Address Line Can Not Be Blank or Invalid Pattern, Please Check In That Field. \nPlease Fill This Way => No. 50/1/A ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(txt_Email.Text) || !Regex.Match(txt_Email.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$").Success)
                    {
                        MessageBox.Show("Invalid Email, Please Check In That Field \n( Example :- lewmina@gmail.com )", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(txt_Contact.Text) || !Regex.Match(txt_Contact.Text, "^[0-9]*$").Success || txt_Contact.Text.Length != 10)
                    {
                        MessageBox.Show("Invalid Mobile Number, Please Check In That Field \nPlease Fill This Way => 0766656326 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult dr = MetroMessageBox.Show(this, "\n\nDo you really want to Update?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr.ToString() == "Yes")
                        {
                            Client client = new Client(); // new Client object created and get values to variables
                            client.Clt_Id = txt_ID.Text.ToString();
                            client.Clt_Name = txt_Name.Text.ToString();
                            client.Clt_Address = txt_Add.Text.ToString();
                            client.Clt_Email = txt_Email.Text.ToString();
                            client.Clt_ContactNo = txt_Contact.Text.ToString();

                            ClientDBaccess CA = new ClientDBaccess();
                            int Status = CA.updateClient(client);
                            if (Status == 1)
                            {
                                MetroMessageBox.Show(this, "\n\nRecord Updated succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MetroMessageBox.Show(this, "\n\nFail to Update", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            grid_SupClt.DataSource = CA.getAllClients();
                            txt_ID.Text = CA.GetClientId();

                            txt_Name.Text = "";
                            txt_Add.Text = "";
                            txt_Email.Text = "";
                            txt_Contact.Text = "";
                            txt_SupItem.Text = "";
                        
                            if (grid_supItems.Rows.Count > 0)
                            {
                                grid_supItems.DataSource = null;
                            }
                            ListBox.Items.Clear();
                            chk_But.Checked = false;
                            chk_cut.Checked = false;
                            chk_Lether.Checked = false;
                            chk_sew.Checked = false;
                        }
                    }
                }
                if (rbn_Supplier.Checked)
                {
                    if (string.IsNullOrEmpty(txt_Name.Text) || !Regex.Match(txt_Name.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
                    {
                        MessageBox.Show("First Name Can Not Be Blank or Invalid Pattern, Please Check In That Field \nPlease Fill This Way => Pasan ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(txt_Add.Text) || !Regex.Match(txt_Add.Text, @"^([A-Z]|[a-zA-Z]|[0-9])+(|[ ]+|[A-Z]+|[a-z]+|[0-9]+|[.-;-/])*$").Success)
                    {
                        MessageBox.Show("Address Line Can Not Be Blank or Invalid Pattern, Please Check In That Field. \nPlease Fill This Way => No. 50/1/A ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(txt_Email.Text) || !Regex.Match(txt_Email.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$").Success)
                    {
                        MessageBox.Show("Invalid Email, Please Check In That Field \n( Example :- lewmina@gmail.com )", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (string.IsNullOrEmpty(txt_Contact.Text) || !Regex.Match(txt_Contact.Text, "^[0-9]*$").Success || txt_Contact.Text.Length != 10)
                    {
                        MessageBox.Show("Invalid Mobile Number, Please Check In That Field \nPlease Fill This Way => 0766656326 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ListBox.Items.Count == 0)
                    {
                        MessageBox.Show("Please Add Items to List ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult dr = MetroMessageBox.Show(this, "\n\nDo you really want to Update?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr.ToString() == "Yes")
                        {
                            Supplier supplier = new Supplier(); // new supplier object created and get values to variables
                            supplier.Sup_Id = txt_ID.Text.ToString();
                            supplier.Sup_Name = txt_Name.Text.ToString();
                            supplier.Address = txt_Add.Text.ToString();
                            supplier.Email = txt_Email.Text.ToString();
                            supplier.ContactNo = txt_Contact.Text.ToString();

                            SupplierItems suppItem = new SupplierItems();
                            suppItem.Sup_Id = txt_ID.Text.ToString();

                            SupplierDBaccess SA = new SupplierDBaccess();
                            int Status = SA.updateSupplier(supplier);
                            if (Status == 1)
                            {
                                MetroMessageBox.Show(this, "\n\nRecord Updated succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MetroMessageBox.Show(this, "\n\nFail to Update", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            SA.deleteSupplierItems(txt_ID.Text.ToString());

                            for (int i = 0; i < ListBox.Items.Count; i++)
                            {
                                suppItem.SupItem_Id = SA.GetSuppItemId();
                                suppItem.ItemType = ListBox.Items[i].ToString();
                                SA.AddSupplierItems(suppItem);
                            }
                            grid_SupClt.DataSource = SA.getAllSuppliers();
                            txt_ID.Text = SA.GetSupplierId();

                            txt_Name.Text = "";
                            txt_Add.Text = "";
                            txt_Email.Text = "";
                            txt_Contact.Text = "";
                            txt_SupItem.Text = "";
                          
                            if (grid_supItems.Rows.Count > 0)
                            {
                                grid_supItems.DataSource = null;
                            }
                            ListBox.Items.Clear();
                            chk_But.Checked = false;
                            chk_cut.Checked = false;
                            chk_Lether.Checked = false;
                            chk_sew.Checked = false;
                        }
                    }
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

        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MetroMessageBox.Show(this, "\n\nDo you really want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr.ToString() == "Yes")
                {
                    if (rbn_Client.Checked)
                    {
                        String ClientId = txt_ID.Text;
                        ClientDBaccess CA = new ClientDBaccess();
                        int Status = CA.deleteClient(ClientId);
                        if (Status == 1)
                        {
                            MetroMessageBox.Show(this, "\n\nRecord Deleted succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MetroMessageBox.Show(this, "\n\n Fail to Delete", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        grid_SupClt.DataSource = CA.getAllClients();
                        txt_ID.Text = CA.GetClientId();

                    }
                    if (rbn_Supplier.Checked)
                    {
                        String SuptId = txt_ID.Text;
                        SupplierDBaccess SA = new SupplierDBaccess();
                        int Status = SA.deleteSupplier(SuptId);
                        if (Status == 1)
                        {
                            MetroMessageBox.Show(this, "\n\nRecord Deleted succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MetroMessageBox.Show(this, "\n\n Fail to Delete", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        SA.deleteSupplierItems(SuptId);

                        grid_SupClt.DataSource = SA.getAllSuppliers();
                        txt_ID.Text = SA.GetSupplierId();
                    }

                    txt_Name.Text = "";
                    txt_Add.Text = "";
                    txt_Email.Text = "";
                    txt_Contact.Text = "";
                    txt_SupItem.Text = "";
                   
                    if (grid_supItems.Rows.Count > 0)
                    {
                        grid_supItems.DataSource = null;
                    }
                    ListBox.Items.Clear();
                    chk_But.Checked = false;
                    chk_cut.Checked = false;
                    chk_Lether.Checked = false;
                    chk_sew.Checked = false;
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

        private void btn_Products_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 4].BringToFront();
                AccountantDBaccess AD = new AccountantDBaccess();
                ManagementDBaccess MD = new ManagementDBaccess();
                rbn_brd.Checked = true;
                grid_product.DataSource = MD.getBrand();
                lb_change2.Visible = false;
                txt_change2.Visible = false;
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

        private void btn_Prices_Click(object sender, EventArgs e)
        {
            listpanel[index = 5].BringToFront();
            AccountantDBaccess AD = new AccountantDBaccess();
            ManagementDBaccess MD = new ManagementDBaccess();
            rbn_brand.Checked = true;
            grid_Type.DataSource = MD.getBrand();
            lb_Itype.Visible = false;
            cmb_IType.Visible = false;
            lb_type.Text = "Brand";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {

                if (rbn_brd.Checked)
            {
                if (string.IsNullOrEmpty(txt_change.Text) || !Regex.Match(txt_change.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
                {
                    MessageBox.Show("Brand Can Not Be Blank or Invalid Pattern, Please Check In That Field ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ManagementDBaccess MD = new ManagementDBaccess();
                    Brand B = new Brand();
                    B.brandId = MD.GetBrandId();
                    B.brandName = txt_change.Text;
                    B.CurrentStatus = "NOT CHANGED";

                    int Status = MD.createBrand(B);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nSaved succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            grid_product.ClearSelection();
                            txt_change.Text = "";
                            txt_change2.Text = "";
                        }
                    else
                        MetroMessageBox.Show(this, "\n\nSave Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    grid_product.DataSource = MD.getBrand();
                }
            }
            if (rbn_dsgn.Checked)
            {
                if (string.IsNullOrEmpty(txt_change.Text) || !Regex.Match(txt_change.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
                {
                    MessageBox.Show("Item Type Can Not Be Blank or Invalid Pattern, Please Check In That Field ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(txt_change2.Text) || !Regex.Match(txt_change2.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
                {
                    MessageBox.Show("Design Can Not Be Blank or Invalid Pattern, Please Check In That Field ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ManagementDBaccess MD = new ManagementDBaccess();
                    Design D = new Design();
                    D.DesignId = MD.GetDesignId();
                    D.ItemType = txt_change.Text;
                    D.DesignType = txt_change2.Text;
                    D.CurrentStatus = "NOT CHANGED";

                    int Status = MD.createDesign(D);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nSaved succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            grid_product.ClearSelection();
                            txt_change.Text = "";
                            txt_change2.Text = "";
                        }
                    else
                        MetroMessageBox.Show(this, "\n\nSave Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    grid_product.DataSource = MD.getDesign();
                }
            }
            if (rbn_ftype.Checked)
            {
                if (string.IsNullOrEmpty(txt_change.Text) || !Regex.Match(txt_change.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
                {
                    MessageBox.Show("Fabric Type Can Not Be Blank or Invalid Pattern, Please Check In That Field ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ManagementDBaccess MD = new ManagementDBaccess();
                    FabricType F = new FabricType();
                    F.fabricId = MD.GetFtypeId();
                    F.fabricType = txt_change.Text;
                    F.CurrentStatus = "NOT CHANGED";

                    int Status = MD.createFabrictype(F);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nSaved succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            grid_product.ClearSelection();
                            txt_change.Text = "";
                            txt_change2.Text = "";
                        }
                    else
                        MetroMessageBox.Show(this, "\n\nSave Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    grid_product.DataSource = MD.getFType();
                }
            }
            if (rbn_Psize.Checked)
            {
                if (string.IsNullOrEmpty(txt_change.Text) || !Regex.Match(txt_change.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
                {
                    MessageBox.Show("Item Type Can Not Be Blank or Invalid Pattern, Please Check In That Field ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (string.IsNullOrEmpty(txt_change2.Text) || !Regex.Match(txt_change2.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
                {
                    MessageBox.Show("Product Can Not Be Blank or Invalid Pattern, Please Check In That Field ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ManagementDBaccess MD = new ManagementDBaccess();
                    ProductSize P = new ProductSize();
                    P.PSizeId = MD.GetSizeId();
                    P.ItemType = txt_change.Text;
                    P.ProSize = txt_change2.Text;
                    P.CurrentStatus = "NOT CHANGED";

                    int Status = MD.createSize(P);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nSaved succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            grid_product.ClearSelection();
                            txt_change.Text = "";
                            txt_change2.Text = "";
                        }
                    else
                        MetroMessageBox.Show(this, "\n\nSave Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    grid_product.DataSource = MD.getItemType();
                }
            }
            if (rbn_itm.Checked)
            {
                if (string.IsNullOrEmpty(txt_change.Text) || !Regex.Match(txt_change.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
                {
                    MessageBox.Show("Product Can Not Be Blank or Invalid Pattern, Please Check In That Field ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ManagementDBaccess MD = new ManagementDBaccess();
                    Item I = new Item();
                    I.ItemID = MD.GetItemId();
                    I.ProductName = txt_change.Text;
                    I.CurrentStatus = "NOT CHANGED";

                    int Status = MD.createItem(I);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nSaved succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            grid_product.ClearSelection();
                            txt_change.Text = "";
                            txt_change2.Text = "";
                        }
                    else
                        MetroMessageBox.Show(this, "\n\nSave Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grid_product.DataSource = MD.getItem();
                }

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

        private void grid_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btn_upt_Click(object sender, EventArgs e)
        {
        }

        private void btn_rmv_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbn_brd.Checked)
            {
                ManagementDBaccess MD = new ManagementDBaccess();

                int Status = MD.deleteBrand(grid_product.CurrentRow.Cells["brandId"].Value.ToString());
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nRemoved succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grid_product.ClearSelection();
                        txt_change.Text = "";
                        txt_change2.Text = "";
                    }
                else
                    MetroMessageBox.Show(this, "\n\nFail to Remove", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grid_product.DataSource = MD.getBrand();
            }
            if (rbn_dsgn.Checked)
            {
                ManagementDBaccess MD = new ManagementDBaccess();

                int Status = MD.deleteDesign(grid_product.CurrentRow.Cells["Design"].Value.ToString());
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nRemoved succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grid_product.ClearSelection();
                        txt_change.Text = "";
                        txt_change2.Text = "";
                    }
                else
                    MetroMessageBox.Show(this, "\n\nFail to Remove", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grid_product.DataSource = MD.getDesign();
            }
            if (rbn_ftype.Checked)
            {
                ManagementDBaccess MD = new ManagementDBaccess();

                int Status = MD.deleteFtype(grid_product.CurrentRow.Cells["fabricId"].Value.ToString());
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nRemoved succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grid_product.ClearSelection();
                        txt_change.Text = "";
                        txt_change2.Text = "";
                    }
                else
                    MetroMessageBox.Show(this, "\n\nFail to Remove", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grid_product.DataSource = MD.getFType();
            }
            if (rbn_Psize.Checked)
            {
                ManagementDBaccess MD = new ManagementDBaccess();

                int Status = MD.deleteSize(grid_product.CurrentRow.Cells["PSizeId"].Value.ToString());
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nRemoved succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grid_product.ClearSelection();
                        txt_change.Text = "";
                        txt_change2.Text = "";
                    }
                else
                    MetroMessageBox.Show(this, "\n\nFail to Remove", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grid_product.DataSource = MD.getItemType();
            }
            if (rbn_itm.Checked)
            {
                ManagementDBaccess MD = new ManagementDBaccess();

                int Status = MD.deleteItem(grid_product.CurrentRow.Cells["Item_id"].Value.ToString());
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nRemoved succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grid_product.ClearSelection();
                        txt_change.Text = "";
                        txt_change2.Text = "";
                    }
                else
                    MetroMessageBox.Show(this, "\n\nFail to Remove", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grid_product.DataSource = MD.getItem();
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

            /*
            AccountantDBaccess AD = new AccountantDBaccess();
            int Status = AD.removeItem(txt_ItemID.Text);
            if (Status == 1)
            {
                MetroMessageBox.Show(this, "\n\nRemoved succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MetroMessageBox.Show(this, "\n\nRemove Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            grid_product.DataSource = AD.getProduct();*/
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            grid_product.ClearSelection();
            txt_change.Text = "";
            txt_change2.Text = "";

        }

        private void chk_AllItems_OnChange(object sender, EventArgs e)
        {
          
        }

        private void grid_Products_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_cal_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_STA_Click(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess Md = new ManagementDBaccess();
                if (rbn_brand.Checked)
            {
                if (cmb_Type.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a Brand", "Error");
                }
                else if (string.IsNullOrEmpty(txt_price.Text) || !Regex.Match(txt_price.Text, "^[0-9]*$").Success)
                {
                    MessageBox.Show("Invalid, Please enter price correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ManagementDBaccess MD = new ManagementDBaccess();
                    Brand B = new Brand();
                    B.brandName = cmb_Type.Text;
                    B.brandPrice = txt_price.Text;
                    B.CurrentStatus = "Sent To Accountant";

                    int Status = MD.ChangeBrandPrice(B);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nSent to accountant succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_Type.Text = null;
                            cmb_IType.Text = null;
                            txt_price.Text = "";
                        }
                    else
                        MetroMessageBox.Show(this, "\n\nSending Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    grid_Type.DataSource = Md.getBrand();
                }
            }
            if (rbn_design.Checked)
            {
                if (cmb_Type.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a Item Type", "Error");
                }
                else if (cmb_IType.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a Design", "Error");
                }
                else if (string.IsNullOrEmpty(txt_price.Text) || !Regex.Match(txt_price.Text, "^[0-9]*$").Success)
                {
                    MessageBox.Show("Invalid, Please enter price correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ManagementDBaccess MD = new ManagementDBaccess();
                    Design D = new Design();
                    D.ItemType = cmb_Type.Text;
                    D.DesignType = cmb_IType.Text;
                    D.DesignPrice = txt_price.Text;
                    D.CurrentStatus = "Sent To Accountant";

                    int Status = MD.ChangeDesignPrice(D);
                    if (Status == 1)
                        {
                            MetroMessageBox.Show(this, "\n\nSent to accountant succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_Type.Text = null;
                            cmb_IType.Text = null;
                            txt_price.Text = "";
                        }
                        else
                            MetroMessageBox.Show(this, "\n\nSending Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        grid_Type.DataSource = MD.getDesign();
                }
            }
            if (rbn_fabricType.Checked)
            {
                if (cmb_Type.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a Fabric Type", "Error");
                }
                else if (string.IsNullOrEmpty(txt_price.Text) || !Regex.Match(txt_price.Text, "^[0-9]*$").Success)
                {
                    MessageBox.Show("Invalid, Please enter price correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ManagementDBaccess MD = new ManagementDBaccess();
                    FabricType F = new FabricType();
                    F.fabricType = cmb_Type.Text;
                    F.fabricPrice = txt_price.Text;
                    F.CurrentStatus = "Sent To Accountant";

                    int Status = MD.ChangeFabricPrice(F);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nSent to accountant succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_Type.Text = null;
                            cmb_IType.Text = null;
                            txt_price.Text = "";
                        }
                    else
                        MetroMessageBox.Show(this, "\n\nSending Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        grid_Type.DataSource = MD.getFType();
                }
            }
            if (rbn_size.Checked)
            {
                if (cmb_Type.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a Item Type", "Error");
                }
                else if (cmb_IType.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a Size", "Error");
                }
                else if (string.IsNullOrEmpty(txt_price.Text) || !Regex.Match(txt_price.Text, "^[0-9]*$").Success)
                {
                    MessageBox.Show("Invalid, Please enter price correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ManagementDBaccess MD = new ManagementDBaccess();
                    ProductSize P = new ProductSize();
                    P.ItemType = cmb_Type.Text;
                    P.ProSize = cmb_IType.Text;
                    P.sizePrice = txt_price.Text;
                    P.CurrentStatus = "Sent To Accountant";

                    int Status = MD.ChangeSizePrice(P);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nSent to accountant succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_Type.Text = null;
                            cmb_IType.Text = null;
                            txt_price.Text = "";
                        }
                    else
                        MetroMessageBox.Show(this, "\n\nSending Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        grid_Type.DataSource = MD.getItemType();
                }
            }
            if (rbn_item.Checked)
            {
                if (cmb_Type.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a Item", "Error");
                }
                else if (string.IsNullOrEmpty(txt_price.Text) || !Regex.Match(txt_price.Text, "^[0-9]*$").Success)
                {
                    MessageBox.Show("Invalid, Please enter price correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    ManagementDBaccess MD = new ManagementDBaccess();
                    Item I = new Item();
                    I.ProductName = cmb_Type.Text;
                    I.ProductPrice = txt_price.Text;
                    I.CurrentStatus = "Sent To Accountant";

                    int Status = MD.ChangeItemPrice(I);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nSent to accountant succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmb_Type.Text = null;
                            cmb_IType.Text = null;
                            txt_price.Text = "";
                        }
                    else
                        MetroMessageBox.Show(this, "\n\nSending Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        grid_Type.DataSource = MD.getItem();
                }
                    cmb_IType.Text = "";
                    cmb_Type.Text = "";
                    txt_price.Text = "";
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
            /*

             AccountantDBaccess AD = new AccountantDBaccess();
             int Status = AD.updatePrice(item);
             if (Status == 1)
             {
                 MetroMessageBox.Show(this, "\n\nPrice Updated succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else
                 MetroMessageBox.Show(this, "\n\nUpdate Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            */

        }

        private void rbn_brand_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess MA = new ManagementDBaccess();
                grid_Type.DataSource = MA.getBrand();
                cmb_Type.DataSource = MA.getBrand();
                cmb_Type.DisplayMember = "brandName";
                lb_Itype.Visible = false;
                cmb_IType.Visible = false;
                lb_type.Text = "Brand Name";
                cmb_Type.Text = null;

                cmb_Type.Text = null;
                cmb_IType.Text = null;
                txt_price.Text = "";
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

        private void rbn_design_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess MA = new ManagementDBaccess();
                grid_Type.DataSource = MA.getDesign();
                cmb_Type.DataSource = MA.getItem();
                cmb_Type.DisplayMember = "ProductName";
                cmb_IType.DataSource = MA.getDesignType(cmb_Type.Text);
                cmb_IType.DisplayMember = "DesignType";
                lb_Itype.Visible = true;
                cmb_IType.Visible = true;
                lb_type.Text = "Item Type";
                lb_Itype.Text = "Design";
                cmb_Type.Text = null;
                cmb_IType.Text = null;

                cmb_Type.Text = null;
                cmb_IType.Text = null;
                txt_price.Text = "";
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

        private void rbn_size_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess MA = new ManagementDBaccess();
                grid_Type.DataSource = MA.getItemType();
                cmb_Type.DataSource = MA.getItem();
                cmb_Type.DisplayMember = "ProductName";
                cmb_IType.DataSource = MA.getSize(cmb_Type.Text);
                cmb_IType.DisplayMember = "ProductSize";
                lb_Itype.Visible = true;
                cmb_IType.Visible = true;
                lb_type.Text = "Item Type";
                lb_Itype.Text = "Product Size";
                cmb_Type.Text = null;
                cmb_IType.Text = null;

                cmb_Type.Text = null;
                cmb_IType.Text = null;
                txt_price.Text = "";
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


        private void rbn_item_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess MA = new ManagementDBaccess();
            grid_Type.DataSource = MA.getItem();
            cmb_Type.DataSource = MA.getItem();
                cmb_Type.DisplayMember = "ProductName";
            lb_Itype.Visible = false;
            cmb_IType.Visible = false;
            lb_type.Text = "Product Name";
            cmb_Type.Text = null;

                cmb_Type.Text = null;
                cmb_IType.Text = null;
                txt_price.Text = "";
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

        private void rbn_fabricType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess MA = new ManagementDBaccess();
            grid_Type.DataSource = MA.getFType();
            cmb_Type.DataSource = MA.getFType();
                cmb_Type.DisplayMember = "fabricType";
            lb_Itype.Visible = false;
            cmb_IType.Visible = false;
            lb_type.Text = "fabric Type";
            cmb_Type.Text = null;

                cmb_Type.Text = null;
                cmb_IType.Text = null;
                txt_price.Text = "";
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

        private void cmb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbn_size.Checked)
            {
                ManagementDBaccess MA = new ManagementDBaccess();
                cmb_IType.DataSource = MA.getSize(cmb_Type.Text);
                    cmb_IType.DisplayMember = "ProductSize";
                    cmb_IType.Text = null;
            }
            if (rbn_design.Checked)
            {
                ManagementDBaccess MA = new ManagementDBaccess();
                    cmb_IType.DataSource = MA.getDesignType(cmb_Type.Text);
                    cmb_IType.DisplayMember = "DesignType";
                    cmb_IType.Text = null;
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

        private void rbn_brd_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess MA = new ManagementDBaccess();
            grid_product.DataSource = MA.getBrand();
            lb_change.Text = "Brand";
            lb_change2.Visible = false;
            txt_change2.Visible = false;

                grid_product.ClearSelection();
                txt_change.Text = "";
                txt_change2.Text = "";
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

        private void rbn_dsgn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess MA = new ManagementDBaccess();
            grid_product.DataSource = MA.getDesign();
            lb_change.Text = "Item Type";
            lb_change2.Text = "Design";
            lb_change2.Visible = true;
            txt_change2.Visible = true;

                grid_product.ClearSelection();
                txt_change.Text = "";
                txt_change2.Text = "";
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

        private void rbn_Psize_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess MA = new ManagementDBaccess();
            grid_product.DataSource = MA.getItemType();
            lb_change.Text = "Item Type";
            lb_change2.Text = "Size";
            lb_change2.Visible = true;
            txt_change2.Visible = true;

                grid_product.ClearSelection();
                txt_change.Text = "";
                txt_change2.Text = "";
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

        private void rbn_itm_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess MA = new ManagementDBaccess();
            grid_product.DataSource = MA.getItem();
            lb_change.Text = "Product Name";
            lb_change2.Visible = false;
            txt_change2.Visible = false;

                grid_product.ClearSelection();
                txt_change.Text = "";
                txt_change2.Text = "";
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

        private void rbn_ftype_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess MA = new ManagementDBaccess();
            grid_product.DataSource = MA.getFType();
            lb_change.Text = "Fabric Type";
            lb_change2.Visible = false;
            txt_change2.Visible = false;

                grid_product.ClearSelection();
                txt_change.Text = "";
                txt_change2.Text = "";
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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void grid_Type_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_STACancel_Click(object sender, EventArgs e)
        {
            cmb_Type.Text = null; 
            cmb_IType.Text = null;
            txt_price.Text = "";
        }
    }
}
