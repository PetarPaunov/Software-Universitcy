SELECT j.JobId, ISNULL(SUM(Price * op.Quantity), 0.0) AS Total
  FROM Jobs j
  LEFT JOIN Orders o ON j.JobId = o.JobId
  LEFT JOIN OrderParts op ON o.OrderId = op.OrderId
  LEFT JOIN Parts p ON op.PartId = p.PartId
  WHERE j.Status = 'Finished'
  GROUP BY j.JobId
  ORDER BY Total DESC, j.JobId 