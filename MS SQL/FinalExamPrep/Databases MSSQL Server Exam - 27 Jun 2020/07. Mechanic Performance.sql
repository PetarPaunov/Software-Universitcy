SELECT m.FirstName + ' ' + m.LastName, AVG((DATEDIFF(DAY, j.IssueDate, j.FinishDate)))
  FROM Mechanics m
  LEFT JOIN Jobs j ON m.MechanicId = j.MechanicId
  GROUP BY FirstName, LastName, m.MechanicId
  ORDER BY m.MechanicId