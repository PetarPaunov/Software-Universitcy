SELECT TOP(1)  AVG(e.Salary) AS MinAverageSalary
  FROM Employees e 
  JOIN Departments d ON e.DepartmentID = d.DepartmentID
  GROUP BY d.DepartmentID
  ORDER BY AVG(e.Salary)