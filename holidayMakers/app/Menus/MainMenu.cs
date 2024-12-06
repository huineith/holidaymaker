using System.Threading.Channels;
using System.Xml.Xsl;
using Npgsql;

namespace app.Menus;

public class MainMenu
{
    private GuestMenu _guestMenu;
    private BookingMenu _bookingMenu;
    private RoomSearchMenu _roomMenu;
    private AddonsMenu _addonsMenu;
    private Queries _queries;
    

    public MainMenu(NpgsqlDataSource database)
    {
        Queries queries = new Queries(database);
        _guestMenu = new GuestMenu(this, queries);
        _bookingMenu = new BookingMenu(this, queries);
        _roomMenu = new RoomSearchMenu(database);
        _addonsMenu = new AddonsMenu(queries);
        _queries = queries;
    }

    public async Task<bool> RunMenu()
    {
        
        bool run = true;
        
        while (run)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;  
            Console.WriteLine("THIS IS THE MAIN MENU");   
            Console.ResetColor();                         
            
            Console.WriteLine($"   1. Guests\u001b[0m");
            Console.WriteLine($"   2. Bookings\u001b[0m");
            Console.WriteLine($"   3. Search Rooms\u001b[0m");
            Console.WriteLine($"   4. Addons");
            Console.WriteLine($"   5. Exit program.\u001b[0m");
            Console.WriteLine("\n");
            int option = int.Parse(Console.ReadLine());
            
                    switch (option)
                    {
                        case 1:
                            await _guestMenu.RunMenu();
                            break;
                        case 2:
                            
                            await _bookingMenu.RunMenu();
                            break;
                        case 3:
                            await _roomMenu.RunMenu();
                            break;
                        case 4:
                            await _addonsMenu.RunMenu();
                            break;
                        case 5:
                            Console.WriteLine("Exiting program!");
                            Console.WriteLine("Goodbye!");
                            return false;
                        
                    }
        }

        return true;
    }
}


    

        
        
    
    
