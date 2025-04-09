using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Exceptions;
using CareerHub.Task2;

namespace CareerHub
{
    public class Applicant
    {
        private int _applicantID;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private string _resume;

        // Properties with validation logic
        public int ApplicantID
        {
            get { return _applicantID; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Applicant ID must be positive.");
                _applicantID = value;
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First name cannot be empty.");
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Last name cannot be empty.");
                _lastName = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                    throw new InVaildEmailException("Error---Invalid email.");
                _email = value;
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Phone number cannot be empty.");
                _phone = value;
            }
        }

        public string Resume
        {
            get { return _resume; }
            set { _resume = value; } 
        }
        public Applicant(string email, string firstName, string lastName)
        {
            if (!email.Contains("@") || !email.Contains("."))
                throw new InVaildEmailException("Invalid email format: " + email);

            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
        public Applicant() { }

        public void CreateProfile(string email, string firstName, string lastName, string phone)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;

            DataBaseManager.con = DataBaseManager.getConnection();
            string query = "INSERT INTO Applicants (FirstName, LastName, Email, Phone, Resume) VALUES (@FirstName, @LastName, @Email, @Phone, @Resume)";
            DataBaseManager.cmd = new SqlCommand(query, DataBaseManager.con);

            DataBaseManager.cmd.Parameters.AddWithValue("@FirstName", FirstName);
            DataBaseManager.cmd.Parameters.AddWithValue("@LastName", LastName);
            DataBaseManager.cmd.Parameters.AddWithValue("@Email", Email);
            DataBaseManager.cmd.Parameters.AddWithValue("@Phone", Phone);
            DataBaseManager.cmd.Parameters.AddWithValue("@Resume", Resume ?? "");

            int rows = DataBaseManager.cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Applicant profile created successfully.");
            else
                Console.WriteLine("Failed to create applicant profile.");

            DataBaseManager.con.Close();
        }

        public void ApplyForJob(int jobID, string coverLetter)
        {
            Console.Write("Enter The Appliacant Id");
            int ApplicantID = Convert.ToInt32(Console.ReadLine());

            DataBaseManager.con = DataBaseManager.getConnection();
            string query = "INSERT INTO JobApplications (JobID, ApplicantID, CoverLetter) VALUES (@JobID, @ApplicantID, @CoverLetter)";
            DataBaseManager.cmd = new SqlCommand(query, DataBaseManager.con);

            DataBaseManager.cmd.Parameters.AddWithValue("@JobID", jobID);
            DataBaseManager.cmd.Parameters.AddWithValue("@ApplicantID", ApplicantID);
            DataBaseManager.cmd.Parameters.AddWithValue("@CoverLetter", coverLetter);

            int rows = DataBaseManager.cmd.ExecuteNonQuery();
            if (rows > 0)
                Console.WriteLine("Applied for the job successfully.");
            else
                Console.WriteLine("Failed to apply for the job.");

            DataBaseManager.con.Close();
        }

        static void Main(string[] args)
        {
            try
            {
                Applicant sonu = new Applicant("sonu", "m", "sudharsn");
            }
            catch (InVaildEmailException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
