using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFace
{
    class Resident : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public double Fees { get; set; }
        public double AccommodationFees { get; set; }

        public Resident(int studentId, string name, double tuitionFees, double accommodationFees)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Fees = tuitionFees + accommodationFees;
            this.AccommodationFees = accommodationFees;
        }

        public void ShowDetails()
        {
            Console.WriteLine("Resident Details");
            Console.WriteLine($"Resident - ID: {StudentId}, Name: {Name}, Tuition Fees: ${Fees - AccommodationFees}, Accommodation Fees: ${AccommodationFees}, Total Fees: ${Fees}");
        }
    }
}
