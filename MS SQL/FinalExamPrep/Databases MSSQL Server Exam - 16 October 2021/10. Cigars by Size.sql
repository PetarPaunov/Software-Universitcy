SELECT cl.LastName, AVG(s.Length) AS CigarLength, CEILING(AVG(s.RingRange)) AS CigarRingRange
  FROM Clients cl
  JOIN ClientsCigars cc ON cl.Id = cc.ClientId
  JOIN Cigars c ON cc.CigarId = c.Id
  JOIN Sizes s ON c.SizeId = s.Id
  GROUP BY LastName
  ORDER BY CigarLength DESC