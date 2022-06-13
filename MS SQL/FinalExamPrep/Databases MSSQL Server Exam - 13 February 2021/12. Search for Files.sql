CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(10)) AS

SELECT Id, Name, CAST(Size AS VARCHAR)+ 'KB'
  FROM Files
  WHERE Name LIKE ('%' + @fileExtension)
  ORDER BY Id, Name, Size DESC