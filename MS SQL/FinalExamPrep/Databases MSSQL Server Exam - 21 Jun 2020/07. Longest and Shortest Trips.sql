SELECT a.Id, a.FirstName + ' ' + a.LastName, MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip, MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
  FROM Accounts a
  JOIN AccountsTrips act ON a.Id = act.AccountId
  JOIN Trips t ON act.TripId = t.Id
  WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
  GROUP BY a.Id, a.FirstName, a.LastName
  ORDER BY LongestTrip DESC, ShortestTrip
