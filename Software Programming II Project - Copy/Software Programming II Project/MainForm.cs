using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Programming_II_Project
{
    public partial class MainForm : Form
    {
        Bycicles bycicles = new Bycicles();
        AccessoriesList acc = new AccessoriesList();
        List<IProductProperties> prop = new List<IProductProperties>();

        List<string> temp = new List<string>();

        double subtotal= 0.0;
        object obj;

        public MainForm()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login f = new login();
            f.ShowDialog();
            this.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bycicles.readProducts();
            acc.readProducts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //prop.Clear();
            string code = textBox1.Text;
            if (code.Trim().Length != 0)
            {
                switch (code[code.Length - 1].ToString())
                {
                    case "A":
                        foreach (Accessories a in acc)
                        {
                            if (code == a.Id)
                            {
                                prop.Add(a);
                                temp.Add(a.Id);
                                listBox1.Items.Add(prop[prop.IndexOf(a)].getMainDetails());
                                subtotal += prop[prop.IndexOf(a)].getPrice();
                                label3.Text = "Subtotal: " + subtotal + " RON";
                                label4.Text = "TVA: " + calculateTVA(subtotal) + " RON";
                                label5.Text = "TOTAL: " + calculateTotal(subtotal) + " RON";
                                textBox1.Clear();
                            }
                        }
                        break;
                    case "B":
                        foreach (Bycicle b in bycicles)
                        {
                            if (b is ElectricBike)
                            {
                                ElectricBike eb = (ElectricBike)b;
                                if (code == eb.Id)
                                {
                                    prop.Add(eb);
                                    temp.Add(eb.Id);
                                    listBox1.Items.Add(prop[prop.IndexOf(eb)].getMainDetails());
                                    subtotal += prop[prop.IndexOf(eb)].getPrice();
                                    label3.Text = "Subtotal: " + subtotal + " RON";
                                    label4.Text = "TVA: " + calculateTVA(subtotal) + " RON";
                                    label5.Text = "TOTAL: " + calculateTotal(subtotal) + " RON";
                                    textBox1.Clear();
                                }
                            }
                            else
                            {
                                if (code == b.Id)
                                {
                                    prop.Add(b);
                                    temp.Add(b.Id);
                                    listBox1.Items.Add(prop[prop.IndexOf(b)].getMainDetails());
                                    subtotal += prop[prop.IndexOf(b)].getPrice();
                                    label3.Text = "Subtotal: " + subtotal + " RON";
                                    label4.Text = "TVA: " + calculateTVA(subtotal) + " RON";
                                    label5.Text = "TOTAL: " + calculateTotal(subtotal) + " RON";
                                    textBox1.Clear();
                                }
                            }
                        }
                        break;
                    default:
                        MessageBox.Show("Invalid ID");
                        textBox1.Clear();
                        break;
                }
            } else
            {
                MessageBox.Show("Invalid ID");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string[] line = listBox1.SelectedItem.ToString().Split(';');
                string[] myItems = line[0].Split(' ');
                temp.Remove(myItems[1]);

                subtotal -= prop[listBox1.SelectedIndex].getPrice();
                label3.Text = "Subtotal: " + subtotal + " RON";
                label4.Text = "TVA: " + calculateTVA(subtotal) + " RON";
                label5.Text = "TOTAL: " + calculateTotal(subtotal) + " RON";
                prop.Remove(prop[listBox1.SelectedIndex]);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox11.Clear();
                textBox12.Clear();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            } else
            {
                MessageBox.Show("Please select an item from the list first");
            }
        }

        public double calculateTVA(double amount)
        {
            return (0.19 * amount);
        }

        public double calculateTotal(double amount)
        {
            return calculateTVA(amount) + amount;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string item in temp) {
                MessageBox.Show(item);
            }
            if (listBox1.SelectedIndex != -1)
            {
                textBox9.Text = temp[listBox1.SelectedIndex];
                int counter = 0;
                foreach (Bycicle b in bycicles)
                {
                    if (b.Id.Equals(temp[listBox1.SelectedIndex]))
                    {
                        counter++;
                        obj = b;
                    }
                }
                if (counter > 0)
                {
                    if (obj is ElectricBike)
                    {
                        ElectricBike el = (ElectricBike)obj;
                        textBox2.Text = el.Name;
                        textBox3.Text = el.Manufacturer;
                        textBox10.Text = counter.ToString();
                        textBox4.Text = el.Price.ToString();
                        textBox5.Text = el.Weight.ToString();
                        textBox6.Text = el.Material;
                        textBox7.Text = el.Speeds.ToString();
                        textBox8.Text = el.TypeOfBrakes;
                        textBox12.Text = el.Size.ToString();
                        checkBox1.Checked = el.SuspensionF;
                        checkBox2.Checked = el.SuspensionB;
                        checkBox3.Checked = el.Customizable;
                        textBox11.Text = el.Autonomy.ToString();
                    }
                    else 
                    {
                        Bycicle b = (Bycicle)obj;
                        textBox2.Text = b.Name;
                        textBox3.Text = b.Manufacturer;
                        textBox10.Text = counter.ToString();
                        textBox4.Text = b.Price.ToString();
                        textBox5.Text = b.Weight.ToString();
                        textBox6.Text = b.Material;
                        textBox7.Text = b.Speeds.ToString();
                        textBox8.Text = b.TypeOfBrakes;
                        textBox12.Text = b.Size.ToString();
                        checkBox1.Checked = b.SuspensionF;
                        checkBox2.Checked = b.SuspensionB;
                        checkBox3.Checked = b.Customizable;
                    }
                }
                int counter2 = 0;
                foreach (Accessories a in acc)
                {
                    if (a.Id.Equals(temp[listBox1.SelectedIndex]))
                    {
                        counter2++;
                        obj = a;
                    }
                }
                if (counter2 > 0)
                {
                    Accessories ac = (Accessories)obj;
                    textBox4.Text = ac.getPrice().ToString();
                    textBox10.Text = counter2.ToString();

                    textBox2.Clear();
                    textBox3.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox11.Clear();
                    textBox12.Clear();
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                }
            }
        }
    }
}
