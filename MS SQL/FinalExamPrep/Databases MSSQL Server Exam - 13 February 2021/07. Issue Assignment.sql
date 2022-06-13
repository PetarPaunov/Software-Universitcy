SELECT i.Id, U.Username + ' : ' + i.Title
  FROM Issues i
  LEFT JOIN Users u ON i.AssigneeId = u.Id
  ORDER BY i.Id DESC, i.AssigneeId