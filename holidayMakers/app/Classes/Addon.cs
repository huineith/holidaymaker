namespace app.Classes;

public class Addon
{
    public int _id;
    public string _name;
    public double _price;

    public Addon(int Id, string Name, double Price)
    {
        _id = Id;
        _name = Name;
        _price = Price;
    }
}