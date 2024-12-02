namespace app.Classes;

public class addonXbooking
{
    public int _bookingId;
    public int _addonId;
    public int _amount;

    public addonXbooking(int BookingId, int AddonId, int Amount)
    {
        _bookingId = BookingId;
        _addonId = AddonId;
        _amount = Amount;
    }
}