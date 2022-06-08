CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(18, 4)) AS
	
	UPDATE Accounts
	   SET Balance += @MoneyAmount
	 WHERE Id = @AccountId
