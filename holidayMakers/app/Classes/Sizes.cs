namespace app.Classes
{
    // Klass för att representera tabellen Sizes
    public class Size
    {
        public int Id;
        public SizeEnum SizeType;

        // Konstruktor för att initialisera fälten
        public Size(int id, SizeEnum sizeType)
        {
            this.Id = id;
            this.SizeType = sizeType;
        }
    }
}