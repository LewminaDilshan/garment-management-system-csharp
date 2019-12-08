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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.Forms
{
    public partial class Accountant : Form
    {
        List<Panel> listpanel = new List<Panel>();
        int index;
        public Accountant()
        {
            InitializeComponent();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            MainForm newform = new MainForm();
            newform.Show();
            this.Close();
        }

        private void Accountant_Load(object sender, EventArgs e)
        {
            listpanel.Add(Panel_Display);
            listpanel.Add(Panel_Price);
            listpanel.Add(Panel_PurchaseSales);
            listpanel.Add(panel_StockDetails);
            listpanel[index].BringToFront();
            listpanel[index = 0].BringToFront();
        }

        private void btn_Price_Click(object sender, EventArgs e)
        {
            listpanel[index = 1].BringToFront();

           /* AccountantDBaccess AD = new AccountantDBaccess();
            grid_product.DataSource = AD.getSentAccountantProduct();*/
        }

        private void grid_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (rbn_brand.Checked)
                {
                    txt_Ftype.Text = grid_product.CurrentRow.Cells["brandName"].Value.ToString();
                    txt_SalesPrice.Text = grid_product.CurrentRow.Cells["brandPrice"].Value.ToString();
                }
                if (rbn_design.Checked)
                {
                    txt_Ftype.Text = grid_product.CurrentRow.Cells["DesignType"].Value.ToString();
                    txt_ItemType.Text = grid_product.CurrentRow.Cells["ItemType"].Value.ToString();
                    txt_SalesPrice.Text = grid_product.CurrentRow.Cells["DesignPrice"].Value.ToString();
                }
                if (rbn_fabricType.Checked)
                {
                    txt_Ftype.Text = grid_product.CurrentRow.Cells["fabricType"].Value.ToString();
                    txt_SalesPrice.Text = grid_product.CurrentRow.Cells["fabricPrice"].Value.ToString();
                }
                if (rbn_size.Checked)
                {
                    txt_Ftype.Text = grid_product.CurrentRow.Cells["ProductSize"].Value.ToString();
                    txt_ItemType.Text = grid_product.CurrentRow.Cells["ItemType"].Value.ToString();
                    txt_SalesPrice.Text = grid_product.CurrentRow.Cells["sizePrice"].Value.ToString();
                }
                if (rbn_item.Checked)
                {
                    txt_Ftype.Text = grid_product.CurrentRow.Cells["ProductName"].Value.ToString();
                    txt_SalesPrice.Text = grid_product.CurrentRow.Cells["productPrice"].Value.ToString();
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

        private void btn_Conupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_product.SelectedRows.Count > 0)
                {
                    if (rbn_brand.Checked)
                    {
                        AccountantDBaccess AD = new AccountantDBaccess();
                        Brand B = new Brand();
                        B.brandId = grid_product.CurrentRow.Cells["brandId"].Value.ToString();
                        int Status = AD.updateBrandPrice(B);
                        if (Status == 1)
                        {
                            MetroMessageBox.Show(this, "\n\nUpdate confirmed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MetroMessageBox.Show(this, "\n\nConfirmation Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        String st = "Sent To Accountant";
                        grid_product.DataSource = AD.getBrand(st);
                        //  grid_product.DataSource = AD.getSentAccountantProduct();
                    }
                    if (rbn_design.Checked)
                    {
                        AccountantDBaccess AD = new AccountantDBaccess();
                        Design D = new Design();
                        D.DesignId = grid_product.CurrentRow.Cells["DesignId"].Value.ToString();
                        int Status = AD.updateDesignPrice(D);
                        if (Status == 1)
                        {
                            MetroMessageBox.Show(this, "\n\nUpdate confirmed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MetroMessageBox.Show(this, "\n\nConfirmation Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        
                        String st = "Sent To Accountant";
                        grid_product.DataSource = AD.getDesign(st);
                    }
                    if (rbn_fabricType.Checked)
                    {
                        AccountantDBaccess AD = new AccountantDBaccess();
                        FabricType F = new FabricType();
                        F.fabricId = grid_product.CurrentRow.Cells["fabricId"].Value.ToString();
                        int Status = AD.updatefabricPrice(F);
                        if (Status == 1)
                        {
                            MetroMessageBox.Show(this, "\n\nUpdate confirmed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MetroMessageBox.Show(this, "\n\nConfirmation Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        String st = "Sent To Accountant";
                        grid_product.DataSource = AD.getFabricType(st);
                    }
                    if (rbn_size.Checked)
                    {
                        AccountantDBaccess AD = new AccountantDBaccess();
                        ProductSize P = new ProductSize();
                        P.PSizeId = grid_product.CurrentRow.Cells["PSizeId"].Value.ToString();
                        int Status = AD.updateSizePrice(P);
                        if (Status == 1)
                        {
                            MetroMessageBox.Show(this, "\n\nUpdate confirmed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MetroMessageBox.Show(this, "\n\nConfirmation Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        String st = "Sent To Accountant";
                        grid_product.DataSource = AD.getProductSize(st);
                    }
                    if (rbn_item.Checked)
                    {
                        AccountantDBaccess AD = new AccountantDBaccess();
                        Item I = new Item();
                        I.ItemID = grid_product.CurrentRow.Cells["Item_id"].Value.ToString();
                        int Status = AD.updateItemPrice(I);
                        if (Status == 1)
                        {
                            MetroMessageBox.Show(this, "\n\nUpdate confirmed succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MetroMessageBox.Show(this, "\n\nConfirmation Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        grid_product.DataSource = AD.getSentAccountantProduct();
                    }
                    txt_ItemType.Text = "";
                    txt_Ftype.Text = "";
                    txt_SalesPrice.Text = "";
                }
                else
                    MetroMessageBox.Show(this, "\n\nPlease select item from datagrid", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void btn_PurSalesOrder_Click(object sender, EventArgs e)
        {
            try
            { 
            listpanel[index = 2].BringToFront();
            rbn_SaleM.Checked = true;
            lb_res.Visible = false;
            lb_del.Visible = true;
            chk_Orders.Checked = false;
          
            SalesOrderDBaccess SO = new SalesOrderDBaccess();
            grid_PurSales.DataSource = SO.getSalesOrders();
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

        private void rbn_SaleM_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SalesOrderDBaccess SO = new SalesOrderDBaccess();
            if (rbn_SaleM.Checked)
            {
                lb_del.Visible = true;
                lb_res.Visible = false;
                if (chk_Orders.Checked)
                {                  
                    String Status = "Delivered";
                    grid_PurSales.DataSource = SO.getDeliveredSalesOrders(Status);
                }
                else
                    grid_PurSales.DataSource = SO.getSalesOrders();
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

        private void rbn_PurM_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
            if (rbn_PurM.Checked)
            {
                lb_del.Visible = false;
                lb_res.Visible = true;
                if (chk_Orders.Checked)
                {
                    String Status = "Received";
                    grid_PurSales.DataSource = PO.getRecievedPurchaseOrders(Status);
                }
                else
                    grid_PurSales.DataSource = PO.getPurchaseOrders();
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

        private void chk_Orders_OnChange(object sender, EventArgs e)
        {
            try
            {
                SalesOrderDBaccess SO = new SalesOrderDBaccess();
                PurchaseOrderDBaccess PO = new PurchaseOrderDBaccess();
                if (rbn_SaleM.Checked)
                {
                    if (chk_Orders.Checked)
                    {
                        String Status = "Delivered";
                        grid_PurSales.DataSource = SO.getDeliveredSalesOrders(Status);
                    }
                    else
                        grid_PurSales.DataSource = SO.getSalesOrders();
                }
                if (rbn_PurM.Checked)
                {
                    if (chk_Orders.Checked)
                    {
                        String Status = "Received";
                        grid_PurSales.DataSource = PO.getRecievedPurchaseOrders(Status);
                    }
                    else
                        grid_PurSales.DataSource = PO.getPurchaseOrders();
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

        private void rbn_brand_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AccountantDBaccess AD = new AccountantDBaccess();
                String st = "Sent To Accountant";
                grid_product.DataSource = AD.getBrand(st);
                p_type.Visible = false;
                txt_ItemType.Visible = false;
                p_Ftype.Text = "Brand";
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
                AccountantDBaccess AD = new AccountantDBaccess();
            String st = "Sent To Accountant";
            grid_product.DataSource = AD.getDesign(st);
            p_type.Visible = true;
            txt_ItemType.Visible = true;
            p_Ftype.Text = "Design";
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
                AccountantDBaccess AD = new AccountantDBaccess();
            String st = "Sent To Accountant";
            grid_product.DataSource = AD.getProductSize(st);
            p_type.Visible = true;
            txt_ItemType.Visible = true;
            p_Ftype.Text = "Size";
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
        {try
            { 
            AccountantDBaccess AD = new AccountantDBaccess();
            String st = "Sent To Accountant";
            grid_product.DataSource = AD.getItem(st);
            p_type.Visible = false;
            txt_ItemType.Visible = false;
            p_Ftype.Text = "Product";
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
                AccountantDBaccess AD = new AccountantDBaccess();
            String st = "Sent To Accountant";
            grid_product.DataSource = AD.getFabricType(st);
            p_type.Visible = false;
            txt_ItemType.Visible = false;
            p_Ftype.Text = "Fabric Type";
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

        private void btn_StockDetails_Click(object sender, EventArgs e)
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

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }
    } 
}
