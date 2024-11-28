namespace app.Classes
{
    public class Facility
    {
        // Fält av Facility-klassen
        public int Id;
        public string FacilityName;

        // Konstruktor för Facility
        public Facility(int id, string facilityName)
        {
            Id = id;
            FacilityName = facilityName;
        }
    }
}