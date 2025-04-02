using System.Transactions;

namespace Assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee(201, "Sonu", "2003-12-05", 50000);
            Manager manager1 = new Manager(202, "Moni", "2002-12-11", 70000, 10000, 15000);
            Employee emp2 = new Manager(203, "Sudharsan", "2001-12-05", 80000, 10000, 15000);

            emp1.DisplayInfo();
            manager1.DisplayInfo();
            emp2.DisplayInfo();
        }
    }

    class Employee
    {
        public int EmpId;
        public string Name;
        public string Dob;
        public double Salary;

        public Employee(int empId, string name, string dob, double salary)
        {
            this.EmpId = empId;
            this.Name = name;
            this.Dob = dob;
            this.Salary = salary;
        }

        public virtual double ComputeSalary()
        {
            return this.Salary;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {EmpId}, Name: {Name}, DOB: {Dob}, Salary: {ComputeSalary()}");
        }
    }

    class Manager : Employee
    {
        public double OnsiteAllowance;
        public double Bonus;

        public Manager(int empId, string name, string dob, double salary, double onsiteAllowance, double bonus)
            : base(empId, name, dob, salary)
        {
            this.OnsiteAllowance = onsiteAllowance;
            this.Bonus = bonus;
        }

        public override double ComputeSalary()
        {
            return Salary + OnsiteAllowance + Bonus;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"ID: {EmpId}, Name: {Name}, DOB: {Dob}, Total Salary: {ComputeSalary()} (Base: {Salary}, Allowance: {OnsiteAllowance}, Bonus: {Bonus})");
        }

       public double Extraincome()
        {
            return OnsiteAllowance + Bonus;
        }
    }
}
