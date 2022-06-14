CREATE VIEW v_UserWithCountries AS
SELECT c.FirstName + ' ' + c.LastName AS CustomerName, c.Age, c.Gender, cs.Name
  FROM Customers c
  LEFT JOIN Countries cs ON c.CountryId = cs.Id
  