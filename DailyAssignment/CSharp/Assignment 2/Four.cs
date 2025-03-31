using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Assignment_2
{
    class Four
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4 };
            int n = array.Length;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += array[i];
            }
            Console.WriteLine("The Average of The Array is {0}", sum / n);

            Console.WriteLine("The largest Number is {0} , and The Smallest Number is {1}", array.Max(), array.Min());
        }
    }
}
