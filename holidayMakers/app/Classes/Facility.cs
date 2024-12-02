namespace app.Classes
{
    // Klass för att representera tabellen Facilities
    public class Facility
    {
        public int Id;
        public string Name;

        // Konstruktor för att initialisera fälten
        public Facility(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}