use InfiniteDB
GO
CREATE PROCEDURE sp_GeneratePayslip
(
    @EmpId INT
)
AS
BEGIN
    DECLARE
        @EmpName VARCHAR(50),
        @Gender CHAR(7),
        @DeptName VARCHAR(30),
        @Salary DECIMAL(10,2),
        @HRA DECIMAL(10,2),
        @DA DECIMAL(10,2),
        @PF DECIMAL(10,2),
        @IT DECIMAL(10,2),
        @Deductions DECIMAL(10,2),
        @GrossSalary DECIMAL(10,2),
        @NetSalary DECIMAL(10,2);

    -- Fetch employee details
    SELECT 
        @EmpName = E.EmpName,
        @Gender = E.Gender,
        @Salary = E.Salary,
        @DeptName = D.DeptName
    FROM tblEmployee E
    JOIN tblDepartment D
        ON E.DepartmentId = D.DeptId
    WHERE E.EmpId = @EmpId;

    IF @Salary IS NULL
    BEGIN
        PRINT 'Employee not found';
        RETURN;
    END

    -- Salary Calculations
    SET @HRA = @Salary * 0.10;      -- 10% HRA
    SET @DA  = @Salary * 0.20;      -- 20% DA
    SET @PF  = @Salary * 0.08;      -- 8% PF
    SET @IT  = @Salary * 0.05;      -- 5% IT

    SET @Deductions = @PF + @IT;
    SET @GrossSalary = @Salary + @HRA + @DA;
    SET @NetSalary = @GrossSalary - @Deductions;

    -- Print Payslip
    PRINT '-----------------------------------------';
    PRINT '              PAY SLIP';
    PRINT '-----------------------------------------';
    PRINT 'Employee ID     : ' + CAST(@EmpId AS VARCHAR);
    PRINT 'Employee Name   : ' + @EmpName;
    PRINT 'Gender          : ' + @Gender;
    PRINT 'Department      : ' + @DeptName;
    PRINT '-----------------------------------------';
    PRINT 'Basic Salary    : ' + CAST(@Salary AS VARCHAR);
    PRINT 'HRA (10%)       : ' + CAST(@HRA AS VARCHAR);
    PRINT 'DA  (20%)       : ' + CAST(@DA AS VARCHAR);
    PRINT '-----------------------------------------';
    PRINT 'Gross Salary    : ' + CAST(@GrossSalary AS VARCHAR);
    PRINT 'PF  (8%)        : ' + CAST(@PF AS VARCHAR);
    PRINT 'IT  (5%)        : ' + CAST(@IT AS VARCHAR);
    PRINT '-----------------------------------------';
    PRINT 'Total Deductions: ' + CAST(@Deductions AS VARCHAR);
    PRINT 'Net Salary      : ' + CAST(@NetSalary AS VARCHAR);
    PRINT '-----------------------------------------';
END;
GO
EXEC sp_GeneratePayslip 104;
--question2

CREATE TABLE tblHoliday
(
    Holiday_Date DATE PRIMARY KEY,
    Holiday_Name VARCHAR(50) NOT NULL
);
GO

INSERT INTO tblHoliday VALUES
('2026-01-26', 'Republic Day'),
('2026-08-15', 'Independence Day'),
('2026-10-24', 'Diwali'),
('2026-12-25', 'Christmas');
GO
--Trigger
CREATE TRIGGER trg_BlockEmployeeOnHoliday
ON tblEmployee
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @HolidayName VARCHAR(50);

    SELECT @HolidayName = Holiday_Name
    FROM tblHoliday
    WHERE Holiday_Date = CAST(GETDATE() AS DATE);

    IF @HolidayName IS NOT NULL
    BEGIN
        RAISERROR (
            'Due to %s you cannot manipulate employee data',
            16,
            1,
            @HolidayName
        );

        ROLLBACK TRANSACTION;
    END
END;
GO

INSERT INTO tblHoliday
VALUES (CAST(GETDATE() AS DATE), 'Test Holiday');
GO

INSERT INTO tblEmployee
VALUES (200, 'Test User', 'Male', 35000, 1);
GO


