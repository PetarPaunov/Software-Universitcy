CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50)) 
RETURNS INT 
AS
BEGIN 
		DECLARE @result INT = ( SELECT COUNT(*)
								FROM Passengers p
								JOIN FlightDestinations fd ON fd.PassengerId = p.Id
								WHERE p.Email = @email
								GROUP BY p.Id)
		IF(@result > 0)
			RETURN @result
		ELSE RETURN 0
	RETURN 0
  END
  
  SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
