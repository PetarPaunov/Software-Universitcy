SELECT o.Name + '-' + a.Name AS OwnersAnimals, o.PhoneNumber, ac.CageId
  FROM Owners o
  JOIN Animals a ON o.Id = a.OwnerId
  JOIN AnimalsCages ac ON a.Id = ac.AnimalId
  JOIN AnimalTypes al ON a.AnimalTypeId = al.Id
  WHERE al.AnimalType = 'Mammals'
  GROUP BY o.Name, a.Name,o.PhoneNumber, ac.CageId
  ORDER BY o.Name, a.Name DESC
