CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
    AS
		DECLARE @emplyeeDepartment INT = (SELECT DepartmentId 
										    FROM Employees
										   WHERE Id = @EmployeeId)
		DECLARE @reportCategoryId INT = (SELECT CategoryId
											 FROM Reports
										    WHERE Id = @ReportId)
		DECLARE @categoryDepartmentId INT = (SELECT DepartmentId 
											   FROM Categories
											  WHERE Id = @reportCategoryId)

		IF(@emplyeeDepartment = @categoryDepartmentId)
			UPDATE Reports SET EmployeeId = @EmployeeId WHERE Id = @ReportId
		ELSE
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1
					 