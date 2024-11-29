namespace app;

public class SightFilter : ISqlFilterable
{
    private Sights _sight;
    private int _thershold;
    private FilterTypes _filter = FilterTypes.Has; // default assumption of Has query as it is the most inclusive query
    
    public SightFilter(Sights sight )
    {
        _sight = sight; 
    }
    public SightFilter(Sights sight, FilterTypes filterType,int threshold )
    {
        _sight = sight;
        _filter = filterType;
        _thershold = threshold; 
    }

    public string ToSqlQueray()
    {   
        string  returnValue="";
        switch (_filter)
        {
            case FilterTypes.Has: 
                returnValue= $"id IN (select room from sightsxrooms where sight={(int)_sight} )";
                break; 
            case  FilterTypes.EqualTo:
                returnValue= $"id IN (select room from sightsxrooms where sight={(int)_sight} And distance={_thershold} ) ";
                break; 
            case FilterTypes.GreaterThan:
                returnValue= $"id IN (select room from sightsxrooms where sight={(int)_sight} And distance>{_thershold} ) ";
                break; 
            case FilterTypes.SmallerThan:
                returnValue= $"id IN (select room from sightsxrooms where sight={(int)_sight} And distance<{_thershold} ) ";
                break; 
        }
        return returnValue;
    }
}