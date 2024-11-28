namespace app.Classes
{
    public class BedType
    {
        // Fält av BedType-klassen
        public int Id;
        public string Type;
        public int Persons;

        // Konstruktor för BedType
        public BedType(int id, string type, int persons)
        {
            Id = id;
            Type = type;
            Persons = persons;
        }
    }
}