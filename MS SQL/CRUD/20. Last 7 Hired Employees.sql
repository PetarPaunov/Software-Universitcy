USE SoftUni
 GO
 --Send to judge only SELECT clause
SELECT TOP(7) FirstName, LastName, HireDate
  FROM Employees
 ORDER BY HireDate DESC 