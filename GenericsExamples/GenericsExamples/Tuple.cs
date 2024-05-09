using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExamples
{
    public class Tuple<T1, T2>
    {
        public Tuple()
        {
            Item1 = default;
            Item2 = default(T2);
        }

        public T1 Item1 {  get; set; }

        public T2 Item2 { get; set;}
    }

    public class Tuple<T1, T2, T3> : Tuple<T1, T2>
    {
        public T3 Item3 { get; set; }
    }

    public class Tuple<T1, T2, T3, T4> : Tuple<T1, T2, T3>
    {
        public T4 Item4 { get; set; }
    }
}
