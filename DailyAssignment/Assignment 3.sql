--Assignment 3

--Q1 List of Managers
select * from Emp
where job = 'Manager';

--Q2. Find out the names and salaries of all employees earning more than 1000 per month. 
select ename , sal from Emp
where sal > 1000

--Q3 Display the names and salaries of all employees except JAMES. 
select ename , sal from Emp
where ename != 'James';

--Q4  Find out the details of employees whose names begin with ‘S’.
select * from emp 
where ename like 's%'

--Q 5. Find out the names of all employees that have ‘A’ anywhere in their name.
select * from emp
where ename like '%A%'

--Q 6. Find out the names of all employees that have ‘L’ as their third character in their name.
select * from emp 
where ename like '__L%'

--Q 7  Compute daily salary of JONES.
select ename , sal OldSalary , (sal/30) DailySalary from emp
where ename = 'Jones';

--Q 8. Calculate the total monthly salary of all employees.

select sum(sal)  TotalSalary from emp;

--Q 9. Print the average annual salary 
select avg(sal) * 12 AvgAnnualSalary from emp;

--Q 10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 
select ename , job ,sal , Dept_no from Emp
where Dept_no != 30;