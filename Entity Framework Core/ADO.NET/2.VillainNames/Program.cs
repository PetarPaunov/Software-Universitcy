using System.Data.SqlClient;

const string SqlConnectionString = "Server=DESKTOP-VFG6D1G\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

using (var connection = new SqlConnection(SqlConnectionString))
{
    connection.Open();

    var sqlQuery = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                       FROM Villains AS v 
                       JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                   GROUP BY v.Id, v.Name 
                     HAVING COUNT(mv.VillainId) > 3 
                   ORDER BY COUNT(mv.VillainId)";

    using (var command = new SqlCommand(sqlQuery, connection))
    {
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var name = reader["Name"];
            var count = reader["MinionsCount"];

            Console.WriteLine($"{name} - {count}");
        }
    }
}