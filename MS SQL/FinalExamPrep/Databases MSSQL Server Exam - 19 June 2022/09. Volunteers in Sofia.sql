SELECT v.Name, v.PhoneNumber, SUBSTRING(v.Address, CHARINDEX(',', v.Address) + 1, LEN(v.Address)) AS Address
  FROM Volunteers v
  JOIN VolunteersDepartments vd ON v.DepartmentId = vd.Id
  WHERE vd.DepartmentName = 'Education program assistant' AND Address LIKE ('%Sofia%')
  ORDER BY v.Name