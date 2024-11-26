using System.Threading.Channels;
using System.Xml.Xsl;

namespace app.Menus;

public class MainMenu
{
    public MainMenu()
    {





    }

    public void RunMenu(MainMenu mainMenu)
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
            
            Console.WriteLine("\nUse the ⬆ and ⬇ to navigate, confirm by \u001b[32mEnter\u001b[0m.");
            Console.WriteLine($"{(option == 1 ? arrow : "    ")}   Option1\u001b[0m");
            Console.WriteLine($"{(option == 2 ? arrow : "    ")}   Option2\u001b[0m");
            Console.WriteLine($"{(option == 3 ? arrow : "    ")}   Option3\u001b[0m");
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
                    Console.WriteLine("WIP");
                    run = false;
                    break;
            }
        }

        Console.WriteLine($"You have selected option {option}.");
        

    }

}
    

        
        
    
    
