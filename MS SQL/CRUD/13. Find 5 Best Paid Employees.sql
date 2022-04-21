USE SoftUni
 GO
 --Send to judge only SELECT clause
SELECT TOP (5) FirstName, LastName 
      FROM Employees
  ORDER BY Salary DESC