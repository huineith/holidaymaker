namespace app;

public class GroupSizeFilter : IRoomFilter
{
    private int _groupSize; 
    public GroupSizeFilter(int groupSize)
    {
        _groupSize = groupSize; 
    }

    public bool Filter(Room room)
    {
        bool passed = room.BedPlaces >= _groupSize;
        return passed; 
    }

    public string FilterInfo()
    {
        string info = $"rooms who have more bed spaces than {_groupSize},";
        return info; 
    }
}