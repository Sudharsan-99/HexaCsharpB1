using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne
{
    class One
    {
        static void Main(string[] args)
        {
            //1. Write a C# Sharp program to swap two numbers.
            int a = 10;
            int b = 20;
            Console.WriteLine("Before Swaping a = {0} and b = {1} ", a, b);
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine("after Swaping a = {0} and b = {1} ", a, b);
        }
    }
}
