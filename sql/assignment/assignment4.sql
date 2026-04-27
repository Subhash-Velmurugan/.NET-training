
CREATE DATABASE assignment4;
USE assignment4;
-- 1. T-SQL PROGRAM TO FIND FACTORIAL
DECLARE @num INT = 5;
DECLARE @fact BIGINT = 1;
DECLARE @i INT = 1;
WHILE @i <= @num
BEGIN
    SET @fact = @fact * @i;
    SET @i = @i + 1;
END

PRINT 'Factorial of ' + CAST(@num AS VARCHAR) + ' is ' + CAST(@fact AS VARCHAR);
-- 2. STORED PROCEDURE: MULTIPLICATION TABLE
IF OBJECT_ID('sp_MultiplicationTable', 'P') IS NOT NULL
    DROP PROCEDURE sp_MultiplicationTable;
GO

CREATE PROCEDURE sp_MultiplicationTable
    @number INT,
    @limit INT
AS
BEGIN
    PRINT '---- MULTIPLICATION TABLE ----';
    DECLARE @i INT = 1;

    WHILE @i <= @limit
    BEGIN
        PRINT CAST(@number AS VARCHAR) 
              + ' x ' 
              + CAST(@i AS VARCHAR) 
              + ' = ' 
              + CAST(@number * @i AS VARCHAR);
        SET @i = @i + 1;
    END
END;
GO
EXEC sp_MultiplicationTable 5, 10;
GO
-- 4. STUDENT & MARKS TABLE
IF OBJECT_ID('Marks', 'U') IS NOT NULL DROP TABLE Marks;
IF OBJECT_ID('Student', 'U') IS NOT NULL DROP TABLE Student;
GO
CREATE TABLE Student
(
    Sid INT PRIMARY KEY,
    Sname VARCHAR(50)
);
GO
CREATE TABLE Marks
(
    Mid INT PRIMARY KEY,
    Sid INT FOREIGN KEY REFERENCES Student(Sid),
    Score INT
);
Go
-- 5. INSERT DATA
INSERT INTO Student VALUES
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');
GO
INSERT INTO Marks VALUES
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);
GO
-- 6. FUNCTION TO CALCULATE STUDENT STATUS
IF OBJECT_ID('fn_StudentStatus', 'FN') IS NOT NULL
    DROP FUNCTION fn_StudentStatus;
GO
CREATE FUNCTION fn_StudentStatus (@score INT)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @status VARCHAR(10);

    IF @score >= 50
        SET @status = 'PASS';
    ELSE
        SET @status = 'FAIL';

    RETURN @status;
END;
GO
-- 7. DISPLAY STUDENT RESULT NEATLY
PRINT '---- STUDENT RESULT ----';
SELECT 
    s.Sid,
    s.Sname,
    m.Score,
    dbo.fn_StudentStatus(m.Score) AS Status
FROM Student s
JOIN Marks m
ON s.Sid = m.Sid
ORDER BY s.Sid;
GO
