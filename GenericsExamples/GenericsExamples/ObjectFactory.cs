using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExamples
{
    public static class ObjectFactory
    {
        public static T Create<T>()
            where T: new()
        {
            return new T();
        }
    }
}
