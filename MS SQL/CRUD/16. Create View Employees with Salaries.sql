USE SoftUni
 GO
 --Send to judge only SELECT clause
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary
  FROM Employees