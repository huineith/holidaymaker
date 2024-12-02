namespace app.Classes
{
    // Record för kvitto
    public record Receipt(int BookingId, string GuestName, DateTime CheckIn, DateTime CheckOut, decimal TotalPrice);
}