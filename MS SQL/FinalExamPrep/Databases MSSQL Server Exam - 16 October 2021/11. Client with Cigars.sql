CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(50))
RETURNS INT 
AS
BEGIN 

	  DECLARE @Result INT =  (SELECT COUNT(*)
								FROM Clients c
								JOIN ClientsCigars cl ON c.Id = cl.ClientId
								WHERE c.FirstName = @name)
	RETURN @Result
END

SELECT dbo.udf_ClientWithCigars('Betty')
