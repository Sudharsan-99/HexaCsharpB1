using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne.Assignment_2
{
    class Five
    {
        static void Main(string[] args)
        {
            //2.	Write a program in C# to accept ten marks and display the following
            int [] marks = new int[10];
            for(int i= 0; i < 10; i++)
            {
                Console.Write($"Mark {i + 1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }

            double average = marks.Average();
            int minMark = marks.Min();
            int maxMark = marks.Max();
            int totalMarks = marks.Sum();
            Console.WriteLine("Total Marks: " + totalMarks);
            Console.WriteLine("Average Marks: " + average);
            Console.WriteLine("Minimum Marks: " + minMark);
            Console.WriteLine("Maximum Marks: " + maxMark);
            Array.Sort(marks);
            Console.WriteLine("Displaying marks in ascending order");
            for(int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine(marks[i] + " ");
            }
            Console.WriteLine("Displaying marks in descending order");
            for (int i = marks.Length - 1 ; i >= 0 ; i--)
            {
                Console.WriteLine(marks[i] + " ");
            }
        }
    }
}
