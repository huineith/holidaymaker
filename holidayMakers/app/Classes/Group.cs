namespace app.Classes
{
    // Klass för att representera tabellen Groups
    public class Group
    {
        public int Guest;
        public int Booking;

        // Konstruktor för att initialisera fälten
        public Group(int guest, int booking)
        {
            this.Guest = guest;
            this.Booking = booking;
        }
    }
}