SELECT e.FirstName + ' ' + e.LastName AS FullName, COUNT(u.Id) AS UsersCount
  FROM Employees e
  LEFT JOIN Reports r ON e.Id = r.EmployeeId
  LEFT JOIN Users u ON r.UserId = u.Id
  GROUP BY e.FirstName, e.LastName
  ORDER BY UsersCount DESC, FirstName