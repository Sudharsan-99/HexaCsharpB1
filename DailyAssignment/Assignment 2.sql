use HexawareDB;

drop table Department;
drop table employee;

create table Department(
Dept_no int primary key,
Dname varchar(30),
Loc varchar(20)
)

create table Emp(
empno int primary key,
ename varchar(30),
job varchar(20),
Mgr_id int ,
Hiredate date,
sal int ,
comm int ,
Dept_no int ,
Foreign key (Dept_no) references Department(Dept_no)
)

insert into Department(Dept_no,Dname,Loc)values
(10,'Accounting','New York'),
(20,'Research','Dallas'),
(30,'Sales','chicago'),
(40,'Operation','Boston');

select * from Department;

INSERT INTO EMP(EMPNO, ENAME, JOB, MGR_ID, HIREDATE, SAL, COMM, Dept_no) VALUES
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);

select * from emp;
--Assignment 1
--1
select * from Emp where ename like 'A%';
--2
select * from Emp where Mgr_id is null;
--3
select empno,ename,sal from Emp
where sal between 1200 and 1400;


--4 without joins
select * , sal+(sal * 0.1) NewSalary
from Emp where Dept_no=20;

-- 4 with joins 
select e.ename,e.sal oldSalary, e.Sal + (e.Sal * 0.1)  NewSalary
FROM Emp e
JOIN Department d on e.Dept_no = d.Dept_no
WHERE d.Dname = 'research';


--5
select COUNT(job) ClerkHeadCount from emp
where job = 'clerk';
--6
select Job, count(*) Total, AVG(Sal) AS Avg_Salary
FROM Emp group by job;
--7
select * from Emp
where sal=(select min(sal)from Emp);
select * from Emp
where sal = (select max(sal)from emp);
--8
select * from Department
where Dept_no not in (select distinct Dept_no from Emp);
--9
select ename,sal from emp
where job='analyst' and sal >1200 and dept_no=20
order by ename asc;

--10
select d.Dname , e.Dept_no , sum(e.sal) TotalSalary
from emp e
join Department d on e.Dept_no=d.Dept_no
group by d.Dname , e.Dept_no;

--11
select ename EmpName,sal Salary from emp
where ename='Miller' or ename='smith';

--12
select *from emp
where ename like 'A%' or ename like 'M%';
--13
select ename , sal MonthlySalary,sal*12 yearlySalary from Emp
where ename='smith';
--14
select ename , sal from Emp
where sal not  between 1500 and 2850;
--15
select mgr_id , count(empno) from emp
group by Mgr_id
having count(empno)>2;

-- 18/3/2025 Days Works
select job,sum(sal) from emp
group by job;

select dept_no , sum(sal) from emp
group by dept_no;

select dept_no , job , sum(sal) from emp
group by dept_no , job
order by dept_no ;

select * from emp
order by dept_no;

--display the no of employee under each manager
select mgr_id , count(empno) from emp
group by(mgr_id)
order by Mgr_id;

-- list min sal dept wise with sal > 5000
select dept_no, min(sal)as  'Minimum salary' from emp
group by Dept_no
having min(sal) > 5000;

--JOINS
--self join
SELECT e1.Ename AS 'Employee Name', e2.Ename AS 'Manager Name'
FROM Emp e1
JOIN Emp e2 ON e1.Mgr_id = e2.Empno;

SELECT e.*
FROM Emp e
JOIN Department d ON e.Dept_no = d.Dept_no
WHERE d.Dname = 'RESEARCH';


--19/3/2025
--SUBQuerys
select ename , job , sal from Emp
where job = (select job from emp where ename ='allen') and sal > (select sal from emp where empno = 7654); 

select * from emp
where sal = (select min(sal) from emp);


select ename , sal , job from emp
where sal > any (select  sal from emp where job = 'salesman');