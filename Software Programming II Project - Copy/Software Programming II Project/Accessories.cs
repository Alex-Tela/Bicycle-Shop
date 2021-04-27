using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Programming_II_Project
{
    class Accessories : AbstractClass, IProductProperties
    {
        string _name;
        double _price;
        static int _counter;
        readonly string _id;

        public Accessories()
        {
            _counter++;
            _id = _counter + "A";
        }

        public Accessories(string name, double price)
        {
            Name = name;
            Price = price;
            _counter++;
            _id = _counter + "A";
        }

        public string Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (firstLetterUpperCase(value))
                {
                    _name = value;
                }
                else
                {
                    _name = "";
                }
            }
        }

        double Price
        {
            get { return this._price; }
            set
            {
                if (validDouble(value.ToString()))
                {
                    _price = value;
                }
                else
                {
                    _price = 0;
                }
            }
        }

        public bool isReturnable(double amount)
        {
            if (amount <= 50)
            {
                return true;
            }
            return false;
        }

        public int Warranty()
        {
            int months = 6;
            if (Price >= 100)
            {
                months = 12;
            }
            else if (Price >= 200)
            {
                months = 18;
            }
            else if (Price >= 300)
            {
                months = 24;
            }

            return months;
        }

        public double getPrice()
        {
            return Price;
        }

        public string getMainDetails()
        {
            return $"ID: {Id}; {Name} .............. PRICE: {Price} RON";
        }
    }
}
