using System.Threading.Channels;
using System.Xml.Xsl;

namespace app.Menus;

public class MainMenu
{
    private GuestMenu _guestMenu;
    private BookingMenu _bookingMenu;
    private Queries _queries;

    public MainMenu(Queries queries)
    {
        _guestMenu = new GuestMenu(this, queries);
        _bookingMenu = new BookingMenu(this, queries);
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
            Console.WriteLine($"   3. SearchMenu\u001b[0m");
            Console.WriteLine($"   4. Exit program.\u001b[0m");
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
                        
                        case 4:
                            Console.WriteLine("Exiting program!");
                            Console.WriteLine("Goodbye!");
                            return false;
                        
                    }
        }

        return true;
    }
}


    

        
        
    
    
