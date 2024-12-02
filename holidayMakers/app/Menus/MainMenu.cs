using System;
using app.Database;
using Npgsql;

namespace app.Menus
{
    public class MainMenu
    {
        private readonly Queries _queries;
        private readonly SubMenu _subMenu;

        // Konstruktor för att initiera queries och submenyer
        public MainMenu(NpgsqlDataSource database)
        {
            _queries = new Queries(database);
            _subMenu = new SubMenu(_queries);
        }

        // Metod för att köra huvudmenyn
        public void RunMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("1. Register Guest");
                Console.WriteLine("2. Search Available Rooms");
                Console.WriteLine("3. Create Booking");
                Console.WriteLine("4. Manage Bookings");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _subMenu.RegisterGuestMenu();
                        break;
                    case "2":
                        _subMenu.SearchAvailableRoomsMenu();
                        break;
                    case "3":
                        _subMenu.CreateBookingMenu();
                        break;
                    case "4":
                        _subMenu.ManageBookingsMenu();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}
