SELECT c.CountryCode, COUNT(m.MountainRange)
  FROM Mountains m
  JOIN MountainsCountries mc ON m.Id = mc.MountainId
  JOIN Countries c ON mc.CountryCode = c.CountryCode
  WHERE c.CountryCode IN ('BG', 'US', 'RU')
  GROUP BY c.CountryCode
  
  