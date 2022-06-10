SELECT r.Description, c.Name
  FROM Reports r
  JOIN Categories c ON r.CategoryId = c.Id
  ORDER BY r.Description, c.Name 