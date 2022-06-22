USE SoftUni
 GO
 --Send to judge only SELECT clause
SELECT FirstName, LastName
  FROM Employees
 WHERE ManagerID IS NULL