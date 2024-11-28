namespace app;
using Npgsql; 
using System.Collections; 
public class RoomQueries: Queries
{
    private List<string> _facilityFilters= new ();
    private string _queryStart="SELECT * FROM rooms";
    private bool _firstFilter = true;
    private bool _ordered = false;
    private string _orderby; 
    public RoomQueries(NpgsqlDataSource database):base(database)
    {
        _queri = _queryStart; 

    }
    
    public async void Query()
    {
        ConstructQuery();
        Console.WriteLine(_queri);
        await using (var cmd = _database.CreateCommand(_queri)) // Skapa vårt kommand/query
        await using (var reader = await cmd.ExecuteReaderAsync()) // Kör vår kommando/query och inväntar resultatet.
            while ( await reader.ReadAsync()) // Läser av 1 rad/objekt i taget ifrån resultatet och kommer avsluta loopen när det inte finns fler rader att läsa. 
            {
                Console.WriteLine($"Id: {reader.GetInt32(0)}, " +
                                  $"size: {reader.GetInt32(1)}," +
                                  $"location: {reader.GetInt32(2)}," +
                                  $"price per Day: {reader.GetDecimal(3)}");
            }
    }

    public void AddFacilityFilter(string facilty)
    {
        _facilityFilters.Add(facilty); 
    }
    private void ConstructQuery()
    {
        foreach (var facility in _facilityFilters)
        {
            if (_firstFilter)
            {
                _queri+=$" where id IN (select room from roomsxfacilities where facility IN "
                    + $"(select id from facilities where facilities.facility='{facility}'))";
                _firstFilter = false; 

            }
            else
            {
                _queri+=$" AND id IN (SELECT room FROM roomsxfacilities WHERE facility In "
                              + $"(select id from facilities where facilities.facility='{facility}'))";
            }
        }


        if (_ordered)
        {
            _queri += $"order by {_orderby}";
        }
        
    }

    public void Order(string Orderer)
    {
        _orderby = Orderer;
        _ordered = true; 
    }
    public void Order(string Orderer,bool desc)
    {
        _orderby = " "+Orderer;
        _ordered = true; 
        if (desc)
        {
            _orderby+=" desc"; 
        }
    }
    
    public void ResetQuery()
    {
        _queri = _queryStart;
    }

    public void ResetFilters()
    {
        _facilityFilters.Clear();
    }
}