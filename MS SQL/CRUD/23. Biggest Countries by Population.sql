USE Geography
 GO
 --Send to judge only SELECT clause
SELECT TOP(30) CountryName, [Population] 
  FROM Countries
  WHERE ContinentCode = 'EU'
  ORDER BY [Population] DESC, CountryName DESC