SELECT 
t.Id,
CASE
	WHEN a.MiddleName IS NULL THEN a.FirstName + ' ' + a.LastName
	ELSE a.FirstName + ' ' + a.MiddleName + ' ' + a.LastName
END AS [Full Name],
c.[Name] AS [From],

(SELECT cc.Name FROM Trips AS tt
	JOIN AccountsTrips AS accT2 ON accT2.TripId = tt.Id
	JOIN Accounts AS aa ON aa.Id = accT2.AccountId
	JOIN Rooms AS rr ON rr.Id = tt.RoomId
	JOIN Hotels AS hh ON hh.Id = rr.HotelId
	JOIN Cities AS cc ON hh.CityId = cc.Id
WHERE tt.Id = t.Id AND a.Id = aa.Id AND hh.Id = h.Id) AS [To]
,
CASE 
WHEN CancelDate IS NOT NULL THEN 'Canceled'
ELSE  CONVERT (NVARCHAR, DATEDIFF(DAY, CONVERT(date, ArrivalDate), CONVERT(date,ReturnDate))) + ' days'
END AS Duration

FROM Trips AS t
	JOIN AccountsTrips AS accT ON accT.TripId = t.Id
	JOIN Accounts AS a ON a.Id = accT.AccountId
	JOIN Cities AS c ON c.Id = a.CityId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
ORDER BY [Full Name], t.Id