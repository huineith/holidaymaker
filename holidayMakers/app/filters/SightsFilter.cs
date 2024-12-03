namespace app;

public class SightsFilter : IRoomFilter
{   
    private bool _passed = false; 
    private bool _comparison = false;
    private double _distance;
    private Sight _filterSight; 
    public SightsFilter( Sight requiredSight)
    {
        _filterSight = requiredSight; 
    }
    public SightsFilter(Sight requiredSight, double distance)
    {
        _filterSight = requiredSight;
        _distance = distance;
        _comparison = true;
    }
    
    public bool Filter(Room room )
    {
        int index = -1; 
        var sightsList = room.GetSights();
       for(int i =0; i< sightsList.Count; i++)
       {
           var roomSight = sightsList[i];
           index += 1; 
            if (roomSight.SightType == _filterSight)
            {
                _passed = true;
                break; 
            }            
        }

        if (_comparison && _passed)
        { 
            _passed = sightsList[index].Distance <= _distance; 
        }
        
        return _passed;
    }
    public string FilterInfo()
    {
        string info = ""; 
        if (_comparison)
        {
             info = $"has sight:{_filterSight} <{_distance}m";    
        }
        else
        {
            info=$"has sight:{_filterSight}"; 
            
        } 
        return info; 
    }
}