
CREATE DATABASE Employeemanagement;
USE Employeemanagement;

CREATE TABLE Employee_Details
(
    Empno INT PRIMARY KEY,
    EmpName VARCHAR(50) NOT NULL,
    Empsal NUMERIC(10,2) CHECK (Empsal >= 25000),
    Emptype CHAR(1) CHECK (Emptype IN ('F','P'))  -- F = Fulltime, P = Parttime
);
GO
CREATE PROCEDURE InsertEmployee
    @EmpName VARCHAR(50),
    @Empsal NUMERIC(10,2),
    @Emptype CHAR(1)
AS
BEGIN
    DECLARE @NewEmpno INT;
    SELECT @NewEmpno = ISNULL(MAX(Empno), 1) + 1 FROM Employee_Details;
    INSERT INTO Employee_Details (Empno, EmpName, Empsal, Emptype)
    VALUES (@NewEmpno, @EmpName, @Empsal, @Emptype);
END;
GO
EXEC InsertEmployee 'John', 30000, 'F';
EXEC InsertEmployee 'David', 27000, 'P';
SELECT * FROM Employee_Details;
