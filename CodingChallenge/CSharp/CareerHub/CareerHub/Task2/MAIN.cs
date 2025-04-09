using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Task2
{
    public class MAIN
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== CareerHub Menu ===");
                Console.WriteLine("1. Insert New Company");
                Console.WriteLine("2. Insert New Job Listing");
                Console.WriteLine("3. Insert New Applicant");
                Console.WriteLine("4. Apply for a Job");
                Console.WriteLine("5. View All Jobs");
                Console.WriteLine("6. View All Companies");
                Console.WriteLine("7. View All Applicants");
                Console.WriteLine("8. Get Applications for a Job");
                Console.WriteLine("9.To search for Job with Salary Range ");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DataBaseManager.InsertNewCompany();
                        break;
                    case "2":
                        DataBaseManager.InsertJobListing();
                        break;
                    case "3":
                        DataBaseManager.InsertNewApplicant();
                        break;
                    case "4":
                        DataBaseManager.InsertApplication();
                        break;
                    case "5":
                        DataBaseManager.GetAllJobs();
                        break;
                    case "6":
                        DataBaseManager.GetAllCompanies();
                        break;
                    case "7":
                        DataBaseManager.GetAllApplicants();
                        break;
                    case "8":
                        Console.Write("Enter Job ID to view applications: ");
                        int jobID = Convert.ToInt32(Console.ReadLine());
                        var apps = new DataBaseManager().GetApplicationsForJob(jobID);
                        Console.WriteLine("\n=== Applications for Job ID: " + jobID + " ===");
                        foreach (var app in apps)
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine($"ApplicationID: {app.ApplicationID}");
                            Console.WriteLine($"ApplicantID: {app.ApplicantID}");
                            Console.WriteLine($"ApplicationDate: {app.ApplicationDate}");
                            Console.WriteLine($"CoverLetter: {app.CoverLetter}");
                        }
                        break;
                    case "9":
                        DataBaseManager.SearchJobsBySalaryRange();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Exiting the application.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}

