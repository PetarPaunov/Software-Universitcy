SELECT u.Username, c.Name
  FROM Users u
  LEFT JOIN Reports r ON u.Id = r.UserId
  LEFT JOIN Categories c ON r.CategoryId = c.Id
  WHERE DATEPART(MONTH, u.Birthdate) = DATEPART(MONTH, r.OpenDate) AND 
		DATEPART(DAY, u.Birthdate) = DATEPART(DAY, r.OpenDate)
	ORDER BY u.Username, c.Name
