SELECT ContinentCode, CurrencyCode, Total AS CurrencyUsage FROM(
SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS Total,
       DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranked
  FROM Countries 
  GROUP BY ContinentCode, CurrencyCode) AS k
  WHERE Total > 1 AND Ranked = 1
  ORDER BY ContinentCode
  