CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(18, 4)) AS
	
	UPDATE Accounts
	   SET Balance -= @MoneyAmount
	 WHERE Id = @AccountId
