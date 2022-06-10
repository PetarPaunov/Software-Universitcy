CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT 
AS 
BEGIN
 	DECLARE @totalHours INT = DATEDIFF(HOUR, @StartDate, @EndDate)
	IF(@StartDate IS NULL)
		RETURN 0
	ELSE IF(@EndDate IS NULL)
		RETURN 0

	RETURN @totalHours
END 


SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
  FROM Reports
