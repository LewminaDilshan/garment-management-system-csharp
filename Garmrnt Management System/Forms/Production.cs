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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using MetroFramework;
using System.Net.Mail;
using System.Net;

namespace Final_Project
{
    public partial class PurchaseOrderForm : Form
    {
        List<Panel> listpanel = new List<Panel>();
        int index;
        public PurchaseOrderForm()
        {
            InitializeComponent();
            SupplierDBaccess SA = new SupplierDBaccess();
            DataTable dt = SA.getAllSuppliers();
            Grid_sup.DataSource = dt;
            validateDatePiker();
        }

        public void validateDatePiker()
        {
            System.DateTime today = System.DateTime.Today;

            this.Picker_ReqDate.MinDate = new System.DateTime(today.Year, today.Month, today.Day);

            this.Picker_ReqDate.MaxDate = today.AddDays(60);
        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            try
            {

                listpanel.Add(panel_Reg);
            listpanel.Add(panel_Order);
            listpanel.Add(panel_Recieve);
            listpanel.Add(panel_display);
            listpanel.Add(Panel_AppOdr);
            listpanel.Add(panel_ConfirmSales);
            listpanel[index].BringToFront();
            listpanel[index = 3].BringToFront();

            SupplierDBaccess SA = new SupplierDBaccess();
            grid_IdNameItem.DataSource = SA.getSupplierIDNameItem();

                /*  
                  SqlDataReader sqlRed = Po.fillCmbSupName();
                  try
                  {
                      while (sqlRed.Read())
                      {
                          cmb_SupName.Items.Add(sqlRed[0] + " (" + sqlRed[1] + ")"); //Load supplier names to combo box
                      }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
                  finally
                  {
                      sqlRed.Close();
                  } */
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

        private void btn_reg_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 0].BringToFront();
            //Get last record from supplier
            SupplierDBaccess SA = new SupplierDBaccess();
            txt_SupId.Text = SA.GetSupplierId();
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

        private void btn_Order_Click_1(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 1].BringToFront();
            //Hide other text boxes when first time open
            txt_ItemType.Visible = false;
            txt_qty2.Visible = false;
            btn_add2.Visible = false;
            btn_remove2.Visible = false;
            lb_other.Visible = false;
            lb_Qty2.Visible = false;
            lb_size.Visible = false;
            lb_color.Visible = false;
            cmb_color.Visible = false;
            cmb_size.Visible = false;

                //create object of SupplierDBaccess class
            SupplierDBaccess SA = new SupplierDBaccess();
            grid_IdNameItem.DataSource = SA.getSupplierIDNameItem();
            PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
            Grid_PurchaseOrder.DataSource = PO.getAllPurchaseOrders();

            grid_IdNameItem.ClearSelection();

            txt_POno.Text = PO.GetPurId();
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
        private void btn_Receive_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 2].BringToFront();
            String status = "Placed";
            PurchaseOrderDBaccess Po = new PurchaseOrderDBaccess();
            grid_RecOrds.DataSource = Po.getSpecialPurchaseOrders(status);
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
            try
            {
                MainForm newform = new MainForm();
            newform.Show();
            this.Close();
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

        private void btn_SupReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txt_SupName.Text))
            {

                MetroMessageBox.Show(this, "\n\nPlease enter Supplier Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txt_Add.Text))
            {
                MetroMessageBox.Show(this, "\n\nPlease enter Supplier Address", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txt_Email.Text))
            {
                MetroMessageBox.Show(this, "\n\nPlease enter Supplier Email Address", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txt_Contact.Text))
            {
                MetroMessageBox.Show(this, "\n\nPlease enter Supplier Contact Number", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_SupName.Text.Any(Char.IsDigit))
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter letter only for Name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_Contact.Text.Any(Char.IsLetter))
            {
                MetroFramework.MetroMessageBox.Show(this, "Cannot enter letters for contact number.enter numbers only!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_Contact.Text.Length != 10)
            {
                MetroFramework.MetroMessageBox.Show(this, "Contact Number should be 10 digits!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (chk_But.Checked == false && chk_cut.Checked == false && chk_Lether.Checked == false && chk_sew.Checked == false)
            {
                MetroFramework.MetroMessageBox.Show(this, "Please select at least one Item type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Supplier supplier = new Supplier(); // new supplier object created and get values to variables
                supplier.Sup_Id = txt_SupId.Text.ToString();
                supplier.Sup_Name = txt_SupName.Text.ToString();
                supplier.Address = txt_Add.Text.ToString();
                supplier.Email = txt_Email.Text.ToString();
                supplier.ContactNo = txt_Contact.Text.ToString();

                SupplierItems suppItem = new SupplierItems();
                suppItem.Sup_Id = txt_SupId.Text.ToString();

                SupplierDBaccess SA = new SupplierDBaccess();
                int Status = SA.createSupplier(supplier);
                if (Status == 1)
                {
                        if (chk_cut.Checked)
                        {
                            suppItem.SupItem_Id = SA.GetSuppItemId();
                            suppItem.ItemType = lb_cut.Text;
                            SA.AddSupplierItems(suppItem);
                        }
                        if (chk_sew.Checked)
                        {
                            suppItem.SupItem_Id = SA.GetSuppItemId();
                            suppItem.ItemType = lb_sew.Text;
                            SA.AddSupplierItems(suppItem);
                        }
                        if(chk_But.Checked)
                        {
                            suppItem.SupItem_Id = SA.GetSuppItemId();
                            suppItem.ItemType = lb_But.Text;
                            SA.AddSupplierItems(suppItem);
                        }
                        if(chk_Lether.Checked)
                        {
                            suppItem.SupItem_Id = SA.GetSuppItemId();
                            suppItem.ItemType = lb_Lether.Text;
                            SA.AddSupplierItems(suppItem);
                        }
                        MetroMessageBox.Show(this, "\n\nYou were registerd succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_SupName.Clear();
                    txt_Add.Clear();
                    txt_Email.Clear();
                    txt_Contact.Clear();
                    chk_But.Checked = false;
                    chk_cut.Checked = false;
                    chk_Lether.Checked = false;
                    chk_sew.Checked = false;


                }
                else
                    MetroMessageBox.Show(this, "\n\nRegistation Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);


                

                DataTable dt = SA.getAllSuppliers();
                Grid_sup.DataSource = dt;

                txt_SupId.Text = SA.GetSupplierId();


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


        private void panel_Reg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_RegClr_Click(object sender, EventArgs e)
        {
            txt_SupName.Clear();
            txt_Add.Clear();
            txt_Email.Clear();
            txt_Contact.Clear();
            chk_But.Checked = false;
            chk_cut.Checked = false;
            chk_Lether.Checked = false;
            chk_sew.Checked = false;
        }

        private void cmb_ItemType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_ItemType.Text == "Others")
            {
                txt_ItemType.Visible = true;
                txt_qty2.Visible = true;
                btn_add2.Visible = true;
                btn_remove2.Visible = true;
                lb_other.Visible = true;
                lb_Qty2.Visible = true;

                lb_Qty.Visible = false;
                btn_Add.Visible = false;
                txt_qty.Visible = false;
                btn_remove.Visible = false;
            }
            if (cmb_ItemType.Text != "Others")
            {
                txt_ItemType.Visible = false;
                txt_qty2.Visible = false;
                btn_add2.Visible = false;
                btn_remove2.Visible = false;
                lb_other.Visible = false;
                lb_Qty2.Visible = false;

                lb_Qty.Visible = true;
                btn_Add.Visible = true;
                txt_qty.Visible = true;
                btn_remove.Visible = true;
            }
            if (cmb_ItemType.Text == "Fabric(SILK)" || cmb_ItemType.Text == "Fabric(COTTON)" || cmb_ItemType.Text == "Fabric(LINEN)" || cmb_ItemType.Text == "Buttons" || cmb_ItemType.Text == "Leather")
            {
                txt_ItemType.Visible = false;
                txt_qty2.Visible = false;
                btn_add2.Visible = false;
                btn_remove2.Visible = false;
                lb_other.Visible = false;
                lb_Qty2.Visible = false;

                lb_Qty.Visible = true;
                btn_Add.Visible = true;
                txt_qty.Visible = true;
                btn_remove.Visible = true;
                lb_size.Visible = true;
                lb_color.Visible = true;
                cmb_color.Visible = true;
                cmb_size.Visible = true;

                if (cmb_ItemType.Text == "Fabric(SILK)" || cmb_ItemType.Text == "Fabric(COTTON)" || cmb_ItemType.Text == "Fabric(LINEN)" || cmb_ItemType.Text == "Leather")
                {
                    cmb_size.Items.Clear();
                    cmb_size.Items.Add("3000 * 4000");
                    cmb_size.Items.Add("4000 * 3500");
                    cmb_size.Items.Add("5000 * 4500");
                    cmb_size.Items.Add("6000 * 7000");
                }
                else if (cmb_ItemType.Text == "Buttons")
                {
                    cmb_size.Items.Clear();
                    cmb_size.Items.Add("0.25 inches");
                    cmb_size.Items.Add("0.300 inches");
                    cmb_size.Items.Add("0.362 inches");
                    cmb_size.Items.Add("0.413 inches");
                    cmb_size.Items.Add("0.457 inches");
                    cmb_size.Items.Add("0.500 inches");
                    cmb_size.Items.Add("0.559 inches");
                    cmb_size.Items.Add("0.590 inches");
                    cmb_size.Items.Add("0.650 inches");
                    cmb_size.Items.Add("0.748 inches");
                    cmb_size.Items.Add("0.807 inches");
                    cmb_size.Items.Add("0.846 inches");
                    cmb_size.Items.Add("0.902 inches");
                    cmb_size.Items.Add("0.950 inches");
                    cmb_size.Items.Add("1.000 inches");
                    cmb_size.Items.Add("1.500 inches");

                }
            }
            else
            {
                lb_size.Visible = false;
                lb_color.Visible = false;
                cmb_color.Visible = false;
                cmb_size.Visible = false;
            }
            if (cmb_ItemType.Text == "Others")
            {
                lb_size.Visible = true;
                lb_color.Visible = true;
                cmb_color.Visible = true;
                cmb_size.Visible = true;
            }

            cmb_color.SelectedItem = null;
            cmb_size.SelectedItem = null;
            txt_ItemType.Text = "";
            txt_qty2.Text = "";

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txt_OsupId.Text) || String.IsNullOrEmpty(txt_OsupEmail.Text) || String.IsNullOrEmpty(txt_OsupName.Text))
            {
                MetroMessageBox.Show(this, "\n\nPlease Select Supplier From the DataGrid", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_ItemType.SelectedIndex == -1)
            {
                MetroMessageBox.Show(this, "\n\nPlease Select Required Item Type", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txt_qty.Text))
            {
                MetroMessageBox.Show(this, "\n\nPlease enter Quantity", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_qty.Text.Any(Char.IsLetter))
            {
                MetroFramework.MetroMessageBox.Show(this, "Cannot enter letters for Quantity.Enter numbers only!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToInt32(txt_qty.Text) <= 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Quantity cannot be minus or zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_size.Visible == true && cmb_size.SelectedIndex == -1)
            {
                MetroFramework.MetroMessageBox.Show(this, "Enter Item Size!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_color.Visible == true && cmb_color.SelectedIndex == -1)
            {
                MetroFramework.MetroMessageBox.Show(this, "Enter Item Color!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cmb_size.SelectedItem != null && cmb_color.SelectedItem != null)
                {
                    this.datagrid_add.Rows.Add(cmb_ItemType.Text, cmb_size.SelectedItem.ToString(), cmb_color.SelectedItem.ToString(), txt_qty.Text);
                }
                else
                    this.datagrid_add.Rows.Add(cmb_ItemType.Text, "", "", txt_qty.Text);

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

        private void btn_add2_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txt_OsupId.Text) || String.IsNullOrEmpty(txt_OsupEmail.Text) || String.IsNullOrEmpty(txt_OsupName.Text))
            {
                MetroMessageBox.Show(this, "\n\nPlease Select Supplier From the DataGrid", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txt_ItemType.Text))
            {
                MetroMessageBox.Show(this, "\n\nPlease Enter Required Item Type", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (String.IsNullOrEmpty(txt_qty2.Text))
            {
                MetroMessageBox.Show(this, "\n\nPlease enter Quantity", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_qty2.Text.Any(Char.IsLetter))
            {
                MetroFramework.MetroMessageBox.Show(this, "Cannot enter letters for Quantity.Enter numbers only!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cmb_size.SelectedItem != null && cmb_color.SelectedItem != null)
                {
                    this.datagrid_add.Rows.Add(txt_ItemType.Text, cmb_size.SelectedItem.ToString(), cmb_color.SelectedItem.ToString(), txt_qty2.Text);
                }
                else
                    this.datagrid_add.Rows.Add(txt_ItemType.Text, "", "", txt_qty2.Text);

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

        private void grid_IdNameItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grid_IdNameItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SupplierDBaccess SA = new SupplierDBaccess();

            txt_OsupId.Text = grid_IdNameItem.CurrentRow.Cells["sup_id"].Value.ToString();
            txt_OsupName.Text = grid_IdNameItem.CurrentRow.Cells["sup_name"].Value.ToString();

            txt_OsupEmail.Text = grid_IdNameItem.CurrentRow.Cells["sup_email"].Value.ToString();

            Grid_ItemType.DataSource = SA.getSupplierItems(grid_IdNameItem.CurrentRow.Cells["sup_id"].Value.ToString());

            lb_SelectSup.Visible = false;
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

        private void btn_remove_Click(object sender, EventArgs e)
        {
            /* foreach (DataGridViewRow row in datagrid_add.SelectedRows)
             {
                 datagrid_add.Rows.RemoveAt(row.Index);
             }*/
            try
            {
                datagrid_add.Rows.RemoveAt(datagrid_add.SelectedRows[0].Index);
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Please select entier row", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_OdrClr_Click(object sender, EventArgs e)
        {
            txt_OsupId.Text = null;
            txt_OsupName.Text = null;
            txt_OsupEmail.Text = null;
            cmb_ItemType.Text = null;
            txt_qty.Text = null;
            txt_qty2.Text = null;
            txt_ItemType.Text = null;
            Picker_ReqDate.ResetText();
            datagrid_add.Rows.Clear();
            datagrid_add.ClearSelection();
            grid_IdNameItem.ClearSelection();
            lb_SelectSup.Visible = true;
        }

        private void btn_remove2_Click(object sender, EventArgs e)
        {
            try
            {
                datagrid_add.Rows.RemoveAt(datagrid_add.SelectedRows[0].Index);
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Please select entier row", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_AppOdr_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 4].BringToFront();
            String Sts = "Approved";
            PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
            grid_AppOdr.DataSource = PO.getSpecialPurchaseOrders(Sts);
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

        private void btn_CreOdr_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagrid_add.Rows.Count == 1)
            {
                MetroMessageBox.Show(this, "Add Items Before proceed", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();

                PurMaster PM = new PurMaster();
                PM.pur_id = txt_POno.Text;
                PM.sup_id = txt_OsupId.Text;
                PM.pur_date = Picker_ReqDate.Value.Date;

                int Status = PO.createPurOrder_master(PM);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nOrder Success, And Sending For Approvel", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_OsupId.Text = null;
                        txt_OsupName.Text = null;
                        txt_OsupEmail.Text = null;
                        cmb_ItemType.Text = null;
                        txt_qty.Text = null;
                        txt_qty2.Text = null;
                        txt_ItemType.Text = null;
                        Picker_ReqDate.ResetText();
                        datagrid_add.Rows.Clear();
                        datagrid_add.ClearSelection();
                        grid_IdNameItem.ClearSelection();
                        lb_SelectSup.Visible = true;
                        txt_POno.Text = PO.GetPurId();
                    }
                else
                    MetroMessageBox.Show(this, "\n\nOrder Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // PurDetails PD = new PurDetails();
                // PD.pd_id = 

                for (int i = 0; i < (datagrid_add.Rows.Count - 1); i++)
                {

                    PurDetails PD = new PurDetails();
                    PD.pd_id = PO.GetPDId();
                    PD.pur_id = txt_POno.Text;
                    PD.pd_Item_type = (datagrid_add.Rows[i].Cells["Item"].Value).ToString();
                    PD.Size = (datagrid_add.Rows[i].Cells["Size"].Value).ToString();
                    PD.color = (datagrid_add.Rows[i].Cells["Color"].Value).ToString();
                    PD.pd_qty = (datagrid_add.Rows[i].Cells["Qty"].Value).ToString();

                    int status = PO.createPurOrder_details(PD);
                }
                PurchaseOrderDBaccess Po = new PurchaseOrderDBaccess();
                Grid_PurchaseOrder.DataSource = Po.getAllPurchaseOrders();
                   
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

        private void grid_AppOdr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SupplierDBaccess SA = new SupplierDBaccess();
            String supId = grid_AppOdr.CurrentRow.Cells["sup_id"].Value.ToString();
            if (SA.getOrdrSuppliers(supId).Rows.Count != 0)
            {
                DataRow dr = SA.getOrdrSuppliers(supId).Rows[0];
                txt_OrderSupEmail.Text = dr["sup_email"].ToString();
                txt_OrderSupContact.Text = dr["sup_cont"].ToString();
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

        private void btn_ConfirmSales_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 5].BringToFront();
            SalesOrderDBaccess SO = new SalesOrderDBaccess();
            StockDBaccess SD = new StockDBaccess();
            String st = "Pending";
            grid_Ordrs.DataSource = SO.getSpecialSalesOrders(st);
            grid_StockDetails.DataSource = SD.getNotDamagedMaterial();
            rbn_Met.Checked = true;
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

        private void grid_Ordrs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SalesOrderDBaccess SO = new SalesOrderDBaccess();

            String saleId = grid_Ordrs.CurrentRow.Cells["sale_id"].Value.ToString();
            grid_Items.DataSource = SO.getOrdrProducts(saleId);
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

        private void btn_ConfirmForApp_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_Ordrs.SelectedRows.Count < 1)
            {
                MetroMessageBox.Show(this, "\n\nSelect Record From Grid to proceed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
                SalesOrderDBaccess SD = new SalesOrderDBaccess();
                String status = "Waiting for Approval";

                String saleId = grid_Ordrs.CurrentRow.Cells["sale_id"].Value.ToString();
                int Status = PO.UpdateSalesOrderStatus(saleId, status);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nSent For Approvel", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MetroMessageBox.Show(this, "\n\nFail to Sent", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                String Sts = "Pending";
                grid_Ordrs.DataSource = SD.getSpecialSalesOrders(Sts);
                grid_Items.DataSource = null;
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

        private void btn_placePurchase_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 1].BringToFront();
            //Hide other text boxes when first time open
            txt_ItemType.Visible = false;
            txt_qty2.Visible = false;
            btn_add2.Visible = false;
            btn_remove2.Visible = false;
            lb_other.Visible = false;
            lb_Qty2.Visible = false;
            lb_size.Visible = false;
            lb_color.Visible = false;
            cmb_color.Visible = false;
            cmb_size.Visible = false;

            SupplierDBaccess SA = new SupplierDBaccess();
            grid_IdNameItem.DataSource = SA.getSupplierIDNameItem();
            PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
            Grid_PurchaseOrder.DataSource = PO.getAllPurchaseOrders();

            grid_IdNameItem.ClearSelection();

            txt_POno.Text = PO.GetPurId();
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

        private void rbn_Met_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbn_Met.Checked)
            {
                StockDBaccess SD = new StockDBaccess();
                grid_StockDetails.DataSource = SD.getNotDamagedMaterial();
            }
            if (rbn_Pro.Checked)
            {
                StockDBaccess SD = new StockDBaccess();
                grid_StockDetails.DataSource = SD.getNotDamagedProduct();
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

        private void btn_PlaceOrds_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
            if (String.IsNullOrEmpty(txt_OrderSupEmail.Text) || String.IsNullOrEmpty(txt_OrderSupContact.Text))
            {
                MetroMessageBox.Show(this, "\n\nPlease Select Approved Purchase Order To Place Order", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (rbn_byEmail.Checked == false && rbn_byContact.Checked == false)
            {
                MetroMessageBox.Show(this, "\n\nPlease Select Communication Method To Place Order", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String status = "Placed";

                String PurId = grid_AppOdr.CurrentRow.Cells["pur_id"].Value.ToString();
                int Status = PO.UpdatePurchaseOrderStatus(PurId, status);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nOrder Is Placed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MetroMessageBox.Show(this, "\n\n Fail To Place", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                String Sts = "Approved";
                grid_AppOdr.DataSource = PO.getSpecialPurchaseOrders(Sts);

                    if (rbn_byEmail.Checked)
                    {
                        try
                        {

                            MailMessage message = new MailMessage();
                            SmtpClient smtp = new SmtpClient();

                            message.From = new MailAddress("lewminadilshan96@gmail.com");
                            message.To.Add(new MailAddress(txt_OrderSupEmail.Text));
                            message.Subject = "Order No " + grid_AppOdr.CurrentRow.Cells["pur_id"].Value.ToString();
                            message.Body = "Your Order Is Placed";

                            smtp.Port = 587;
                            smtp.Host = "smtp.gmail.com";
                            smtp.EnableSsl = true;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential("lewminadilshan96@gmail.com", "0763854323xyz");
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.Send(message);
                            MetroMessageBox.Show(this, "\n\nE-mail Sent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_PlaceCancel_Click(object sender, EventArgs e)
        {
            txt_OrderSupContact.Text = "";
            txt_OrderSupEmail.Text = "";
            grid_AppOdr.ClearSelection();
            rbn_byContact.Checked = false;
            rbn_byEmail.Checked = false;
        }

        private void btn_rec_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
            String status = "Recieved";

            String PurId = grid_RecOrds.CurrentRow.Cells["pur_id"].Value.ToString();
            int Status = PO.UpdatePurchaseOrderStatus(PurId, status);
            if (Status == 1)
            {
                MetroMessageBox.Show(this, "\n\nStatus Changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MetroMessageBox.Show(this, "\n\nUpdate Status Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            String Sts = "Placed";
            grid_RecOrds.DataSource = PO.getSpecialPurchaseOrders(Sts);
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

        private void btn_NotRec_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
            String status = "Not Recieved";

            String PurId = grid_AppOdr.CurrentRow.Cells["pur_id"].Value.ToString();
            int Status = PO.UpdatePurchaseOrderStatus(PurId, status);
            if (Status == 1)
            {
                MetroMessageBox.Show(this, "\n\nStatus Changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MetroMessageBox.Show(this, "\n\nUpdate Status Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            String Sts = "Placed";
            grid_AppOdr.DataSource = PO.getSpecialPurchaseOrders(Sts);
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

        private void txt_SupId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

