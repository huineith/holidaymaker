namespace app.Classes;

public class Room
{
    public int _id;
    public int _size;
    public int _location;
    public double _priceDay;
    public double _rating;

    public Room(int Id, int Size, int location, double PriceDay, double Rating)
    {
        _id = Id;
        _location = location;
        _size = Size;
        _priceDay = PriceDay;
        _rating = Rating;
    }
    
    
}