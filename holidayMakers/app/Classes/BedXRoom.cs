namespace app.Classes
{
    public class BedXRoom
    {
        // Fält av BedXRoom-klassen
        public int RoomId; // room motsvarar RoomId här
        public int BedTypeId; // bedType motsvarar BedTypeId här
        public int Amount;

        // Konstruktor för BedXRoom
        public BedXRoom(int roomId, int bedTypeId, int amount)
        {
            RoomId = roomId;
            BedTypeId = bedTypeId;
            Amount = amount;
        }
    }
}