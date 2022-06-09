CREATE PROCEDURE usp_TransferMoney(@senderId INT, @recieverId INT, @amount DECIMAL(18,4)) AS
BEGIN TRANSACTION 
  IF @amount < 0
  BEGIN
	 ROLLBACK
    END 

  EXEC usp_WithdrawMoney @senderId, @amount
  EXEC usp_DepositMoney @recieverId, @amount 

COMMIT 
