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
    public partial class loginSection : UserControl
    {
        public loginSection()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.FromArgb(55, 55, 55);
            pictureBox2.BackColor = Color.FromArgb(55, 55, 55);

        }

        private void guest_Click(object sender, EventArgs e)
        {
            /*login log = new login();
            guestLogin guest = new guestLogin();
            log.Controls.Add(guest);
            guest.Location = new Point(0,90);
            guest.Size = new Size(185, 233);
            guest.BringToFront();
            Hide();

            /*GuestView guest = new GuestView();
            guest.StartPosition = FormStartPosition.CenterScreen;
            guest.Show();
            login log = new login();
            log.loginSection1.Hide();
            log.guestLogin1.Show();
            log.guestLogin1.BringToFront();
            log.Refresh();
            log.Show();*/
            ((login)(ParentForm)).guestLogin1.Show();
            ((login)(ParentForm)).loginSection1.Hide();
            ((login)(ParentForm)).adminLogin1.Hide();

        }

        private void admin_Click(object sender, EventArgs e)
        {
            ((login)(ParentForm)).adminLogin1.Show();
            ((login)(ParentForm)).loginSection1.Hide();
            ((login)(ParentForm)).guestLogin1.Hide();
        }

        private void guest_MouseEnter(object sender, EventArgs e)
        {
            ((login)(ParentForm)).selectedBtn.Visible = true;
            ((login)(ParentForm)).selectedBtn.Location = new Point(0, 83);
        }

        private void guest_MouseLeave(object sender, EventArgs e)
        {
            ((login)(ParentForm)).selectedBtn.Visible = false;
        }

        private void admin_MouseEnter(object sender, EventArgs e)
        {
            ((login)(ParentForm)).selectedBtn.Visible = true;
            ((login)(ParentForm)).selectedBtn.Location = new Point(0, 139);
        }

        private void admin_MouseLeave(object sender, EventArgs e)
        {
            ((login)(ParentForm)).selectedBtn.Visible = false;
        }
    }
}
