using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootFinder.EventArg
{
    public class FunctionEventArgs : EventArgs
    {
        public Func<double, double> Function { get; }

        public double Xmin { get;}

        public double Xmax { get; }

        public double Dx { get; }

        public string Name { get; }

        public FunctionEventArgs(Func<double, double> function, 
            double xmin, double xmax, double dx, string name)
        {
            Function = function;
            Xmin = xmin;
            Xmax = xmax;
            Dx = dx;
            Name = name;
        }
    }
}
