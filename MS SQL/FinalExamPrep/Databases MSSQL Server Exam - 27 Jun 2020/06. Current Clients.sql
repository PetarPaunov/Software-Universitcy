SELECT c.FirstName + ' ' + c.LastName, DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going], j.Status
  FROM Clients c
  LEFT JOIN Jobs j ON c.ClientId = j.ClientId
  WHERE j.Status != 'Finished'
ORDER BY [Days going] DESC, c.ClientId