namespace app.RoomSearch;

public class Location
{
    public City CityIdentifyer;
    public String CityName; 
    public String Country;

    public Location(City city, string cityName, string country)
    {
        CityIdentifyer = city;
        CityName = cityName;
        Country = country; 
    }

   
    public string InfoString()
    {
        return $"{CityName}, {Country}";
    }
}