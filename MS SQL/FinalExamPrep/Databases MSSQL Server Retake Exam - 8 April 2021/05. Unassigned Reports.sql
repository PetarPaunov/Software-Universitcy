SELECT r.Description, FORMAT(R.OpenDate, 'dd-MM-yyyy')
  FROM Reports r
  LEFT JOIN Employees e ON r.EmployeeId = e.Id
  WHERE r.EmployeeId IS NULL
  ORDER BY r.OpenDate, r.Description 