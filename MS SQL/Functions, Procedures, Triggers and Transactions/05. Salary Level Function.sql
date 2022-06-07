CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
 RETURNS VARCHAR(10)
 AS
 BEGIN
	DECLARE @Type NVARCHAR(10)
			 IF (@salary < 30000)
				SET @Type = 'Low'
		ELSE IF @salary BETWEEN 30000 AND 50000
				SET @Type = 'Average'
		   ELSE 
				SET @Type = 'High'
	
	RETURN @Type
 END