namespace app;

public interface IRoomFilter
{
    bool Filter(Room room);

    string FilterInfo();
}