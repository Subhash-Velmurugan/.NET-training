use emp_details;
--1
SELECT DISTINCT *
FROM emp
WHERE job = 'MANAGER';
--2
SELECT ename, sal
FROM emp
WHERE sal > 1000;
--3
SELECT ename, sal
FROM emp
WHERE ename <> 'JAMES';
--4

SELECT *
FROM emp
WHERE ename LIKE 'S%';
--5

SELECT ename
FROM emp
WHERE ename LIKE '%A%';
--6

SELECT ename
FROM emp
WHERE ename LIKE '__L%';
--7

SELECT ename, sal/30 AS daily_salary
FROM emp
WHERE ename = 'JONES';
--8

SELECT SUM(sal) AS total_monthly_salary
FROM emp;
--9

SELECT AVG(sal * 12) AS average_annual_salary
FROM emp;
--10

SELECT ename, job, sal, deptno
FROM emp
WHERE NOT (job = 'SALESMAN' AND deptno = 30);
--11

SELECT ename, job, sal, deptno
FROM emp
WHERE NOT (job = 'SALESMAN' AND deptno = 30);
--12

SELECT ename AS Employee, sal AS "Monthly Salary"
FROM emp
WHERE sal > 1500 AND deptno IN (10, 30);
--13
SELECT ename, job, sal
FROM emp
WHERE job IN ('MANAGER', 'ANALYST')
  AND sal NOT IN (1000, 3000, 5000);
--14

SELECT name
FROM sys.tables;
--15


SELECT ename
FROM emp
WHERE ename LIKE '%LL%'
  AND (deptno = 30 OR MGR_ID= 7782);
--16
SELECT Ename
FROM EMP
WHERE DATEDIFF(YEAR, Hiredate, GETDATE()) > 30
AND DATEDIFF(YEAR, Hiredate, GETDATE()) < 40;
--17
SELECT d.dname, e.ename
FROM emp e
JOIN dept d ON e.deptno = d.deptno
ORDER BY d.dname ASC, e.ename DESC;
--18
SELECT Ename, DATEDIFF(YEAR, Hiredate, GETDATE()) AS ExperienceInYears
FROM EMP WHERE Ename = 'MILLER';
















