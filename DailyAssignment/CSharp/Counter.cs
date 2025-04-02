using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Counter
    {
        static void Main(string[] args)
        {
            Count.CountFunc();
            Count.CountFunc();
            Count.CountFunc();
            Count.CountFunc();
        }

    }

    class Count
    {
        public static int count = 0;

        public static void CountFunc()
        {
            count++;
            Console.WriteLine($"CountFunc called {count} time(s).");
        }
    }
}
