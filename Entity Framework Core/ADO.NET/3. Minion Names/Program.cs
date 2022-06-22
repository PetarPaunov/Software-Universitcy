using System.Data.SqlClient;

const string SqlConnectionString = "Server=DESKTOP-VFG6D1G\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

using (var connection = new SqlConnection(SqlConnectionString))
{
    connection.Open();

    int id = int.Parse(Console.ReadLine());

    var vilianQury = "SELECT Name FROM Villains WHERE Id = @Id";

    using var command = new SqlCommand(vilianQury, connection);
    command.Parameters.AddWithValue("@Id", id);
    var result = command.ExecuteScalar();

    if (result == null)
    {
        Console.WriteLine($"No villain with ID {id} exists in the database.");
    }
    else
    {
        var minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

        using (var minionCommand = new SqlCommand(minionsQuery, connection))
        {
            minionCommand.Parameters.AddWithValue("@Id", id);
            var reader = minionCommand.ExecuteReader();

            Console.WriteLine($"Villain: {result}");

            if (!reader.HasRows)
            {
                Console.WriteLine("(no minions)");
            }

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
            }
        }
    }
}