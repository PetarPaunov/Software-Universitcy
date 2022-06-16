SELECT a.Id, a.Email, c.Name, COUNT(t.Id) AS Trips
  FROM Accounts a
  JOIN AccountsTrips AS accTr ON accTr.AccountId = a.Id
  JOIN Trips AS t ON t.Id = accTr.TripId
  JOIN Rooms AS r ON r.Id = t.RoomId
  JOIN Hotels AS h ON h.Id = r.HotelId
  JOIN Cities AS c ON a.CityId = c.Id 
  WHERE h.CityId = c.Id
  GROUP BY a.Id, a.Email, c.Name
  ORDER BY Trips DESC, a.Id


  