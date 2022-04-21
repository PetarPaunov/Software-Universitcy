USE SoftUni
 GO
 --Send to judge only SELECT clause
SELECT FirstName, LastName
  FROM Employees
 WHERE DepartmentID != 4