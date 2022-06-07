CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4), @interestRate FLOAT, @numberOfYear INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	
	DECLARE @result DECIMAL(18,4) = 0;
	DECLARE @inner FLOAT = 1 + @interestRate
	    SET @result = @sum * (POWER(@inner, @numberOfYear))

	RETURN @result
END