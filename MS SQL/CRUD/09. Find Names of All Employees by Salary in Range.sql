USE SoftUni
 GO
 --Send to judge only SELECT clause
SELECT FirstName, LastName, JobTitle
  FROM Employees
 WHERE Salary BETWEEN 20000 AND 30000