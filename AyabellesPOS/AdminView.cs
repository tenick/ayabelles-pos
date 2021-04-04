using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyabellesPOS
{
    public partial class AdminView : Form
    {
        public AdminView()
        {
            InitializeComponent();
            label5.Visible = false; // test label 1
            label6.Visible = false; // test label 2
        }

        private bool mouseDown;
        private Point lastLocation;

    private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Menu")
                    Application.OpenForms[i].Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // This event is called once for each tab button in your tab control

            // First paint the background with a color based on the current tab

            // e.Index is the index of the tab in the TabPages collection.
            switch (e.Index)
            {
                case 0:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(46,46,46)), e.Bounds);
                    break;
                case 1:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(46, 46, 46)), e.Bounds);
                    break;
                case 2:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(46, 46, 46)), e.Bounds);
                    break;
                default:
                    break;
            }

            // Then draw the current tab button text 
            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-2, -2);
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, tabControl1.TabPages[e.Index].Font = new Font("Century Gothic", 10, FontStyle.Regular), SystemBrushes.HighlightText, paddedBounds);

            
        }

        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(46, 46, 46)), e.Bounds);
                    break;
                case 1:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(46, 46, 46)), e.Bounds);
                    break;
                case 2:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(46, 46, 46)), e.Bounds);
                    break;
                default:
                    break;
            }

            // Then draw the current tab button text 
            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-2, -2);
            e.Graphics.DrawString(tabControl2.TabPages[e.Index].Text, tabControl2.TabPages[e.Index].Font = new Font("Century Gothic", 10, FontStyle.Regular), SystemBrushes.HighlightText, paddedBounds);
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private int getImageCount(int tabIndex)
        {
            string folderPath = "";
            if (tabIndex == 0)
                folderPath = @"\Foods\";
            else if (tabIndex == 1)
                folderPath = @"\Noodles\";
            else if (tabIndex == 2)
                folderPath = @"\Beverages\";

            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + folderPath);
            int fileCount = dir.GetFiles().Length;
            return fileCount;
        }

        private string[] getImageNames(int tabIndex)
        {
            string folderPath = "";
            if (tabIndex == 0)
                folderPath = @"\Foods\";
            else if (tabIndex == 1)
                folderPath = @"\Noodles\";
            else if (tabIndex == 2)
                folderPath = @"\Beverages\";

            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + folderPath);

            int fileCount = 0;
            foreach(FileInfo file in dir.GetFiles())
                fileCount++;
            string[] imgNames = new string[fileCount];
            int ctr = 0;
            foreach(FileInfo file in dir.GetFiles())
            {
                imgNames[ctr] = file.Name;
                ctr++;
            }
            return imgNames;
        }

        private void AdminView_Load(object sender, EventArgs e)
        {
            adminControl1.menu.PerformClick();

            checkOutHeader.Visible = false;

            ResizeRedraw = true;
            numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.Increment = 0.01m;
            numericUpDown1.Increment = 0.5m;

            /*LOADING THE PRODUCTS*/
            //MENU
                //TABPAGE 1
                    addProductsMenu(tabControl1, 0);
                //END OF TAB PAGE 1
                //TAB PAGE 2
                    addProductsMenu(tabControl1, 1);
                //END OF TAB PAGE 2
                //TAB PAGE 3
                    addProductsMenu(tabControl1, 2);
                //END OF TAB PAGE 3
            //PRODUCT MANAGEMENT
                //TAB PAGE 1
                    addProductsProdMngmnt(tabControl2, 0);
                //END OF TAB PAGE 1
                //TAB PAGE 2
                    addProductsProdMngmnt(tabControl2, 1);
                //END OF TAB PAGE 2
                //TAB PAGE 3
                    addProductsProdMngmnt(tabControl2, 2);
                //END OF TAB PAGE 3

            addSalesFiles();
        }

        private void addSalesFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + @"\History\");
            listBox1.Items.Clear();
            foreach(FileInfo file in dir.GetFiles())
            {
                listBox1.Items.Add(file.Name);
            }
        }

        private void openTextFile_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item first");
            }
            else
            {
                string fileName = (string)listBox1.SelectedItem;
                Process.Start(Environment.CurrentDirectory + @"\History\" + fileName);
            }
        }


        private void deleteTextFile_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item first");
            }
            else
            {
                string fileName = (string)listBox1.SelectedItem;
                File.Delete(Environment.CurrentDirectory + @"\History\" + fileName);
                addSalesFiles();
            }
        }

        private void addProductsMenu(TabControl tabControl, int index)
        {
            foreach (Panel p in generateListForMenu(tabControl, index))
            {
                tabControl.TabPages[index].Controls.Add(p);
            }
        }

        private void addProductsProdMngmnt(TabControl tabControl, int index)
        {
            List<Panel> generatedList = generateListForProdMngmnt(tabControl, index);
            foreach (Panel p in generatedList)
            {
                tabControl.TabPages[index].Controls.Add(p);
            }
            //add them prices
            addPrices(tabControl, index);
            //add edit buttons
            addEditButtons(tabControl, index);
        }

        List<string> products = new List<string>();
        List<decimal> amount = new List<decimal>();
        private void addToCheckOut(object sender, EventArgs e)
        {
            NumericUpDown n = (NumericUpDown)sender;
            Panel parentPanel = (Panel)n.Parent;

            panel5.HorizontalScroll.Maximum = 0;
            panel5.AutoScroll = false;
            panel5.VerticalScroll.Visible = false;
            panel5.AutoScroll = true;

            

            if (n.Value != 0)
            {
                foreach(Control c in parentPanel.Controls)
                {
                    if(c.GetType() == typeof(Label))
                    {
                        if (char.IsLetter(c.Text[0]))
                        {
                            if (!products.Contains(c.Text))
                            {
                                products.Add(c.Text);
                                amount.Add(n.Value);
                                int prodIndex = products.IndexOf(c.Text);
                            }
                            else if (products.Contains(c.Text))
                            {
                                int prodIndex = products.IndexOf(c.Text);
                                amount[prodIndex] = n.Value;
                            }
                        }
                    }
                }
            }
            else if(n.Value == 0)
            {
                foreach (Control c in parentPanel.Controls)
                {
                    if (c.GetType() == typeof(Label))
                    {
                        if (char.IsLetter(c.Text[0]))
                        {
                            int prodIndex = products.IndexOf(c.Text);
                            products.Remove(c.Text);
                            amount.Remove(amount[prodIndex]);
                        }
                    }
                }
            }
            Label[] foods = new Label[products.Count];
            Label[] price = new Label[amount.Count];
            int x = 0, y = 0;
            panel5.Controls.Clear();
            for(int i = 0; i < products.Count; i++)
            {
                foods[i] = new Label();

                foods[i].Text = products[i];
                foods[i].Font = new Font("Century Gothic", 15, FontStyle.Bold);
                if (products[i].Length > 11)
                {
                    foods[i].Font = new Font("Century Gothic", 11, FontStyle.Bold);
                }
                if (products[i].Length > 11 && products[i].Length <= 14)
                {
                    foods[i].Font = new Font("Century Gothic", 12, FontStyle.Bold);
                }
                if (products[i].Length > 14 && products[i].Length <= 17)
                {
                    foods[i].Font = new Font("Century Gothic", 10, FontStyle.Bold);
                }
                if (products[i].Length > 17)
                {
                    foods[i].Font = new Font("Century Gothic", 9, FontStyle.Bold);
                }
                foods[i].Size = new Size(200, 30);
                foods[i].Location = new Point(x, y+(30*i));

                panel5.Controls.Add(foods[i]);
            }
            //amount labels
            x = 200;
            y = 0;
            for (int i = 0; i < amount.Count; i++)
            {
                price[i] = new Label();

                price[i].Text = ""+amount[i];
                price[i].Font = new Font("Century Gothic", 15, FontStyle.Bold);
                price[i].Size = new Size(60, 30);
                price[i].Location = new Point(x, y + (30 * i));

                panel5.Controls.Add(price[i]);
            }
            setTotal();
        }

        
        private void checkOut_Click(object sender, EventArgs e)
        {
            if (change.Equals("") || customerCash.Text.Equals("") || total.Text.Equals(""))
            {
                MessageBox.Show("Payment required");
            }
            else
            {
                string fileName = DateTime.Today.ToString("dd-MM-yyyy") + " " + DateTime.Now.ToString("HH-mm-ss") + ".txt";
                label5.Text = fileName;
                string path = Environment.CurrentDirectory + @"\History\";
                string fullPath = Path.Combine(path, fileName);
                label5.Text = fullPath;
                File.Create(fullPath).Close();

                TextWriter tw = new StreamWriter(fullPath);
                label6.Text = "" + products.Count;
                tw.WriteLine("-----PRODUCTS BOUGHT-----");
                foreach (string s in products)
                    tw.WriteLine(s);
                if (numericUpDown1.Value != 0)
                    tw.WriteLine("Rice");
                if (numericUpDown2.Value != 0)
                    tw.WriteLine("Banana");
                if (numericUpDown3.Value != 0)
                    tw.WriteLine("Bread");
                tw.WriteLine("-----AMOUNT OF PRODUCTS-----");
                foreach (decimal s in amount)
                    tw.WriteLine(s);
                if (numericUpDown1.Value != 0)
                    tw.WriteLine("" + numericUpDown1.Value);
                if (numericUpDown2.Value != 0)
                    tw.WriteLine("" + numericUpDown2.Value);
                if (numericUpDown3.Value != 0)
                    tw.WriteLine("" + numericUpDown3.Value);
                tw.WriteLine("-----TOTAL-----");
                tw.WriteLine(total.Text);

                tw.Close();

                //resetting
                panel5.Controls.Clear();
                customerCash.Text = "";
                total.Text = "";
                change.Text = "";
                products.Clear();
                amount.Clear();
                updateItems(0);
                updateItems(1);
                updateItems(2);
                addSalesFiles();
                MessageBox.Show("Transaction Complete");
                adminControl1.menu.PerformClick();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
            setTotal();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            setTotal();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            setTotal();
        }

        private void setTotal()
        {
            double totalPrice = 0;
            for (int i = 0; i < products.Count; i++)
            {
                string prodName = products[i].ToLower();
                int price = Convert.ToInt32(File.ReadAllText(Environment.CurrentDirectory + @"\PriceList\" + prodName + ".txt"));
                int prodAmount = Convert.ToInt32(amount[i]);
                totalPrice += price * prodAmount;
            }
            //add ons total

            double num1Total = Convert.ToDouble(numericUpDown1.Value) * 10;
            double num2Total = Convert.ToInt32(numericUpDown2.Value) * 10;
            double num3Total = Convert.ToInt32(numericUpDown3.Value) * 10;

            double addOnsTotal = num1Total + num2Total + num3Total;

            total.Text = "PHP " + (totalPrice+addOnsTotal);
        }

        private void customerCash_TextChanged(object sender, EventArgs e)
        {
            if (!total.Text.Equals(""))
            {
                if (!customerCash.Text.Equals(""))
                {
                    int cash = Convert.ToInt32(customerCash.Text);
                    string modifiedTotal = total.Text.Remove(0, 3); //<----
                    label6.Text = "mod total: " + modifiedTotal;
                    int totalPrice = Convert.ToInt32(modifiedTotal);
                    if (cash - totalPrice >= 0)
                    {
                        change.Text = "PHP " + (cash - totalPrice);
                    }
                }
                if (customerCash.Text.Equals(""))
                {
                    change.Text = "PHP " + 0;
                }
            }
            else
            {
                MessageBox.Show("There are no orders");
                customerCash.Text = "";
            }
        }

        private void addPrices(TabControl tabControl, int tabIndex)
        {
            string price = "";
            foreach (Panel p in tabControl.TabPages[tabIndex].Controls)
            {

                label6.Text = "wop";
                foreach (Control c in p.Controls)
                {
                    if (c.GetType() == typeof(Label))
                    {
                        if (char.IsDigit(c.Text[0]))
                        {
                            continue;
                        }
                        else
                        {
                            string prodName = c.Text.ToLower();
                            try
                            {
                                price = File.ReadAllText(Environment.CurrentDirectory + @"\PriceList\" + prodName + ".txt");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Create new price for " + prodName);
                                addNewPrice(prodName);
                            }
                            label6.Text = "price added: "+ price;
                            price = File.ReadAllText(Environment.CurrentDirectory + @"\PriceList\" + prodName + ".txt");
                            break;
                        }
                    }
                }
                p.Controls.Add(addPriceLabel(Convert.ToInt32(price)));
            }
        }

        private Label addPriceLabel(int price)
        {
            Label newPrice = new Label();
            newPrice.Text = ""+price;
            newPrice.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            newPrice.Size = new Size(140, 30);
            newPrice.Location = new Point(0, 150);
            newPrice.BringToFront();
            return newPrice;
        }

        private void addNewPrice(string product)
        {
            AddNewPrice newPrice = new AddNewPrice();
            newPrice.setName(product);
            newPrice.StartPosition = FormStartPosition.CenterScreen;
            newPrice.ShowDialog();
        }

        private void addEditButtons(TabControl tabControl, int index)
        {
            Button removeItem = new Button();
            Button addItem = new Button();
            Button editPrices = new Button();
            Button stopEdit = new Button();

            setButtonProperties(removeItem);
            setButtonProperties(addItem);
            setButtonProperties(editPrices);
            setButtonProperties(stopEdit);

            removeItem.Text = "Remove Item";
            addItem.Text = "Add Item";
            editPrices.Text = "Edit Price";
            stopEdit.Text = "Stop Edit";

            removeItem.Location = new Point(0, 0);
            addItem.Location = new Point(150, 0);
            editPrices.Location = new Point(300, 0);
            stopEdit.Location = new Point(450, 0);

            ImageList icons = new ImageList();
            icons.ImageSize = new Size(30, 30);
            icons.Images.Add(Properties.Resources.appbar_edit_minus);
            icons.Images.Add(Properties.Resources.appbar_edit_add);
            icons.Images.Add(Properties.Resources.appbar_page_edit);
            icons.Images.Add(Properties.Resources.appbar_close_white);


            removeItem.Image = icons.Images[0];
            addItem.Image = icons.Images[1];
            editPrices.Image = icons.Images[2];
            stopEdit.Image = icons.Images[3];

            stopEdit.Enabled = false;

            //events
            removeItem.Click += new EventHandler(showRemoveButtons);
            addItem.Click += new EventHandler(addNewProduct);
            stopEdit.Click += new EventHandler(hideButtons);
            editPrices.Click += new EventHandler(showEditPrices);

            tabControl.TabPages[index].Controls.Add(removeItem);
            tabControl.TabPages[index].Controls.Add(addItem);
            tabControl.TabPages[index].Controls.Add(editPrices);
            tabControl.TabPages[index].Controls.Add(stopEdit);
        }

        private void showEditPrices(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            TabPage parentTabPage = new TabPage();
            parentTabPage = (TabPage)b.Parent;

            foreach(Control c in parentTabPage.Controls)
            {
                if (c.GetType() == typeof(Panel))
                {
                    foreach(Control c2 in c.Controls)
                    {
                        if (c2.GetType() == typeof(Button))
                        {
                            if(c2.Text[0] == 'E')
                            {
                                c2.Visible = true;
                                c2.BringToFront();
                            }
                        }
                    }
                }
            }

            foreach (Control c in parentTabPage.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    if (c.Text.Equals("Stop Edit"))
                    {
                        c.Enabled = true;
                    }
                }
            }

        }

        private void showRemoveButtons(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            TabPage parentTabPage = new TabPage();
            parentTabPage = (TabPage)b.Parent;
            
            foreach(Control c in parentTabPage.Controls)
            {
                if(c.GetType() == typeof(Panel))
                {
                    foreach(Control c2 in c.Controls)
                    {
                        if (c2.GetType() == typeof(Button))
                        {
                            if(c2.Text[0] == 'R')
                            {
                                c2.Visible = true;
                                c2.BringToFront();
                            }
                        }
                    }
                }
            }
            
            foreach(Control c in parentTabPage.Controls)
            {
                if(c.GetType() == typeof(Button))
                {
                    if(c.Text.Equals("Stop Edit"))
                    {
                        c.Enabled = true;
                    }
                }
            }
            

        }

        private void addNewProduct(object sender, EventArgs e)
        {
            int tabIndex = tabControl2.SelectedIndex;
            string folderPath = "";
            if (tabIndex == 0)
                folderPath = @"Foods\";
            else if (tabIndex == 1)
                folderPath = @"Noodles\";
            else if (tabIndex == 2)
                folderPath = @"Beverages\";

            label6.Text = "selected tab: " + tabIndex;
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg) | *jpg";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(open.FileName);
                    File.Copy(open.FileName, Path.Combine(folderPath, Path.GetFileName(open.FileName)));
                }

                updateItems(tabIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void hideButtons(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            TabPage parentTabPage = new TabPage();
            parentTabPage = (TabPage)b.Parent;

            foreach (Control c in parentTabPage.Controls)
            {
                if (c.GetType() == typeof(Panel))
                {
                    foreach (Control c2 in c.Controls)
                    {
                        if (c2.GetType() == typeof(Button))
                        {
                            c2.Visible = false;
                        }
                    }
                }
            }
            setPrices();
            b.Enabled = false;
        }

        private void setButtonProperties(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = Color.FromArgb(46, 46, 46);
            b.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            b.ForeColor = Color.FromArgb(255, 255, 255);
            b.Size = new Size(120, 30);
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.ImageAlign = ContentAlignment.MiddleRight;
        }

        ImageList foodPics1 = new ImageList();
        private List<Panel> generateListForMenu(TabControl tabControl, int tabIndex)
        {
            tabControl.TabPages[tabIndex].HorizontalScroll.Maximum = 0;
            tabControl.TabPages[tabIndex].AutoScroll = false;
            tabControl.TabPages[tabIndex].VerticalScroll.Visible = false;
            tabControl.TabPages[tabIndex].AutoScroll = true;

            Directory.CreateDirectory(Environment.CurrentDirectory + @"\Foods\");
            Directory.CreateDirectory(Environment.CurrentDirectory + @"\Noodles\");
            Directory.CreateDirectory(Environment.CurrentDirectory + @"\Beverages\");

            int imageAmt = getImageCount(tabIndex); // get amount of files in foods folder
            //label5.Text = "" + imageAmt; // for verification only

            Panel[] foods = new Panel[imageAmt];
            NumericUpDown[] quantity = new NumericUpDown[imageAmt];
            Label[] name = new Label[imageAmt];
            PictureBox[] foodPic = new PictureBox[imageAmt];

            string folderPath = "";
            if (tabIndex == 0)
                folderPath = @"\Foods\";
            else if (tabIndex == 1)
                folderPath = @"\Noodles\";
            else if (tabIndex == 2)
                folderPath = @"\Beverages\";

            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + folderPath);

            foodPics1.Images.Clear();
            foreach (FileInfo file in dir.GetFiles())
            {
                Bitmap bmp = new Bitmap(file.FullName);
                foodPics1.Images.Add(bmp);
            }
            foodPics1.ImageSize = new Size(150, 120);

            string[] imageNames = getImageNames(tabIndex); // get file names in food folder

            int x = 0, y = 0, rows = 0;
            for (int i = 0; i < imageAmt; i++)
            {
                foods[i] = new Panel();
                foodPic[i] = new PictureBox();
                quantity[i] = new NumericUpDown();
                name[i] = new Label();

                foodPic[i].Size = new Size(140, 120);
                foodPic[i].Location = new Point(0, 30);
                foodPic[i].Image = foodPics1.Images[i];

                

                name[i].Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(imageNames[i].Replace(".jpg", "").ToLower());
                name[i].Font = new Font("Century Gothic", 15, FontStyle.Bold);
                if(imageNames[i].Replace(".jpg", "").Length > 11)
                {
                    name[i].Font = new Font("Century Gothic", 11, FontStyle.Bold);
                }
                if (imageNames[i].Replace(".jpg", "").Length > 11 && imageNames[i].Replace(".jpg", "").Length <= 14)
                {
                    name[i].Font = new Font("Century Gothic", 12, FontStyle.Bold);
                }
                if (imageNames[i].Replace(".jpg", "").Length > 14 && imageNames[i].Replace(".jpg", "").Length <= 17)
                {
                    name[i].Font = new Font("Century Gothic", 10, FontStyle.Bold);
                }
                if (imageNames[i].Replace(".jpg", "").Length > 17)
                {
                    name[i].Font = new Font("Century Gothic", 9, FontStyle.Bold);
                }
                name[i].Size = new Size(140, 30);
                name[i].Location = new Point(0, 0);

                quantity[i].Size = new Size(140, 30);
                quantity[i].Location = new Point(0, 150);
                quantity[i].BorderStyle = BorderStyle.None;
                quantity[i].Font = new Font("Century Gothic", 11, FontStyle.Bold);
                quantity[i].ValueChanged += new EventHandler(addToCheckOut);

                foods[i].Size = new Size(140, 170);
                foods[i].BackColor = Color.FromName("White");
                foods[i].Controls.Add(foodPic[i]);
                foods[i].Controls.Add(quantity[i]);
                foods[i].Controls.Add(name[i]);

                if (i % 4 == 0)
                {
                    y = 0;
                    x = 0;
                    rows = i / 4;
                    y += rows * 180;
                }
                x = 150 * (i - (4 * rows));

                foods[i].Location = new Point(x, y);
                //tabControl1.TabPages[0].Controls.Add(foods[i]);
            }
            return foods.ToList();
        }
        ImageList foodPics2 = new ImageList();
        private List<Panel> generateListForProdMngmnt(TabControl tabControl, int tabIndex)
        {
            tabControl.TabPages[tabIndex].HorizontalScroll.Maximum = 0;
            tabControl.TabPages[tabIndex].AutoScroll = false;
            tabControl.TabPages[tabIndex].VerticalScroll.Visible = false;
            tabControl.TabPages[tabIndex].AutoScroll = true;

            int imageAmt = getImageCount(tabIndex); // get amount of files in foods folder
            //label5.Text = "" + imageAmt; // for verification only

            Panel[] foods = new Panel[imageAmt];
            //label5.Text = "panel amt: " + foods.Length;
            //NumericUpDown[] quantity = new NumericUpDown[imageAmt]; replace with buttons
            Button[] remove = new Button[imageAmt];
            Button[] edit = new Button[imageAmt];

            Label[] name = new Label[imageAmt];
            PictureBox[] foodPic = new PictureBox[imageAmt];

            //image list food list declaration <---

            string folderPath = "";
            if (tabIndex == 0)
                folderPath = @"\Foods\";
            else if (tabIndex == 1)
                folderPath = @"\Noodles\";
            else if (tabIndex == 2)
                folderPath = @"\Beverages\";

            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + folderPath);

            foodPics2.Images.Clear();
            foreach (FileInfo file in dir.GetFiles())
            {
                Bitmap bmp = new Bitmap(file.FullName);
                foodPics2.Images.Add(bmp);
            }

            
            foodPics2.ImageSize = new Size(150, 120);

            string[] imageNames = getImageNames(tabIndex); // get file names in food folder

            int x = 0, y = 50, rows = 0;
            for (int i = 0; i < imageAmt; i++)
            {
                foods[i] = new Panel();
                foodPic[i] = new PictureBox();
                remove[i] = new Button();
                edit[i] = new Button();
                name[i] = new Label();

                foodPic[i].Size = new Size(140, 120);
                foodPic[i].Location = new Point(0, 30);
                foodPic[i].Image = foodPics2.Images[i];

                name[i].Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(imageNames[i].Replace(".jpg", "").ToLower());
                name[i].Font = new Font("Century Gothic", 15, FontStyle.Bold);
                if (imageNames[i].Replace(".jpg", "").Length > 11)
                {
                    name[i].Font = new Font("Century Gothic", 11, FontStyle.Bold);
                }
                if (imageNames[i].Replace(".jpg", "").Length > 11 && imageNames[i].Replace(".jpg", "").Length <= 14)
                {
                    name[i].Font = new Font("Century Gothic", 12, FontStyle.Bold);
                }
                if (imageNames[i].Replace(".jpg", "").Length > 14 && imageNames[i].Replace(".jpg", "").Length <= 17)
                {
                    name[i].Font = new Font("Century Gothic", 10, FontStyle.Bold);
                }
                if (imageNames[i].Replace(".jpg", "").Length > 17)
                {
                    name[i].Font = new Font("Century Gothic", 9, FontStyle.Bold);
                }
                name[i].Size = new Size(140, 30);
                name[i].Location = new Point(0, 0);
                
                remove[i].FlatStyle = FlatStyle.Flat;
                remove[i].FlatAppearance.BorderSize = 0;
                remove[i].BackColor = Color.FromArgb(46, 46, 46);
                remove[i].Size = new Size(140, 30);
                remove[i].Location = new Point(0, 150);
                remove[i].Visible = false;
                remove[i].Text = "Remove";
                remove[i].Font = new Font("Century Gothic", 12, FontStyle.Bold);
                remove[i].ForeColor = Color.FromArgb(255,255,255);
                remove[i].Click += new EventHandler(removeClick);

                edit[i].FlatStyle = FlatStyle.Flat;
                edit[i].FlatAppearance.BorderSize = 0;
                edit[i].BackColor = Color.FromArgb(46, 46, 46);
                edit[i].Size = new Size(140, 30);
                edit[i].Location = new Point(0, 150);
                edit[i].Visible = false;
                edit[i].Text = "Edit Price";
                edit[i].Font = new Font("Century Gothic", 12, FontStyle.Bold);
                edit[i].ForeColor = Color.FromArgb(255, 255, 255);
                edit[i].Click += new EventHandler(editPrice);

                foods[i].Size = new Size(140, 180);
                foods[i].BackColor = Color.FromName("White");
                foods[i].Controls.Add(foodPic[i]);
                foods[i].Controls.Add(remove[i]);
                foods[i].Controls.Add(edit[i]);
                foods[i].Controls.Add(name[i]);

                
                if (i % 4 == 0)
                {
                    y = 50;
                    x = 0;
                    rows = i / 4;
                    y += rows * 180;
                }
                x = 150 * (i - (4*rows));
                foods[i].Location = new Point(x, y);
            }

            return foods.ToList();
        }

        void editPrice(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Panel parentPanel = new Panel();
            parentPanel = (Panel)b.Parent;

            int index = tabControl2.SelectedIndex;

            string prodName = "";
            foreach(Control c in parentPanel.Controls)
            {
                if (c.GetType() == typeof(Label))
                {
                    if (char.IsDigit(c.Text[0]))
                    {
                        continue;
                    }
                    else
                    {
                        prodName = c.Text.ToLower();
                        break;
                    }
                }
            }
            addNewPrice(prodName);
        }

        private void setPrices()
        {
            int index = tabControl2.SelectedIndex;
            string prodName = "";
            foreach(Control c in tabControl2.TabPages[index].Controls)
            {
                if(c.GetType() == typeof(Panel))
                {
                    foreach(Control c2 in c.Controls)
                    {
                        if (c2.GetType() == typeof(Label))
                        {
                            if (char.IsLetter(c2.Text[0]))
                            {
                                prodName = c2.Text.ToLower();
                            }
                            if (char.IsDigit(c2.Text[0]))
                            {
                                c2.Text = File.ReadAllText(Environment.CurrentDirectory + @"\PriceList\" + prodName + ".txt");
                            }
                        }
                    }
                }
            }
        }

        void removeClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Panel parentPanel = new Panel();
            parentPanel = (Panel)b.Parent;
            string imageName = "";
            
            int tabIndex = tabControl2.SelectedIndex;
            label5.Text = ""+tabIndex;

            foreach(Control c in parentPanel.Controls)
            {
                if(c.GetType() == typeof(Label))
                {
                    if(char.IsLetter(c.Text[0]))
                        imageName = (c.Text+".jpg").ToLower();
                }
            }

            string folderPath = "";
            if (tabIndex == 0)
                folderPath = @"\Foods\";
            else if (tabIndex == 1)
                folderPath = @"\Noodles\";
            else if (tabIndex == 2)
                folderPath = @"\Beverages\";

            string filePath = Environment.CurrentDirectory + folderPath + imageName;
            label5.Text = filePath;
            try
            {
                foodPics1.Images.Clear();
                foodPics1.Dispose();

                foodPics2.Images.Clear();
                foodPics2.Dispose();

                GC.Collect();
                GC.WaitForPendingFinalizers();

                File.Delete(filePath);
                updateItems(tabIndex);
            }
            catch (IOException error)
            {
                MessageBox.Show("File is being used by another process", "Error");
            }
        }

        private void updateItems(int tabIndex)
        {
            foodPics1.Images.Clear();
            foodPics1.Dispose();

            foodPics2.Images.Clear();
            foodPics2.Dispose();

            ArrayList list1 = new ArrayList(tabControl1.TabPages[tabIndex].Controls);
            foreach (Control c in list1)
            {
                tabControl1.TabPages[tabIndex].Controls.Remove(c);
            }
            ArrayList list2 = new ArrayList(tabControl2.TabPages[tabIndex].Controls);
            foreach (Control c in list2)
            {
                tabControl2.TabPages[tabIndex].Controls.Remove(c);
            }
            addProductsMenu(tabControl1, tabIndex);
            addProductsProdMngmnt(tabControl2, tabIndex);
        }
    }
}
