using Final_Project.entity;
using Final_Project.repository;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.Forms
{
    
    public partial class Stock : Form
    {
        List<Panel> listpanel = new List<Panel>();
        int index;
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            listpanel.Add(Panel_Display);
            listpanel.Add(Panel_FinishedPro);
            listpanel.Add(Panel_damage);
            listpanel.Add(Panel_PurchaseMet);
            listpanel[index].BringToFront();
            listpanel[index = 0].BringToFront();
        }

        private void btn_FinishedPro_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 1].BringToFront();
            StockDBaccess SD = new StockDBaccess();
            grid_product.DataSource = SD.getAllProduct();
            txt_PID.Text = SD.GetProductId();
            grid_product.ClearSelection();
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

        private void btn_PurchaseMet_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 3].BringToFront();

            StockDBaccess SD = new StockDBaccess();
            grid_met.DataSource = SD.getAllMaterial();
            txt_MID.Text = SD.GetMaterialId();
            grid_met.ClearSelection();
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

        private void btn_DamageStatus_Click(object sender, EventArgs e)
        {
            try
            {
                listpanel[index = 2].BringToFront();
            rbn_Pro.Checked = true;
            StockDBaccess SD = new StockDBaccess();
            grid_Damaged.DataSource = SD.getAllProduct();
            grid_Damaged.ClearSelection();
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

        private void chk_ResMet_OnChange(object sender, EventArgs e)
        {
            try
            {
                StockDBaccess SD = new StockDBaccess();
            if (chk_ResMet.Checked)
            {
                grid_met.DataSource = SD.getReceivedMet();
            }
            else
                grid_met.DataSource = SD.getAllMaterial();
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

        private void btn_M_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Mtype.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Material Type", "Error");
            }
            else if (cmb_MSize.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Size", "Error");
            }
            else if (cmb_Mcolor.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Color", "Error");

            }
            else if (string.IsNullOrEmpty(txt_Mqty.Text) || !Regex.Match(txt_Mqty.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("Invalid, Please enter price correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToInt32(txt_Mqty.Text) <= 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Quantity cannot be minus or zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                StockMaterial SM = new StockMaterial();
                SM.MatId = txt_MID.Text;
                SM.MaterialType = cmb_Mtype.Text;
                SM.Size = cmb_MSize.Text;
                SM.Color = cmb_Mcolor.Text;
                SM.Quantity = txt_Mqty.Text;
                SM.Description = txt_Area_M_Des.Text;

                StockDBaccess SD = new StockDBaccess();
                int Status = SD.createMaterial(SM);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nRecord added succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MetroMessageBox.Show(this, "\n\n Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (chk_ResMet.Checked)
                {
                    grid_met.DataSource = SD.getReceivedMet();
                }
                else
                    grid_met.DataSource = SD.getAllMaterial();

                txt_MID.Text = SD.GetMaterialId();
                cmb_ftype.Text = null;
                cmb_MSize.Text = null;
                cmb_Mcolor.Text = null;
                cmb_Mtype.Text = null;
                txt_Mqty.Text = "";
                txt_Area_M_Des.Text = "";
                grid_met.ClearSelection();
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

        private void grid_met_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(chk_ResMet.Checked)
            {
                cmb_Mtype.Text = grid_met.CurrentRow.Cells["pd_Item_type"].Value.ToString();
                cmb_MSize.Text = grid_met.CurrentRow.Cells["Size"].Value.ToString();
                cmb_Mcolor.Text = grid_met.CurrentRow.Cells["color"].Value.ToString();
                txt_Mqty.Text = grid_met.CurrentRow.Cells["pd_qty"].Value.ToString();
            }
            else
            {
                txt_MID.Text = grid_met.CurrentRow.Cells["Mat_id"].Value.ToString();
                cmb_Mtype.Text = grid_met.CurrentRow.Cells["Material_Type"].Value.ToString();
                cmb_MSize.Text = grid_met.CurrentRow.Cells["Size"].Value.ToString();
                cmb_Mcolor.Text = grid_met.CurrentRow.Cells["color"].Value.ToString();
                txt_Mqty.Text = grid_met.CurrentRow.Cells["Quantity"].Value.ToString();
                txt_Area_M_Des.Text = grid_met.CurrentRow.Cells["Descriptions"].Value.ToString();
            }
            
        }

        private void btn_M_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Mtype.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Material Type", "Error");
            }
            else if (cmb_MSize.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Size", "Error");
            }
            else if (cmb_Mcolor.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Color", "Error");

            }
            else if (string.IsNullOrEmpty(txt_Mqty.Text) || !Regex.Match(txt_Mqty.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("Invalid, Please enter price correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToInt32(txt_Mqty.Text) <= 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Quantity cannot be minus or zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!chk_ResMet.Checked)
                {
                    StockMaterial SM = new StockMaterial();
                    SM.MatId = txt_MID.Text;
                    SM.MaterialType = cmb_Mtype.Text;
                    SM.Size = cmb_MSize.Text;
                    SM.Color = cmb_Mcolor.Text;
                    SM.Quantity = txt_Mqty.Text;
                    SM.Description = txt_Area_M_Des.Text;

                    StockDBaccess SD = new StockDBaccess();
                    int Status = SD.updateMaterial(SM);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nsuccesfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MetroMessageBox.Show(this, "\n\nUpdate Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    grid_met.DataSource = SD.getAllMaterial();
                    txt_MID.Text = SD.GetMaterialId();
                    cmb_ftype.Text = null;
                    cmb_MSize.Text = null;
                    cmb_Mcolor.Text = null;
                    cmb_Mtype.Text = null;
                    txt_Mqty.Text = "";
                    txt_Area_M_Des.Text = "";
                    grid_met.ClearSelection();
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

        private void btn_M_remove_Click(object sender, EventArgs e)
        {
            try
            {
                StockDBaccess SD = new StockDBaccess();
            int Status = SD.deleteMaterial(txt_MID.Text);
            if (Status == 1)
            {
                MetroMessageBox.Show(this, "\n\nsuccesfully Removed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MetroMessageBox.Show(this, "\n\nRemove Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            grid_met.DataSource = SD.getAllMaterial();
            txt_MID.Text = SD.GetMaterialId();
            cmb_ftype.Text = null;
            cmb_MSize.Text = null;
            cmb_Mcolor.Text = null;
            cmb_Mtype.Text = null;
            txt_Mqty.Text = "";
            txt_Area_M_Des.Text = "";
            grid_met.ClearSelection();
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

        private void btn_M_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                txt_MID.Text = "";
            cmb_ftype.Text = null;
            cmb_MSize.Text = null;
            cmb_Mcolor.Text = null;
            cmb_Mtype.Text = null;
            txt_Mqty.Text = "";
            txt_Area_M_Des.Text = "";
            grid_met.ClearSelection();

            StockDBaccess SD = new StockDBaccess();
            txt_MID.Text = SD.GetMaterialId();
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_ptype.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Material Type", "Error");
            }
            else if (cmb_Brand.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Brand", "Error");
            }
            else if (cmb_Design.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Design", "Error");
            }
            else if (cmb_size.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Size", "Error");
            }
            else if (cmb_color.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Color", "Error");

            }
            else if (cmb_ptype.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Product Type", "Error");
            }
           
            else if (cmb_ftype.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Color", "Error");

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
                StockDBaccess SD = new StockDBaccess();
                StockProduct SP = new StockProduct();
                SP.ProId = txt_PID.Text;
                SP.ProType = cmb_ptype.Text;
                SP.Brand = cmb_Brand.Text;
                SP.Design = cmb_Design.Text;
                SP.Size = cmb_size.Text;
                SP.Color = cmb_color.Text;
                SP.FabricType = cmb_ftype.Text;
                SP.Quantity = txt_qty.Text;
                SP.Description = txt_Area_des.Text;



                int Status = SD.createProduct(SP);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nRecord added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MetroMessageBox.Show(this, "\n\n Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                grid_product.DataSource = SD.getAllProduct();
                txt_PID.Text = SD.GetProductId();
                cmb_ptype.Text = null;
                cmb_Brand.Text = null;
                cmb_Design.Text = null;
                cmb_size.Text = null;
                cmb_color.Text = null;
                cmb_ftype.Text = null;
                txt_Area_des.Text = "";
                txt_qty.Text = "";
                grid_product.ClearSelection();
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

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_ptype.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Material Type", "Error");
            }
            else if (cmb_Brand.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Brand", "Error");
            }
            else if (cmb_Design.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Design", "Error");
            }
            else if (cmb_size.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Size", "Error");
            }
            else if (cmb_color.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Color", "Error");

            }
            else if (cmb_ptype.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Product Type", "Error");
            }

            else if (cmb_ftype.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Color", "Error");

            }
            else if (string.IsNullOrEmpty(txt_Mqty.Text) || !Regex.Match(txt_Mqty.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("Invalid, Please enter price correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txt_Mqty.Text) || !Regex.Match(txt_Mqty.Text, "^[0-9]*$").Success)
            {
                MessageBox.Show("Invalid, Please enter Quantity correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Convert.ToInt32(txt_qty.Text) <= 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Quantity cannot be minus or zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                StockProduct SP = new StockProduct();
                SP.ProId = txt_PID.Text;
                SP.ProType = cmb_ptype.Text;
                SP.Size = cmb_size.Text;
                SP.Color = cmb_color.Text;
                SP.FabricType = cmb_ftype.Text;
                SP.Quantity = txt_qty.Text;
                SP.Description = txt_Area_des.Text;

                StockDBaccess SD = new StockDBaccess();
                int Status = SD.updateProduct(SP);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nsuccesfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    MetroMessageBox.Show(this, "\n\nUpdate Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                grid_product.DataSource = SD.getAllProduct();
                txt_PID.Text = SD.GetProductId();
                cmb_ptype.Text = null;
                cmb_Brand.Text = null;
                cmb_Design.Text = null;
                cmb_size.Text = null;
                cmb_color.Text = null;
                cmb_ftype.Text = null;
                txt_Area_des.Text = "";
                txt_qty.Text = "";
                grid_product.ClearSelection();
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

        private void btn_remove_Click(object sender, EventArgs e)
        {
            try
            {
                StockDBaccess SD = new StockDBaccess();
            int Status = SD.deleteProduct(txt_PID.Text);
            if (Status == 1)
            {
                MetroMessageBox.Show(this, "\n\nsuccesfully Removed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MetroMessageBox.Show(this, "\n\nRemove Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            grid_product.DataSource = SD.getAllProduct();
            txt_PID.Text = SD.GetProductId();
            cmb_ptype.Text = null;
            cmb_Brand.Text = null;
            cmb_Design.Text = null;
            cmb_size.Text = null;
            cmb_color.Text = null;
            cmb_ftype.Text = null;
            txt_Area_des.Text = "";
            txt_qty.Text = "";
            grid_product.ClearSelection();
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            try
            {
                txt_PID.Text = "";
                cmb_ptype.Text = null;
                cmb_Brand.Text = null;
                cmb_Design.Text = null;
                cmb_size.Text = null;
                cmb_color.Text = null;
                cmb_ftype.Text = null;
                txt_Area_des.Text = "";
                txt_qty.Text = "";
                grid_product.ClearSelection();

                StockDBaccess SD = new StockDBaccess();
                txt_PID.Text = SD.GetProductId();
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
            txt_PID.Text = grid_product.CurrentRow.Cells["Pro_id"].Value.ToString();
            cmb_ptype.Text = grid_product.CurrentRow.Cells["Product_Type"].Value.ToString();
            cmb_Brand.Text = grid_product.CurrentRow.Cells["Brand"].Value.ToString();
            cmb_Design.Text = grid_product.CurrentRow.Cells["Design"].Value.ToString();
            cmb_size.Text = grid_product.CurrentRow.Cells["Size"].Value.ToString();
            cmb_color.Text = grid_product.CurrentRow.Cells["color"].Value.ToString();
            cmb_ftype.Text = grid_product.CurrentRow.Cells["Fabric_Type"].Value.ToString();
            txt_qty.Text = grid_product.CurrentRow.Cells["Quantity"].Value.ToString();
            txt_Area_des.Text = grid_product.CurrentRow.Cells["Descriptions"].Value.ToString();

          /*  StockDBaccess SD = new StockDBaccess();
            Image ProImg = SD.ConvertBinaryToImage(txt_PID.Text);*/
            
        }

        private void rbn_Pro_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbn_Pro.Checked)
            {
                StockDBaccess SD = new StockDBaccess();
                grid_Damaged.DataSource = SD.getAllProduct();
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

        private void rbn_Met_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbn_Met.Checked)
            {
                StockDBaccess SD = new StockDBaccess();
                grid_Damaged.DataSource = SD.getAllMaterial();
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

        private void btn_dmg_Click(object sender, EventArgs e)
        {
            try
            {
                StockDBaccess SD = new StockDBaccess();
            if (grid_Damaged.SelectedRows.Count < 1)
            {
                MetroMessageBox.Show(this, "\n\nSelect Record From Grid to proceed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                String status = "Damaged";
                if (rbn_Pro.Checked)
                {
                    String ProId = grid_Damaged.CurrentRow.Cells["Pro_id"].Value.ToString();
                    int Status = SD.UpdateProductDamageStatus(ProId, status);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nStatus Changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MetroMessageBox.Show(this, "\n\nUpdate Status Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    grid_Damaged.DataSource = SD.getAllProduct();
                }


                if (rbn_Met.Checked)
                {
                    String MatId = grid_Damaged.CurrentRow.Cells["Mat_id"].Value.ToString();
                    int Status = SD.UpdateMaterialDamageStatus(MatId, status);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nStatus Changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MetroMessageBox.Show(this, "\n\nUpdate Status Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    grid_Damaged.DataSource = SD.getAllMaterial();
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

        private void btn_ndmg_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_Damaged.SelectedRows.Count < 1)
            {
                MetroMessageBox.Show(this, "\n\nSelect Record From Grid to proceed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                StockDBaccess SD = new StockDBaccess();
            String status = "Not Damaged";
            if (rbn_Pro.Checked)
            {
                String ProId = grid_Damaged.CurrentRow.Cells["Pro_id"].Value.ToString();
                int Status = SD.UpdateProductDamageStatus(ProId, status);
                if (Status == 1)
                {
                    MetroMessageBox.Show(this, "\n\nStatus Changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MetroMessageBox.Show(this, "\n\nUpdate Status Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                grid_Damaged.DataSource = SD.getAllProduct();

            }
                if (rbn_Met.Checked)
                {
                    String MatId = grid_Damaged.CurrentRow.Cells["Mat_id"].Value.ToString();
                    int Status = SD.UpdateMaterialDamageStatus(MatId, status);
                    if (Status == 1)
                    {
                        MetroMessageBox.Show(this, "\n\nStatus Changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MetroMessageBox.Show(this, "\n\nUpdate Status Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    grid_Damaged.DataSource = SD.getAllMaterial();
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

        private void btn_home_Click(object sender, EventArgs e)
        {
            MainForm newform = new MainForm();
            newform.Show();
            this.Close();
        }
        /*
        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                if (pb_Product.Image != null)
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Dispose();
                }
                return ms.ToArray();
            }
        }*/


        private void btn_picOpen_Click(object sender, EventArgs e)
        {/*
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    String fileName;
                    fileName = ofd.FileName;
                    pb_Product.Image = Image.FromFile(fileName);
                }
            }*/
        }

        private void p_type_Click(object sender, EventArgs e)
        {

        }

        private void Panel_PurchaseMet_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmb_ptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementDBaccess MA = new ManagementDBaccess();
            StockDBaccess SD = new StockDBaccess();
            cmb_size.DataSource = MA.getSize(cmb_ptype.Text);
            cmb_size.DisplayMember = "ProductSize";

            cmb_Design.DataSource = MA.getDesignType(cmb_ptype.Text);
            cmb_Design.DisplayMember = "DesignType";
            cmb_size.Text = null;
            cmb_Design.Text = null;
            grid_Damaged.DataSource = SD.getAllProduct();
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

        private void txt_Mqty_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
