namespace app.Classes
{
    // Klass för att representera tabellen Rooms
    public class Room
    {
        public int Id;
        public SizeEnum Size;
        public int Location;
        public decimal PriceDay;
        public decimal Rating;
        public bool Pool;
        public bool EveningEntertainment;
        public bool KidsClub;
        public bool Restaurant;

        // Konstruktor för att initialisera fälten
        public Room(int id, SizeEnum size, int location, decimal priceDay, decimal rating, bool pool = false, bool eveningEntertainment = false, bool kidsClub = false, bool restaurant = false)
        {
            this.Id = id;
            this.Size = size;
            this.Location = location;
            this.PriceDay = priceDay;
            this.Rating = rating;
            this.Pool = pool;
            this.EveningEntertainment = eveningEntertainment;
            this.KidsClub = kidsClub;
            this.Restaurant = restaurant;
        }
    }
}