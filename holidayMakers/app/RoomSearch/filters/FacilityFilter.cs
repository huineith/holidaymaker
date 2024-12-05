namespace app.RoomSearch;

public class FacilityFilter : IRoomFilter
{
    private bool _passed = true; 
    public  Facility RequiredFacility ;
    
    public FacilityFilter()
    {
       
    }
    public FacilityFilter(Facility filteringFacility)
    {
        RequiredFacility = filteringFacility;
    }

    public bool Filter(Room room )
    { 
        var facilityList = room.GetFacilities();
        _passed = facilityList.Exists(x => x == RequiredFacility);
        
        return _passed; 
    }
    public string FilterInfo()
    {
        string info = $"rooms have {RequiredFacility},";
        return info; 
    }

  
    
}