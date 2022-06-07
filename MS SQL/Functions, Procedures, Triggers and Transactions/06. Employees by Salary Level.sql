CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel NVARCHAR(50)) AS
	SELECT FirstName, LastName
	  FROM Employees
	 WHERE @salaryLevel = dbo.ufn_GetSalaryLevel(Salary)