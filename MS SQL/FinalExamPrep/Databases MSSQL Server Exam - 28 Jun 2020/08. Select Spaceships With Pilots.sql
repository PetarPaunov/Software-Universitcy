SELECT s.Name, s.Manufacturer
  FROM Spaceships s
  LEFT JOIN Journeys j ON s.Id = j.SpaceshipId
  LEFT JOIN TravelCards tc ON j.Id = tc.JourneyId
  LEFT JOIN Colonists c ON tc.ColonistId = c.Id
  WHERE DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30 AND tc.JobDuringJourney = 'Pilot'
  GROUP BY s.Name, s.Manufacturer
  ORDER BY s.Name

  
