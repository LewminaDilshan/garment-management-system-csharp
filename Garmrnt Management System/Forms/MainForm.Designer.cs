namespace Final_Project
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuGradientPanel2 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btn_close = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuTileButton6 = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_stock = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_Acc = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_Manage = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_Sales = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_purchase = new Bunifu.Framework.UI.BunifuTileButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
            this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.Black;
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.Gray;
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.White;
            this.bunifuGradientPanel2.Location = new System.Drawing.Point(0, 679);
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(1305, 55);
            this.bunifuGradientPanel2.TabIndex = 1;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.btn_close);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Gray;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(1305, 60);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.Image = global::Final_Project.Properties.Resources.icon;
            this.btn_close.ImageActive = global::Final_Project.Properties.Resources.icon;
            this.btn_close.InitialImage = global::Final_Project.Properties.Resources.icon;
            this.btn_close.Location = new System.Drawing.Point(0, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(59, 60);
            this.btn_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_close.TabIndex = 0;
            this.btn_close.TabStop = false;
            this.btn_close.Zoom = 10;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // bunifuTileButton6
            // 
            this.bunifuTileButton6.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTileButton6.color = System.Drawing.Color.Transparent;
            this.bunifuTileButton6.colorActive = System.Drawing.Color.DodgerBlue;
            this.bunifuTileButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton6.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.bunifuTileButton6.ForeColor = System.Drawing.Color.Black;
            this.bunifuTileButton6.Image = ((System.Drawing.Image)(resources.GetObject("bunifuTileButton6.Image")));
            this.bunifuTileButton6.ImagePosition = 20;
            this.bunifuTileButton6.ImageZoom = 50;
            this.bunifuTileButton6.LabelPosition = 41;
            this.bunifuTileButton6.LabelText = "Reports";
            this.bunifuTileButton6.Location = new System.Drawing.Point(932, 366);
            this.bunifuTileButton6.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton6.Name = "bunifuTileButton6";
            this.bunifuTileButton6.Size = new System.Drawing.Size(217, 208);
            this.bunifuTileButton6.TabIndex = 19;
            this.bunifuTileButton6.Click += new System.EventHandler(this.bunifuTileButton6_Click);
            // 
            // btn_stock
            // 
            this.btn_stock.BackColor = System.Drawing.Color.Transparent;
            this.btn_stock.color = System.Drawing.Color.Transparent;
            this.btn_stock.colorActive = System.Drawing.Color.LawnGreen;
            this.btn_stock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_stock.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btn_stock.ForeColor = System.Drawing.Color.Black;
            this.btn_stock.Image = global::Final_Project.Properties.Resources.istock_505647848;
            this.btn_stock.ImagePosition = 20;
            this.btn_stock.ImageZoom = 70;
            this.btn_stock.LabelPosition = 41;
            this.btn_stock.LabelText = "Stock";
            this.btn_stock.Location = new System.Drawing.Point(932, 160);
            this.btn_stock.Margin = new System.Windows.Forms.Padding(6);
            this.btn_stock.Name = "btn_stock";
            this.btn_stock.Size = new System.Drawing.Size(217, 205);
            this.btn_stock.TabIndex = 18;
            this.btn_stock.Click += new System.EventHandler(this.btn_stock_Click);
            // 
            // btn_Acc
            // 
            this.btn_Acc.BackColor = System.Drawing.Color.Transparent;
            this.btn_Acc.color = System.Drawing.Color.Transparent;
            this.btn_Acc.colorActive = System.Drawing.Color.Teal;
            this.btn_Acc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Acc.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btn_Acc.ForeColor = System.Drawing.Color.Black;
            this.btn_Acc.Image = ((System.Drawing.Image)(resources.GetObject("btn_Acc.Image")));
            this.btn_Acc.ImagePosition = 20;
            this.btn_Acc.ImageZoom = 50;
            this.btn_Acc.LabelPosition = 41;
            this.btn_Acc.LabelText = "Accountant";
            this.btn_Acc.Location = new System.Drawing.Point(706, 366);
            this.btn_Acc.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Acc.Name = "btn_Acc";
            this.btn_Acc.Size = new System.Drawing.Size(224, 208);
            this.btn_Acc.TabIndex = 16;
            this.btn_Acc.Click += new System.EventHandler(this.btn_Acc_Click);
            // 
            // btn_Manage
            // 
            this.btn_Manage.BackColor = System.Drawing.Color.Transparent;
            this.btn_Manage.color = System.Drawing.Color.Transparent;
            this.btn_Manage.colorActive = System.Drawing.Color.MediumSpringGreen;
            this.btn_Manage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Manage.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btn_Manage.ForeColor = System.Drawing.Color.Black;
            this.btn_Manage.Image = ((System.Drawing.Image)(resources.GetObject("btn_Manage.Image")));
            this.btn_Manage.ImagePosition = 20;
            this.btn_Manage.ImageZoom = 50;
            this.btn_Manage.LabelPosition = 41;
            this.btn_Manage.LabelText = "Management";
            this.btn_Manage.Location = new System.Drawing.Point(470, 366);
            this.btn_Manage.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Manage.Name = "btn_Manage";
            this.btn_Manage.Size = new System.Drawing.Size(233, 208);
            this.btn_Manage.TabIndex = 15;
            this.btn_Manage.Click += new System.EventHandler(this.btn_Manage_Click);
            // 
            // btn_Sales
            // 
            this.btn_Sales.BackColor = System.Drawing.Color.Transparent;
            this.btn_Sales.color = System.Drawing.Color.Transparent;
            this.btn_Sales.colorActive = System.Drawing.Color.DarkSlateBlue;
            this.btn_Sales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Sales.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btn_Sales.ForeColor = System.Drawing.Color.Black;
            this.btn_Sales.Image = global::Final_Project.Properties.Resources.surface_crm;
            this.btn_Sales.ImagePosition = 20;
            this.btn_Sales.ImageZoom = 70;
            this.btn_Sales.LabelPosition = 41;
            this.btn_Sales.LabelText = "Sales";
            this.btn_Sales.Location = new System.Drawing.Point(470, 160);
            this.btn_Sales.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Sales.Name = "btn_Sales";
            this.btn_Sales.Size = new System.Drawing.Size(233, 205);
            this.btn_Sales.TabIndex = 14;
            this.btn_Sales.Click += new System.EventHandler(this.btn_Sales_Click);
            // 
            // btn_purchase
            // 
            this.btn_purchase.BackColor = System.Drawing.Color.Transparent;
            this.btn_purchase.color = System.Drawing.Color.Transparent;
            this.btn_purchase.colorActive = System.Drawing.Color.Maroon;
            this.btn_purchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_purchase.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btn_purchase.ForeColor = System.Drawing.Color.Black;
            this.btn_purchase.Image = global::Final_Project.Properties.Resources.howtopurchaseorder_750xx4256_2394_0_0;
            this.btn_purchase.ImagePosition = 20;
            this.btn_purchase.ImageZoom = 70;
            this.btn_purchase.LabelPosition = 41;
            this.btn_purchase.LabelText = "Production";
            this.btn_purchase.Location = new System.Drawing.Point(706, 160);
            this.btn_purchase.Margin = new System.Windows.Forms.Padding(6);
            this.btn_purchase.Name = "btn_purchase";
            this.btn_purchase.Size = new System.Drawing.Size(224, 205);
            this.btn_purchase.TabIndex = 20;
            this.btn_purchase.Click += new System.EventHandler(this.btn_purchase_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Final_Project.Properties.Resources.download;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(92, 221);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 302);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Vivaldi", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.bunifuCustomLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuCustomLabel1.ImageKey = "(none)";
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(24, 75);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(822, 95);
            this.bunifuCustomLabel1.TabIndex = 22;
            this.bunifuCustomLabel1.Text = "Andre Life Style Clothing";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Final_Project.Properties.Resources.wallpaper2you_103797;
            this.ClientSize = new System.Drawing.Size(1305, 734);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_purchase);
            this.Controls.Add(this.bunifuTileButton6);
            this.Controls.Add(this.btn_stock);
            this.Controls.Add(this.btn_Acc);
            this.Controls.Add(this.btn_Manage);
            this.Controls.Add(this.btn_Sales);
            this.Controls.Add(this.bunifuGradientPanel2);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.bunifuGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel2;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuImageButton btn_close;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton6;
        private Bunifu.Framework.UI.BunifuTileButton btn_stock;
        private Bunifu.Framework.UI.BunifuTileButton btn_Acc;
        private Bunifu.Framework.UI.BunifuTileButton btn_Manage;
        private Bunifu.Framework.UI.BunifuTileButton btn_Sales;
        private Bunifu.Framework.UI.BunifuTileButton btn_purchase;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
    }
}