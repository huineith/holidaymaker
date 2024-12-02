namespace app.Classes
{
    // Klass för att representera tabellen RoomXFacilities
    public class RoomXFacility
    {
        public int Room;
        public int Facility;

        // Konstruktor för att initialisera fälten
        public RoomXFacility(int room, int facility)
        {
            this.Room = room;
            this.Facility = facility;
        }
    }
}