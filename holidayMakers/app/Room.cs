namespace app;

using System.Collections; 
public class Room
{
    public int Id;
    public  Size RoomSize;
    public  Location LocationInfo;
    public  double Price;
    public  double Rating;
    public double  BedPlaces;
    private List<BedsInfo> _bedList=new(); 
    private  List<Facility> _facilities=new();
    private  List<SightsInfo> _sights=new();
    
    
    public Room(int id, Size roomSize, Location location, double price, double rating)
    {
        Id = id;
        RoomSize = roomSize;
        LocationInfo = location;
        Price = price;
        Rating = rating; 

    }
    
  
    public void PrintInfo()
    {
        Console.WriteLine( $"id:{Id}, size:{RoomSize}, price:{Price}, rating:{Rating}, location:{LocationInfo.InfoString()} \n"
                           +$"facilities:{this._FacilitesInfo()} \nsites:{this._SightInfo()} \n" 
                           +$"Total beds:{BedPlaces}, bedTypes: {this._BedTypeInfo()} ");
    }

    public void CalcBedPlaces()
    {
        int beds = 0; 
        foreach(var bed in _bedList)
        {
            if (bed.Bed == BedType.Single)
            {
                beds += 1*bed.Amount; 
            }
            else
            {
                beds += 2*bed.Amount;; 
            }
        }

        BedPlaces= beds; 
    }

    private string _FacilitesInfo()
    {
        string textInfo = ""; 
        foreach (var facility in _facilities)
        {
            textInfo += $"{facility},";
        }
        return textInfo;
    }
    
    private string _SightInfo()
    {
        string textInfo = ""; 
        foreach (var sight in _sights)
        {
            textInfo += $"{sight.SightType} {sight.Distance}m,";
        }
        return textInfo;
    }
    
    private string _BedTypeInfo()
    {
        string textInfo = ""; 
        foreach (var bed in _bedList)
        {
            textInfo += $"{bed.Amount} {bed.Bed},";
        }
        return textInfo;
    }
    public void AddFacility(Facility facility)
    {
        _facilities.Add(facility);
    }
    public void AddSight(SightsInfo sight)
    { 
        _sights.Add(sight); 
    }

    public void AddBed(BedsInfo bed)
    {
        _bedList.Add(bed);
    }
    public List<Facility> GetFacilities()
    {
        return _facilities; 
    }
    public List<SightsInfo> GetSights()
    {
        return _sights; 
    }

    public List<BedsInfo> GetBeds()
    {
        return _bedList; 
    }

}