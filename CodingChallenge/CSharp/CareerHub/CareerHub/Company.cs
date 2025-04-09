using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Task2;

namespace CareerHub
{
    public class Company
    {
        private int _companyID;
        private string _companyName;
        private string _location;

        public int CompanyID
        {
            get { return _companyID; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Company ID must be a positive integer.");
                _companyID = value;
            }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Company name cannot be empty.");
                _companyName = value;
            }
        }

        public string Location
        {
            get { return _location; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Location cannot be empty.");
                _location = value;
            }
        }

        //Methods
       
        public void PostJob(string jobTitle, string jobDescription, string jobLocation, decimal salary, string jobType)
        {
            DataBaseManager.con = DataBaseManager.getConnection();

            string query = @"INSERT INTO Jobs (CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType)
                             VALUES (@CompanyID, @JobTitle, @JobDescription, @JobLocation, @Salary, @JobType)";

            DataBaseManager.cmd = new SqlCommand(query, DataBaseManager.con);
            DataBaseManager.cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
            DataBaseManager.cmd.Parameters.AddWithValue("@JobTitle", jobTitle);
            DataBaseManager.cmd.Parameters.AddWithValue("@JobDescription", jobDescription);
            DataBaseManager.cmd.Parameters.AddWithValue("@JobLocation", jobLocation);
            DataBaseManager.cmd.Parameters.AddWithValue("@Salary", salary);
            DataBaseManager.cmd.Parameters.AddWithValue("@JobType", jobType);

            int rows = DataBaseManager.cmd.ExecuteNonQuery();
            if (rows > 0)
                Console.WriteLine("Job posted successfully!");
            else
                Console.WriteLine("Failed to post the job.");

            DataBaseManager.con.Close();
        }

        public List<JobListingClass> GetJobs()
        {
            List<JobListingClass> jobs = new List<JobListingClass>();
            DataBaseManager.con = DataBaseManager.getConnection();

            string query = "SELECT * FROM Jobs WHERE CompanyID = @CompanyID";
            DataBaseManager.cmd = new SqlCommand(query, DataBaseManager.con);
            DataBaseManager.cmd.Parameters.AddWithValue("@CompanyID", CompanyID);

            DataBaseManager.dr = DataBaseManager.cmd.ExecuteReader();

            while (DataBaseManager.dr.Read())
            {
                JobListingClass job = new JobListingClass()
                {
                    JobID = Convert.ToInt32(DataBaseManager.dr["JobID"]),
                    CompanyID = Convert.ToInt32(DataBaseManager.dr["CompanyID"]),
                    JobTitle = DataBaseManager.dr["JobTitle"].ToString(),
                    JobDescription = DataBaseManager.dr["JobDescription"].ToString(),
                    JobLocation = DataBaseManager.dr["JobLocation"].ToString(),
                    Salary = Convert.ToDecimal(DataBaseManager.dr["Salary"]),
                    JobType = DataBaseManager.dr["JobType"].ToString(),
                    PostedDate = Convert.ToDateTime(DataBaseManager.dr["PostedDate"])
                };

                jobs.Add(job);
            }

            DataBaseManager.dr.Close();
            DataBaseManager.con.Close();

            return jobs;
        }
    }
}
