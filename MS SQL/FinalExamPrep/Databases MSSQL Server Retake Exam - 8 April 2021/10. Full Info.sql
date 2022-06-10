SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee, 
	   ISNULL(d.Name, 'None') AS Department, 
	   ISNULL(c.Name, 'None') AS Category, 
	   ISNULL(r.Description,'None'), 
	   FORMAT(r.OpenDate, 'dd.MM.yyyy') AS [OpenDate], 
	   ISNULL(s.Label,'None') AS Status, 
	   ISNULL(u.Name, 'None') AS [USER]
  FROM Reports r
  LEFT JOIN Employees e ON e.Id=r.EmployeeId
  LEFT JOIN Categories c ON c.Id=r.CategoryId
  LEFT JOIN Departments d ON d.Id=e.DepartmentId
  LEFT JOIN STATUS s ON s.Id=r.StatusId
  LEFT JOIN Users u ON u.Id=r.UserId
  ORDER BY e.FirstName DESC,e.LastName DESC,Department  ASC,Category ASC,Description ASC,r.OpenDate ASC,
  Status ASC,[USER] ASC
