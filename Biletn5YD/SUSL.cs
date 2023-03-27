using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletn5YD
{
    public  class SUSL
    {
        public static double USL(double a, double b, double c)
        {
            double price = 0;
            if (c==0)
            {
                price = ((a * b) / 10000) * 1000;// Окна
            }
            if (c == 1)
            {
                price = ((a * b) / 10000) * 2000;// Балконы
            }
            if (c == 2)
            {
                price = ((a * b) / 10000) * 3000;// Двери
            }
            return price;
        }
    }
}
