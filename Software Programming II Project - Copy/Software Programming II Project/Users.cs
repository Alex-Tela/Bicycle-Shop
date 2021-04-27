using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Configuration;

namespace Software_Programming_II_Project
{
    class Users: List<User>
    {
        public void readUsers()
        {
           
            OleDbConnection connect = new OleDbConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
            OleDbCommand command = new OleDbCommand("SELECT * FROM Users;", connect);
            try
            {
                connect.Open();
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.Add(new User((Int32)reader["Type"], reader["Username"].ToString(), reader["Password"].ToString()));
                    //MessageBox.Show(reader["Type"].GetType().ToString());
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connect.Close();

            /*foreach (User user in this)
            {
                MessageBox.Show(user.ToString());
            }*/
        }

        public bool validateUsers(string s1, string s2)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (s1.Equals(this[i].Username) && s2.Equals(this[i].Password))
                {
                    return true;
                }
            }
            return false;
        }

        public int checkType(string s1)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (s1.Equals(this[i].Username))
                {
                    return this[i].Type;
                }
            }
            return 0;
        }

        public void add(int t, string u, string p)
        {
            if (User.validity(u) && User.validity(p))
            {
                this.Add(new User((Int32)t, u, p));
                OleDbConnection connect = new OleDbConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
                OleDbCommand command = new OleDbCommand("INSERT INTO Users([Type], [Username], [Password]) VALUES (@Type, @Username, @Password);", connect);
                command.Parameters.Add("@Type", OleDbType.Integer).Value = t;
                command.Parameters.Add("@Username", OleDbType.VarChar).Value = u;
                command.Parameters.Add("@Password", OleDbType.VarChar).Value = p;
                try
                {
                    connect.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Successfully added {t},{u},{p}!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connect.Close();
            } else
            {
                MessageBox.Show("Invalid string!");
            }
        }

        public void update(int oldt, string oldu, string oldp, int newt, string newu, string newp)
        {
            if (User.validity(newu) && User.validity(newp))
            {
                OleDbConnection connect = new OleDbConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
                OleDbCommand command = new OleDbCommand("UPDATE Users SET [Type]=@var1, [Username]=@var2, " +
                    "[Password]=@var3 WHERE [Type]=@var4 AND [Username]=@var5 AND [Password]=@var6;", connect);
                command.Parameters.Add("@var1", OleDbType.Integer).Value = newt;
                command.Parameters.Add("@var2", OleDbType.VarChar).Value = newu;
                command.Parameters.Add("@var3", OleDbType.VarChar).Value = newp;
                command.Parameters.Add("@var4", OleDbType.Integer).Value = oldt;
                command.Parameters.Add("@var5", OleDbType.VarChar).Value = oldu;
                command.Parameters.Add("@var6", OleDbType.VarChar).Value = oldp;

                try
                {
                    connect.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show($"Successfully updated {oldt},{oldu},{oldp} to {newt},{newu},{newp}!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connect.Close();
            } else
            {
                MessageBox.Show("Invalid string!");
            }
        }

        public void remove(int t, string u, string p)
        {
            OleDbConnection connect = new OleDbConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
            OleDbCommand command = new OleDbCommand($"DELETE FROM Users WHERE [Type]=@Type AND [Username]=@Username AND [Password]=@Password;", connect);
            command.Parameters.Add("@Type", OleDbType.Integer).Value = t;
            command.Parameters.Add("@Username", OleDbType.VarChar).Value = u;
            command.Parameters.Add("@Password", OleDbType.VarChar).Value = p;
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
                MessageBox.Show($"Successfully deleted {t},{u},{p}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connect.Close();
        }
    }
}
