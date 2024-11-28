namespace app.Classes
{
    public class SightXRoom
    {
        // Fält av SightXRoom-klassen
        public int SightId; // sight motsvarar SightId här
        public int RoomId; // room motsvarar RoomId här
        public int Distance;

        // Konstruktor för SightXRoom
        public SightXRoom(int sightId, int roomId, int distance)
        {
            SightId = sightId;
            RoomId = roomId;
            Distance = distance;
        }
    }
}