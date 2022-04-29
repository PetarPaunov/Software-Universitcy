SELECT TOP(5) c.CountryName, r.RiverName
  FROM Countries c 
  FULL JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
  FULL JOIN Rivers r ON cr.RiverId = r.Id
  WHERE c.ContinentCode LIKE 'AF'
  ORDER BY c.CountryName	