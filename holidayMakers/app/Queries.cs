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

    

    public Guest GetLatestGuest()
    {
        
        using(var cmd = _database.CreateCommand("SELECT * FROM GUESTS ORDER BY id DESC LIMIT 1"))
            using (var reader =  cmd.ExecuteReader())
                if (reader.Read())
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

        throw new Exception("No guest found");
    }

    public async Task<List<Location>> ReadLocations()
    {
        var LocationList = new List<Location>();
        
        await using (var cmd = _database.CreateCommand("SELECT * FROM locations"))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    LocationList.Add(new Location(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2)));
                }

        return LocationList;
    }

    public async Task<List<BedType>> ReadBeds()
    {
        var BedTypeList = new List<BedType>();
        await using(var cmd = _database.CreateCommand("SELECT * FROM bedtypes"))
            await using(var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    BedTypeList.Add(new BedType(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2)));
                }

        return BedTypeList;
    }

    public async Task<List<Room>> GetRooms()
    {
        var RoomList = new List<Room>();
        await using (var cmd = _database.CreateCommand("SELECT * FROM rooms"))
            await using(var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    RoomList.Add(new Room(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetInt32(2),
                        reader.GetDouble(3),
                        reader.GetDouble(4),
                        reader.GetString(5)));
                }

        return RoomList;
    }
    

    public async Task<List<BedXRoom>> GetBedXrooms()
    {
        var bedXroomList = new List<BedXRoom>();
        await using(var cmd = _database.CreateCommand("SELECT * FROM bedsxrooms"))
            await using(var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())

                {
                    bedXroomList.Add(new BedXRoom(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetInt32(2)));
                }

        return bedXroomList;
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

    public async void AddNewGuest(string email,string fname, string lname, string phone, DateTime bDate, DateTime regdate)
    {
        await using (var cmd = _database.CreateCommand(
                         $"INSERT INTO GUESTS(email,firstname,lastname,phone,dateofbirth,regdate) " +
                         "VALUES ($1,$2,$3,$4,$5,$6)"))
        {
            cmd.Parameters.AddWithValue(email);
            cmd.Parameters.AddWithValue(fname);
            cmd.Parameters.AddWithValue(lname);
            cmd.Parameters.AddWithValue(phone);
            cmd.Parameters.AddWithValue(bDate);
            cmd.Parameters.AddWithValue(regdate);
            
            await cmd.ExecuteNonQueryAsync();
        }
    }
    public async Task BlockUser(int ind, bool blocker)
    {
        try
        {
            await using (var cmd = _database.CreateCommand($"UPDATE guests SET blocked= $1 WHERE id=$2"))
            {
                cmd.Parameters.AddWithValue(blocker);
                cmd.Parameters.AddWithValue(ind);
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                Console.WriteLine($"{rowsAffected} row(s) updated.");
            }
        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.WriteLine(npgsqlEx.Message);
        }
    }
    public async Task ChangeGuestData(int ind, string info,string field)
    {
        try
        {
            await using (var cmd = _database.CreateCommand($"UPDATE guests SET {field} = $1 WHERE id = $2;"))
            {

                cmd.Parameters.AddWithValue(info);
                cmd.Parameters.AddWithValue(ind);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                Console.WriteLine($"{rowsAffected} row(s) updated.");
            }

        }
        catch (NpgsqlException npgsqlEx)
        {
            Console.WriteLine(npgsqlEx.Message);
        }
    }
}