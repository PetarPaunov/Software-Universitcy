SELECT COUNT(c.CountryCode) AS Count 
  FROM Countries c 
  LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
  LEFT JOIN Mountains m ON mc.MountainId = m.Id
  WHERE m.Id IS NULL 