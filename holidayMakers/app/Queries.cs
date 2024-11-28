using System.Data;
using System.Xml;
using app.Classes;
using Npgsql;

namespace app;

public class Queries
{

    private Guest _guest;
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

    public async Task<Guest> ReadGuestToObject()
    {
        await using (var cmd = _database.CreateCommand("SELECT * FROM GUESTS WHERE id='1'"))
            await using(var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                return new Guest(
                   reader.GetInt32(0), // Assuming the ID is the first column
                    reader.GetString(1), // Assuming email is the second column
                   reader.GetString(2), // Assuming first name
                   reader.GetString(3), // Assuming last name
                    reader.GetString(4), // Assuming phone
                    reader.GetDateTime(5).ToShortDateString(), // Assuming date of birth
                   reader.GetDateTime(6),
                   reader.GetBoolean(7) ? "Blocked" : "No"  // Assuming "Blocked" is the 7th column

                    );
                }

        throw new Exception("Guest not found");
    }
    
    public async Task<List<Guest>> ReadGuestToList()
    {

        var guestList = new List<Guest>();
        await using (var cmd = _database.CreateCommand("SELECT * FROM GUESTS"))
        await using(var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                guestList.Add(new Guest(
                    reader.GetInt32(0), // Assuming the ID is the first column
                    reader.GetString(1), // Assuming email is the second column
                    reader.GetString(2), // Assuming first name
                    reader.GetString(3), // Assuming last name
                    reader.GetString(4), // Assuming phone
                    reader.GetDateTime(5).ToShortDateString(), // Assuming date of birth
                    reader.GetDateTime(6),
                    reader.GetBoolean(7) ? "Blocked" : "No"  // Assuming "Blocked" is the 7th column

                ));
            }

        return guestList;
    }
}