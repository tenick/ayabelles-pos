using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyabellesPOS
{
    public partial class guestControl : UserControl
    {
        public guestControl()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.FromArgb(55, 55, 55);
            pictureBox2.BackColor = Color.FromArgb(55, 55, 55);
            pictureBox3.BackColor = Color.FromArgb(55, 55, 55);
            pictureBox4.BackColor = Color.FromArgb(55, 55, 55);
        }

        private void home_Click(object sender, EventArgs e)
        {
            selectedBtn.Location = new Point(0, 7);
        }

        private void about_Click(object sender, EventArgs e)
        {
            selectedBtn.Location = new Point(0, 63);
        }

        private void order_Click(object sender, EventArgs e)
        {
            selectedBtn.Location = new Point(0, 119);
        }

        private void checkout_Click(object sender, EventArgs e)
        {
            selectedBtn.Location = new Point(0, 175);
        }
    }
}
