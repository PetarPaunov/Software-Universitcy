CREATE PROC usp_SearchByAirportName(@airportName VARCHAR(70)) 
	AS
	SELECT a.AirportName, 
		   p.FullName, 
		   CASE WHEN fd.TicketPrice <= 400 THEN 'Low'
			    WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
				ELSE 'High' END, 
		   ac.Manufacturer, 
		   ac.Condition, 
		   [at].TypeName
	  FROM Airports a
	  JOIN FlightDestinations fd ON fd.AirportId = a.Id
	  JOIN Passengers p ON fd.PassengerId = p.Id
	  JOIN Aircraft ac ON fd.AircraftId = ac.Id
	  JOIN AircraftTypes [at] ON ac.TypeId = [at].Id 
	  WHERE a.AirportName = @airportName
	  ORDER BY ac.Manufacturer, p.FullName