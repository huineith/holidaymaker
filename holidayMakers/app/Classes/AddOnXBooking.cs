namespace app.Classes
{
    // Klass för att representera tabellen AddOnsXBookings
    public class AddOnXBooking
    {
        public int Booking;
        public int AddOn;
        public int Amount;

        // Konstruktor för att initialisera fälten
        public AddOnXBooking(int booking, int addOn, int amount)
        {
            this.Booking = booking;
            this.AddOn = addOn;
            this.Amount = amount;
        }
    }
}