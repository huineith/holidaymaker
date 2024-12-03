namespace app;

public class FacilityFilter : IRoomFilter
{
    private bool _passed = true; 
    public  List<Facility> RequiredFacilities =new ();
    
    public FacilityFilter()
    {
       
    }
    public FacilityFilter(List<Facility> filterList)
    {
        RequiredFacilities = filterList;
    }

    public bool Filter(Room room )
    { 
        var facilityList = room.GetFacilities();
        foreach (var facility in RequiredFacilities)
        {
            _passed = facilityList.Exists(x => x == facility);
            if (!_passed)
            {
                return _passed;
            }
            
        } 
        return _passed; 
    }
    public string FilterInfo()
    {
        string info = "Has facilities:";
        foreach (var facility in RequiredFacilities)
        {
            info += $"{facility},";
        }

        return info; 
    }

  
    
}