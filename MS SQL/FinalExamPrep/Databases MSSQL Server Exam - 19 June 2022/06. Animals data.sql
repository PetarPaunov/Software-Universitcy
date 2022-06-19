SELECT a.Name, an.AnimalType, FORMAT(a.BirthDate, 'dd.MM.yyyy') AS BirthDate
  FROM Animals a
  LEFT JOIN AnimalTypes an ON a.AnimalTypeId = an.Id
  ORDER BY a.Name 