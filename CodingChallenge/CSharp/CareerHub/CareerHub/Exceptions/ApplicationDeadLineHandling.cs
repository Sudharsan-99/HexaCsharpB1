using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Task2;

namespace CareerHub.Exceptions
{
    public class ApplicationDeadLineHandling
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Job ID: ");
            int jobID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Applicant ID: ");
            int applicantID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Cover Letter: ");
            string coverLetter = Console.ReadLine();

            try
            {
                SqlConnection con = DataBaseManager.getConnection();

               
                string deadlineQuery = "SELECT ApplicationDeadline FROM Jobs WHERE JobID = @JobID";
                SqlCommand deadlineCmd = new SqlCommand(deadlineQuery, con);
                deadlineCmd.Parameters.AddWithValue("@JobID", jobID);

                object result = deadlineCmd.ExecuteScalar();

                if (result == null)
                {
                    throw new Exception("No deadline found for this Job ID.");
                }

                DateTime deadline = Convert.ToDateTime(result);

                
                if (DateTime.Now > deadline)
                {
                    throw new Exception("Application deadline has passed. You can no longer apply.");
                }

              
                string insertQuery = "INSERT INTO Applications (JobID, ApplicantID, CoverLetter) VALUES (@JobID, @ApplicantID, @CoverLetter)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                insertCmd.Parameters.AddWithValue("@JobID", jobID);
                insertCmd.Parameters.AddWithValue("@ApplicantID", applicantID);
                insertCmd.Parameters.AddWithValue("@CoverLetter", coverLetter);

                int rows = insertCmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Application submitted successfully.");
                else
                    Console.WriteLine("Failed to submit application.");

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
