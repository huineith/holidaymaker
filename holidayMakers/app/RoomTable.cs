namespace app;
using Npgsql; 

public class RoomTable
{       
    private NpgsqlDataSource _database;
    private List<Location> _locationList=new();
    public List<Room> RoomList=new();
    private List<IRoomFilter> _filters = new();
    private List<int> _displayedIndexes = new(); 
    
    public RoomTable(NpgsqlDataSource database)
    {
        _database = database;
    
    }



    public async Task _Load()
    { 
        await _LoadLocationsTable(); 
        await _LoadRoomTable() ;
        await _LoadFacilities();
        await _LoadSights();
        await _LoadBedsInfo();
        await SetDisplayToAll();
        
       
    }
        
    
     
     private async Task _LoadRoomTable()
     {
         await using (var cmd = _database.CreateCommand("Select * from rooms")) 
         await using (var reader = await cmd.ExecuteReaderAsync()) 
             while ( await reader.ReadAsync())
             {
                 RoomList.Add(new Room(reader.GetInt32(0), (Size)reader.GetInt32(1), _locationList[reader.GetInt32(2)-1],reader.GetDouble(3),
                     reader.GetDouble(4)));
             }
     }
     
    private async Task _LoadLocationsTable()
    {
        await using (var cmd = _database.CreateCommand("Select * from locations")) 
        await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                _locationList.Add(new Location((City)reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));

            }
    }

    private async Task _LoadFacilities()
    {
        Console.WriteLine(RoomList.Count);
        await using (var cmd = _database.CreateCommand("Select * from roomsxfacilities")) 
        await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {   
                
                var tempRoom=   RoomList[reader.GetInt32(0)-1];
                tempRoom.AddFacility((Facility)reader.GetInt32(1) );
                
            }
    }
    private async Task _LoadSights()
    {
        await using (var cmd = _database.CreateCommand("Select * from sightsxrooms")) 
        await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                RoomList[reader.GetInt32(1)-1].AddSight(new SightsInfo( (Sight)reader.GetInt32(0), reader.GetDouble(2) ));

            }
    }

    private async Task _LoadBedsInfo()
    {
        await using (var cmd = _database.CreateCommand("Select * from bedsxrooms")) 
        await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                var tempRoom=   RoomList[reader.GetInt32(0)-1];
             tempRoom.AddBed(new BedsInfo( (BedType)reader.GetInt32(1), reader.GetInt32(2) ));

            }
        
        foreach (var room in RoomList)
        {
         room.CalcBedPlaces();   
        }
        
    }


    public async Task SetDisplayToAll()
    {   
        _displayedIndexes.Clear();
        for (int i = 0; i < RoomList.Count; i++)
        {
            _displayedIndexes.Add(i);
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


    public void FilterInfo()
    {
        for (int j = 0; j < _filters.Count; j++)
        {
            Console.WriteLine($"filter:{j},{_filters[j].FilterInfo()}");
        }
    }
    public void ApplyFilter()
    {
        foreach (IRoomFilter filter in _filters)
        {
            _displayedIndexes = _Checkfilter(_displayedIndexes, filter);
            if (_displayedIndexes.Count == 0)
            {
                Console.WriteLine("No Valid Results");
                break; 
            } ; 
        }
      
    }
    
    private List<int> _Checkfilter(List<int> unFiltered,IRoomFilter filter)
    {
        List<int> filteredList = new();
        foreach (int index in unFiltered)
        {
            Room selectedRoom = RoomList[index];
            if (filter.Filter(selectedRoom))
            {
                filteredList.Add(index);
            }
            
        }

        return filteredList;
    }

    public List<Room> GetRoomLiST()
    {
        return RoomList; 
    }


    private List<int> indexRooms; 
    private List<int> filteredRooms;



}