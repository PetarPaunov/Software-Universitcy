CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(50))
RETURNS INT 
AS 
BEGIN 
	RETURN(SELECT COUNT(*)
			 FROM Volunteers v
			 JOIN VolunteersDepartments vd ON v.DepartmentId = vd.Id
			WHERE DepartmentName = @VolunteersDepartment)
  END 

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')