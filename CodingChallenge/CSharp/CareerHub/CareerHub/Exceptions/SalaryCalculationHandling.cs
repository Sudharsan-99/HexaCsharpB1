using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Task2;

namespace CareerHub.Exceptions
{
    class SalaryCalculationHandling
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnection con = DataBaseManager.getConnection();
                string query = "SELECT JobID, JobTitle, Salary FROM Jobs";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                decimal totalSalary = 0;
                int validCount = 0;

                Console.WriteLine("\n=== Salary Report ===");

                while (reader.Read())
                {
                    try
                    {
                        int jobID = Convert.ToInt32(reader["JobID"]);
                        string jobTitle = reader["JobTitle"].ToString();
                        decimal salary = Convert.ToDecimal(reader["Salary"]);

                        if (salary < 0)
                            throw new Exception($"Negative salary detected for JobID {jobID} - '{jobTitle}'");

                        totalSalary += salary;
                        validCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

                reader.Close();
                con.Close();

                if (validCount > 0)
                {
                    decimal averageSalary = totalSalary / validCount;
                    Console.WriteLine($"\nAverage Salary: {averageSalary:F2}");
                }
                else
                {
                    Console.WriteLine("Error--No valid salaries found to compute average.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error while calculating average salary: " + ex.Message);
            }
        }
    }
}
