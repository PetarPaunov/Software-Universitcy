CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(50)) AS

SELECT a.Name, CASE WHEN a.OwnerId IS NULL THEN 'For adoption'
				ELSE o.Name END
  FROM Animals a
LEFT JOIN Owners o ON a.OwnerId = o.Id
WHERE a.Name = @AnimalName
