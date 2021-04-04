using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyabellesPOS
{
    public partial class AddNewPrice : Form
    {
        public AddNewPrice()
        {
            InitializeComponent();
        }
        string productName = "";
        int price = 0;
        public void setName(string name)
        {
            
            productName = name;
            label2.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());

            Text = "Add new price for " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Add price", "Error");
            }
            else
            {
                string path = Environment.CurrentDirectory + @"\PriceList\" + productName + ".txt";
                File.Create(path).Close();
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(textBox1.Text);
                tw.Close();
                Close();
            }
        }
    }
}
