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
    class Bycicles: List<Bycicle>
    {
        public void readProducts()
        {
            OleDbConnection connect = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\alexu\Documents\ProjectDatabase.accdb");
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Products;", connect);
            try
            {
                connect.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Name"].ToString().Equals("Electric"))
                    {
                        this.Add(new ElectricBike(reader["Name"].ToString(), reader["Manufacturer"].ToString(), Convert.ToDouble(reader["Price"]), Convert.ToDouble(reader["Weight"]), reader["Material"].ToString(), Convert.ToChar(reader["Size"]), Convert.ToBoolean(reader["SuspensionF"]), Convert.ToBoolean(reader["SuspensionB"]),
                        (Int32)reader["Speeds"], reader["TypeOfBrakes"].ToString(), Convert.ToBoolean(reader["Customizable"]), (Int32)reader["Autonomy"]));
                    }
                    else
                    {
                        this.Add(new Bycicle(reader["Name"].ToString(), reader["Manufacturer"].ToString(), Convert.ToDouble(reader["Price"]), Convert.ToDouble(reader["Weight"]), reader["Material"].ToString(), Convert.ToChar(reader["Size"]), Convert.ToBoolean(reader["SuspensionF"]), Convert.ToBoolean(reader["SuspensionB"]),
                            (Int32)reader["Speeds"], reader["TypeOfBrakes"].ToString(), Convert.ToBoolean(reader["Customizable"])));
                    }
                    //MessageBox.Show("Name: " + reader["Name"].ToString());
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connect.Close();
        }

        public void add(string n, string m, double p, double w, string ma, char s, bool sF, bool sB, int sp, string t, bool c)
        {
            this.Add(new Bycicle(n, m, p, w, ma, s, sF, sB, sp, t, c));
            OleDbConnection connect = new OleDbConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
            OleDbCommand command = new OleDbCommand("INSERT INTO Products([Name], [Manufacturer], [Price], [Weight], [Material], [Size], [SuspensionF], [SuspensionB], [Speeds], [TypeOfBrakes], [Customizable]) VALUES (@Name, @Manufacturer, @Price, @Weight, @Material, @Size, @SuspensionF, @SuspensionB, @Speeds, @TypeOfBrakes, @Customizable);", connect);
            command.Parameters.Add("@Name", OleDbType.VarChar).Value = n;
            command.Parameters.Add("@Manufacturer", OleDbType.VarChar).Value = m;
            command.Parameters.Add("@Price", OleDbType.Double).Value = p;
            command.Parameters.Add("@Weight", OleDbType.Double).Value = w;
            command.Parameters.Add("@Material", OleDbType.VarChar).Value = ma;
            command.Parameters.Add("@Size", OleDbType.Char).Value = s;
            command.Parameters.Add("@SuspensionF", OleDbType.Boolean).Value = sF;
            command.Parameters.Add("@SuspensionB", OleDbType.Boolean).Value = sB;
            command.Parameters.Add("@Speeds", OleDbType.Integer).Value = sp;
            command.Parameters.Add("@TypeOfBrakes", OleDbType.VarChar).Value = t;
            command.Parameters.Add("@Customizable", OleDbType.Boolean).Value = c;
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
                MessageBox.Show($"Successfully added {n},{m},{p},{w},{ma},{s},{sF},{sB},{sp},{t},{c}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connect.Close();
        }

        public void add(string n, string m, double p, double w, string ma, char s, bool sF, bool sB, int sp, string t, bool c, int a)
        {
            this.Add(new ElectricBike(n, m, p, w, ma, s, sF, sB, sp, t, c, a));
            OleDbConnection connect = new OleDbConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
            OleDbCommand command = new OleDbCommand("INSERT INTO Products([Name], [Manufacturer], [Price], [Weight], [Material], [Size], [SuspensionF], [SuspensionB], [Speeds], [TypeOfBrakes], [Customizable], [Autonomy]) VALUES (@Name, @Manufacturer, @Price, @Weight, @Material, @Size, @SuspensionF, @SuspensionB, @Speeds, @TypeOfBrakes, @Customizable, @Autonomy);", connect);
            command.Parameters.Add("@Name", OleDbType.VarChar).Value = n;
            command.Parameters.Add("@Manufacturer", OleDbType.VarChar).Value = m;
            command.Parameters.Add("@Price", OleDbType.Double).Value = p;
            command.Parameters.Add("@Weight", OleDbType.Double).Value = w;
            command.Parameters.Add("@Material", OleDbType.VarChar).Value = ma;
            command.Parameters.Add("@Size", OleDbType.Char).Value = s;
            command.Parameters.Add("@SuspensionF", OleDbType.Boolean).Value = sF;
            command.Parameters.Add("@SuspensionB", OleDbType.Boolean).Value = sB;
            command.Parameters.Add("@Speeds", OleDbType.Integer).Value = sp;
            command.Parameters.Add("@TypeOfBrakes", OleDbType.VarChar).Value = t;
            command.Parameters.Add("@Customizable", OleDbType.Boolean).Value = c;
            command.Parameters.Add("@Autonomy", OleDbType.Integer).Value = a;
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
                MessageBox.Show($"Successfully added {n},{m},{p},{w},{ma},{s},{sF},{sB},{sp},{t},{c},{a}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connect.Close();
        }

        public void update(string n, string m, double p, double w, string ma, char s, bool sF, bool sB, int sp, string t, bool c, string newn, string newm, double newp, double neww, string newma, char news, bool newsF, bool newsB, int newsp, string newt, bool newc)
        {
            OleDbConnection connect = new OleDbConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
            OleDbCommand command = new OleDbCommand("UPDATE Products SET [Name]=@NName, [Manufacturer]=@NManufacturer, " +
                "[Price]=@NPrice, [Weight]=@NWeight, [Material]=@NMaterial, [Size]=@NSize, [SuspensionF]=@NSuspensionF, " +
                "[SuspensionB]=@NSuspensionB, [Speeds]=@NSpeeds, [TypeOfBrakes]=@NTypeOfBrakes, [Customizable]=@NCustomizable" +
                " WHERE [Name]=@Name AND [Manufacturer]=@Manufacturer AND [Price]=@Price AND [Weight]=@Weight AND " +
                "[Material]=@Material AND [Size]=@Size AND [SuspensionF]=@SuspensionF AND [SuspensionB]=@SuspensionB AND " +
                "[Speeds]=@Speeds AND [TypeOfBrakes]=@TypeOfBrakes AND [Customizable]=@Customizable;", connect);

            command.Parameters.Add("@NName", OleDbType.VarChar).Value = newn;
            command.Parameters.Add("@NManufacturer", OleDbType.VarChar).Value = newm;
            command.Parameters.Add("@NPrice", OleDbType.Double).Value = newp;
            command.Parameters.Add("@NWeight", OleDbType.Double).Value = neww;
            command.Parameters.Add("@NMaterial", OleDbType.VarChar).Value = newma;
            command.Parameters.Add("@NSize", OleDbType.Char).Value = news;
            command.Parameters.Add("@NSuspensionF", OleDbType.Boolean).Value = newsF;
            command.Parameters.Add("@NSuspensionB", OleDbType.Boolean).Value = newsB;
            command.Parameters.Add("@NSpeeds", OleDbType.Integer).Value = newsp;
            command.Parameters.Add("@NTypeOfBrakes", OleDbType.VarChar).Value = newt;
            command.Parameters.Add("@NCustomizable", OleDbType.Boolean).Value = newc;

            command.Parameters.Add("@Name", OleDbType.VarChar).Value = n;
            command.Parameters.Add("@Manufacturer", OleDbType.VarChar).Value = m;
            command.Parameters.Add("@Price", OleDbType.Double).Value = p;
            command.Parameters.Add("@Weight", OleDbType.Double).Value = w;
            command.Parameters.Add("@Material", OleDbType.VarChar).Value = ma;
            command.Parameters.Add("@Size", OleDbType.Char).Value = s;
            command.Parameters.Add("@SuspensionF", OleDbType.Boolean).Value = sF;
            command.Parameters.Add("@SuspensionB", OleDbType.Boolean).Value = sB;
            command.Parameters.Add("@Speeds", OleDbType.Integer).Value = sp;
            command.Parameters.Add("@TypeOfBrakes", OleDbType.VarChar).Value = t;
            command.Parameters.Add("@Customizable", OleDbType.Boolean).Value = c;

            try
            {
                connect.Open();
                command.ExecuteNonQuery();

                MessageBox.Show($"Successfully updated {newn},{newm},{newp},{neww},{newma},{news},{newsF},{newsB},{newsp},{newt},{newc}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connect.Close();
        }

        public void update(string n, string m, double p, double w, string ma, char s, bool sF, bool sB, int sp, string t, bool c, int a, string newn, string newm, double newp, double neww, string newma, char news, bool newsF, bool newsB, int newsp, string newt, bool newc, int newa)
        {
            OleDbConnection connect = new OleDbConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
            OleDbCommand command = new OleDbCommand("UPDATE Products SET [Name]=@NName, [Manufacturer]=@NManufacturer, " +
                "[Price]=@NPrice, [Weight]=@NWeight, [Material]=@NMaterial, [Size]=@NSize, [SuspensionF]=@NSuspensionF, " +
                "[SuspensionB]=@NSuspensionB, [Speeds]=@NSpeeds, [TypeOfBrakes]=@NTypeOfBrakes, [Customizable]=@NCustomizable, [Autonomy]=@NAutonomy" +
                " WHERE [Name]=@Name AND [Manufacturer]=@Manufacturer AND [Price]=@Price AND [Weight]=@Weight AND " +
                "[Material]=@Material AND [Size]=@Size AND [SuspensionF]=@SuspensionF AND [SuspensionB]=@SuspensionB AND " +
                "[Speeds]=@Speeds AND [TypeOfBrakes]=@TypeOfBrakes AND [Customizable]=@Customizable AND [Autonomy]=@Autonomy;", connect);

            command.Parameters.Add("@NName", OleDbType.VarChar).Value = newn;
            command.Parameters.Add("@NManufacturer", OleDbType.VarChar).Value = newm;
            command.Parameters.Add("@NPrice", OleDbType.Double).Value = newp;
            command.Parameters.Add("@NWeight", OleDbType.Double).Value = neww;
            command.Parameters.Add("@NMaterial", OleDbType.VarChar).Value = newma;
            command.Parameters.Add("@NSize", OleDbType.Char).Value = news;
            command.Parameters.Add("@NSuspensionF", OleDbType.Boolean).Value = newsF;
            command.Parameters.Add("@NSuspensionB", OleDbType.Boolean).Value = newsB;
            command.Parameters.Add("@NSpeeds", OleDbType.Integer).Value = newsp;
            command.Parameters.Add("@NTypeOfBrakes", OleDbType.VarChar).Value = newt;
            command.Parameters.Add("@NCustomizable", OleDbType.Boolean).Value = newc;
            command.Parameters.Add("@NAutonomy", OleDbType.Integer).Value = newa;

            command.Parameters.Add("@Name", OleDbType.VarChar).Value = n;
            command.Parameters.Add("@Manufacturer", OleDbType.VarChar).Value = m;
            command.Parameters.Add("@Price", OleDbType.Double).Value = p;
            command.Parameters.Add("@Weight", OleDbType.Double).Value = w;
            command.Parameters.Add("@Material", OleDbType.VarChar).Value = ma;
            command.Parameters.Add("@Size", OleDbType.Char).Value = s;
            command.Parameters.Add("@SuspensionF", OleDbType.Boolean).Value = sF;
            command.Parameters.Add("@SuspensionB", OleDbType.Boolean).Value = sB;
            command.Parameters.Add("@Speeds", OleDbType.Integer).Value = sp;
            command.Parameters.Add("@TypeOfBrakes", OleDbType.VarChar).Value = t;
            command.Parameters.Add("@Customizable", OleDbType.Boolean).Value = c;
            command.Parameters.Add("@Autonomy", OleDbType.Integer).Value = a;

            try
            {
                connect.Open();
                command.ExecuteNonQuery();

                MessageBox.Show($"Successfully updated {newn},{newm},{newp},{neww},{newma},{news},{newsF},{newsB},{newsp},{newt},{newc},{newa}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connect.Close();
        }

        public void remove(string n, string m, double p, double w, string ma, char s, bool sF, bool sB, int sp, string t, bool c)
        {
            OleDbConnection connect = new OleDbConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
            OleDbCommand command = new OleDbCommand($"DELETE FROM Products WHERE [Name]=@Name AND [Manufacturer]=@Manufacturer AND [Price]=@Price AND [Weight]=@Weight AND [Material]=@Material AND [Size]=@Size AND [SuspensionF]=@SuspensionF AND [SuspensionB]=@SuspensionB AND [Speeds]=@Speeds AND [TypeOfBrakes]=@TypeOfBrakes AND [Customizable]=@Customizable;", connect);
            command.Parameters.Add("@Name", OleDbType.VarChar).Value = n;
            command.Parameters.Add("@Manufacturer", OleDbType.VarChar).Value = m;
            command.Parameters.Add("@Price", OleDbType.Double).Value = p;
            command.Parameters.Add("@Weight", OleDbType.Double).Value = w;
            command.Parameters.Add("@Material", OleDbType.VarChar).Value = ma;
            command.Parameters.Add("@Size", OleDbType.Char).Value = s;
            command.Parameters.Add("@SuspensionF", OleDbType.Boolean).Value = sF;
            command.Parameters.Add("@SuspensionB", OleDbType.Boolean).Value = sB;
            command.Parameters.Add("@Speeds", OleDbType.Integer).Value = sp;
            command.Parameters.Add("@TypeOfBrakes", OleDbType.VarChar).Value = t;
            command.Parameters.Add("@Customizable", OleDbType.Boolean).Value = c;
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
                MessageBox.Show($"Successfully deleted {n},{m},{p},{w},{ma},{s},{sF},{sB},{sp},{t},{c}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connect.Close();
        }

        public void remove(string n, string m, double p, double w, string ma, char s, bool sF, bool sB, int sp, string t, bool c, int a)
        {
            OleDbConnection connect = new OleDbConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
            OleDbCommand command = new OleDbCommand($"DELETE FROM Products WHERE [Name]=@Name AND [Manufacturer]=@Manufacturer AND [Price]=@Price AND [Weight]=@Weight AND [Material]=@Material AND [Size]=@Size AND [SuspensionF]=@SuspensionF AND [SuspensionB]=@SuspensionB AND [Speeds]=@Speeds AND [TypeOfBrakes]=@TypeOfBrakes AND [Customizable]=@Customizable AND [Autonomy]=@Autonomy;", connect);
            command.Parameters.Add("@Name", OleDbType.VarChar).Value = n;
            command.Parameters.Add("@Manufacturer", OleDbType.VarChar).Value = m;
            command.Parameters.Add("@Price", OleDbType.Double).Value = p;
            command.Parameters.Add("@Weight", OleDbType.Double).Value = w;
            command.Parameters.Add("@Material", OleDbType.VarChar).Value = ma;
            command.Parameters.Add("@Size", OleDbType.Char).Value = s;
            command.Parameters.Add("@SuspensionF", OleDbType.Boolean).Value = sF;
            command.Parameters.Add("@SuspensionB", OleDbType.Boolean).Value = sB;
            command.Parameters.Add("@Speeds", OleDbType.Integer).Value = sp;
            command.Parameters.Add("@TypeOfBrakes", OleDbType.VarChar).Value = t;
            command.Parameters.Add("@Customizable", OleDbType.Boolean).Value = c;
            command.Parameters.Add("@Autonomy", OleDbType.Integer).Value = a;
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
                MessageBox.Show($"Successfully deleted {n},{m},{p},{w},{ma},{s},{sF},{sB},{sp},{t},{c},{a}!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connect.Close();
        }

        public string toString()
        {
            string text = "";
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] is ElectricBike)
                {
                    ElectricBike e = (ElectricBike)this[i];
                    text += e.toString() + Environment.NewLine;
                } else
                {
                    text += this[i].toString() + Environment.NewLine;
                }
            }
            return text;
        }

        public string reportOnPrice()
        {
            this.Sort(Bycicle.comparePrice);
            return this.toString();
        }

        public string reportOnTypeAndSize()
        {
            this.Sort(Bycicle.compareTypeAndSize);
            return this.toString();
        }

        public bool validateAll(string n, string m, string p, string w, string ma, string sp, string t)
        {
            if (Bycicle.validity(n) && Bycicle.validity(m) && Bycicle.validity(ma) && Bycicle.validity(t))
            {
                if (Bycicle.validDouble(p) && Bycicle.validDouble(w))
                {
                    if (Bycicle.validInt(sp))
                    {
                        return true;
                    } else
                    {
                        MessageBox.Show("Invalid integer in \"Speeds\" field");
                        return false;
                    }
                } else
                {
                    MessageBox.Show("Invalid number formats in \"Price\" and/or \"Weight\" fields");
                    return false;
                }
            } else
            {
                MessageBox.Show("Invalid string or whitespace added in \"Name\", \"Manufacturer\", \"Material\" or \"Type of Brakes\" fields");
                return false;
            }
        }
    }
}
