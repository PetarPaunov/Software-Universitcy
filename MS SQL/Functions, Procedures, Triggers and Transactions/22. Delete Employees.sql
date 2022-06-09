CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY, 
	FirstName VARCHAR(MAX) NOT NULL, 
	LastName VARCHAR(MAX) NOT NULL, 
	MiddleName VARCHAR(MAX) NOT NULL, 
	JobTitle VARCHAR(MAX) NOT NULL, 
	DepartmentId INT REFERENCES Departments(DepartmentId), 
	Salary DECIMAL(18,2)
)

CREATE TRIGGER tr_deletedEmployees ON Employees FOR DELETE
AS

INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary) 
SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary FROM deleted