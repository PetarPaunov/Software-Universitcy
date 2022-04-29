SELECT TOP(5) WITH TIES c.CountryName, ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name], 
					  ISNULL(MAX(p.Elevation), '0') AS [Highest Peak Elevation],
					  ISNULL(m.MountainRange, '(no mountain)') AS Mountain
FROM Countries c
LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m ON mc.MountainId = m.Id
LEFT JOIN Peaks p ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange
ORDER BY c.CountryName, p.PeakName

  




