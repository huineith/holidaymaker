namespace app.Classes;

public class Room
{
    public int _id;
    public int _size;
    public int _location;
    public double _priceDay;
    public double _rating;
    public string _name;

    public Room(int Id, int Size, int location, double PriceDay, double Rating,string Name)
    {
        _id = Id;
        _location = location;
        _size = Size;
        _priceDay = PriceDay;
        _rating = Rating;
        _name = Name;
    }
    
    
}