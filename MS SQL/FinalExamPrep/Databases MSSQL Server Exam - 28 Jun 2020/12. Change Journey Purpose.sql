CREATE PROC usp_ChangeJourneyPurpose(@journeyId INT, @NewPurpose VARCHAR(30)) AS

IF(@journeyId NOT IN (SELECT Id FROM Journeys))
	THROW 50001, 'The journey does not exist!', 1
ELSE IF((SELECT Purpose FROM Journeys WHERE Id = @journeyId) = @NewPurpose)
	THROW 50002, 'You cannot change the purpose!', 1
ELSE 
 BEGIN 
  UPDATE Journeys SET Purpose = @NewPurpose
   END

-- Tests
EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'
