--Assignment 4

-- 1. List unique departments of the EMP table. 
select distinct dept_no from emp;
-- 2. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename as Employee,sal as MonthlySalary from emp
where sal > 1500 and Dept_no in (10,30)
-- 3. Display the name, job, and salary of all the employees whose job is MANAGER or  ANALYST and their salary is not equal to 1000, 3000, or 5000.
select ename , job , Sal from emp
where job in('Manager' ,'Analyst')
and sal not in (select sal from emp where sal in(1000,3000,5000))
-- 4. Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%.
select ename , sal , comm from emp
where comm > (sal * 1.10)

--5. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782. 
SELECT Ename 
FROM Emp 
WHERE Ename LIKE '%L%L%' 
AND (Dept_no = 30 OR Mgr_id = 7782);

--6 


--7. Retrieve the names of departments in ascending order and their employees in descending order. 
select d.dname dept , e.ename empname
from Department d
left join emp e on d.Dept_no = e.Dept_no
order by d.Dname asc , e.ename desc

--8

--9
select * from emp
where ename like '_____%'

--10. Copy empno, ename of all employees from emp table who work for dept 10 into a new table called emp10

create table emp10(
empno int primary key,
ename varchar(20)
);
INSERT INTO Emp10 (Empno, Ename)
SELECT Empno, Ename 
FROM Emp 
WHERE Dept_no = 10;
