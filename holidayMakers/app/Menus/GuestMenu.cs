using System.Threading.Channels;
using app.Classes;

namespace app.Menus;

public class GuestMenu
{
    private MainMenu _mainMenu;

    private Guest _guest;

    private Queries _queries;
    public List<Guest> guestlist = new List<Guest>();

    public async Task populateList()
    {
        guestlist = await _queries.ReadGuestToList();
    }


    public GuestMenu(MainMenu mainMenu, Queries queries)
    {
        _mainMenu = mainMenu;
        _queries = queries;
        _guest = new Guest(0, "", "", "", "", "", DateTime.Now, "", queries);

    }



    public async Task RunMenu()
    {
        await populateList();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("THIS IS THE GUEST MENU");
        Console.ResetColor();
        
        bool run = true;
        
        while (run)
        {
            Console.WriteLine($"    1. Alter guests\u001b[0m");
            Console.WriteLine($"    2. Create new guest\u001b[0m");
            Console.WriteLine($"    3. Print list of guests\u001b[0m");
            Console.WriteLine($"    4. Go back to main menu\u001b[0m");
            int option = int.Parse(Console.ReadLine());
            
                    switch (option)
                    {
                        case 1: 
                            Console.Clear();
                            bool altered = await _guest.AlterGuest(guestlist);
                            if (altered)
                            {
                                Console.WriteLine("Guest data has been altered. Returning to the main menu...");
                                await Task.Delay(1000); 
                                run = false; 
                            }

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
                            Console.WriteLine("Birth Date (YYYY-MM-DD): ");
                            string birthDateInput = Console.ReadLine();

                            if (DateTime.TryParseExact(birthDateInput, "yyyy-MM-dd", null,
                                    System.Globalization.DateTimeStyles.None, out DateTime birthDate))
                            {
                                DateTime regDate = DateTime.Now;
                                _queries.AddNewGuest(email, firstName, lastName, phoneNr, birthDate, regDate);
                                guestlist.Add(_queries.GetLatestGuest());
                                Console.WriteLine("New guest created successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid date format, use YYYY-MM-DD.");
                            }

                            break;
                        case 3: // Print list of guests
                            Console.Clear();
                            foreach (var guest in guestlist)
                            {
                                Console.WriteLine(
                                    $"{guest.Id}, {guest.Email}, {guest.FirstName}, {guest.LastName}, {guest.Phone}, {guest.DateOfBirth}, {guest.Blocked}");
                            }
                            break;
                        case 4: 
                            run = false; 
                            break;
                    }

                    break;
        }
    }
}
