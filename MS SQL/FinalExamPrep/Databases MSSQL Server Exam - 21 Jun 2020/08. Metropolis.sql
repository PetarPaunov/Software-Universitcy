SELECT TOP(10) c.Id, c.Name AS City, c.CountryCode AS Country, COUNT(a.Id) AS Accounts
  FROM Cities c
  JOIN Accounts a ON c.Id = a.CityId
  GROUP BY c.Name, c.CountryCode, c.Id
  ORDER BY Accounts DESC