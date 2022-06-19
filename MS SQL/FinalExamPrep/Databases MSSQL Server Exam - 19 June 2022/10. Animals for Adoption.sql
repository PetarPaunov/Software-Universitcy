SELECT Name, YEAR(BirthDate), al.AnimalType
  FROM Animals a
  JOIN AnimalTypes al ON a.AnimalTypeId = al.Id
  WHERE OwnerId IS NULL AND 
		DATEDIFF(YEAR, BirthDate, '01/01/2022') < 5 AND al.AnimalType != 'Birds'
 ORDER BY a.Name
