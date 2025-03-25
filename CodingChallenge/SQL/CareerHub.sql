create database CareerHub;
use CareerHub;

--Companies Table
create table Companies(
CompanyID int identity(1,1) primary key,
CompanyName varchar(30) not null,
[Location] varchar(30) not null
);

--Jobs Table
create table Jobs(
JobID int identity(1,1) primary key,
CompanyID int ,
foreign key (CompanyID) references Companies(companyID),
JobTitle varchar(20) not null,
JobDescription text,
JobLocation varchar(20),
Salary decimal(10,2),
JobType varchar(20),
PostedDate datetime default getdate()
);

--Applicants Table
create table Applicants (
ApplicantID int identity(1,1) primary key,
FirstName varchar(30) not null,
LastName varchar(20) not null,
Email varchar(40) unique not null,
Phone varchar(20) unique not null,
[Resume] text
);

--Applications Table
create table Applications(
ApplicationID int identity(1,1) primary key,
JobID int not null,
foreign key (JobID) references Jobs(JobID),
ApplicantID int,
foreign key (ApplicantID) references Applicants(ApplicantID),
ApplicationDate datetime default getdate(),
CoverLetter text
);

--inserting into Companies
insert into Companies(CompanyName, [Location])values 
('Google', 'Bangalore'),
('Amazon', 'Hyderabad'),
('Hexaware', 'Mumbai'),
('TCS', 'Mumbai'),
('HCL Technologies', 'Noida'),
('Adobe', 'New york'),
('Flipkart', 'Bangalore'),
('Microsoft', 'new york'),
('Apple', 'new york'),
('IBM', 'new york'),
('Facebook', 'calfronia'),
('Infosys', 'Bangalore');

--inserting into Jobs
insert into Jobs (JobID, CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) values 
(1, 1, 'Software Engineer', 'Develop and maintain web applications.', 'Bangalore', 120000.00, 'Full-time','2024-03-10 09:00:00'),
(2, 2, 'Data Analyst', 'Analyze business data', 'Hyderabad', 90000.00, 'Full-time','2024-02-25 14:30:00'),
(3, 3, 'System Administrator', 'Manage IT infrastructure and security.', 'Mumbai', 80000.00, 'Full-time','2024-03-05 11:15:00'),
(4, 4, 'Project Manager', 'Lead software development teams.', 'Mumbai', 100000.00, 'Full-time', GETDATE()),
(5, 5, 'Network Engineer', 'Design and maintain computer networks.', 'Noida', 85000.00, 'Contract', GETDATE()),
(6, 6, 'UX Designer', 'Create user-friendly designs.', 'New York', 95000.00, 'Full-time', GETDATE()),
(7, 7, 'Ui Designer', 'create Frontend', 'Bangalore', 75000.00, 'Full-time', GETDATE()),
(8, 8, 'Cloud Architect', 'Develop cloud-based solutions.', 'New York', 130000.00, 'Full-time', '2024-01-15 12:10:00'),
(9, 9, 'iOS Developer', 'Build applications for iPhone.', 'New York', 110000.00, 'Full-time', GETDATE()),
(10, 10, 'Cybersecurity', 'Protect company data and networks.', 'New York', 105000.00, 'Full-time', GETDATE()),
(11, 11, 'Machine Enginner', 'Develop AI models', 'California', 125000.00, 'Full-time', GETDATE()),
(12, 12, 'Software Developer', 'Work on enterprise solutions.', 'Bangalore', 95000.00, 'Full-time','2024-03-08 18:10:00');


--inserting into Applicants
insert into Applicants (FirstName, LastName, Email, Phone, [Resume]) values
('Sudharsan', 'R', 'sudharsan.r@gmail.com', '9876543210', 'Experienced software engineer skilled in backend development.'),
('Banuraekha', 'S', 'banuraekha.s@gmail.com', '8765432109', 'Data analyst with Skill in Python and SQL.'),
('Monish', 'K', 'monish.k@gmail.com', '7654321098', 'Network engineer with experience in cloud infrastructure.'),
('Mohan', 'V', 'mohan.v@gmail.com', '6543210987', 'Project manager with a decade of leadership experience.'),
('Prabu', 'T', 'prabu.t@gmail.com', '5432109876', 'Cybersecurity analyst with expertise in threat detection.'),
('Monkey D.', 'Luffy', 'luffy@gmail.com', '1234567890', 'Aspiring leader with strong teamwork'),
('Roronoa', 'Zoro', 'zoro@gmail.com', '2345678901', 'Security Specialist '),
('Nami', 'Navigator', 'nami@gmail.com', '3456789012', 'Ui designer'),
('Sanji', 'Vinsmoke', 'sanji@gmail.com', '4567890123', 'UX Designer with strong experience in user interface design and customer experience enhancement.'),
('Usopp', 'Sniper King', 'usopp@gmail.com', '5678901234', 'Network Engineer with knowledge in network security'),
('Nico', 'Robin', 'robin@gmail.com', '6789012345', 'Historian and Data Analyst'),
('Tony Tony', 'Chopper', 'chopper@gmail.com', '7890123456', 'Medical IT Specialist experienced in healthcare software');

