namespace app.Classes
{
    // Klass för att representera tabellen Sights
    public class Sight
    {
        public int Id;
        public string Name;

        // Konstruktor för att initialisera fälten
        public Sight(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}