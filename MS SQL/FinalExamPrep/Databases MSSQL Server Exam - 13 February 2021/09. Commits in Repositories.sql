SELECT TOP(5) r.Id, r.Name, COUNT(c.Id) AS Commits
  FROM Repositories r
  JOIN Commits c ON r.Id = c.RepositoryId
  JOIN RepositoriesContributors rc ON r.Id = rc.RepositoryId
  GROUP BY r.Name, R.Id
  ORDER BY Commits DESC, r.Id, r.Name

