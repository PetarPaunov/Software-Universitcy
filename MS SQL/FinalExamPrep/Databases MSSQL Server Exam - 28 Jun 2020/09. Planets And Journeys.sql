SELECT p.Name, COUNT(j.Id) AS JourneysCount
  FROM Planets p 
  JOIN Spaceports s ON p.Id = s.PlanetId
  JOIN Journeys j ON s.Id = j.DestinationSpaceportId
  GROUP BY p.Name
  ORDER BY JourneysCount DESC, p.Name