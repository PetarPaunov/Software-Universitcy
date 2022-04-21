USE Geography
 GO
 --Send to judge only SELECT clause
SELECT CountryName, CountryCode, 
		CASE WHEN CurrencyCode = 'EUR' 
			 THEN 'Euro' 
			 ELSE 'Not Euro' 
			  END 
			   AS Currency 
  FROM Countries
  ORDER BY CountryName