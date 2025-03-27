using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne
{
    class AssignmentOne
    {
        public static void Main(string[] args)
        {
            //string a = Console.ReadLine();
            //string b = Console.ReadLine();
            //int num1 = Int32.Parse(a);
            //int num2 = Int32.Parse(b);
            //Console.WriteLine(num1 + num2);        

            // 1.Write a C# Sharp program to accept two integers and check whether they are equal or not. 
            Console.WriteLine("1.Write a C# Sharp program to accept two integers and check whether they are equal or not. ");
            Console.WriteLine("Enter the first Number = ");
            int   a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second Number = ");
            int  b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Output");
            if (a == b)
            {
                Console.WriteLine($"{a} and {b} are equal ");

            }
            else
            {
                Console.WriteLine($"{a} and {b} are not equal ");
            }

            //2. Write a C# Sharp program to check whether a given number is positive or negative.
            Console.WriteLine("2. Write a C# Sharp program to check whether a given number is positive or negative.");
            Console.WriteLine("Enter a Number = ");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Output");
            if (c >= 0)
            {
                Console.WriteLine("{0} is a positive number ", c);
            }
            else
            {
                Console.WriteLine("{0} is not a positive number ", c);
            }


            //3.Write a C# Sharp program that takes two numbers as input and  performs all operations (+,-,*,/) on them and displays the result of that operation. 
            Console.WriteLine("3.Write a C# Sharp program that takes two numbers as input and  performs all operations (+,-,*,/) on them and displays the result of that operation. ");
            Console.WriteLine("Arithmethic Operations");
            Console.WriteLine("Output");
            int sum = a + b;
            int sub = a - b;
            int mul = a * b;
            float div = a / b;
            Console.WriteLine($"the Sum of {a} and {b} is {sum}");
            Console.WriteLine($"the Sub of {a} and {b} is {sub}");
            Console.WriteLine($"the mul of {a} and {b} is {mul}");
            Console.WriteLine($"the div of {a} and {b} is {div}");

            //4.Write a C# Sharp program that prints the multiplication table of a number as input.
            Console.WriteLine("4.Write a C# Sharp program that prints the multiplication table of a number as input.");
            Console.WriteLine($"Multiplication table of {c} ");
            Console.WriteLine("Output");
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(c + " * " + i + " = " + c * i);
            }

            //5.Write a C# program to compute the sum of two given integers. If two values are the same, return the triple of their sum.
            Console.WriteLine("5.Write a C# program to compute the sum of two given integers. If two values are the same, return the triple of their sum.");
            int sum1 = a + b;
            Console.WriteLine("Output");
            if (a == b)
            {
                Console.WriteLine($"{a} and {b} are equal so the Sum is {sum1 * 3}");
            }
            else
            {
                Console.WriteLine($"{a} and {b} are not equal so the Sum is {sum1}");
            }
        }

    }
}
