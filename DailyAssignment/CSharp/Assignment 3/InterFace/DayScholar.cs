using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFace
{
    class DayScholar : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public double Fees { get; set; }


        public DayScholar(int studentId, string name, double tuitionFees)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Fees = tuitionFees;
        }

        public void ShowDetails()
        {
            Console.WriteLine("\n--- Day Scholar Details ---");
            Console.WriteLine($"Student ID: {StudentId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Fees: ${Fees}");
        }
    }
}
