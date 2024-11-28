namespace app.Classes
{
    public class AddOnXBooking
    {
        // Fält av AddOnXBooking-klassen
        public int BookingId; // booking motsvarar BookingId här
        public int AddOnId; // addon motsvarar AddOnId här
        public int Amount;

        // Konstruktor för AddOnXBooking
        public AddOnXBooking(int bookingId, int addOnId, int amount)
        {
            BookingId = bookingId;
            AddOnId = addOnId;
            Amount = amount;
        }
    }
}