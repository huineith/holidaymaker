namespace app.Classes
{
    public class Location
    {
        // Fält av Location-klassen
        public int Id;
        public string Name;
        public string Country;

        // Konstruktor för Location
        public Location(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}