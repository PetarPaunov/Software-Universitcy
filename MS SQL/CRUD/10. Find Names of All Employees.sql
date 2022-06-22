USE SoftUni
 GO
 --Send to judge only SELECT clause
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name] 
  FROM Employees
 WHERE Salary IN(25000, 14000, 12500, 23600)