using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExamples
{
    public static class VariableHelper
    {
        public static void Swap<T>(ref T var1, ref T var2)
            // where T : struct
            // where T: class
        {
            T aux = var1;
            var1 = var2;
            var2 = aux;
        }
    }
}
