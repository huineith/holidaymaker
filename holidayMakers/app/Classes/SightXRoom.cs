namespace app.Classes
{
    // Klass för att representera tabellen SightsXRooms
    public class SightXRoom
    {
        public int Sight;
        public int Room;
        public int Distance;

        // Konstruktor för att initialisera fälten
        public SightXRoom(int sight, int room, int distance)
        {
            this.Sight = sight;
            this.Room = room;
            this.Distance = distance;
        }
    }
}