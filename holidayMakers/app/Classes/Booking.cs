using System.Runtime.InteropServices.JavaScript;

namespace app.Classes;

public class Booking
{
    public int _id;
    public int _admin;
    public int _room;
    public int _guest;
    public DateTime _startDate;
    public DateTime _endDate;

    public Booking(int id, int admin, int room, int guest, DateTime startDate, DateTime endDate)
    {
        _id = id;
        _admin = admin;
        _room = room;
        _guest = guest;
        _startDate = startDate;
        _endDate = endDate;
    }
}