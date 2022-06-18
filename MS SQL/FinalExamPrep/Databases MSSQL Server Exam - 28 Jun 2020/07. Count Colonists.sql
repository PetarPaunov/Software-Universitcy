SELECT COUNT(*) AS [count]
  FROM Colonists c
  LEFT JOIN TravelCards tc ON c.Id = tc.ColonistId
  LEFT JOIN Journeys j ON tc.JourneyId = j.Id
  WHERE J.Purpose = 'Technical'