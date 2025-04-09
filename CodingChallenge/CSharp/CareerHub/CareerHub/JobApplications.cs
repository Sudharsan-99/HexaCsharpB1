using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub
{
    public class JobApplications
    {
        private int _applicationID;
        private int _jobID;
        private int _applicantID;
        private DateTime _applicationDate;
        private string _coverLetter;

        // Properties
        public int ApplicationID
        {
            get { return _applicationID; }
            set { _applicationID = value; }
        }

        public int JobID
        {
            get { return _jobID; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Job ID must be a positive integer.");
                _jobID = value;
            }
        }

        public int ApplicantID
        {
            get { return _applicantID; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Applicant ID must be a positive integer.");
                _applicantID = value;
            }
        }

        public DateTime ApplicationDate
        {
            get { return _applicationDate; }
            set { _applicationDate = value; }
        }

        public string CoverLetter
        {
            get { return _coverLetter; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Cover letter cannot be empty.");
                _coverLetter = value;
            }
        }

        // Constructor
        public JobApplications() { }
        public JobApplications(int jobID, int applicantID, string coverLetter)
        {
            JobID = jobID;
            ApplicantID = applicantID;
            CoverLetter = coverLetter;
            ApplicationDate = DateTime.Now;
        }
        public JobApplications(int applicationID, int jobID, int applicantID, DateTime applicationDate, string coverLetter)
        {
            ApplicationID = applicationID;
            JobID = jobID;
            ApplicantID = applicantID;
            ApplicationDate = applicationDate;
            CoverLetter = coverLetter;
        }

        public void Display()
        {
            Console.WriteLine($"ApplicationID: {ApplicationID}, JobID: {JobID}, ApplicantID: {ApplicantID}");
            Console.WriteLine($"Applied On: {ApplicationDate}");
            Console.WriteLine("Cover Letter:");
            Console.WriteLine(CoverLetter);
        }

        public override string ToString()
        {
            return $"ApplicationID: {ApplicationID}, JobID: {JobID}, ApplicantID: {ApplicantID}, " +
                   $"ApplicationDate: {ApplicationDate}, CoverLetter: {CoverLetter}";
        }


    }
}
