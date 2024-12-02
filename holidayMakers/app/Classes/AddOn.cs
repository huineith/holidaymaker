namespace app.Classes
{
    // Klass för att representera tabellen AddOns
    public class AddOn
    {
        public int Id;
        public string Type;
        public decimal Price;

        // Konstruktor för att initialisera fälten
        public AddOn(int id, string type, decimal price)
        {
            this.Id = id;
            this.Type = type;
            this.Price = price;
        }
    }
}