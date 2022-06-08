CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT REFERENCES Accounts(Id) NOT NULL,
	OldSum DECIMAL(18,2) NOT NULL,
	NewSum DECIMAL(18,2) NOT NULL
)

CREATE TRIGGER tr_AccountInfo ON Accounts FOR UPDATE 
AS
	DECLARE @newSum DECIMAL(18, 2) = (SELECT Balance FROM inserted)
	DECLARE @oldSum DECIMAL(18, 2) = (SELECT Balance FROM deleted)
	DECLARE @accountId INT = (SELECT Id FROM inserted)

	INSERT INTO Logs (AccountId, OldSum, NewSum) VALUES 
	(@accountId, @oldSum, @newSum)


UPDATE Accounts SET Balance += 100 WHERE Id = 1

SELECT *
  FROM Logs