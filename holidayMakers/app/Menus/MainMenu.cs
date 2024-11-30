using System.Threading.Channels;
using System.Xml.Xsl;

namespace app.Menus;

public class MainMenu
{
    private GuestMenu _guestMenu;
    private SubMenu2 _subMenu2;
    private Queries _queries;

    public MainMenu(Queries queries)
    {
        _guestMenu = new GuestMenu(this, queries);
        _subMenu2 = new SubMenu2(this);
    }

    public async Task RunMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("THIS IS THE MAIN MENU");
        Console.ResetColor();
        
        bool run = true;
        
        while (run)
        {
            Console.WriteLine($"   1. Guests\u001b[0m");
            Console.WriteLine($"   2. Submenu2\u001b[0m");
            Console.WriteLine($"   3. Option 3\u001b[0m");
            Console.WriteLine($"   4. Option4\u001b[0m");
            Console.WriteLine("\n");
            int option = int.Parse(Console.ReadLine());
            
                    switch (option)
                    {
                        case 1:
                            await _guestMenu.RunMenu();
                            break;
                        case 2:
                            
                            _subMenu2.RunMenu();
                            break;
                        
                    }
                    run = false;
                    break;
        }
    }
}


    

        
        
    
    
