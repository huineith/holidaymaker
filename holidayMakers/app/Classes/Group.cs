namespace app.Classes
{
    public class Group
    {
        // Fält av Group-klassen
        public int GuestId; // guest motsvarar GuestId här
        public int BookingId; // booking motsvarar BookingId här

        // Konstruktor för Group
        public Group(int guestId, int bookingId)
        {
            GuestId = guestId;
            BookingId = bookingId;
        }
    }
}