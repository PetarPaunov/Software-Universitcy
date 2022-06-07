CREATE PROC usp_GetHoldersWithBalanceHigherThan(@number DECIMAL(18,2)) AS
SELECT FirstName, LastName
  FROM AccountHolders ah
  JOIN Accounts a ON ah.Id = a.AccountHolderId
  GROUP BY FirstName, LastName
  HAVING SUM(Balance) > @number
  ORDER BY FirstName, LastName