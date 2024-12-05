namespace app.RoomSearch;

public interface IRoomFilter
{
    bool Filter(Room room);

    string FilterInfo();
}