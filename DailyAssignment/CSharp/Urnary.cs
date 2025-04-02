using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures_and_class
{
    class Urnary
    {
        public int value;
        public Urnary(int val)
        {
            this.value = val;
        }

        public static Urnary operator ++(Urnary num)
        {
            num.value += 1;
            return num;
        }
        public void Display()
        {
            Console.WriteLine("Value: " + value);
        }

        static void Main(string[] args)
        {

            Urnary num1 = new Urnary(10);

            Console.WriteLine("Original Urnary:");
            num1.Display();

            ++num1;

            Console.WriteLine("After increment:");
            num1.Display();
        }
    }

   
}
