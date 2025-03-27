-- 1. Write a SQL query to find those employees who receive a higher salary than the employee with ID 7566. Return their names
select ename as EmpName , Sal as Salary from Emp
where sal > (select sal from emp where empno=7566);

-- 2.Write a SQL query to find out which employees have the same designation as the employee whose ID is 7876. Return name, department no and job .
select ename as Name ,dept_no as DeptNo , Job from emp
where job in (select job from emp where empno=7876);

--3  Write a SQL query to find those employees who report to that manager whose name starts with a 'B' or 'C'. Return first name, employee ID and salary
select ename from emp
where ename in (select ename from emp where ename like 'B%' or ename like 'C%') and Mgr_id is not null;

-- NorthWind

--4


--5






