
CREATE DATABASE emp
USE emp

-- ======================
-- Create Tables
-- ======================

CREATE TABLE DEPT (
    DEPTNO INT PRIMARY KEY,
    DNAME  VARCHAR(20),
    LOC    VARCHAR(20)
);

CREATE TABLE EMP (
    EMPNO    INT PRIMARY KEY,
    ENAME    VARCHAR(20),
    JOB      VARCHAR(20),
    MGR_ID   INT NULL,
    HIREDATE DATE,
    SAL      INT,
    COMM     INT NULL,
    DEPTNO   INT,
    CONSTRAINT FK_EMP_DEPT
        FOREIGN KEY (DEPTNO) REFERENCES DEPT(DEPTNO)
);

-- ======================
-- Insert Data into DEPT
-- ======================

INSERT INTO DEPT VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

-- ======================
-- Insert Data into EMP
-- ======================

INSERT INTO EMP VALUES
(7369, 'SMITH',  'CLERK',     7902, '1980-12-17',  800,  NULL, 20),
(7499, 'ALLEN',  'SALESMAN',  7698, '1981-02-20', 1600,  300,  30),
(7521, 'WARD',   'SALESMAN',  7698, '1981-02-22', 1250,  500,  30),
(7566, 'JONES',  'MANAGER',   7839, '1981-04-02', 2975,  NULL, 20),
(7654, 'MARTIN', 'SALESMAN',  7698, '1981-09-28', 1250, 1400,  30),
(7698, 'BLAKE',  'MANAGER',   7839, '1981-05-01', 2850,  NULL, 30),
(7782, 'CLARK',  'MANAGER',   7839, '1981-06-09', 2450,  NULL, 10),
(7788, 'SCOTT',  'ANALYST',   7566, '1987-04-19', 3000,  NULL, 20),
(7839, 'KING',   'PRESIDENT', NULL, '1981-11-17', 5000,  NULL, 10),
(7844, 'TURNER', 'SALESMAN',  7698, '1981-09-08', 1500,  0,   30),
(7876, 'ADAMS',  'CLERK',     7788, '1987-05-23', 1100,  NULL, 20),
(7900, 'JAMES',  'CLERK',     7698, '1981-12-03',  950,  NULL, 30),
(7902, 'FORD',   'ANALYST',   7566, '1981-12-03', 3000,  NULL, 20),
(7934, 'MILLER', 'CLERK',     7782, '1982-01-23', 1300,  NULL, 10);

-- ======================
-- EXERCISES
-- ======================

-- 1. Employees whose name begins with 'A'
SELECT * FROM EMP WHERE ENAME LIKE 'A%';

-- 2. Employees without a manager
SELECT * FROM EMP WHERE MGR_ID IS NULL;

-- 3. Employees earning between 1200 and 1400
SELECT EMPNO, ENAME, SAL
FROM EMP
WHERE SAL BETWEEN 1200 AND 1400;

-- 4. 10% pay rise for RESEARCH department
SELECT * FROM EMP WHERE DEPTNO = 20;

UPDATE EMP
SET SAL = SAL * 1.10
WHERE DEPTNO = 20;
SELECT * FROM EMP WHERE DEPTNO = 20;

-- 5. Number of CLERKS employed
SELECT COUNT(*) AS Number_of_Clerks
FROM EMP
WHERE JOB = 'CLERK';

-- 6. Average salary and count for each job
SELECT JOB,
       AVG(SAL) AS Average_Salary,
       COUNT(*) AS Employee_Count
FROM EMP
GROUP BY JOB;

-- 7. Employees with lowest and highest salary
SELECT *
FROM EMP
WHERE SAL = (SELECT MIN(SAL) FROM EMP)
   OR SAL = (SELECT MAX(SAL) FROM EMP);

-- 8. Departments with no employees
SELECT *
FROM DEPT
WHERE DEPTNO NOT IN (
    SELECT DISTINCT DEPTNO FROM EMP
);

-- 9. Analysts earning more than 1200 in department 20
SELECT ENAME, SAL
FROM EMP
WHERE JOB = 'ANALYST'
  AND SAL > 1200
  AND DEPTNO = 20
ORDER BY ENAME;

-- 10. Total salary by department
SELECT D.DEPTNO, D.DNAME, SUM(E.SAL) AS Total_Salary
FROM DEPT D
LEFT JOIN EMP E
ON D.DEPTNO = E.DEPTNO
GROUP BY D.DEPTNO, D.DNAME;

-- 11. Salary of MILLER and SMITH
SELECT ENAME, SAL
FROM EMP
WHERE ENAME IN ('MILLER', 'SMITH');

-- 12. Employees whose names begin with A or M
SELECT ENAME
FROM EMP
WHERE ENAME LIKE 'A%'
   OR ENAME LIKE 'M%';

-- 13. Yearly salary of SMITH
SELECT ENAME, SAL * 12 AS Yearly_Salary
FROM EMP
WHERE ENAME = 'SMITH';

-- 14. Employees whose salary is not between 1500 and 2850
SELECT ENAME, SAL
FROM EMP
WHERE SAL NOT BETWEEN 1500 AND 2850;

-- 15. Managers with more than 2 employees reporting to them
SELECT M.ENAME AS Manager_Name,COUNT(E.EMPNO) AS Number_of_Reportees
FROM EMP E JOIN EMP M ON E.MGR_ID = M.EMPNO
GROUP BY M.ENAME HAVING COUNT(E.EMPNO) > 2;