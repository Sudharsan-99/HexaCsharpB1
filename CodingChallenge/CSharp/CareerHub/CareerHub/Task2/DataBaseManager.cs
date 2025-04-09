using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CareerHub.Task2
{
    public class DataBaseManager
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static SqlConnection getConnection()
        {
            con = new SqlConnection("data source = DESKTOP-R2484O8\\SQLEXPRESS;initial catalog = CareerHub;integrated security = true;");
            con.Open();
            return con;
        }

        public static void InsertJobListing()
        {
            Console.Write("Enter Company ID: ");
            int companyID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Job Title: ");
            string jobTitle = Console.ReadLine();

            Console.Write("Enter Job Description: ");
            string jobDescription = Console.ReadLine();

            Console.Write("Enter Job Location: ");
            string jobLocation = Console.ReadLine();

            Console.Write("Enter Salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Job Type (e.g., Full-time, Part-time, Contract): ");
            string jobType = Console.ReadLine();

         
            con = getConnection();

            string query = @"INSERT INTO Jobs (CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType) 
                     VALUES (@CompanyID, @JobTitle, @JobDescription, @JobLocation, @Salary, @JobType)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@CompanyID", companyID);
            cmd.Parameters.AddWithValue("@JobTitle", jobTitle);
            cmd.Parameters.AddWithValue("@JobDescription", jobDescription);
            cmd.Parameters.AddWithValue("@JobLocation", jobLocation);
            cmd.Parameters.AddWithValue("@Salary", salary);
            cmd.Parameters.AddWithValue("@JobType", jobType);

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Job posted successfully.");
            else
                Console.WriteLine("Failed to post job.");

            con.Close();
        }

        public static void InsertNewCompany()
        {
            Console.Write("Enter Company Name: ");
            string CompanyName = Console.ReadLine();

            Console.Write("Enter Company Location: ");
            string Location = Console.ReadLine();

            try
            {
                SqlConnection con = getConnection();
                string query = "insert into Companies (CompanyName, Location) values (@CompanyName, @Location)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                cmd.Parameters.AddWithValue("@Location", Location);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Company inserted successfully!");
                else
                    Console.WriteLine("Failed to insert company.");

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void InsertNewApplicant()
        {
            Console.Write("Enter the email = ");
            string email = Console.ReadLine();
            Console.Write("Enter the First Name = ");
            string firstname = Console.ReadLine();
            Console.Write("Enter the Last Name = ");
            string lastname = Console.ReadLine();
            Console.Write("Enter the Phone Number = ");
            string phone = Console.ReadLine();
            Applicant applicant = new Applicant();
            applicant.CreateProfile(email,firstname,lastname,phone);
        }

        public static void InsertApplication()
        {
            Console.Write("Enter Job ID: ");
            int JobID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Applicant ID: ");
            int ApplicantID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Cover Letter: ");
            string CoverLetter = Console.ReadLine();

            try
            {
                SqlConnection con = getConnection();

                string query = "INSERT INTO Applications (JobID, ApplicantID, CoverLetter) " +
                               "VALUES (@JobID, @ApplicantID, @CoverLetter)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@JobID", JobID);
                cmd.Parameters.AddWithValue("@ApplicantID", ApplicantID);
                cmd.Parameters.AddWithValue("@CoverLetter", CoverLetter);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Job application submitted successfully!");
                else
                    Console.WriteLine("Failed to submit application.");

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void GetAllJobs()
        {
            try
            {
                SqlConnection con = getConnection();

                string query = "select * from Jobs";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n=== List of Job Listings ===");

                while (reader.Read())
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"JobID: {reader["JobID"]}");
                    Console.WriteLine($"CompanyID: {reader["CompanyID"]}");
                    Console.WriteLine($"JobTitle: {reader["JobTitle"]}");
                    Console.WriteLine($"Description: {reader["JobDescription"]}");
                    Console.WriteLine($"Location: {reader["JobLocation"]}");
                    Console.WriteLine($"Salary: {reader["Salary"]}");
                    Console.WriteLine($"JobType: {reader["JobType"]}");
                    Console.WriteLine($"PostedDate: {reader["PostedDate"]}");
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving jobs: " + ex.Message);
            }
        }

        public static void GetAllCompanies()
        {
            try
            {
                SqlConnection con = getConnection();

                string query = "select * from Companies";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n=== List of Companies ===");

                while (reader.Read())
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"CompanyID   : {reader["CompanyID"]}");
                    Console.WriteLine($"CompanyName : {reader["CompanyName"]}");
                    Console.WriteLine($"Location    : {reader["Location"]}");
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving companies: " + ex.Message);
            }
        }

        public static void GetAllApplicants()
        {
            try
            {
                SqlConnection con = getConnection();
                string query = "select * FROM Applicants";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n=== List of Applicants ===");

                while (reader.Read())
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"ApplicantID : {reader["ApplicantID"]}");
                    Console.WriteLine($"Name        : {reader["FirstName"]} {reader["LastName"]}");
                    Console.WriteLine($"Email       : {reader["Email"]}");
                    Console.WriteLine($"Phone       : {reader["Phone"]}");
                    Console.WriteLine($"Resume      : {reader["Resume"]}");
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving applicants: " + ex.Message);
            }
        }
        public List<JobApplications> GetApplicationsForJob(int jobID)
        {
            List<JobApplications> applications = new List<JobApplications>();

            try
            {
                SqlConnection con = getConnection();
                string query = "select * from Applications Where JobID = @JobID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@JobID", jobID);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    JobApplications application = new JobApplications
                    {
                        ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                        JobID = Convert.ToInt32(reader["JobID"]),
                        ApplicantID = Convert.ToInt32(reader["ApplicantID"]),
                        ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]),
                        CoverLetter = reader["CoverLetter"].ToString()
                    };
                    applications.Add(application);
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving applications: " + ex.Message);
            }

            return applications;
        }

        public static void SearchJobsBySalaryRange()
        {
            try
            {
                Console.Write("Enter minimum salary: ");
                decimal minSalary = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter maximum salary: ");
                decimal maxSalary = Convert.ToDecimal(Console.ReadLine());

                if (minSalary < 0 || maxSalary < 0 || minSalary > maxSalary)
                {
                    Console.WriteLine("Invalid salary range. Please enter non-negative values and ensure min ≤ max.");
                    return;
                }

                SqlConnection con = getConnection();
                string query = $"select J.JobTitle, C.CompanyName, J.Salary from Jobs J join Companies C on J.CompanyID = C.CompanyID where J.Salary between @MinSalary AND @MaxSalary";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MinSalary", minSalary);
                cmd.Parameters.AddWithValue("@MaxSalary", maxSalary);

                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n=== Job Listings in Salary Range ===");

                bool found = false;
                while (reader.Read())
                {
                    found = true;
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Job Title   : {reader["JobTitle"]}");
                    Console.WriteLine($"Company Name: {reader["CompanyName"]}");
                    Console.WriteLine($"Salary      : {reader["Salary"]}");
                }

                if (!found)
                {
                    Console.WriteLine("No job listings found in the given salary range.");
                }

                reader.Close();
                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter numeric values for salary.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
        }

    }
}
