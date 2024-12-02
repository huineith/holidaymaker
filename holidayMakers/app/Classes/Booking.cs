namespace app.Classes
{
    // Klass för att representera tabellen Bookings
    public class Booking
    {
        public int Id;
        public int Admin;
        public int Room;
        public int Guest;
        public DateTime StartDate;
        public DateTime EndDate;

        // Konstruktor för att initialisera fälten
        public Booking(int id, int admin, int room, int guest, DateTime startDate, DateTime endDate)
        {
            this.Id = id;
            this.Admin = admin;
            this.Room = room;
            this.Guest = guest;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
    }
}