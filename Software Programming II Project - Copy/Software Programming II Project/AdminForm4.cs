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
    public partial class AdminForm4 : Form
    {
        Users users = new Users();
        int status;

        int oldType;
        string oldUser, oldPas;

        public AdminForm4()
        {
            InitializeComponent();
        }

        private void AdminForm4_Load(object sender, EventArgs e)
        {
            users.readUsers();
            foreach (User user in users)
            {
                listBox1.Items.Add(user.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button5.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            groupBox1.Enabled = true;
            groupBox1.Text = "Add User";
            status = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button1.Enabled = false;
                button5.Enabled = false;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                groupBox1.Enabled = true;
                groupBox1.Text = "Update Selected User";
                string[] items = listBox1.Items[listBox1.SelectedIndex].ToString().Split(',');
                oldType = int.Parse(items[0]);
                oldUser = items[1];
                oldPas = items[2];
                textBox1.Text = oldType.ToString();
                textBox2.Text = oldUser;
                textBox3.Text = oldPas;
            }
            else
            {
                MessageBox.Show("No user selected!");
            }
            status = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                groupBox1.Enabled = true;
                groupBox1.Text = "Delete Selected User";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                string[] items = listBox1.Items[listBox1.SelectedIndex].ToString().Split(',');
                oldType = int.Parse(items[0]);
                oldUser = items[1];
                oldPas = items[2];
                textBox1.Text = oldType.ToString();
                textBox2.Text = oldUser;
                textBox3.Text = oldPas;
            }
            else
            {
                MessageBox.Show("No user selected!");
            }
            status = 3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                switch (status)
                {
                    case 1:
                        users.add(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text);
                        populate();
                        break;
                    case 2:
                        users.update(oldType, oldUser, oldPas, int.Parse(textBox1.Text), textBox2.Text, textBox3.Text);
                        populate();
                        break;
                    case 3:
                        users.remove(oldType, oldUser, oldPas);
                        populate();
                        break;
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                groupBox1.Enabled = false;
                groupBox1.Text = "Edit User";
                button1.Enabled = true;
                button2.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                MessageBox.Show("One or more fields are empty!");
            }
        }

        public void populate()
        {
            listBox1.Items.Clear();
            users.Clear();
            users.readUsers();
            foreach (User user in users)
            {
                listBox1.Items.Add(user.ToString());
            }
        }

        private void editProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm f = new AdminForm();
            f.ShowDialog();
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login f1 = new login();
            f1.ShowDialog();
            this.Hide();
        }

        private void AdminForm4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            groupBox1.Enabled = false;
            groupBox1.Text = "Edit User";
            button1.Enabled = true;
            button2.Enabled = true;
            button5.Enabled = true;
        }
    }
}
