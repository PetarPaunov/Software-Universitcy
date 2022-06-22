using System.Data.SqlClient;

const string SqlConnectionString = "Server=DESKTOP-VFG6D1G\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true";

using (var connection = new SqlConnection(SqlConnectionString))
{
    connection.Open();

    string[] minionInfo = Console.ReadLine().Split(" ");

    string minionName = minionInfo[1];
    string minionAge = minionInfo[2];
    string minionTown = minionInfo[3];

    string villainName = Console.ReadLine();

    string minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";

    using var minionIdCommand = new SqlCommand(minionIdQuery, connection);
    minionIdCommand.Parameters.AddWithValue("@Name", minionName);
    var minionId = minionIdCommand.ExecuteScalar();
    
    var townId = GetTownId(connection, minionTown);

    if (townId == null)
    {
        string townInsertQuery = "INSERT INTO Towns (Name) VALUES (@townName)";

        using var insertTownCommand = new SqlCommand(townInsertQuery, connection);
        insertTownCommand.Parameters.AddWithValue("@townName", minionTown);
        insertTownCommand.ExecuteNonQuery();

        Console.WriteLine($"Town {minionTown} was added to the database.");
    }

    string getVillainQuery = "SELECT Id FROM Villains WHERE Name = @Name";

    using var villainCommand = new SqlCommand(getVillainQuery, connection);
    villainCommand.Parameters.AddWithValue("@Name", villainName);
    var villain = villainCommand.ExecuteScalar();

    if (villain == null)
    {
        string insertVillainQuery = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        using var insertVillainCommand = new SqlCommand(insertVillainQuery, connection);
        insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
        insertVillainCommand.ExecuteNonQuery();

        Console.WriteLine($"Villain {villainName} was added to the database.");
    }

    townId = GetTownId(connection, minionTown);

    string insertMinionQuery = "INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";

    using var insertMinionCommad = new SqlCommand(insertMinionQuery, connection);
    insertMinionCommad.Parameters.AddWithValue("@nam", minionName);
    insertMinionCommad.Parameters.AddWithValue("@age", minionAge);
    insertMinionCommad.Parameters.AddWithValue("@townId", townId);
    insertMinionCommad.ExecuteNonQuery();

    string insertMinionVillainQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

    using var insertMinVillCommand = new SqlCommand(insertMinionVillainQuery, connection);
    insertMinVillCommand.Parameters.AddWithValue("villainId", villain);
    insertMinVillCommand.Parameters.AddWithValue("minionId", minionId);
    insertMinionCommad.ExecuteNonQuery();

    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}");
}

static object GetTownId(SqlConnection connection, string minionTown)
{
    string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";
    using var townCommad = new SqlCommand(townIdQuery, connection);
    townCommad.Parameters.AddWithValue("@townName", minionTown);
    var id = townCommad.ExecuteScalar();

    return id;
}