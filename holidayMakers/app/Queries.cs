using System.Data;
using Npgsql;

namespace app;

public class Queries
{
    private NpgsqlDataSource _database;

    public Queries(NpgsqlDataSource database)
    {
        _database = database;
    }

    public async void AllGuests()
    {
        await using (var cmd = _database.CreateCommand("SELECT * FROM guests WHERE id='1'"))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"id: {reader.GetInt32(0)}\n");
                    Console.WriteLine($"email: {reader.GetString(1)}\n");
                    Console.WriteLine($"fName: {reader.GetString(2)}\n");
                    Console.WriteLine($"lName: {reader.GetString(3)}\n");
                    Console.WriteLine($"phone: {reader.GetString(4)}\n");
                    Console.WriteLine($"birthdate: {reader.GetDateTime(5).ToShortDateString()}\n");
                    Console.WriteLine($"blocked?: {(reader.GetBoolean(7) ? "Blocked" : "no")}");

                    Console.WriteLine("_____________");
                    
                }
    }
}