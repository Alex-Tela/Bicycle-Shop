using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Programming_II_Project
{
    public interface IProductProperties
    {
        double getPrice();

        bool isReturnable(double amount);

        int Warranty();

        string getMainDetails();
    }
}
