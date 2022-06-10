SELECT m.FirstName + ' ' + m.LastName, j.Status, J.IssueDate
  FROM Mechanics m
  LEFT JOIN Jobs j ON m.MechanicId = j.MechanicId 
  ORDER BY m.MechanicId, j.IssueDate, j.JobId

