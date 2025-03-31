using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne
{
    class Two
    {
        static void Main(string[] args)
        {
            //2. Write a C# program that takes a number as input and displays it four times in a row (separated by blank spaces), and
            //then four times in the next row, with no separation. You should do it twice:
            //Use the console. Write and use {0}.
            Console.WriteLine("Enter a Number ");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("{0} ", num);
                }
                Console.WriteLine();

                for (int j = 0; j < 4; j++)
                {
                    Console.Write(num);
                }
                Console.WriteLine();
            }

        }
    }
}
