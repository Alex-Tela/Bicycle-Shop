using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Programming_II_Project
{
    class User: AbstractClass
    {
        int _type;
        string _username;
        string _password;

        public User()
        {
            _type = 2;
            _username = "";
            _password = "";
        }

        public User(int type, string username, string password)
        {
            Type = type;
            Username = username;
            Password = password;
        }

        public int Type
        {
            get { return _type; }
            set { if (value >= 1 && value <= 2)
                {
                    _type = value;
                }
                else 
                {
                    _type = 2;
                }
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    _username = value;
                }
                else
                {
                    MessageBox.Show("Enter a valid string!");
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    _password = value;
                }
                else
                {
                    MessageBox.Show("Enter a valid string!");
                }
            }
        }

        public override string ToString()
        {
            return $"{_type},{_username},{_password}";
        }

        /*static public bool validity(string s)
        {
            char[] chars = {',', '.', '/', '\"', '|', '=', '+', '-', '!', '~', '`', '@', '#', '$', '%', '^', '&', '*',
            '(', ')', '_', ':', ';', '<', '>', '{', '}', '[', ']'};
            foreach (char ch in chars)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].ToString() == ch.ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }*/
    }
}
