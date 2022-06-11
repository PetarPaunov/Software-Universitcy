	SELECT cl.FirstName + ' ' + cl.LastName AS FullName, a.Country, a.ZIP, 
			'$' + CAST(MAX(c.PriceForSingleCigar) AS VARCHAR) AS CigarPrice
	  FROM Clients cl
	  JOIN Addresses a ON cl.AddressId = a.Id
	  JOIN ClientsCigars cc ON cl.Id = cc.ClientId
	  JOIN Cigars c ON cc.CigarId = c.Id
	  WHERE a.ZIP NOT LIKE ('%[^0-9]%')
	  GROUP BY cl.FirstName, cl.LastName, a.Country, a.ZIP
	  ORDER BY FullName

 