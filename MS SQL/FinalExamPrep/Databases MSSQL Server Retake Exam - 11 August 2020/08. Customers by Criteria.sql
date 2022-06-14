SELECT FirstName, Age, PhoneNumber
  FROM Customers
  WHERE Age >= 21 AND (FirstName LIKE '%an%' OR RIGHT(PhoneNumber, 2) = '38') AND CountryId != (SELECT Id From Countries WHERE Name = 'Greece') 
  ORDER BY FirstName, Age DESC
