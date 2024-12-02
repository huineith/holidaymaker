namespace app.Classes
{
    // Klass för att representera tabellen Locations
    public class Location
    {
        public int Id;
        public string Name;
        public string Country;

        // Konstruktor för att initialisera fälten
        public Location(int id, string name, string country)
        {
            this.Id = id;
            this.Name = name;
            this.Country = country;
        }
    }
}