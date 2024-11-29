namespace app;

public class FacilitiesFilter(Facilities facilities) : ISqlFilterable
{
    
    private Facilities _facility = facilities;
    private FilterTypes _filterType = FilterTypes.Has;  //All facilities queries are of the "Has type"  no other should be possible

    public string ToSqlQueray()
    {
        string returnValue = $" id IN (select room from roomsxfacilities where facility={(int)_facility}) ";
        return returnValue; 
    }
}