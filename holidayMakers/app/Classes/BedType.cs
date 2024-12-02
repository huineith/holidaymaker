namespace app.Classes
{
    // Klass för att representera tabellen BedTypes
    public class BedType
    {
        public int Id;
        public BedTypeEnum Type;
        public int Persons;

        // Konstruktor för att initialisera fälten
        public BedType(int id, BedTypeEnum type, int persons)
        {
            this.Id = id;
            this.Type = type;
            this.Persons = persons;
        }
    }
}