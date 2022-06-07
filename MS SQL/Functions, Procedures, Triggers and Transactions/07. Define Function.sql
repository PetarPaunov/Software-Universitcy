CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN		  
DECLARE @index INT = 1;

WHILE @index <= LEN(@word)
	 BEGIN
		DECLARE @char CHAR(1) = SUBSTRING(@word, @index, 1);

			 IF (CHARINDEX(@char, @setOfLetters) = 0)
				RETURN 0

			SET @index += 1
	  END
RETURN 1
END