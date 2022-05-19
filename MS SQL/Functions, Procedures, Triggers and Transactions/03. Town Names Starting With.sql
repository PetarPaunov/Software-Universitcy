CREATE PROC usp_GetTownsStartingWith (@subLetter VARCHAR(50)) AS
SELECT [Name] 
  FROM Towns
 WHERE [Name] LIKE @subLetter + '%'

