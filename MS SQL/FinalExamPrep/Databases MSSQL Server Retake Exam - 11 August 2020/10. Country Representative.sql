SELECT result.Name, result.DistributorName FROM 
(
SELECT c.Name, d.Name AS DistributorName, DENSE_RANK() OVER (PARTITION By c.Name ORDER BY COUNT(i.Id) DESC) AS Ranked
  FROM Countries c
  LEFT JOIN Distributors d ON c.Id = d.CountryId
  LEFT JOIN Ingredients i ON d.Id = i.DistributorId
  GROUP BY c.Name, d.Name
  ) AS result
WHERE result.Ranked = 1
ORDER BY result.Name, result.DistributorName

