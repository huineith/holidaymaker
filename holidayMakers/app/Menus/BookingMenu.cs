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
    private List<Room> _rooms;
    private List<Booking> _bookings;
    private List<Guest> _guests;
    private List<addonXbooking> _addonXbooking;
    private List<Addon> _addons;

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
        _rooms = await _queries.GetRooms();
        _bookings = await _queries.ReadBookings();
        _guests = await _queries.ReadGuestToList();
        _addonXbooking = await _queries.ReadAddonXbooking();
        _addons = await _queries.ReadAddons();
        
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("THIS IS THE BOOKINGS MENU");
        Console.ResetColor();

        bool run = true;

        while (run)
        {
            Console.WriteLine($"   1. Create Booking(dont use)\u001b[0m");
            Console.WriteLine($"   2. List bookings\u001b[0m");
            Console.WriteLine($"   3. Show locations\u001b[0m");
            Console.WriteLine($"   4. Show rooms\u001b[0m");
            Console.WriteLine($"   5. Go back.");
            Console.WriteLine($"   6. Create booking.v2.");
            Console.WriteLine($"   7. Delete booking.v2.");
            
            
            Console.WriteLine("\n");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Clear();
                    
                    Console.WriteLine("What date would you like to check in? (enter YYYY-MM-DD");
                    DateTime newStartDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine(newStartDate);
                    Console.WriteLine("To when?");
                    DateTime newEndDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine(newEndDate);

                    foreach (var booking in _bookings)
                    {
                        
                    }
                    
                    for (int i = 0; i < LocationList.Count; i++)
                    {
                        Console.WriteLine($"{LocationList[i].Id}. {LocationList[i].Country} : {LocationList[i].Name}");
                        
                        
                    }
                    Console.WriteLine("\n Where do you want to go?");
                    int countryPick = int.Parse(Console.ReadLine());
                    foreach (var room in _rooms)
                    {
                        if (room._location == countryPick)
                        {
                            int totalPpl = 0;
                            Console.WriteLine($"id: {room._id}\n" +
                                              $"Rating: {room._rating}");
                            Console.WriteLine($"Price per night: {room._priceDay} USD");
                            
                            foreach (var location in LocationList)
                            {
                                if (location.Id == room._location)
                                {
                                    Console.WriteLine($"Country {location.Country}, City: {location.Name}");
                                    
                                }
                            }

                            foreach (var bed in bedXroomList)
                            {
                                if (bed.RoomId == room._id)
                                {
                                    foreach (var bedtype in _bedTypes)
                                    {
                                        if (bed.BedTypeId == bedtype.Id)
                                        {
                                            Console.WriteLine($"BedType: {bedtype.Type}, amount: {bed.Amount}");
                                            totalPpl += (bedtype.Persons * bed.Amount);
                                        }
                                    }

                                }
                            }
                            Console.WriteLine($"Total bedspots: {totalPpl}");
                            Console.WriteLine("________\n");
                        }
                        
                    }
                    Console.WriteLine("What room would you like to book?");
                    int pickedRoomId = int.Parse(Console.ReadLine());
                   
                    
                    break;
                case 2:

                    foreach (var booking in _bookings)
                    {
                        Console.WriteLine($"Booking ID: {booking._id}\n"+
                        $"Start: {booking._startDate.ToShortDateString()}\n"+
                        $"End: {booking._endDate.ToShortDateString()}\n");

                        foreach (var room in _rooms)
                        {
                            if (booking._room == room._id)
                            {
                                Console.WriteLine(
                                    
                                    $"Room ID: {room._id}\n"
                                );
                            }
                        }

                        foreach (var guest in _guests)
                        {
                                if (guest.Id == booking._guest)
                                {
                                    Console.WriteLine($"Guest: {guest.FirstName} , {guest.LastName}");
                                    
                                }
                        }

                        foreach (var addonX in _addonXbooking)
                        {
                            if (addonX._bookingId == booking._id)
                            {
                                foreach (var addon in _addons)
                                {
                                    if (addon._id == addonX._addonId)
                                    {
                                        Console.WriteLine($"Addon: {addon._name}, Price: {addon._price}USD/day");
                                    }
                                    
                                }
                            }
                        }
                        Console.WriteLine("_______________________");
                    }
                    
                    
                    break;
                case 3:
                    foreach (var location in LocationList)
                    {
                        Console.WriteLine($"{location.Id}. {location.Country}: Location: {location.Name}");
                    }

                    break;
                case 4:
                    foreach (var Room in _rooms)
                    {
                        int totalPpl = 0;
                        Console.WriteLine($"id: {Room._id}\n" +
                                          $"Rating: {Room._rating}");
                        Console.WriteLine($"Price per night: {Room._priceDay} USD");
                        foreach (var location in LocationList)
                        {
                            if (location.Id == Room._location)
                            {
                                Console.WriteLine($"Country {location.Country}, City: {location.Name}");
                            }
                        }

                        foreach (var bed in bedXroomList)
                        {
                            if(bed.RoomId == Room._id)
                            {
                                foreach (var bedtype in _bedTypes)
                                {
                                    if (bed.BedTypeId == bedtype.Id)
                                    {
                                        Console.WriteLine($"BedType: {bedtype.Type}, amount: {bed.Amount}");
                                        totalPpl += (bedtype.Persons * bed.Amount);
                                    }
                                }
                                
                            }
                        }
                        Console.WriteLine($"Total bedspots: {totalPpl}");
                        Console.WriteLine("________\n");
                    }
                    break;
                case 5:
                    run = false;
                    break;
                case 6:
                    
                    {
                        Console.Clear();
                        Console.WriteLine("CREATE BOOKING");

                        Console.Write("Admin ID: ");
                        int adminId = int.Parse(Console.ReadLine());  

                        Console.Write("Room ID: ");
                        int roomId = int.Parse(Console.ReadLine());  

                        Console.Write("Guest ID: ");
                        int guestId = int.Parse(Console.ReadLine());  

                        Console.Write("Start Date (yyyy-mm-dd): ");
                        DateTime startDate = DateTime.Parse(Console.ReadLine());  

                        Console.Write("End Date (yyyy-mm-dd): ");
                        DateTime endDate = DateTime.Parse(Console.ReadLine());   

                        await _queries.CreateBooking(adminId, roomId, guestId, startDate, endDate);  

                        Console.WriteLine("Booking created successfully.");  
                    }
                    break;
                
                case 7:
                    
                        Console.Clear();
                        Console.WriteLine("DELETE BOOKING");

                        Console.Write("Booking ID: ");
                        int bookingId = int.Parse(Console.ReadLine());  // Läser in boknings-ID från användaren och konverterar det till int

                        await _queries.DeleteBooking(bookingId);  // Anropar metoden för att ta bort bokningen

                        Console.WriteLine("Booking deleted successfully.");  
                        
                        Console.ReadKey();  // Väntar på att användaren trycker på en tangent innan den fortsätter
                        break;
            }
            run = false;
            break;
        }
    }
}
