using System.Threading.Channels;
using app.Classes;

namespace app.Menus;

public class GuestMenu
{
    private MainMenu _mainMenu;

    private Queries _queries;
    public List<Guest> guestlist = new List<Guest>();

    public async void populateList()
    {
        guestlist = await _queries.ReadGuestToList();
    }
    
    
    


    public GuestMenu(MainMenu mainMenu, Queries queries)
    {
        _mainMenu = mainMenu;
        _queries = queries;
        
    }
    
    

    public void RunMenu()
    {
        populateList();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("THIS IS THE SUBMENU 1");
        
        
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
            Console.WriteLine($"{(option == 1 ? arrow : "    ")}   Print 10 guests\u001b[0m");
            Console.WriteLine($"{(option == 2 ? arrow : "    ")}   Create new guest\u001b[0m");
            Console.WriteLine($"{(option == 3 ? arrow : "    ")}   Print list of guests\u001b[0m");
            Console.WriteLine($"{(option == 4 ? arrow : "    ")}   Go back\u001b[0m");

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
                    switch (option)
                    {
                        case 1:
                            _queries.AllGuests();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Enter the guest info.");
                            Console.WriteLine("Email: ");
                            string email = Console.ReadLine();
                            Console.WriteLine("Firstname: ");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Lastname: ");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Phone Number");
                            string phoneNr = Console.ReadLine();
                            Console.WriteLine("Birth Date (YYYY-MM-DD: ");
                            string birthDateinput = Console.ReadLine();
                            if (DateTime.TryParseExact(birthDateinput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime birthDate))
                        {
                            Console.WriteLine("Date entered correctly");
                            
                        }
                            else
                            {
                                Console.WriteLine("Invalid date format, use YYYY-MM-DD");
                            }
                            DateTime regDate = DateTime.Now;
                            
                            
                            break;
                        case 3:
                            foreach (var guest in guestlist)
                            {
                                Console.WriteLine($"{guest.Id}, {guest.Email}, {guest.FirstName}, {guest.LastName}, {guest.Phone}, {guest.DateOfBirth}, {guest.Blocked}");
                            }

                            break;
                        case 4:
                            Console.Clear();
                            _mainMenu.RunMenu();
                            break;
                    }
                    {
                        
                    }
                    run = false;
                    break;
            }
        }

        Console.WriteLine($"You have selected option {option}.");
        
    }
}