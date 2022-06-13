SELECT f.Id, f.Name, CAST(f.Size AS VARCHAR)+ 'KB'
  FROM Files f
  LEFT JOIN Files pf ON f.Id = pf.ParentId
  WHERE pf.ParentId IS NULL
  ORDER BY f.Id, f.Name, f.Size DESC