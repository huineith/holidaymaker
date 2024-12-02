namespace app;
using Npgsql; 

public class RoomTable
{       
    private NpgsqlDataSource _database;
    private List<Location> _locationList=new();
    private List<Room> RoomList=new(); 
    
    
    public RoomTable(NpgsqlDataSource database)
    {
        _database = database;
        _LoadLocationsTable();
        _LoadRoomTable();
        _LoadFacilities();
        _LoadSights();
        _LoadBedsInfo();
    }



     
     private async void _LoadRoomTable()
     {
         await using (var cmd = _database.CreateCommand("Select * from rooms")) 
         await using (var reader = await cmd.ExecuteReaderAsync()) 
             while ( await reader.ReadAsync())
             {
                 RoomList.Add(new Room(reader.GetInt32(0), (Size)reader.GetInt32(1), _locationList[reader.GetInt32(2)-1],reader.GetDouble(3),
                     reader.GetDouble(4)));
             }
     }
     
    private async void _LoadLocationsTable()
    {
        await using (var cmd = _database.CreateCommand("Select * from locations")) 
        await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                _locationList.Add(new Location((City)reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));

            }
    }

    private async void _LoadFacilities()
    {
        await using (var cmd = _database.CreateCommand("Select * from roomsxfacilities")) 
        await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                RoomList[reader.GetInt32(0)-1].AddFacility((Facility)reader.GetInt32(1));

            }
    }
    private async void _LoadSights()
    {
        await using (var cmd = _database.CreateCommand("Select * from sightsxrooms")) 
        await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                RoomList[reader.GetInt32(1)-1].AddSight(new SightsInfo( (Sight)reader.GetInt32(0), reader.GetDouble(2) ));

            }
    }

    private async void _LoadBedsInfo()
    {
        await using (var cmd = _database.CreateCommand("Select * from bedsxrooms")) 
        await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                RoomList[reader.GetInt32(0)-1].AddBed(new BedsInfo( (BedType)reader.GetInt32(1), reader.GetInt32(2) ));

            }

        foreach (var room in RoomList)
        {
         room.CalcBedPlaces();   
        }
        
    }



    public void PrintInfo()
    {
        foreach(var room in RoomList)
        {
            Console.WriteLine("-------------------------------------");
            room.PrintInfo();
        }
        
        
    }



}