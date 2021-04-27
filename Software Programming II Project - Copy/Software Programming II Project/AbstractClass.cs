using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Programming_II_Project
{
    abstract class AbstractClass
    {
        static public bool validity(string s)
        {
            char[] chars = {' ', ',', '.', '/', '\"', '|', '=', '+', '-', '!', '~', '`', '@', '#', '$', '%', '^', '&', '*',
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
        }

        static public bool validDouble(string num)
        {
            double res;
            return (double.TryParse(num, out res));

            /*char[] legalChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string convert = num.ToString();
            int countPoint = 0;
            foreach (char number in convert)
            {
                if (number == '.')
                    countPoint -= 1;
            }
            if (countPoint > 1)
            {
                return false;
            } else
            {
                int n = convert.Length - 1;
                foreach (char number in convert)
                {
                    foreach (char ch in legalChars)
                    {
                        if (number == ch)
                            n -= 1;
                    }
                }
                return (n == 0) ? true : false;
            }*/
        }

        static public bool validInt(string num)
        {
            int res;
            return (int.TryParse(num, out res));
        }

        static public bool firstLetterUpperCase(string text)
        {
            char[] upletters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] lowletters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            foreach (char ch in upletters)
            {
                if (text[0] == ch)
                {
                    text.Remove(0, 1);
                    break;
                }
            }

            int n = text.Length;
            foreach (char txt in text)
            {
                foreach (char ch in lowletters)
                {
                    if (txt == ch || txt == ' ')
                    {
                        n -= 1;
                    }
                }
                foreach (char ch in upletters)
                {
                    if (txt == ch)
                    {
                        n -= 1;
                    }
                }
            }
            return (n == 0) ? true : false;
        }
    }
}
