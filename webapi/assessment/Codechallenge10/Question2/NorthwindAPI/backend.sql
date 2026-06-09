use northwind
SELECT EmployeeID, FirstName, LastName
FROM Employees
WHERE EmployeeID = 5;
GO
CREATE PROCEDURE GetCustomersByCountry
    @Country NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM Customers
    WHERE Country = @Country
END
EXEC GetCustomersByCountry 'USA'