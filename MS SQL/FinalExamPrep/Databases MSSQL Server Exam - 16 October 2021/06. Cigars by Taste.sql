SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength
  FROM Cigars c
  LEFT JOIN Tastes t ON c.TastId = t.Id
  WHERE t.TasteType IN ('Earthy', 'Woody')
  ORDER BY PriceForSingleCigar DESC