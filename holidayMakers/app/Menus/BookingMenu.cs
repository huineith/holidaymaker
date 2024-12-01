using app.Classes;

namespace app.Menus;


public class BookingMenu
{
    private MainMenu _mainMenu;
    private Location _location;
    private Queries _queries;
    public List<Location> LocationList = new ();
    public List<BedXRoom> bedXroomList= new ();
    private BedType _bedType;
    private List<BedType> _bedTypes;

    public BookingMenu(MainMenu mainMenu, Queries queries)
    {
        _mainMenu = mainMenu;
        _queries = queries;
    }

    public async Task RunMenu()
    {
        bedXroomList = await _queries.GetBedXrooms();
        LocationList = await _queries.ReadLocations();
        _bedTypes = await _queries.ReadBeds();
        
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("THIS IS THE BOOKINGS MENU");
        Console.ResetColor();

        bool run = true;

        while (run)
        {
            Console.WriteLine($"   1. Create Booking\u001b[0m");
            Console.WriteLine($"   2. List bookings\u001b[0m");
            Console.WriteLine($"   3. Show locations\u001b[0m");
            Console.WriteLine($"   4. Option4\u001b[0m");
            Console.WriteLine("\n");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    //WIP
                    break;
                case 2:

                    //WIP
                    break;
                case 3:
                    foreach (var location in LocationList)
                    {
                        Console.WriteLine($"{location.Id}. {location.Country}: Location: {location.Name}");
                    }

                    break;

            }

            run = false;
            break;
        }
    }
}
