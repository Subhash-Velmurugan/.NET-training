create database assessment2;
use assessment2;
CREATE TABLE emp (
    id INT IDENTITY PRIMARY KEY,
    empid INT NOT NULL,
    name VARCHAR(150) NOT NULL,
    deptno INT,
    dept VARCHAR(100),
    salary FLOAT NULL,
    DOJ date
);

INSERT INTO emp (empid, name, deptno, dept, salary, doj)
VALUES
(101, 'Ramesh', 10, 'Sales', 1400, '2019-03-15'),
(102, 'Suresh', 20, 'HR', 2200, '2018-07-10'),
(103, 'Anita', 10, 'Finance', 3000, '2020-01-20'),
(104, 'Kiran', 3, 'IT', 4000, '2023-06-01'),
(105, 'Meena', 20, 'Sales', 1200, '2024-02-12'),
(106, 'Rahul', 4, 'Admin', 2500, '2022-11-05'),
(107, 'Priya', 5, 'Marketing', 1800, '2025-08-18');

--1.Write a query to display your birthday( day of week)
select datename(weekday, '2005-01-26') AS Birthday;
--2.Write a query to display your age in days
select datediff(day, '2005-01-26', getdate()) AS age;
--3.Write a query to display all employees information those who joined before 5 years in the current month
SELECT *
FROM emp
WHERE doj < DATEFROMPARTS(
              YEAR(GETDATE()) - 5,
              MONTH(GETDATE()),
              1
          )
--4. Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
BEGIN TRANSACTION;
INSERT INTO emp (empid, name, deptno, dept, salary, doj)
VALUES
(201, 'Arun', 10, 'Sales', 10000, '2020-01-15'),
(202, 'Bala', 20, 'HR', 12000, '2021-03-10'),
(203, 'Chitra', 3, 'IT', 15000, '2022-06-25')
SAVE TRAN after_insert;
UPDATE emp
SET salary = salary * 1.15
WHERE empid = 202;
SAVE TRAN after_update;
DELETE FROM emp
WHERE empid = 201;
ROLLBACK TRAN after_update;
COMMIT;
select * from emp;
--5.  Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
GO
CREATE FUNCTION dbo.CalculateBonus
(
    @salary FLOAT,
    @deptno INT
)
RETURNS FLOAT
AS
BEGIN
    DECLARE @bonus FLOAT;
    IF @deptno = 10
        SET @bonus = @salary * 0.15;
    ELSE IF @deptno = 20
        SET @bonus = @salary * 0.20;
    ELSE
        SET @bonus = @salary * 0.05
    RETURN @bonus;
END;
Go
SELECT 
    empid,
    name,
    deptno,
    salary,
    dbo.CalculateBonus(salary, deptno) AS Bonus
FROM emp;
--6.. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
GO
CREATE PROCEDURE UpdateSalesEmployeeSalary
AS
BEGIN
    UPDATE emp
    SET salary = salary + 500
    WHERE dept = 'Sales'
      AND salary < 1500;
END;
GO
EXEC UpdateSalesEmployeeSalary;
select * from emp where dept ='Sales';