using System;
using System.Data.SqlClient;

namespace CareerHub.Exceptions
{
    class GetJobsWithConnectionHandling
    {
        public static void FetchJobListings()
        {
            SqlConnection con = null;

            try
            {
                string connectionString = "data source=DESKTOP-R2484O8\\SQLEXPRESS;initial catalog=CareerHub;integrated security=true;";
                con = new SqlConnection(connectionString);
                con.Open();
                Console.WriteLine("Connection established successfully.\n");

                string query = "SELECT * FROM Jobs";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("=== Job Listings ===");

                while (reader.Read())
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"JobID      : {reader["JobID"]}");
                    Console.WriteLine($"Title      : {reader["JobTitle"]}");
                    Console.WriteLine($"Location   : {reader["JobLocation"]}");
                    Console.WriteLine($"Salary     : {reader["Salary"]}");
                    Console.WriteLine($"JobType    : {reader["JobType"]}");
                    Console.WriteLine($"PostedDate : {reader["PostedDate"]}");
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== CareerHub - Job Board ===\n");
            FetchJobListings();
        }
    }
}
