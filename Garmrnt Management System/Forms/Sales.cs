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
using Final_Project.entity;
using Final_Project.repository;
using System.Net.Mail;
using System.Net;

namespace Final_Project
{
    public partial class SalesOrderForm : Form
    {
        List<Panel> listpanel = new List<Panel>();
        int index;
        public SalesOrderForm()
        {
            try
            {
                InitializeComponent();
            ClientDBaccess CA = new ClientDBaccess();
            DataTable dt = CA.getAllClients();
            Grid_clt.DataSource = dt;
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

        private void SalesOrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                listpanel.Add(panel_reg);
            listpanel.Add(panel_order);
            listpanel.Add(panel_delivery);
            listpanel.Add(panel_disply);
            listpanel.Add(Panel_AppOdr);
            listpanel[index].BringToFront();
            listpanel[index = 3].BringToFront();

            ClientDBaccess CA = new ClientDBaccess();
            grid_IdNameItem.DataSource = CA.getAllClients();
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
            //Get last record from Client
            ClientDBaccess CA = new ClientDBaccess();
            txt_CltId.Text = CA.GetClientId();
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

        private void btn_Order_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 1].BringToFront();
            //Hide other text boxes when first time open

            SalesOrderDBaccess So = new SalesOrderDBaccess();
            ClientDBaccess CA = new ClientDBaccess();
            grid_IdNameItem.DataSource = CA.getAllClients();
            grid_Sales.DataSource = So.getSalesOrders();
            txt_SOno.Text = So.GetSaleId();
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

        private void btn_delivery_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 2].BringToFront();
            SalesOrderDBaccess SD = new SalesOrderDBaccess();
            String st = "Placed";
            grid_DeliOrds.DataSource = SD.getSpecialSalesOrders(st);
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

