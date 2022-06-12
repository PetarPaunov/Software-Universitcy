SELECT ap.AirportName, fd.Start, fd.TicketPrice, p.FullName, a.Manufacturer, a.Model
  FROM FlightDestinations fd
  LEFT JOIN Airports ap ON fd.AirportId = ap.Id
  LEFT JOIN Passengers p ON fd.PassengerId = p.Id
  LEFT JOIN Aircraft a ON fd.AircraftId = a.Id
  WHERE DATEPART(HOUR, fd.Start) BETWEEN 6 AND 20 AND fd.TicketPrice > 2500
  ORDER BY a.Model