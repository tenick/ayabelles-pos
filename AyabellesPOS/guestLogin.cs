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
    public partial class guestLogin : UserControl
    {
        public guestLogin()
        {
            InitializeComponent();
        }
        
        private void goBack_Click(object sender, EventArgs e)
        {
            ((login)(ParentForm)).loginSection1.Show();
            ((login)(ParentForm)).guestLogin1.Hide();
            ((login)(ParentForm)).adminLogin1.Hide();

            toolTip1.Hide(textBox1);
            textBox1.BackColor = Color.FromName("Control");

            toolTip2.Hide(textBox2);
            textBox2.BackColor = Color.FromName("Control");
        }

        private void submit_Click(object sender, EventArgs e)
        {
            bool logged = true;
            
            if (textBox1.Text.Trim().Length == 0)
            {
                textBox1.BackColor = Color.FromArgb(249, 100, 126);
                toolTip1.Show("Username Required", textBox1, 2000);
                logged = false;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                textBox2.BackColor = Color.FromArgb(249, 100, 126);
                toolTip2.Show("Password Required", textBox2, 2000);
                logged = false;
            }
            if (logged)
            {
                GuestView guest = new GuestView();
                guest.Show();
                guest.Location = ((login)(ParentForm)).Location;
                ((login)(ParentForm)).Hide();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            toolTip1.Hide(textBox1);
            textBox1.BackColor = Color.FromName("Control");
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            toolTip2.Hide(textBox2);
            textBox2.BackColor = Color.FromName("Control");
        }
    }
}
