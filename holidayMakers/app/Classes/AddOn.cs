namespace app.Classes
{
    public class AddOn
    {
        // Fält av AddOn-klassen
        public int Id;
        public string Type;
        public decimal Price;

        // Konstruktor för AddOn
        public AddOn(int id, string type, decimal price)
        {
            Id = id;
            Type = type;
            Price = price;
        }
    }
}