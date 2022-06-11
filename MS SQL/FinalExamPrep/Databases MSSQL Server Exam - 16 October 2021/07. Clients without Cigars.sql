SELECT c.Id, c.FirstName + ' ' + c.LastName, c.Email AS ClientName
  FROM Clients c
  LEFT JOIN ClientsCigars cc ON c.Id = cc.ClientId
  LEFT JOIN Cigars ci ON cc.CigarId = ci.Id
  WHERE ci.Id IS NULL
ORDER BY c.FirstName, c.LastName