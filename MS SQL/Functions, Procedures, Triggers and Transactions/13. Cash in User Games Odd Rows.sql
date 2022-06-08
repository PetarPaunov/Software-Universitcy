CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS @returnedTable TABLE
(
SumCash money
)
AS
BEGIN
		DECLARE @result money

		SET @result  = 
			(SELECT SUM(k.Cash) AS SumCash FROM (
				SELECT g.Name, ug.Cash, ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS RowsNumber
					FROM UsersGames ug
						JOIN Games g ON ug.GameId = g.Id
							WHERE g.Name = @gameName) AS k
			WHERE k.RowsNumber % 2 != 0)

			INSERT INTO @returnedTable SELECT @result
			RETURN 
END