using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootFinder.BusinessLayer.Mathematics
{
    public static class MathHelper
    {
        public static List<double> GetRoots(
            Func<double,double> function,
            double Xmin,
            double Xmax,
            double dx,
            double eps)
        {
            List<double> result = new List<double>();

            double Ymax = function(Xmax);

            double temp = Xmin;

            double currentY = 0;

            while (temp <= Xmax)
            {
                currentY = function(temp);

                if (Math.Abs(currentY / Ymax) <= eps)
                { 
                    result.Add(temp);
                }

                temp += dx;
            }

            return result;
        }
    }
}