        private void btn_CltReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_CltName.Text) || !Regex.Match(txt_CltName.Text, "^([A-Z]|[a-z])[a-zA-Z]*$").Success)
            {
                MessageBox.Show("First Name Can Not Be Blank or Invalid Pattern, Please Check In That Field \nPlease Fill This Way => Pasan ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_CltAdd.Text) || !Regex.Match(txt_CltAdd.Text, @"^([A-Z]|[a-zA-Z]|[0-9])+(|[ ]+|[A-Z]+|[a-z]+|[0-9]+|[.-;-/])*$").Success)
            {
                MessageBox.Show("Address Line Can Not Be Blank or Invalid Pattern, Please Check In That Field. \nPlease Fill This Way => No. 50/1/A ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_CltEmail.Text) || !Regex.Match(txt_CltEmail.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$").Success)
            {
                MessageBox.Show("Invalid Email, Please Check In That Field \n( Example :- lewmina@gmail.com )", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_CltContact.Text) || txt_CltContact.Text.Length > 0)
            {
                if (!Regex.Match(txt_CltContact.Text, "^[0-9]*$").Success || txt_CltContact.Text.Length != 10)
                {
                    MessageBox.Show("Invalid Mobile Number, Please Check In That Field \nPlease Fill This Way => 0766656326 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Client client = new Client(); // new Client object created and get values to variables
                client.Clt_Id = txt_CltId.Text.ToString();
                client.Clt_Name = txt_CltName.Text.ToString();
                client.Clt_Address = txt_CltAdd.Text.ToString();
                client.Clt_Email = txt_CltEmail.Text.ToString();
                client.Clt_ContactNo = txt_CltContact.Text.ToString();

                ClientDBaccess CA = new ClientDBaccess();
                int Status = CA.createClient(client);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nYou were registerd succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MetroMessageBox.Show(this, "\n\nRegistation Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DataTable dt = CA.getAllClients();
                Grid_clt.DataSource = dt;
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

        private void cmb_ProType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_ProType.Text == "Others")
            {

                lb_Qty.Visible = false;
                btn_Add.Visible = false;
                txt_qty.Visible = false;
                btn_remove.Visible = false;
            }
            else
            {

                lb_Qty.Visible = true;
                btn_Add.Visible = true;
                txt_qty.Visible = true;
                btn_remove.Visible = true;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_ProType.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_ftype.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Fabric Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_Brand.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Brand", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_Design.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Design", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_size.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Size", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (cmb_color.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_qty.Text) || !Regex.Match(txt_qty.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("Invalid, Please enter Quantity correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToInt32(txt_qty.Text) <= 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Quantity cannot be minus or zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SalesOrderDBaccess SD = new SalesOrderDBaccess();
                Item I = new Item(); Brand B = new Brand(); Design D = new Design(); ProductSize P = new ProductSize(); FabricType F = new FabricType();
                I.ProductName = cmb_ProType.Text;
                B.brandName = cmb_Brand.Text;
                P.ItemType = cmb_ProType.Text;
                P.ProSize = cmb_size.Text;
                D.ItemType = cmb_ProType.Text;
                D.DesignType = cmb_Design.Text;
                F.fabricType = cmb_ftype.Text;
                DataView dv = new DataView(SD.getItemPrice(I)); DataView dv1 = new DataView(SD.getBrandPrice(B)); DataView dv2 = new DataView(SD.getDesignPrice(D)); DataView dv3 = new DataView(SD.getProductSizePrice(P)); DataView dv4 = new DataView(SD.getFabricTypePrice(F));
                DataTable dt = dv.ToTable(true, "productPrice");
                DataTable dt1 = dv1.ToTable(true, "brandPrice");
                DataTable dt2 = dv2.ToTable(true, "DesignPrice");
                DataTable dt3 = dv3.ToTable(true, "sizePrice");
                DataTable dt4 = dv4.ToTable(true, "fabricPrice");
                int price;
                if (cmb_color.Text == "White")
                {
                    price = (Convert.ToInt32(dt.Rows[0]["productPrice"].ToString()) + Convert.ToInt32(dt1.Rows[0]["brandPrice"].ToString()) + Convert.ToInt32(dt2.Rows[0]["DesignPrice"].ToString()) + Convert.ToInt32(dt3.Rows[0]["sizePrice"].ToString()) + Convert.ToInt32(dt4.Rows[0]["fabricPrice"].ToString()) + 250) * Convert.ToInt32(txt_qty.Text);
                }
                else
                {
                    price = (Convert.ToInt32(dt.Rows[0]["productPrice"].ToString()) + Convert.ToInt32(dt1.Rows[0]["brandPrice"].ToString()) + Convert.ToInt32(dt2.Rows[0]["DesignPrice"].ToString()) + Convert.ToInt32(dt3.Rows[0]["sizePrice"].ToString()) + Convert.ToInt32(dt4.Rows[0]["fabricPrice"].ToString()) + 100) * Convert.ToInt32(txt_qty.Text);
                }


                this.datagrid_add.Rows.Add(cmb_ProType.Text, cmb_ftype.Text, cmb_Brand.Text, cmb_Design.Text, cmb_size.Text, cmb_color.Text, txt_qty.Text, price);
                //////////////////////////////////////////
                DataTable dtt = dv.ToTable(true, "Item_id");
                DataTable dtt5 = dv1.ToTable(true, "brandId");
                DataTable dtt6 = dv2.ToTable(true, "DesignId");
                DataTable dtt7 = dv3.ToTable(true, "PSizeId");
                DataTable dtt8 = dv4.ToTable(true, "fabricId");


                SaleDetails SD2 = new SaleDetails();
                SD2.sd_id = SD.GetSDId();
                SD2.sale_id = txt_SOno.Text;
                SD2.sd_Product = cmb_ProType.Text;
                SD2.Item_id = dtt.Rows[0]["Item_id"].ToString();
                SD2.brandId = dtt5.Rows[0]["brandId"].ToString();
                SD2.DesignId = dtt6.Rows[0]["DesignId"].ToString();
                SD2.fabricId = dtt7.Rows[0]["PSizeId"].ToString();
                SD2.PSizeId = dtt8.Rows[0]["fabricId"].ToString();
                SD2.sd_qty = txt_qty.Text;
                SD2.sd_Product_price = price.ToString();

                int status = SD.createSale_details(SD2);
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
            
        }

        private void grid_IdNameItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_OcltId.Text = grid_IdNameItem.CurrentRow.Cells["clt_id"].Value.ToString();
            txt_OcltName.Text = grid_IdNameItem.CurrentRow.Cells["clt_name"].Value.ToString();
            txt_OcltAdd.Text = grid_IdNameItem.CurrentRow.Cells["clt_add"].Value.ToString();
            txt_OcltEmail.Text = grid_IdNameItem.CurrentRow.Cells["clt_email"].Value.ToString();
            txt_CintContact.Text = grid_IdNameItem.CurrentRow.Cells["clt_cont"].Value.ToString();

            lb_SelectClt.Visible = false;
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
            txt_OcltId.Text = null;
            txt_OcltName.Text = null;
            txt_OcltAdd.Text = null;
            txt_OcltEmail.Text = null;
            txt_CintContact.Text = null;
            cmb_ProType.Text = null;
            cmb_ftype.Text = null;
            cmb_Brand.Text = null;
            cmb_Design.Text = null;
            cmb_size.Text = null;
            cmb_color.Text = null;
            txt_qty.Text = null;
            txt_odrTot.Text = null;
            Picker_ReqDate.ResetText();
            datagrid_add.Rows.Clear();
            datagrid_add.ClearSelection();
            grid_IdNameItem.ClearSelection();
            lb_SelectClt.Visible = true;
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

            SalesOrderDBaccess SO = new SalesOrderDBaccess();
            String status = "Approved";
            grid_AppOdr.DataSource = SO.getSpecialSalesOrders(status);
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
                if (string.IsNullOrEmpty(txt_odrTot.Text))
            {
                MessageBox.Show("You must get Order Total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Picker_ReqDate.Value.Date == DateTime.Today.Date)
            {
                MessageBox.Show("You must select a Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Picker_ReqDate.Value.Date <= DateTime.Today.Date)
            {
                MessageBox.Show("You must select a Future Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_OcltId.Text))
            {
                MessageBox.Show("You must select a Client", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                SalesOrderDBaccess SO = new SalesOrderDBaccess();

                SaleMaster SM = new SaleMaster();
                SM.sale_id = txt_SOno.Text;
                SM.clt_id = txt_OcltId.Text;
                SM.sale_date = Picker_ReqDate.Value.Date;
                SM.sale_total = Convert.ToInt32(txt_odrTot.Text);

                int Status = SO.createSale_master(SM);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nOrder Created succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MetroMessageBox.Show(this, "\n\nOrder Creation Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grid_Sales.DataSource = SO.getSalesOrders();
                txt_SOno.Text = SO.GetSaleId();

                txt_OcltId.Text = null;
                txt_OcltName.Text = null;
                txt_OcltAdd.Text = null;
                txt_OcltEmail.Text = null;
                txt_CintContact.Text = null;
                cmb_ProType.Text = null;
                cmb_ftype.Text = null;
                cmb_Brand.Text = null;
                cmb_Design.Text = null;
                cmb_size.Text = null;
                cmb_color.Text = null;
                txt_qty.Text = null;
                txt_odrTot.Text = null;
                Picker_ReqDate.ResetText();
                datagrid_add.Rows.Clear();
                datagrid_add.ClearSelection();
                grid_IdNameItem.ClearSelection();
                lb_SelectClt.Visible = true;
            }

                // PurDetails PD = new PurDetails();
                // PD.pd_id = 
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
                ClientDBaccess CA = new ClientDBaccess();
            String cltId = grid_AppOdr.CurrentRow.Cells["clt_id"].Value.ToString();
            if (CA.getOrdrClients(cltId).Rows.Count != 0)
            {
                DataRow dr = CA.getOrdrClients(cltId).Rows[0];
                txt_OrderClientEmail.Text = dr["clt_email"].ToString();
                txt_OrderClientContact.Text = dr["clt_cont"].ToString();
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

        private void btn_Delivered_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_DeliOrds.Rows.Count != 1)
            {
                SalesOrderDBaccess SO = new SalesOrderDBaccess();
                String status = "Delivered";

                int Status = SO.UpdateSalesOrderStatus(grid_DeliOrds.CurrentRow.Cells["sale_id"].Value.ToString(), status);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nUpdated succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MetroMessageBox.Show(this, "\n\nUpdation Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cmb_ProType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess MA = new ManagementDBaccess();
            cmb_size.DataSource = MA.getSize(cmb_ProType.Text);
            cmb_size.DisplayMember = "ProductSize";
            
            cmb_Design.DataSource = MA.getDesignType(cmb_ProType.Text);
            cmb_Design.DisplayMember = "DesignType";
            cmb_Design.Text = null;
            cmb_size.Text = null;
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

        private void btn_cal_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagrid_add.Rows.Count < 1)
            {
                MessageBox.Show("You must select a Color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int total = 0;
                for (int a = 0; a < datagrid_add.Rows.Count; a++)
                {
                    total += Convert.ToInt32(datagrid_add.Rows[a].Cells[7].Value);
                }
                txt_odrTot.Text = total.ToString();
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

        private void btn_PlaceOrder_Click(object sender, EventArgs e)
        {
            try
            {
                SalesOrderDBaccess SO = new SalesOrderDBaccess();
            if (String.IsNullOrEmpty(txt_OrderClientEmail.Text) || String.IsNullOrEmpty(txt_OrderClientContact.Text))
            {
                MetroMessageBox.Show(this, "\n\nPlease Select Approved Purchase Order To Place Order", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (rbn_clientEmail.Checked == false && rbn_clientContact.Checked == false)
            {
                MetroMessageBox.Show(this, "\n\nPlease Select Communication Method To Place Order", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String status = "Placed";

                String SaleId = grid_AppOdr.CurrentRow.Cells["sale_id"].Value.ToString();
                int Status = SO.UpdateSalesOrderStatus(SaleId, status);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nOrder Is Placed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MetroMessageBox.Show(this, "\n\nFail To Place", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                String Sts = "Approved";
                grid_AppOdr.DataSource = SO.getSpecialSalesOrders(Sts);

                if(rbn_clientEmail.Checked)
                {
                    try
                    {

                        MailMessage message = new MailMessage();
                        SmtpClient smtp = new SmtpClient();

                        message.From = new MailAddress("lewminadilshan96@gmail.com");
                        message.To.Add(new MailAddress(txt_OrderClientEmail.Text));
                        message.Subject = "Order No "+ grid_AppOdr.CurrentRow.Cells["sale_id"].Value.ToString(); 
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

        private void Picker_ReqDate_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void Panel_AppOdr_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
