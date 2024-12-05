namespace app.RoomSearch;

public class LocationFilter: IRoomFilter
{
    private bool _passed = true; 
    private Location _filterLocation; 
    
    public LocationFilter(Location filterLocation)
    {
        _filterLocation = filterLocation; 
    }

    public bool Filter(Room room)
    {
        var location= room.LocationInfo;
        _passed = location.CityIdentifyer == _filterLocation.CityIdentifyer;
        return _passed; 
    }

    public string FilterInfo()
    {
        string info = $"rooms in {_filterLocation.InfoString() },";
        return info; 
    }
}