using System.Data.SqlClient;

const string SqlConnectionString = "Server=DESKTOP-VFG6D1G\\SQLEXPRESS;Database=MinionsDb;Integrated Security=true";

using (var connection = new SqlConnection(SqlConnectionString))
{
    connection.Open();

    string countryName = Console.ReadLine();

    string townsToUpperQuery = @"UPDATE Towns
                                    SET Name = UPPER(Name)
                                  WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

    using var changedTownsCommand = new SqlCommand(townsToUpperQuery, connection);
    changedTownsCommand.Parameters.AddWithValue("@countryName", countryName);
    var townsCount = changedTownsCommand.ExecuteNonQuery();

    string getTownsQuery = @"SELECT t.Name 
                               FROM Towns as t
                               JOIN Countries AS c ON c.Id = t.CountryCode
                              WHERE c.Name = @countryName";

    using (var getTownsCommand = new SqlCommand(getTownsQuery, connection))
    {
        List<string> towns = new List<string>();

        getTownsCommand.Parameters.AddWithValue("@countryName", countryName);
        var townsReaded = getTownsCommand.ExecuteReader();

        while (townsReaded.Read())
        {
            towns.Add((string)townsReaded[0]);
        }

        if (towns.Count == 0)
        {
            Console.WriteLine("No town names were affected.");
        }
        else
        {
            Console.WriteLine($"{townsCount} town names were affected.");
            Console.WriteLine($"[{string.Join(", ", towns)}]");
        }
    }
}