using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Task2;

namespace CareerHub
{
    public class JobListingClass
    {
        private int _jobID;
        private int _companyID;
        private string _jobTitle;
        private string _jobDescription;
        private string _jobLocation;
        private decimal _salary;
        private string _jobType;
        private DateTime _postedDate;

        public int JobID { get { return _jobID; } set { _jobID = value; } }
        public int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }
        public string JobTitle
        {
            get { return _jobTitle; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Job title cannot be empty.");
                _jobTitle = value;
            }
        }

        public string JobDescription
        {
            get { return _jobDescription; }
            set { _jobDescription = value; }
        }

        public string JobLocation
        {
            get { return _jobLocation; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Job location cannot be empty.");
                _jobLocation = value;
            }
        }

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary must be a positive number.");
                _salary = value;
            }
        }

        public string JobType
        {
            get { return _jobType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Job type cannot be empty.");
                _jobType = value;
            }
        }

        public DateTime PostedDate
        {
            get { return _postedDate; }
            set { _postedDate = value; }
        }



        public void Apply(int applicantID, string coverLetter)
        {
            DataBaseManager.con = DataBaseManager.getConnection();

            Console.Write("Enter The JobID You wish to Apply = ");
            int JobID = Convert.ToInt32(Console.ReadLine());

            string query = "insert into JobApplications(JobID, ApplicantID, CoverLetter) VALUES (@JobID, @ApplicantID, @CoverLetter)";
            DataBaseManager.cmd = new SqlCommand(query, DataBaseManager.con);

            DataBaseManager.cmd.Parameters.AddWithValue("@JobID", JobID);
            DataBaseManager.cmd.Parameters.AddWithValue("@ApplicantID", applicantID);
            DataBaseManager.cmd.Parameters.AddWithValue("@CoverLetter", coverLetter);

            int rows = DataBaseManager.cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                Console.WriteLine("Application submitted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to apply for the job.");
            }

            DataBaseManager.con.Close();
        }


        public List<Applicant> GetApplicants()
        {
            List<Applicant> applicants = new List<Applicant>();
            DataBaseManager.con = DataBaseManager.getConnection();

            string query = $"select a.ApplicantID, a.FirstName, a.LastName, a.Email, a.Phone, a.Resume from Applicants a join JobApplications ap on a.ApplicantID = ap.ApplicantID where ap.JobID = @JobID";


            DataBaseManager.cmd = new SqlCommand(query, DataBaseManager.con);
            DataBaseManager.cmd.Parameters.AddWithValue("@JobID", JobID);

            DataBaseManager.dr = DataBaseManager.cmd.ExecuteReader();

            while (DataBaseManager.dr.Read())
            {
                Applicant applicant = new Applicant()
                {
                    ApplicantID = Convert.ToInt32(DataBaseManager.dr["ApplicantID"]),
                    FirstName = DataBaseManager.dr["FirstName"].ToString(),
                    LastName = DataBaseManager.dr["LastName"].ToString(),
                    Email = DataBaseManager.dr["Email"].ToString(),
                    Phone = DataBaseManager.dr["Phone"].ToString(),
                    Resume = DataBaseManager.dr["Resume"].ToString()
                };

                applicants.Add(applicant);
            }

            DataBaseManager.dr.Close();
            DataBaseManager.con.Close();

            return applicants;
        }



    }
}
