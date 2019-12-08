namespace Final_Project.Forms
{
    partial class Systemreportsform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Systemreportsform));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuGradientPanel2 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btn_home = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btn_SupReport = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_PurchaseReport = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btn_SalesReport = new Bunifu.Framework.UI.BunifuTileButton();
            this.CrisReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btn_clientReport = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_StockProRep = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_StockMat = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
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
            this.bunifuGradientPanel2.Controls.Add(this.btn_home);
            this.bunifuGradientPanel2.Controls.Add(this.bunifuImageButton1);
            this.bunifuGradientPanel2.Controls.Add(this.pictureBox2);
            this.bunifuGradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.Gold;
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.White;
            this.bunifuGradientPanel2.Location = new System.Drawing.Point(133, 0);
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(1251, 57);
            this.bunifuGradientPanel2.TabIndex = 6;
            // 
            // btn_home
            // 
            this.btn_home.BackColor = System.Drawing.Color.Transparent;
            this.btn_home.Image = global::Final_Project.Properties.Resources.home;
            this.btn_home.ImageActive = null;
            this.btn_home.InitialImage = global::Final_Project.Properties.Resources.home;
            this.btn_home.Location = new System.Drawing.Point(0, 0);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(59, 57);
            this.btn_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_home.TabIndex = 17;
            this.btn_home.TabStop = false;
            this.btn_home.Zoom = 10;
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuImageButton1.Image = global::Final_Project.Properties.Resources.icon;
            this.bunifuImageButton1.ImageActive = global::Final_Project.Properties.Resources.icon;
            this.bunifuImageButton1.Location = new System.Drawing.Point(1198, 0);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(51, 57);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 16;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Final_Project.Properties.Resources.user_silhouette;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(1137, -1);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 58);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.btn_StockMat);
            this.bunifuGradientPanel1.Controls.Add(this.btn_StockProRep);
            this.bunifuGradientPanel1.Controls.Add(this.btn_clientReport);
            this.bunifuGradientPanel1.Controls.Add(this.btn_SupReport);
            this.bunifuGradientPanel1.Controls.Add(this.btn_PurchaseReport);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuGradientPanel1.Controls.Add(this.btn_SalesReport);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Gold;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(133, 720);
            this.bunifuGradientPanel1.TabIndex = 5;
            // 
            // btn_SupReport
            // 
            this.btn_SupReport.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_SupReport.color = System.Drawing.Color.DarkOliveGreen;
            this.btn_SupReport.colorActive = System.Drawing.Color.Lime;
            this.btn_SupReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SupReport.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SupReport.ForeColor = System.Drawing.Color.Black;
            this.btn_SupReport.Image = global::Final_Project.Properties.Resources.clipboard;
            this.btn_SupReport.ImagePosition = 13;
            this.btn_SupReport.ImageZoom = 35;
            this.btn_SupReport.LabelPosition = 26;
            this.btn_SupReport.LabelText = "Supplier Report";
            this.btn_SupReport.Location = new System.Drawing.Point(-1, 374);
            this.btn_SupReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_SupReport.Name = "btn_SupReport";
            this.btn_SupReport.Size = new System.Drawing.Size(134, 87);
            this.btn_SupReport.TabIndex = 8;
            this.btn_SupReport.Click += new System.EventHandler(this.btn_SupReport_Click);
            // 
            // btn_PurchaseReport
            // 
            this.btn_PurchaseReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_PurchaseReport.color = System.Drawing.Color.DodgerBlue;
            this.btn_PurchaseReport.colorActive = System.Drawing.Color.Aquamarine;
            this.btn_PurchaseReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PurchaseReport.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PurchaseReport.ForeColor = System.Drawing.Color.Black;
            this.btn_PurchaseReport.Image = global::Final_Project.Properties.Resources.clipboard;
            this.btn_PurchaseReport.ImagePosition = 5;
            this.btn_PurchaseReport.ImageZoom = 40;
            this.btn_PurchaseReport.LabelPosition = 27;
            this.btn_PurchaseReport.LabelText = "Purchase Report";
            this.btn_PurchaseReport.Location = new System.Drawing.Point(1, 282);
            this.btn_PurchaseReport.Margin = new System.Windows.Forms.Padding(6);
            this.btn_PurchaseReport.Name = "btn_PurchaseReport";
            this.btn_PurchaseReport.Size = new System.Drawing.Size(133, 94);
            this.btn_PurchaseReport.TabIndex = 4;
            this.btn_PurchaseReport.Click += new System.EventHandler(this.btn_PurchaseReport_Click);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(3, 24);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(160, 46);
            this.bunifuCustomLabel1.TabIndex = 3;
            this.bunifuCustomLabel1.Text = "Reports";
            // 
            // btn_SalesReport
            // 
            this.btn_SalesReport.BackColor = System.Drawing.Color.IndianRed;
            this.btn_SalesReport.color = System.Drawing.Color.IndianRed;
            this.btn_SalesReport.colorActive = System.Drawing.Color.MistyRose;
            this.btn_SalesReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SalesReport.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SalesReport.ForeColor = System.Drawing.Color.Black;
            this.btn_SalesReport.Image = global::Final_Project.Properties.Resources.clipboard;
            this.btn_SalesReport.ImagePosition = 13;
            this.btn_SalesReport.ImageZoom = 35;
            this.btn_SalesReport.LabelPosition = 26;
            this.btn_SalesReport.LabelText = "Sales Report";
            this.btn_SalesReport.Location = new System.Drawing.Point(0, 198);
            this.btn_SalesReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_SalesReport.Name = "btn_SalesReport";
            this.btn_SalesReport.Size = new System.Drawing.Size(133, 86);
            this.btn_SalesReport.TabIndex = 5;
            this.btn_SalesReport.Click += new System.EventHandler(this.btn_SalesReport_Click);
            // 
            // CrisReport
            // 
            this.CrisReport.ActiveViewIndex = -1;
            this.CrisReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrisReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrisReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrisReport.Location = new System.Drawing.Point(133, 57);
            this.CrisReport.Name = "CrisReport";
            this.CrisReport.Size = new System.Drawing.Size(1251, 663);
            this.CrisReport.TabIndex = 7;
            // 
            // btn_clientReport
            // 
            this.btn_clientReport.BackColor = System.Drawing.Color.Olive;
            this.btn_clientReport.color = System.Drawing.Color.Olive;
            this.btn_clientReport.colorActive = System.Drawing.Color.Lime;
            this.btn_clientReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clientReport.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clientReport.ForeColor = System.Drawing.Color.Black;
            this.btn_clientReport.Image = global::Final_Project.Properties.Resources.clipboard;
            this.btn_clientReport.ImagePosition = 13;
            this.btn_clientReport.ImageZoom = 35;
            this.btn_clientReport.LabelPosition = 26;
            this.btn_clientReport.LabelText = "Client Report";
            this.btn_clientReport.Location = new System.Drawing.Point(0, 118);
            this.btn_clientReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_clientReport.Name = "btn_clientReport";
            this.btn_clientReport.Size = new System.Drawing.Size(134, 86);
            this.btn_clientReport.TabIndex = 9;
            this.btn_clientReport.Click += new System.EventHandler(this.btn_clientReport_Click);
            // 
            // btn_StockProRep
            // 
            this.btn_StockProRep.BackColor = System.Drawing.Color.Gold;
            this.btn_StockProRep.color = System.Drawing.Color.Gold;
            this.btn_StockProRep.colorActive = System.Drawing.Color.Lime;
            this.btn_StockProRep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_StockProRep.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StockProRep.ForeColor = System.Drawing.Color.Black;
            this.btn_StockProRep.Image = global::Final_Project.Properties.Resources.clipboard;
            this.btn_StockProRep.ImagePosition = 13;
            this.btn_StockProRep.ImageZoom = 35;
            this.btn_StockProRep.LabelPosition = 26;
            this.btn_StockProRep.LabelText = "Stock Product Report";
            this.btn_StockProRep.Location = new System.Drawing.Point(1, 460);
            this.btn_StockProRep.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_StockProRep.Name = "btn_StockProRep";
            this.btn_StockProRep.Size = new System.Drawing.Size(134, 87);
            this.btn_StockProRep.TabIndex = 10;
            this.btn_StockProRep.Click += new System.EventHandler(this.btn_StockProRep_Click);
            // 
            // btn_StockMat
            // 
            this.btn_StockMat.BackColor = System.Drawing.Color.Orange;
            this.btn_StockMat.color = System.Drawing.Color.Orange;
            this.btn_StockMat.colorActive = System.Drawing.Color.Lime;
            this.btn_StockMat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_StockMat.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StockMat.ForeColor = System.Drawing.Color.Black;
            this.btn_StockMat.Image = global::Final_Project.Properties.Resources.clipboard;
            this.btn_StockMat.ImagePosition = 13;
            this.btn_StockMat.ImageZoom = 35;
            this.btn_StockMat.LabelPosition = 26;
            this.btn_StockMat.LabelText = "Stock material Report";
            this.btn_StockMat.Location = new System.Drawing.Point(-1, 547);
            this.btn_StockMat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_StockMat.Name = "btn_StockMat";
            this.btn_StockMat.Size = new System.Drawing.Size(134, 84);
            this.btn_StockMat.TabIndex = 11;
            this.btn_StockMat.Click += new System.EventHandler(this.btn_StockMat_Click);
            // 
            // Systemreportsform
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1384, 720);
            this.Controls.Add(this.CrisReport);
            this.Controls.Add(this.bunifuGradientPanel2);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Systemreportsform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Systemreportsform";
            this.bunifuGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel2;
        private Bunifu.Framework.UI.BunifuImageButton btn_home;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuTileButton btn_SupReport;
        private Bunifu.Framework.UI.BunifuTileButton btn_PurchaseReport;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuTileButton btn_SalesReport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrisReport;
        private Bunifu.Framework.UI.BunifuTileButton btn_StockMat;
        private Bunifu.Framework.UI.BunifuTileButton btn_StockProRep;
        private Bunifu.Framework.UI.BunifuTileButton btn_clientReport;
    }
}