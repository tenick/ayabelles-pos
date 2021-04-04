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
    public partial class adminControl : UserControl
    {
        public adminControl()
        {
            InitializeComponent();
            Load += adminControl_Load;
        }

        private void menu_Click(object sender, EventArgs e)
        {
            selectedBtn.Location = new Point(0, 10);
            ((AdminView)ParentForm).tabControl1.Visible = true;
            ((AdminView)ParentForm).tabControl2.Visible = false;
            ((AdminView)ParentForm).panel4.Visible = false;
            ((AdminView)ParentForm).checkOutHeader.Visible = false;
            ((AdminView)ParentForm).salesTab.Visible = false;
            ((AdminView)ParentForm).salesHeader.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedBtn.Location = new Point(0, 66);
            ((AdminView)ParentForm).panel4.Visible = true;
            ((AdminView)ParentForm).checkOutHeader.Visible = true;
            ((AdminView)ParentForm).tabControl1.Visible = false;
            ((AdminView)ParentForm).tabControl2.Visible = false;
            ((AdminView)ParentForm).salesTab.Visible = false;
            ((AdminView)ParentForm).salesHeader.Visible = false;
        }

        private void productManagement_Click(object sender, EventArgs e)
        {
            selectedBtn.Location = new Point(0, 119);
            ((AdminView)(ParentForm)).tabControl2.Visible = true;
            ((AdminView)(ParentForm)).tabControl1.Visible = false;
            ((AdminView)ParentForm).panel4.Visible = false;
            ((AdminView)ParentForm).checkOutHeader.Visible = false;
            ((AdminView)ParentForm).salesTab.Visible = false;
            ((AdminView)ParentForm).salesHeader.Visible = false;
        }

        private void salesReport_Click(object sender, EventArgs e)
        {
            selectedBtn.Location = new Point(0, 175);
            ((AdminView)ParentForm).salesTab.Visible = true;
            ((AdminView)ParentForm).salesHeader.Visible = true;
            ((AdminView)(ParentForm)).tabControl1.Visible = false;
            ((AdminView)(ParentForm)).tabControl2.Visible = false;
            ((AdminView)ParentForm).panel4.Visible = false;
            ((AdminView)ParentForm).checkOutHeader.Visible = false;
        }

        private void adminControl_Load(object sender, EventArgs e)
        {
            //menu.PerformClick();
        }

        
    }
}
