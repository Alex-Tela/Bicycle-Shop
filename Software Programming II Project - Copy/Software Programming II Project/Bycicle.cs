using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Programming_II_Project
{
    class Bycicle: AbstractClass, IProductProperties
    {
        string _name;
        string _manufacturer;
        double _price;
        double _weight;
        string _material;
        char _size;
        bool _suspensionF;
        bool _suspensionB;
        int _speeds;
        string _typeOfBrakes;
        bool _customizeable;
        static int _counter = 0;
        readonly string _id;

        public Bycicle()
        {
            _name = "N/A";
            _manufacturer = "N/A";
            _price = 0.0;
            _weight = 0.0;
            _material = "";
            _size = 'S';
            _suspensionF = false;
            _suspensionB = false;
            _speeds = 1;
            _typeOfBrakes = "Wheel";
            _customizeable = false;
            _counter++;
            this._id = _counter + "B";
        }

        public Bycicle(string name, string manufacturer, double price, double weight, string material, char size, 
            bool suspensionF, bool suspensionB, int speeds, string typeOfBrakes, bool customizable)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            Weight = weight;
            Material = material;
            Size = size;
            SuspensionF = suspensionF;
            SuspensionB = suspensionB;
            Speeds = speeds;
            TypeOfBrakes = typeOfBrakes;
            Customizable = customizable;
            _counter++;
            _id = _counter + "B";           
        }

        public string Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
            set { if (firstLetterUpperCase(value))
                {
                    _name = value;
                } else
                {
                    _name = "";
                }
            }      
        }

        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                if (firstLetterUpperCase(value))
                {
                    _manufacturer = value;
                } else
                {
                    _manufacturer = "";
                }
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (validDouble(value.ToString()))
                {
                    _price = value;
                } else
                {
                    _price = 0;
                }
            }
        }

        public double Weight
        {
            get { return _weight; }
            set
            {
                if (validDouble(value.ToString()))
                {
                    _weight = value;
                }
            }
        }

        public string Material
        {
            get { return _material; }
            set
            {
                if (firstLetterUpperCase(value))
                {
                    _material = value;
                }
            }
        }

        public char Size
        {
            get { return _size; }
            set
            {
                if (value == 'S' || value == 'M' || value == 'L')
                {
                    _size = value;
                } else
                {
                    _size = 'S';
                }
            }
        }

        public bool SuspensionB
        {
            get { return _suspensionB; }
            set { _suspensionB = value; }
        }

        public bool SuspensionF
        {
            get { return _suspensionF; }
            set { _suspensionF = value; }
        }

        public int Speeds
        {
            get { return _speeds; }
            set
            {
                if (value >= 0 || value <= 12)
                {
                    _speeds = value;
                }
                else
                {
                    _speeds = 3;
                }
            }
        }

        public string TypeOfBrakes
        {
            get { return _typeOfBrakes; }
            set { if (firstLetterUpperCase(value))
                {
                    _typeOfBrakes = value; 
                } }
        }

        public bool Customizable
        {
            get { return _customizeable; }
            set { _customizeable = value; }
        }

        public string toString()
        {
            return $"{Name},{Manufacturer},{Price},{Weight},{Material},{Size},{SuspensionF},{SuspensionB},{Speeds},{TypeOfBrakes},{Customizable}";
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
            return $"ID: {Id}; {Name} bike, {Manufacturer} .............. PRICE: {Price} RON";
        }

        static public int comparePrice(Bycicle b1, Bycicle b2)
        {
            return b1.Price.CompareTo(b2.Price);
        }

        static public int compareTypeAndSize(Bycicle b1, Bycicle b2)
        {
            int result = b1.Name.CompareTo(b2.Name);
            if (result == 0)
            {
                return b1.Size.CompareTo(b2.Size);
            }
            return result;
        }
    }
}
