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

namespace Software_Programming_II_Project
{
    public partial class AdminForm : Form
    {
        Bycicles bycicles = new Bycicles();
        int status, oldSpeeds, oldAutonomy;
        string oldName, oldMan, oldMaterial, oldBrakes;
        double oldPrice, oldWeight;
        char oldSize;
        bool oldSusF, oldSusB, oldCustom;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (button2.Enabled == false || button3.Enabled == false)
            {
                populateTextBoxes();
            }
        }

        public AdminForm()
        {
            InitializeComponent();
        }

        private void editUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm4 f = new AdminForm4();
            f.ShowDialog();
            this.Close();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            bycicles.readProducts();
            foreach (Bycicle b in bycicles)
            {
                if (b is ElectricBike)
                {
                    ElectricBike c = (ElectricBike)b;
                    listBox1.Items.Add(c.toString());
                } else
                {
                    listBox1.Items.Add(b.toString());
                }
            }
            label12.Text = "Number of products: " + bycicles.Count.ToString();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login f1 = new login();
            f1.ShowDialog();
            this.Hide();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            File.WriteAllText("reportPrice.txt", bycicles.reportOnPrice());
            MessageBox.Show("Successfully created report \"reportPrice.txt\"!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            File.WriteAllText("reportTypeAndSize.txt", bycicles.reportOnTypeAndSize());
            MessageBox.Show("Successfully created report \"reportTypeAndSize.txt\"!");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "Electric")
            {
                textBox9.Enabled = true;
            }
            else
            {
                textBox9.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            comboBox1.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            groupBox1.Enabled = true;
            groupBox1.Text = "Add Product";
            status = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                comboBox1.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                groupBox1.Enabled = true;
                groupBox1.Text = "Update Selected Product";
                populateTextBoxes();


            }
            else
            {
                MessageBox.Show("No user selected!");
            }
            status = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                comboBox1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                groupBox1.Enabled = true;
                groupBox1.Text = "Delete Selected Product";
                populateTextBoxes();

            }
            else
            {
                MessageBox.Show("No user selected!");
            }
            status = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && textBox5.Text.Length > 0 && textBox6.Text.Length > 0 && textBox7.Text.Length > 0 && textBox8.Text.Length > 0)
            {
                switch (status)
                {
                    case 1:                        
                        if (bycicles.validateAll(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text))
                        {
                            if (textBox2.Text == "Electric")
                            {
                                bycicles.add(textBox2.Text, textBox3.Text, double.Parse(textBox4.Text), double.Parse(textBox5.Text), textBox6.Text, char.Parse(comboBox1.SelectedItem.ToString()), bool.Parse(checkBox1.Checked.ToString()), bool.Parse(checkBox2.Checked.ToString()), int.Parse(textBox7.Text), textBox8.Text, bool.Parse(checkBox3.Checked.ToString()), int.Parse(textBox9.Text));
                            }
                            else
                            {
                                bycicles.add(textBox2.Text, textBox3.Text, double.Parse(textBox4.Text), double.Parse(textBox5.Text), textBox6.Text, char.Parse(comboBox1.SelectedItem.ToString()), bool.Parse(checkBox1.Checked.ToString()), bool.Parse(checkBox2.Checked.ToString()), int.Parse(textBox7.Text), textBox8.Text, bool.Parse(checkBox3.Checked.ToString()));
                            }
                                //populateTextBoxes();
                            populateListBox();
                        }
                        break;
                    case 2:
                        if (bycicles.validateAll(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text))
                        {
                            if (textBox2.Text == "Electric")
                            {
                                bycicles.update(oldName, oldMan, oldPrice, oldWeight, oldMaterial, oldSize, oldSusF, oldSusB, oldSpeeds, oldBrakes, oldCustom, oldAutonomy, textBox2.Text, textBox3.Text, double.Parse(textBox4.Text), double.Parse(textBox5.Text), textBox6.Text, char.Parse(comboBox1.SelectedItem.ToString()), bool.Parse(checkBox1.Checked.ToString()), bool.Parse(checkBox2.Checked.ToString()), int.Parse(textBox7.Text), textBox8.Text, bool.Parse(checkBox3.Checked.ToString()), int.Parse(textBox9.Text));
                            }
                            else
                            {
                                bycicles.update(oldName, oldMan, oldPrice, oldWeight, oldMaterial, oldSize, oldSusF, oldSusB, oldSpeeds, oldBrakes, oldCustom, textBox2.Text, textBox3.Text, double.Parse(textBox4.Text), double.Parse(textBox5.Text), textBox6.Text, char.Parse(comboBox1.SelectedItem.ToString()), bool.Parse(checkBox1.Checked.ToString()), bool.Parse(checkBox2.Checked.ToString()), int.Parse(textBox7.Text), textBox8.Text, bool.Parse(checkBox3.Checked.ToString()));
                            }
                            populateTextBoxes();
                            populateListBox();
                        }
                        break;
                    case 3:
                        if (textBox2.Text == "Electric")
                        {
                            bycicles.remove(textBox2.Text, textBox3.Text, double.Parse(textBox4.Text), double.Parse(textBox5.Text), textBox6.Text, char.Parse(comboBox1.SelectedItem.ToString()), bool.Parse(checkBox1.Checked.ToString()), bool.Parse(checkBox2.Checked.ToString()), int.Parse(textBox7.Text), textBox8.Text, bool.Parse(checkBox3.Checked.ToString()), int.Parse(textBox9.Text));
                        }
                        else
                        {
                            bycicles.remove(textBox2.Text, textBox3.Text, double.Parse(textBox4.Text), double.Parse(textBox5.Text), textBox6.Text, char.Parse(comboBox1.SelectedItem.ToString()), bool.Parse(checkBox1.Checked.ToString()), bool.Parse(checkBox2.Checked.ToString()), int.Parse(textBox7.Text), textBox8.Text, bool.Parse(checkBox3.Checked.ToString()));
                        }
                        populateTextBoxes();
                        populateListBox();
                        break;
                }
                label12.Text = "Number of products: " + bycicles.Count.ToString();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                comboBox1.SelectedIndex = -1;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                groupBox1.Enabled = false;
                groupBox1.Text = "Edit Product";
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                MessageBox.Show("One or more fields are empty!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox1.SelectedIndex = -1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            groupBox1.Enabled = false;
            groupBox1.Text = "Edit Product";
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        public void populateTextBoxes()
        {
            string[] items = listBox1.Items[listBox1.SelectedIndex].ToString().Split(',');
            oldName = items[0];
            oldMan = items[1];
            oldPrice = double.Parse(items[2]);
            oldWeight = double.Parse(items[3]);
            oldMaterial = items[4];
            oldSize = char.Parse(items[5]);
            oldSusF = bool.Parse(items[6]);
            oldSusB = bool.Parse(items[7]);
            oldSpeeds = int.Parse(items[8]);
            oldBrakes = items[9];
            oldCustom = bool.Parse(items[10]);
            if (oldName == "Electric")
            {
                oldAutonomy = int.Parse(items[11]);
            }

            textBox1.Text = bycicles[listBox1.SelectedIndex].Id.ToString();
            textBox2.Text = oldName.ToString();
            textBox3.Text = oldMan.ToString();
            textBox4.Text = oldPrice.ToString();
            textBox5.Text = oldWeight.ToString();
            textBox6.Text = oldMaterial.ToString();
            textBox7.Text = oldSpeeds.ToString();
            textBox8.Text = oldBrakes.ToString();
            if (textBox9.Enabled == true)
            {
                textBox9.Text = oldAutonomy.ToString();
            }
            comboBox1.Text = oldSize.ToString();
            checkBox1.Checked = oldSusF;
            checkBox2.Checked = oldSusB;
            checkBox3.Checked = oldCustom;
        }

        public void populateListBox()
        {
            listBox1.Items.Clear();
            bycicles.Clear();
            bycicles.readProducts();
            foreach (Bycicle bycicle in bycicles)
            {
                listBox1.Items.Add(bycicle.toString());
            }
            label12.Text = "Number of products: " + bycicles.Count.ToString();
        }
    }
}
