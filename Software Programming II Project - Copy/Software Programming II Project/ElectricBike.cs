using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Programming_II_Project
{
    class ElectricBike: Bycicle
    {
        int _autonomy;

        public ElectricBike()
        {

        }

        public ElectricBike(string name, string manufacturer, double price, double weight, string material, char size, 
            bool suspensionF, bool suspensionB, int speeds, string typeOfBrakes, bool customizable, int autonomy):base(name, manufacturer, price, 
                weight, material, size, suspensionF, suspensionB, speeds, typeOfBrakes, customizable)
        {
            Autonomy = autonomy;
        }

        public int Autonomy
        {
            get { return _autonomy; }
            set { if (value > 0 && value <= 150) {
                    _autonomy = value;
                } }
        }

        public string toString()
        {
            return base.toString() + $",{Autonomy}";
        }


    }
}
