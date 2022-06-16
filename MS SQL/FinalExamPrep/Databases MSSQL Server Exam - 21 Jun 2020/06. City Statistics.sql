SELECT c.Name, COUNT(h.Id) AS Hotels
  FROM Cities c
  JOIN Hotels h ON c.Id = h.CityId
  GROUP BY c.Name
  ORDER BY Hotels DESC, c.Name