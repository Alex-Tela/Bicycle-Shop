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
    public partial class login : Form
    {
        Users users = new Users();

        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {        
            users.readUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                string strUser = textBox1.Text;
                string txtPas = textBox2.Text;
                bool result = users.validateUsers(strUser, txtPas);
                if (result)
                {
                    int userType = users.checkType(strUser);
                    switch (userType)
                    {
                        case 0:
                            MessageBox.Show("Incorrect username and password!", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case 1:
                            this.Hide();
                            AdminForm4 f1 = new AdminForm4();
                            f1.ShowDialog();     
                            break;
                        case 2:
                            this.Hide();
                            MainForm f2 = new MainForm();
                            f2.ShowDialog();
                            break;
                    }
                } else
                {
                    MessageBox.Show("Incorrect username and password!", "Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else
            {
                MessageBox.Show("One or more fields are empty.", "Empty fields!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
