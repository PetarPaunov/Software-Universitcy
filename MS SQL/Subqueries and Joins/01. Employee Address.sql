SELECT TOP(5) 
		e.EmployeeID AS EmployeeId, 
		e.JobTitle, 
		a.AddressID AS AddressId, 
		a.AddressText 
  FROM Employees e
  JOIN Addresses a ON e.AddressID = a.AddressID
  ORDER BY a.AddressID