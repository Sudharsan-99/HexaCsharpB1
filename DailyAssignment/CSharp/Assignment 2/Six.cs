using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Assignment_2
{
    class Six
    {
        static void Main(string[] args)
        {
            int[] source = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] target = new int[source.Length];
            for (int i = 0; i < source.Length; i++) { 
                    target[i] = source[i];
            }
            Console.WriteLine("Copied Elements ");
            for (int i = 0; i < target.Length; i++) { 
                 Console.WriteLine(target[i]);
            }

        }
    }
}
