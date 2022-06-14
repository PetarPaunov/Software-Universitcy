SELECT d.Name, i.Name, p.Name, AVG(f.Rate)
  FROM Distributors d
  LEFT JOIN Ingredients i ON d.Id = i.DistributorId
  LEFT JOIN ProductsIngredients pr ON i.Id = pr.IngredientId
  LEFT JOIN Products p ON pr.ProductId = p.Id
  LEFT JOIN Feedbacks f ON p.Id = f.ProductId
  GROUP BY d.Name, i.Name, p.Name
  HAVING AVG(f.Rate) BETWEEN 5  AND 8
  ORDER BY d.Name, i.Name, p.Name