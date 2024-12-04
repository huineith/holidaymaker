namespace app;
using Npgsql; 

public class RoomTable
{       
    private NpgsqlDataSource _database;
    public List<Location> LocationList=new();
    public List<Room> RoomList=new();
    private List<IRoomFilter> _filters = new();
    private List<int> _unbookedIndexes = new();
    public List<int> _filteredIndexes;
    public string HolidayStart;
    public string HolidayEnd;
    private int _orderBy = 0;
    private bool _desc = false; 
    
    public RoomTable(NpgsqlDataSource database,string holidayStart, string holidayEnd)
    {
        _database = database;
        HolidayStart = holidayStart;
        HolidayEnd = holidayEnd;
    }



    public async Task Load()
    { 
        await _LoadLocationsTable(); 
        await _LoadRoomTable() ;
        await _LoadFacilities();
        await _LoadSights();
        await _LoadBedsInfo();
        await LoadTimeFilteredRooms();
        
       
    }
        
    public void PrintInfo()
    {
        ApplyFilters();
        switch (_orderBy)
        {
            case 0: break; 
            case 1:  //orderBy id
                if (_desc)
                {
                    _filteredIndexes.Sort((x, y) => RoomList[y].Id.CompareTo(RoomList[x].Id));    
                }
                else{_filteredIndexes.Sort((x, y) => RoomList[x].Id.CompareTo(RoomList[y].Id)); }
                break;
            case 2:  //orderBy price
                if (_desc)
                {
                    _filteredIndexes.Sort((x, y) => RoomList[y].Price.CompareTo(RoomList[x].Price));    
                }
                else{_filteredIndexes.Sort((x, y) => RoomList[x].Price.CompareTo(RoomList[y].Price)); }
                break;
            case 3:  //orderBy rating
                if (_desc)
                {
                    _filteredIndexes.Sort((x, y) => RoomList[y].Rating.CompareTo(RoomList[x].Rating));    
                }
                else{_filteredIndexes.Sort((x, y) => RoomList[x].Rating.CompareTo(RoomList[y].Rating)); }
                break;    
            
        }
        foreach(int index in _filteredIndexes )
        {
            var room =  RoomList[index];
            Console.WriteLine("-------------------------------------");
            room.PrintInfo();
        }
        
        
    }




    public void OrderById()
    {
        _orderBy = 1; //alternative "1"
        _desc = false; 
    }
    public void OrderById(bool desc)
    {
        _orderBy = 1;
        _desc = desc; 
    }
    public void OrderByPrice()
    {
        _orderBy = 2;
        _desc = false; 
    } 
    public void OrderByPrice(bool desc)
    {
        _orderBy = 2;
        _desc = desc; 
    }
    public void OrderByRating()
    {
        _orderBy = 3;
        _desc = false; 
    }
    public void OrderByRating(bool desc)
    {
        _orderBy = 3;
        _desc = desc; 
    }
    
    public  void ResetFilteredIndexes()
    {
        _filteredIndexes=new List<int>(_unbookedIndexes); 
    }
    
  

  

    public void PrintFilterInfo()
    {
        for (int j = 0; j < _filters.Count; j++)
        {   Console.WriteLine("-------------------------------------");
            Console.WriteLine($"filter:{j},{_filters[j].FilterInfo()}");
        }
    }

    public void RemoveFilter(int index)
    {
        _filters.RemoveAt(index);
        ResetFilteredIndexes();
    }
    public void ApplyFilters()
    {
        foreach (IRoomFilter filter in _filters)
        {
          
             _filteredIndexes = _Checkfilter( filter);
            if (_filteredIndexes.Count == 0)
            {
                Console.WriteLine("No Valid Results");
                break; 
            } ; 
        }
      
    }
    
    private List<int> _Checkfilter( IRoomFilter filter)
    {
        List<int> passedIndexes = new();
        
        foreach (var index in _filteredIndexes)
        {
            Room selectedRoom = RoomList[index];
            if (filter.Filter(selectedRoom))
            {
                passedIndexes.Add(index);
            }
        }

        return passedIndexes; 
    }

    public void AddFilter(IRoomFilter filter)
    {
        _filters.Add(filter);
    }

    public void ClearFilters()
    {
        ResetFilteredIndexes();
        _filters.Clear();
    }
   


     private async Task _LoadRoomTable()
     {
         await using (var cmd = _database.CreateCommand("Select * from rooms")) 
         await using (var reader = await cmd.ExecuteReaderAsync()) 
             while ( await reader.ReadAsync())
             {
                 RoomList.Add(new Room(reader.GetInt32(0), (Size)reader.GetInt32(1), LocationList[reader.GetInt32(2)-1],reader.GetDouble(3),
                     reader.GetDouble(4)));
             }
     }
     
    private async Task _LoadLocationsTable()
    {
        await using (var cmd = _database.CreateCommand("Select * from locations")) 
        await using (var reader = await cmd.ExecuteReaderAsync())
            while (await reader.ReadAsync())
            {
                LocationList.Add(new Location((City)reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));

            }
    }

    private async Task _LoadFacilities()
    {
        
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
    
    public async Task LoadTimeFilteredRooms()
    {   
        
        string sq1=$" (select room from bookings where  (bookings.startdate between '{HolidayStart}' And '{HolidayEnd}'))" ;
        string sq2=$" (select room from bookings where  (bookings.enddate between '{HolidayStart}' And '{HolidayEnd}'))" ;
        string query = "Select * from rooms where id not in "+sq1 +" and id not in "+sq2;
       
        await using (var cmd = _database.CreateCommand(query )) 
        await using (var reader = await cmd.ExecuteReaderAsync()) 
            while ( await reader.ReadAsync())
            {
                _unbookedIndexes.Add(reader.GetInt32(0)-1); 
        
     
            }

        ResetFilteredIndexes();
        
    }

}