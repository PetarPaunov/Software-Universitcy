CREATE PROC usp_SearchByTaste(@taste VARCHAR(50)) AS

SELECT c.CigarName, 
	   '$' + CAST(c.PriceForSingleCigar AS VARCHAR),
	   t.TasteType , 
	   b.BrandName, 
	   CAST(s.Length AS VARCHAR) + ' cm', CAST(s.RingRange AS VARCHAR) + ' cm'
  FROM Cigars c
  FULL JOIN Tastes t ON c.TastId = t.Id
  FULL JOIN Brands b ON c.BrandId = b.Id
  FULL JOIN Sizes s ON c.SizeId = s.Id
  WHERE t.TasteType = @taste
  ORDER BY s.Length, s.RingRange DESC

  EXEC usp_SearchByTaste 'Woody'