using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootFinder.BusinessLayer.Validators
{
    public static class ValidationHelper
    {
        public static bool ValidateDoubleNumberInput(string value, out string error)
        {
            error = string.Empty;

            double n = 0;

            if (double.TryParse(value, out n))
            { 
                return true;
            }

            error = "Incorrect input!";

            return false;
        }
    }
}
