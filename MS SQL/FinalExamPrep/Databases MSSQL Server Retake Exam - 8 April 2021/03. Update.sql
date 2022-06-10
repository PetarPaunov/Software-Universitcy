SELECT *
  FROM Reports

UPDATE Reports SET CloseDate = OpenDate
 WHERE CloseDate IS NULL