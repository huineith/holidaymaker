using System.Threading.Channels;
using System.Xml.Xsl;

namespace app.Menus;

public class MainMenu
{
    private SubMenu1 _subMenu1;
    private SubMenu2 _subMenu2;

    public MainMenu()
    {
        _subMenu1 = new SubMenu1(this);
        _subMenu2 = new SubMenu2(this);
    }

    public void RunMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("THIS IS THE MAIN MENU");
        Console.ResetColor();

        ConsoleKeyInfo key;
        int option = 1;
        bool run = true;
        (int Left, int Top) = Console.GetCursorPosition();
        string arrow ="===>\u001b[32m";
        
        while (run)
        {
            
            Console.SetCursorPosition(Left,Top);
            
            Console.WriteLine("\nUse the Up and Down arrows to navigate, confirm by \u001b[32mEnter\u001b[0m.");
            Console.WriteLine($"{(option == 1 ? arrow : "    ")}   Submenu1\u001b[0m");
            Console.WriteLine($"{(option == 2 ? arrow : "    ")}   Submenu2\u001b[0m");
            Console.WriteLine($"{(option == 3 ? arrow : "    ")}   Option 3\u001b[0m");
            Console.WriteLine($"{(option == 4 ? arrow : "    ")}   Option4\u001b[0m");

            key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    option = (option == 4 ? 1 : option+1);
                    break;
                case ConsoleKey.UpArrow:
                    option = (option == 1 ? 4 : option-1);
                    break;
                case ConsoleKey.Enter:
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            _subMenu2.RunMenu();
                            
                            break;
                        case 2:
                            Console.Clear();
                            _subMenu2.RunMenu();
                            break;
                        
                    }
                    run = false;
                    break;
            }
        }

        
        

    }

}
    

        
        
    
    
