namespace app.Classes
{
    public class RoomXFacility
    {
        // Fält av RoomXFacility-klassen
        public int RoomId; // room motsvarar RoomId här
        public int FacilityId; // facility motsvarar FacilityId här

        // Konstruktor för RoomXFacility
        public RoomXFacility(int roomId, int facilityId)
        {
            RoomId = roomId;
            FacilityId = facilityId;
        }
    }
}