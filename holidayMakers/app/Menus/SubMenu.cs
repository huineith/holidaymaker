using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Classes;
using app.Database;

namespace app.Menus
{
    public class SubMenu
    {
        private readonly Queries _queries;

        // Konstruktor för att initiera queries
        public SubMenu(Queries queries)
        {
            _queries = queries;
        }

        // Metod för att registrera en ny gäst
        public async void RegisterGuestMenu()
        {
            Console.Clear();
            Console.WriteLine("REGISTER GUEST");

            Console.Write("Email: ");
            string email = Console.ReadLine();  // Läser in e-postadressen från användaren

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();  // Läser in förnamnet från användaren

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();  // Läser in efternamnet från användaren

            Console.Write("Phone: ");
            string phone = Console.ReadLine();  // Läser in telefonnumret från användaren

            Console.Write("Date of Birth (yyyy-mm-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());  // Läser in födelsedatumet och konverterar det till DateTime-format

            await _queries.RegisterGuest(email, firstName, lastName, phone, dateOfBirth);  // Anropar metoden för att registrera gästen

            Console.WriteLine("Guest registered successfully.");  // Visar en bekräftelsemeddelande
            Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
        }

        // Metod för att söka efter lediga rum
        public async void SearchAvailableRoomsMenu()
        {
            Console.Clear();
            Console.WriteLine("SEARCH AVAILABLE ROOMS");

            Console.Write("Start Date (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());  // Läser in startdatumet från användaren och konverterar det till DateTime-format

            Console.Write("End Date (yyyy-mm-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());  // Läser in slutdatumet från användaren och konverterar det till DateTime-format

            List<Room> rooms = await _queries.SearchAvailableRooms(startDate, endDate);  // Anropar metoden för att söka efter lediga rum

            Console.WriteLine("\nAvailable Rooms:");
            foreach (var room in rooms)  // Itererar genom listan av lediga rum
            {
                Console.WriteLine($"Room ID: {room.Id}, Size: {room.Size}, Location: {room.Location}, Price per Day: {room.PriceDay}, Rating: {room.Rating}");
                // Visar detaljer om varje rum
            }
            Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
        }

        // Metod för att skapa en ny bokning
        public async void CreateBookingMenu()
        {
            Console.Clear();
            Console.WriteLine("CREATE BOOKING");

            Console.Write("Admin ID: ");
            int adminId = int.Parse(Console.ReadLine());  // Läser in administratörens ID från användaren och konverterar det till int

            Console.Write("Room ID: ");
            int roomId = int.Parse(Console.ReadLine());  // Läser in rummets ID från användaren och konverterar det till int

            Console.Write("Guest ID: ");
            int guestId = int.Parse(Console.ReadLine());  // Läser in gästens ID från användaren och konverterar det till int

            Console.Write("Start Date (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());  // Läser in startdatumet från användaren och konverterar det till DateTime-format

            Console.Write("End Date (yyyy-mm-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());  // Läser in slutdatumet från användaren och konverterar det till DateTime-format

            await _queries.CreateBooking(adminId, roomId, guestId, startDate, endDate);  // Anropar metoden för att skapa en ny bokning

            Console.WriteLine("Booking created successfully.");  // Visar en bekräftelsemeddelande
            Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
        }


        // Metod för att hantera bokningar
        public void ManageBookingsMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("MANAGE BOOKINGS");
                Console.WriteLine("1. Add Booking Addon");
                Console.WriteLine("2. Update Booking");
                Console.WriteLine("3. Delete Booking");
                Console.WriteLine("4. Search Rooms by Distance to Beach");
                Console.WriteLine("5. Search Rooms by Distance to City Center");
                Console.WriteLine("6. Sort Rooms by Price");
                Console.WriteLine("7. Sort Rooms by Rating");
                Console.WriteLine("8. Describe Group");
                Console.WriteLine("9. Combined Search");
                Console.WriteLine("10. Back to Main Menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBookingAddonMenu();
                        break;
                    case "2":
                        UpdateBookingMenu();
                        break;
                    case "3":
                        DeleteBookingMenu();
                        break;
                    case "4":
                        SearchRoomsByDistanceToBeachMenu();
                        break;
                    case "5":
                        SearchRoomsByDistanceToCityCenterMenu();
                        break;
                    case "6":
                        SortRoomsByPriceMenu();
                        break;
                    case "7":
                        SortRoomsByRatingMenu();
                        break;
                    case "8":
                        DescribeGroupMenu();
                        break;
                    case "9":
                        CombinedSearchMenu();
                        break;
                    case "10":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        // Metod för att lägga till tillägg till en bokning
        public async void AddBookingAddonMenu()
        {
            Console.Clear();
            Console.WriteLine("ADD BOOKING ADDON");

            Console.Write("Booking ID: ");
            int bookingId = int.Parse(Console.ReadLine());  // Läser in boknings-ID från användaren och konverterar det till int

            Console.Write("Addon ID: ");
            int addonId = int.Parse(Console.ReadLine());  // Läser in tilläggs-ID från användaren och konverterar det till int

            Console.Write("Amount: ");
            int amount = int.Parse(Console.ReadLine());  // Läser in antalet från användaren och konverterar det till int

            await _queries.AddBookingAddon(bookingId, addonId, amount);  // Anropar metoden för att lägga till tillägg till bokningen

            Console.WriteLine("Booking addon added successfully.");  // Visar en bekräftelsemeddelande
            Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
        }

        // Metod för att uppdatera en bokning
        public async void UpdateBookingMenu()
        {
            Console.Clear();
            Console.WriteLine("UPDATE BOOKING");

            Console.Write("Booking ID: ");
            int bookingId = int.Parse(Console.ReadLine());  // Läser in boknings-ID från användaren och konverterar det till int

            Console.Write("New Start Date (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());  // Läser in nytt startdatum från användaren och konverterar det till DateTime-format

            Console.Write("New End Date (yyyy-mm-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());  // Läser in nytt slutdatum från användaren och konverterar det till DateTime-format

            await _queries.UpdateBooking(bookingId, startDate, endDate);  // Anropar metoden för att uppdatera bokningen

            Console.WriteLine("Booking updated successfully.");  // Visar en bekräftelsemeddelande
            Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
        }

        // Metod för att avboka
        public async void DeleteBookingMenu()
        {
            Console.Clear();
            Console.WriteLine("DELETE BOOKING");

            Console.Write("Booking ID: ");
            int bookingId = int.Parse(Console.ReadLine());  // Läser in boknings-ID från användaren och konverterar det till int

            await _queries.DeleteBooking(bookingId);  // Anropar metoden för att ta bort bokningen

            Console.WriteLine("Booking deleted successfully.");  // Visar en bekräftelsemeddelande
            Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
        }
    }
}

        // Metod för att söka på boenden baserat på avstånd till strand
        public async void SearchRoomsByDistanceToBeachMenu()
        {
            Console.Clear();
            Console.WriteLine("SEARCH ROOMS BY DISTANCE TO BEACH");

            Console.Write("Max Distance to Beach: ");
            int maxDistance = int.Parse(Console.ReadLine());  // Läser in max avstånd till stranden från användaren och konverterar det till int

            List<Room> rooms = await _queries.SearchRoomsByDistanceToBeach(maxDistance);  // Anropar metoden för att söka efter rum baserat på avstånd till stranden

            Console.WriteLine("\nRooms within distance to beach:");
            foreach (var room in rooms)  // Itererar genom listan av rum
            {
                Console.WriteLine($"Room ID: {room.Id}, Size: {room.Size}, Location: {room.Location}, Price per Day: {room.PriceDay}, Rating: {room.Rating}");
                // Visar detaljer om varje rum
            }
            Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
        }

        // Metod för att söka på boenden baserat på avstånd till centrum
        public async void SearchRoomsByDistanceToCityCenterMenu()
        {
            Console.Clear();
            Console.WriteLine("SEARCH ROOMS BY DISTANCE TO CITY CENTER");

            Console.Write("Max Distance to City Center: ");
            int maxDistance = int.Parse(Console.ReadLine());  // Läser in max avstånd till centrum från användaren och konverterar det till int

            List<Room> rooms = await _queries.SearchRoomsByDistanceToCityCenter(maxDistance);  // Anropar metoden för att söka efter rum baserat på avstånd till centrum

            Console.WriteLine("\nRooms within distance to city center:");
            foreach (var room in rooms)  // Itererar genom listan av rum
            {
                Console.WriteLine($"Room ID: {room.Id}, Size: {room.Size}, Location: {room.Location}, Price per Day: {room.PriceDay}, Rating: {room.Rating}");
                // Visar detaljer om varje rum
            }
            Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
        }

        // Metod för att sortera sökresultat på pris (lågt till högt)
        public async void SortRoomsByPriceMenu()
        {
            Console.Clear();
            Console.WriteLine("SORT ROOMS BY PRICE (LOW TO HIGH)");

            List<Room> rooms = await _queries.SortRoomsByPrice();  // Anropar metoden för att sortera rum efter pris

            Console.WriteLine("\nRooms sorted by price:");
            foreach (var room in rooms)  // Itererar genom listan av rum
            {
                Console.WriteLine($"Room ID: {room.Id}, Size: {room.Size}, Location: {room.Location}, Price per Day: {room.PriceDay}, Rating: {room.Rating}");
                // Visar detaljer om varje rum
            }
            Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
        }

        // Metod för att sortera sökresultat på omdöme (högt till lågt)
        public async void SortRoomsByRatingMenu()
        {
            Console.Clear();
            Console.WriteLine("SORT ROOMS BY RATING (HIGH TO LOW)");

            List<Room> rooms = await _queries.SortRoomsByRating();  // Anropar metoden för att sortera rum efter betyg

            Console.WriteLine("\nRooms sorted by rating:");
            foreach (var room in rooms)  // Itererar genom listan av rum
            {
                Console.WriteLine($"Room ID: {room.Id}, Size: {room.Size}, Location: {room.Location}, Price per Day: {room.PriceDay}, Rating: {room.Rating}");
                // Visar detaljer om varje rum
            }
            Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
        }

        // Metod för att beskriva sällskapet
        public async void DescribeGroupMenu()
        {
            Console.Clear();
            Console.WriteLine("DESCRIBE GROUP");

            Console.Write("Booking ID: ");
            int bookingId = int.Parse(Console.ReadLine());  // Läser in boknings-ID från användaren och konverterar det till int

            List<Guest> guests = await _queries.DescribeGroup(bookingId);  // Anropar metoden för att beskriva sällskapet

            Console.WriteLine("\nGroup Description:");
            foreach (var guest in guests)  // Itererar genom listan av gäster
            {
                Console.WriteLine($"First Name: {guest.FirstName}, Last Name: {guest.LastName}, Email: {guest.Email}, Phone: {guest.Phone}, Date of Birth: {guest.DateOfBirth}");
                // Visar detaljer om varje gäst
            }
            Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
        }

        // Metod för att kombinera alla sökkriterier
        public async void CombinedSearchMenu()
        {
            Console.Clear();
            Console.WriteLine("COMBINED SEARCH");

            Console.Write("Start Date (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());  // Läser in startdatum från användaren och konverterar det till DateTime-format

            Console.Write("End Date (yyyy-mm-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());  // Läser in slutdatum från användaren och konverterar det till DateTime-format

            Console.Write("Max Distance to Beach: ");
            int maxDistanceToBeach = int.Parse(Console.ReadLine());  // Läser in max avstånd till stranden från användaren och konverterar det till int

            Console.Write("Pool (true/false): ");
            bool pool = bool.Parse(Console.ReadLine());  // Läser in om pool önskas (true/false) och konverterar till bool

            Console.Write("Evening Entertainment (true/false): ");
            bool eveningEntertainment = bool.Parse(Console.ReadLine());  // Läser in om kvällsunderhållning önskas (true/false) och konverterar till bool

            Console.Write("Kids Club (true/false): ");
            bool kidsClub = bool.Parse(Console.ReadLine());  // Läser in om barnklubb önskas (true/false) och konverterar till bool

            Console.Write("Restaurant (true/false): ");
            bool restaurant = bool.Parse(Console.ReadLine());  // Läser in om restaurang önskas (true/false) och konverterar till bool

            List<Room> rooms = await _queries.CombinedSearch(startDate, endDate, maxDistanceToBeach, pool, eveningEntertainment, kidsClub, restaurant);  // Anropar metoden för kombinerad sökning

            Console.WriteLine("\nRooms matching all criteria:");
            foreach (var room in rooms)  // Itererar genom listan av rum
            {
                Console.WriteLine($"Room ID: {room.Id}, Size: {room.Size}, Location: {room.Location}, Price per Day: {room.PriceDay}, Rating: {room.Rating}");
                // Visar detaljer om varje rum
            }
            Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
        }
    }
}

