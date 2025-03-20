create database ITSolutions

use ITSolutions;

create table clients(
client_ID int primary Key,
C_name varchar(50) not null,
C_Address varchar(60),
email varchar(30) unique,
phone int ,
Buisness varchar(20) not null
);

create table Departments(
Dept_no int primary key,
Dname varchar(20) not null,
loc varchar(20)
)


create table Employees(
Empno int primary key,
Emp_name varchar(20) not null,
Job varchar(20),
salary int,
check(salary > 0),
Dept_no int,
Foreign key (Dept_no) references Departments(Dept_no)
);

create table projects(
project_ID int primary key ,
descr varchar(30) not null,
Project_Start_Date date ,
Planned_End_Date date,
Actual_End_Date date ,
check(Actual_End_Date > Planned_End_Date),
Budget numeric(10) check(Budget > 0),
client_ID int ,
Foreign key (client_ID) references clients(client_ID)
);

create table EmpProjectTasks(
Project_ID int ,
Empno int ,
Primary key(Project_id,Empno),
Foreign key (Project_ID) references projects(project_ID),
Foreign key (Empno) references Employees(Empno),
Project_Start_Date date,
End_Date date,
Task varchar(30) not null,
Project_status varchar(30) not null
);

alter table clients
alter column phone varchar(20);

insert into clients(client_ID,C_name,C_Address,email,phone,Buisness)Values
(1001 , 'ACME Utilities', 'Noida', 'contact@acmeutil.com', '9567880032', 'Manufacturing'),
(1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', '8734210090', 'Consultant'),  
(1003, 'MoneySaver Distributors', 'Kolkata', 'save@moneysaver.com', '7799886655', 'Reseller'),  
(1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', '9210342219', 'Professional');

insert into Employees(Empno,Emp_name,Job,salary,Dept_no)values
(7001, 'Sandeep', 'Analyst', 25000, 10),  
(7002, 'Rajesh', 'Designer', 30000, 10),  
(7003, 'Madhav', 'Developer', 40000, 20),  
(7004, 'Manoj', 'Developer', 40000, 20),  
(7005, 'Abhay', 'Designer', 35000, 10),  
(7006, 'Uma', 'Tester', 30000, 30),  
(7007, 'Gita', 'Tech. Writer', 30000, 40),  
(7008, 'Priya', 'Tester', 35000, 30),  
(7009, 'Nutan', 'Developer', 45000, 20),  
(7010, 'Smita', 'Analyst', 20000, 10),  
(7011, 'Anand', 'Project Mgr', 65000, 10);

INSERT INTO Departments (Dept_no, Dname, Loc)  
VALUES  
(10, 'Design', 'Pune'),  
(20, 'Development', 'Pune'),  
(30, 'Testing', 'Mumbai'),  
(40, 'Document', 'Mumbai');

INSERT INTO Projects (Project_ID, Descr, Project_Start_Date, Planned_End_Date, Actual_End_Date, Budget, Client_ID) VALUES  
(401, 'Inventory', '2011-04-01', '2011-10-01', '2011-10-31', 150000, 1001),  
(402, 'Accounting', '2011-08-01', '2012-01-01', NULL, 500000, 1002),  
(403, 'Payroll', '2011-10-01', '2011-12-31', NULL, 75000, 1003),  
(404, 'Contact Mgmt', '2011-11-01', '2011-12-31', NULL, 50000, 1004);

INSERT INTO EmpProjectTasks(Project_ID, Empno, Project_Start_Date, End_Date, Task,Project_status) VALUES  
(401, 7001, '2011-04-01', '2011-04-20', 'System Analysis', 'Completed'),
(401, 7002, '2011-04-21', '2011-05-30', 'System Design', 'Completed'),
(401, 7003, '2011-06-01', '2011-07-15', 'Coding', 'Completed'),
(401, 7004, '2011-07-18', '2011-09-01', 'Coding', 'Completed'),
(401, 7006, '2011-09-03', '2011-09-15', 'Testing', 'Completed'),
(401, 7009, '2011-09-18', '2011-10-05', 'Code Change', 'Completed'),
(401, 7008, '2011-10-06', '2011-10-16', 'Testing', 'Completed'),
(401, 7007, '2011-10-06', '2011-10-22', 'Documentation', 'Completed'),
(401, 7011, '2011-10-22', '2011-10-31', 'Sign off', 'Completed'),
(402, 7010, '2011-08-01', '2011-08-20', 'System Analysis', 'Completed'),
(402, 7002, '2011-08-22', '2011-09-30', 'System Design', 'Completed'),
(402, 7004, '2011-10-01', NULL, 'Coding', 'In Progress');

select * from clients;
select * from Employees;
select * from Departments;
select * from EmpProjectTasks;
select * from projects;
