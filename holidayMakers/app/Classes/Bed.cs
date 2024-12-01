namespace app.Classes;


    public class BedType
    {
        
        public int Id;
        public string Type;
        public int Persons;

        
        public BedType(int id, string type, int persons)
        {
            Id = id;
            Type = type;
            Persons = persons;
        }
    }
