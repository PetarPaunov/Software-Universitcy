SELECT a.FirstName, a.LastName, FORMAT(a.BirthDate, 'MM-dd-yyyy'), c.Name, a.Email
  FROM Accounts a
  JOIN Cities c ON a.CityId = c.Id
  WHERE Email LIKE ('e%')
ORDER BY c.Name
