SELECT p.FullName, COUNT(a.Id), SUM(fd.TicketPrice)
  FROM Passengers p
  JOIN FlightDestinations fd ON fd.PassengerId = p.Id
  JOIN Aircraft a ON fd.AircraftId = a.Id
  WHERE FullName LIKE ('_a%')
  GROUP BY FullName
  HAVING COUNT(a.Id) > 1
  ORDER BY p.FullName

