using System;

namespace app.Classes
{
    public class Booking
    {
        // Fält av Booking-klassen
        public int Id;
        public int AdminId; // admin motsvarar AdminId här
        public int RoomId; // room motsvarar RoomId här
        public int GuestId; // guest motsvarar GuestId här
        public DateTime StartDate;
        public DateTime EndDate;

        // Konstruktor för Booking
        public Booking(int id, int adminId, int roomId, int guestId, DateTime startDate, DateTime endDate)
        {
            Id = id;
            AdminId = adminId;
            RoomId = roomId;
            GuestId = guestId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}