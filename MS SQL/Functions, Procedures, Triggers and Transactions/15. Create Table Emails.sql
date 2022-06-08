CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY, 
	Recipient INT REFERENCES Accounts(Id) NOT NULL, 
	[Subject] NVARCHAR(MAX) NOT NULL, 
	Body NVARCHAR(MAX) NOT NULL
)

CREATE TRIGGER tr_EmailOnLog ON Logs FOR INSERT
AS
	DECLARE @accountId INT = (SELECT AccountId FROM inserted)
	DECLARE @subject NVARCHAR(100) = 'Balance change for account: ' + CAST(@accountId AS VARCHAR(50))
	DECLARE @oldSym DECIMAL(18, 2) = (SELECT OldSum FROM inserted)
	DECLARE @newSym DECIMAL(18, 2) = (SELECT NewSum FROM inserted)

	DECLARE @body NVARCHAR(100) = 'On ' + CONVERT(VARCHAR(30),GETDATE(),103) + ' your balance was changed from ' + CAST (@oldSym AS VARCHAR(50))+ ' to ' + CAST(@newSym AS VARCHAR(50)) + '.'

	INSERT INTO NotificationEmails (Recipient, Subject, Body) VALUES 
	(@accountId ,@subject, @body)

UPDATE Accounts SET Balance += 100 WHERE Id = 3

SELECT *
  FROM NotificationEmails