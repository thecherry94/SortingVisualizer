using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithm.Exceptions
{
    public class InvalidGenericTypeException : Exception
    {
        public InvalidGenericTypeException(Type given, Type[] expected)
            : base("An invalid type has been set for the generic argument.\n" +
                   "Given:\t\t" + given.ToString() +
                   "Expected:\t\t" + format_expected(expected))
        {
            
        }

        private static string format_expected(Type[] exp)
        {
            string retval = "";

            for (int i = 0; i < exp.Length; i++)
            {
                retval += exp[i];

                if (i != exp.Length - 1)
                    retval += ", ";
            }

            return retval;  
        }
    }
}
