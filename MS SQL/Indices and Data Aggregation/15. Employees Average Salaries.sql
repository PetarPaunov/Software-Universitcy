SELECT * INTO MyNewTabele
  FROM Employees
  WHERE Salary > 30000

  DELETE  
    FROM MyNewTabele
   WHERE ManagerID = 42
 
 UPDATE MyNewTabele
    SET Salary += 5000
  WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
  FROM MyNewTabele
  GROUP BY DepartmentID

  
  