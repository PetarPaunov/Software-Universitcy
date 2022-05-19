CREATE PROC usp_GetEmployeesFromTown (@townName NVARCHAR(50)) AS
SELECT FirstName, LastName
  FROM Employees e
  JOIN Addresses a ON e.AddressID = a.AddressID
  JOIN Towns t ON a.TownID = t.TownID
 WHERE t.Name = @townName