--inserting into Application
insert into Applications(JobID, ApplicantID, ApplicationDate, CoverLetter) values
(1, 1, '2024-03-12 10:00:00', 'I am excited to apply for the Software Engineer position.'),
(2, 2, '2024-02-28 15:00:00', 'As a Data Analyst, I have strong skills in Python and SQL.'),
(3, 3, '2024-03-07 12:00:00', 'I am a certified Network Engineer with cloud expertise.'),
(4, 4, '2025-04-16 11:30:00', 'With 10 years of project management experience,'),
(5, 5, '2025-05-20 09:45:00', 'As a Cybersecurity Analyst, I specialize in threat detection and prevention.'),
(6, 6, '2025-05-25 14:20:00', 'I am an aspiring leader with strong teamwork skills.'),
(7, 7, '2025-04-28 16:10:00', 'As a Security Specialist.'),
(7, 8, '2025-04-18 13:30:00', 'I am an experienced UI Designer'),
(6, 9, '2024-03-22 10:45:00', 'With extensive experience in UX/UI design'),
(5, 10, '2025-05-26 15:00:00', 'I have a solid foundation in security and system architecture.'),
(2, 11, '2024-02-29 13:00:00', 'I have a strong background in data analysis and pattern recognition,'),
(8, 12, '2025-05-18 10:30:00', 'I have experience in AI-driven diagnostics and healthcare software solutions.');


--5. Write an SQL query to count the number of applications received for each job listing in the "Jobs" table. 
--Display the job title and the corresponding application count. 
--Ensure that it lists all jobs, even if they have no applications
select j.jobtitle,count(a.ApplicationID) as ApplicationCount
from Jobs j 
left join Applications a on j.JobID = a.JobID
group by j.jobtitle;

--6. Develop an SQL query that retrieves job listings from the "Jobs" table within a specified salary range.
--Allow parameters for the minimum and maximum salary values. 
--Display the job title, company name, location, and salary for each matching job.
select j.JobTitle, c.CompanyName, j.JobLocation, j.Salary
from Jobs j
join Companies c on j.CompanyID = c.CompanyID
where j.Salary BETWEEN 80000 AND 120000
ORDER BY j.Salary;

--7.Write an SQL query that retrieves the job application history for a specific applicant. 
--Allow a parameter for the ApplicantID, and return a result set with the job titles, company names, and 
--application dates for all the jobs the applicant has applied to.
select j.JobTitle, c.CompanyName, a.ApplicationDate from Applications a
join Jobs j on a.JobID = j.JobID
join Companies c on j.CompanyID = c.CompanyID
where a.ApplicantID = 2;

----8.Create an SQL query that calculates and displays the average salary offered by all companies for 
--job listings in the "Jobs" table. 
--Ensure that the query filters out jobs with a salary of zero.
select avg(Salary) AverageSalary
from Jobs
where Salary > 0;

--9


--10. Find the applicants who have applied for positions in companies located in 'CityX' 
--and have at least 3 years of experience.
select a.FirstName,a.Experience, c.CompanyName, c.[location] from Applicants a
join Applications app on a.ApplicantID = app.ApplicantID
join Jobs j on app.JobID = j.JobID
join Companies c on j.CompanyID = c.CompanyID
where c.location = 'bangalore' and a.Experience >= 3;

--11 Retrieve a list of distinct job titles with salaries between $60,000 and $80,000
select distinct JobTitle
from Jobs
where Salary between 60000 and 80000;

--12 Find the jobs that have not received any applications.
select j.JobID, j.JobTitle, c.CompanyName, j.JobLocation from Jobs j
left join Applications a on j.JobID = a.JobID
join Companies c on j.CompanyID = c.CompanyID
where a.ApplicationID is null;

--13 .Retrieve a list of job applicants along with the companies they have applied to and 
--the positions they have applied for.
select a.ApplicantID, a.firstname as ApplicantName, c.CompanyName, j.JobTitle ,app.ApplicationDate from Applications app
join Applicants a on app.ApplicantID = a.ApplicantID
join Jobs j on app.JobID = j.JobID
join Companies c on j.CompanyID = c.CompanyID;

--14. Retrieve a list of companies along with the count of jobs they have posted, 
--even if they have not received any applications.
select c.CompanyName, count(j.JobID) as JobCount
from Companies c
left join Jobs j on c.CompanyID = j.CompanyID
group by c.CompanyName;

--15.List all applicants along with the companies and positions they have applied for, 
--including those who have not applied.
select a.FirstName, c.CompanyName, j.JobTitle
from Applicants a
left join Applications app on a.ApplicantID = app.ApplicantID
left join Jobs j on app.JobID = j.JobID
left join Companies c on j.CompanyID = c.CompanyID;

--16.Find companies that have posted jobs with a salary higher than the average salary of all jobs.
select c.CompanyName from Companies c
join Jobs j on c.CompanyID = j.CompanyID
where j.Salary > (select avg(Salary)from Jobs where Salary > 0);

--17 Display a list of applicants with their names and a concatenated string of their city and state.
select concat(FirstName, ' ', LastName) as ApplicantName , concat(city ,' ',[state]) from Applicants;

--18. Retrieve a list of jobs with titles containing either 'Developer' or 'Engineer'.
select * from Jobs
where JobTitle like '%Developer%' or JobTitle like '%Engineer%';

--19. Retrieve a list of applicants and the jobs they have applied for, 
--including those who have not applied and jobs without applicants
select a.ApplicantID, a.FirstName, j.JobID,j.JobTitle, c.CompanyName from Applicants a
full join Applications app on a.ApplicantID = app.ApplicantID
full  JOIN Jobs j on app.JobID = j.JobID
left join Companies c on j.CompanyID = c.CompanyID;

--20.List all combinations of applicants and companies where the company is in a specific city and
--the applicant has more than 2 years of experience. For example: city=Chennai
select a.FirstName,a.Experience,c.CompanyName,c.[location] from Applicants a
cross join Companies c
where c.[location] = 'bangalore' 
AND a.Experience > 2;
