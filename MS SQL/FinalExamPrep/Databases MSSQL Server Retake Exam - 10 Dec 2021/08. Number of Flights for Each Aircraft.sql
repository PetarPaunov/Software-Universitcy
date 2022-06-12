SELECT a.Id, a.Manufacturer, MAX(a.FlightHours) AS FlightHours, COUNT(fd.Id) AS FlightDestinationsCount, ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
  FROM Aircraft a
  JOIN FlightDestinations fd ON a.Id = fd.AircraftId
  GROUP BY a.Id, a.Manufacturer
  HAVING COUNT(fd.Id) >= 2
  ORDER BY FlightDestinationsCount DESC, a.Id 
