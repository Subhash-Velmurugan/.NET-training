use Employeemanagement
Go
CREATE PROCEDURE UpdateEmployeeSalary
    @Empno INT,
    @UpdatedSalary NUMERIC(10,2) OUTPUT
AS
BEGIN
    UPDATE Employee_Details
    SET Empsal = Empsal + 100
    WHERE Empno = @Empno;
    SELECT @UpdatedSalary = Empsal
    FROM Employee_Details
    WHERE Empno = @Empno;
END;
GO
DECLARE @sal NUMERIC(10,2);
EXEC UpdateEmployeeSalary 2, @sal OUTPUT;
PRINT @sal