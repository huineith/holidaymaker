namespace app.Classes
{
    // Klass för att representera tabellen BedsXRooms
    public class BedXRoom
    {
        public int Room;
        public int BedType;
        public int Amount;

        // Konstruktor för att initialisera fälten
        public BedXRoom(int room, int bedType, int amount)
        {
            this.Room = room;
            this.BedType = bedType;
            this.Amount = amount;
        }
    }
}