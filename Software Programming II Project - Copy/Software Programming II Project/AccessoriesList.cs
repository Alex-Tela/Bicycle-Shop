using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Programming_II_Project
{
    class AccessoriesList: List<Accessories>
    {
        public void readProducts()
        {
            OleDbConnection connect = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\alexu\Documents\ProjectDatabase.accdb");
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Other;", connect);
            try
            {
                connect.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.Add(new Accessories(reader["_name"].ToString(), (Int32)reader["Price"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connect.Close();
        }
    }
}
