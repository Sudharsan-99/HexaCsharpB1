using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class TimePeriod
    {
        private double seconds;

        public TimePeriod(double hours)
        {
            this.Hours = hours; 
        }

        public double Hours
        {
            set { seconds = value * 3600; } 
            get { return seconds / 3600; }             
        }

        public override string ToString()
        {
            return $"Time Period: {Hours} hours ({seconds} seconds)";
        }

        static void Main(string[] args)
        {
            TimePeriod time = new TimePeriod(2.5);
            Console.WriteLine(time);

            time.Hours = 1.5;
            Console.WriteLine(time);
        }
    }
}
