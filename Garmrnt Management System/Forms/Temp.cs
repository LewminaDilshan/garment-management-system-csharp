using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Temp : Form
    {
        List<Panel> listpanel = new List<Panel>();
        int index;
        public Temp()
        {
            InitializeComponent();
        }

        private void Temp_Load(object sender, EventArgs e)
        {
            listpanel.Add(bunifuGradientPanel1);
            listpanel.Add(bunifuGradientPanel2);
            listpanel.Add(bunifuGradientPanel3);
            listpanel.Add(bunifuGradientPanel4);
            listpanel[index].BringToFront();
            listpanel[index=3].BringToFront();
        }

        private void usertile_Click(object sender, EventArgs e)
        {

          
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // If the clicked label is black, the player clicked
                // an icon that's already been revealed --
                // ignore the click
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                clickedLabel.ForeColor = Color.Black;
            }
        }

        private void label_leave(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // If the clicked label is black, the player clicked
                // an icon that's already been revealed --
                // ignore the click
                if (clickedLabel.ForeColor == Color.White)
                    return;

                clickedLabel.ForeColor = Color.White;
            }
        }
       
        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
                listpanel[index=0].BringToFront();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
                listpanel[index=1].BringToFront();       
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
                listpanel[index = 2].BringToFront();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
