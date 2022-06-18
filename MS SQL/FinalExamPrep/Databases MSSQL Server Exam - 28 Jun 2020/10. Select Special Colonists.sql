SELECT JobDuringJourney
	,FullName
	,Ranked
  FROM
  (SELECT tc.JobDuringJourney AS JobDuringJourney
		,c.FirstName + ' ' + c.LastName AS FullName, DENSE_RANK() OVER(PARTITION BY tc.JobDuringJourney  ORDER BY c.BirthDate) AS Ranked
  FROM Colonists c
  JOIN TravelCards tc ON c.Id = tc.ColonistId
  JOIN Journeys j ON tc.JourneyId = j.Id
  GROUP BY tc.JobDuringJourney, c.BirthDate, c.FirstName, c.LastName
  ) AS result
  WHERE Ranked = 2
  