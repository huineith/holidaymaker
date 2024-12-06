using System.Threading.Channels;

namespace app.Menus;
using app.Classes;


public class AddonsMenu
{
    private Queries _queries;
    private List<Addon> _addons;
    private List<Booking> _guestBookings; 
    private List<addonXbooking> _bookingAddons;
 
    public AddonsMenu(Queries queries)
    {
        _queries = queries; 
    }

    

   public async Task RunMenu()
   {
       _addons =await _queries.ReadAddons();
       bool run = true; 
       
       Console.Clear();
       int guestId = await _ObtainGuestId();
       if (guestId == -1)
       {
           run = false; 
       }
       else
       {
           _guestBookings = await _queries.ReadGuestBookings(guestId);
       } 
        
        while (run)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("THIS IS THE Addon MENU");
            Console.ResetColor();
            Console.WriteLine($"   1. List Bookings");
            Console.WriteLine($"   2. add Addons");
            Console.WriteLine($"   3. Alter Addons");
            Console.WriteLine($"   4. Remove Addons ");
            Console.WriteLine($"   5. Go back.");
            Console.WriteLine("\n");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {case 1:
                    Console.WriteLine("--------------------------------------------------------------------");
                foreach (var booking in _guestBookings)
                {
                    Console.WriteLine($"Booking id: {booking._id }, room id:{booking._room}, booking start:{booking._startDate.ToString("yyyy-MM-dd hh:mm")},booking end:{booking._endDate.ToString("yyyy-MM-dd hh:mm")}   ");
                }

                Console.WriteLine("--------------------------------------------------------------------");
                break;
            case 2:

                int choosenBooking = _GetBookingId();
                bool correctBookingId = _guestBookings.Exists(x => x._id == choosenBooking);
                if (!correctBookingId && choosenBooking > 0)
                {
                    Console.WriteLine("in correct booking id");   
                }
                
                if (correctBookingId)
                {
                   Console.WriteLine("choose addOn by id");
                   _PrintAddOnsList();
                    int choosenAddon= int.Parse(Console.ReadLine());

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine($"How many {_addons[choosenAddon-1]._name} would you like to add?");
                    int choosenAmount=int.Parse(Console.ReadLine());

                    _queries.AddNewAddon(choosenBooking, choosenAddon, choosenAmount); 
                    
                    Console.WriteLine("extra choices booked");
                }
                break;
            case 3:
                choosenBooking = _GetBookingId(); 
                correctBookingId = _guestBookings.Exists(x => x._id == choosenBooking);
                if (!correctBookingId && choosenBooking > 0)
                { Console.WriteLine("in correct booking id");   
                }
                
                if (correctBookingId)
                {
                    _bookingAddons = await _queries.ReadAddonsOfBooking(choosenBooking);
                    foreach (var addon in _bookingAddons) 
                    { 
                        Console.WriteLine($"id:{addon._addonId} addon:{_addons[addon._addonId-1]._name} ,amount:{addon._amount} ");    
                    }
                    Console.WriteLine("choose addon by id:\n  -1 to abort");
                    int addonIdToAlter=int.Parse(Console.ReadLine());
                    if (addonIdToAlter < 0) { }
                    else
                    {
                        Console.WriteLine("change amount to:");
                        int alteredAmount=int.Parse(Console.ReadLine());
                        await _queries.ChangeAddonData(choosenBooking,addonIdToAlter,alteredAmount);
                        
                    }
                }
                
                break; 
            case 4: 
                choosenBooking = _GetBookingId(); 
                correctBookingId = _guestBookings.Exists(x => x._id == choosenBooking);
                if (!correctBookingId && choosenBooking > 0)
                { Console.WriteLine("in correct booking id");   
                }

                if (correctBookingId)
                {
                    _bookingAddons = await _queries.ReadAddonsOfBooking(choosenBooking);
                    foreach (var addon in _bookingAddons) 
                    { 
                        Console.WriteLine($"id:{addon._addonId} addon:{_addons[addon._addonId-1]} ,amount:{addon._amount} ");    
                    }
                    Console.WriteLine("choose addon by id:\n  -1 to abort");
                    int addonToDelete=int.Parse(Console.ReadLine());
                    if (addonToDelete < 0) { }
                    else
                    {
                        _queries.DeleteAddon(choosenBooking, addonToDelete);
                    }
                }
                break; 
            case 5:
                run = false; 
                break; 
            }
        
        }
        

    }

   
   
   
   
   
   
   
   
   
   
   //-------------------------------------------------------------------------------------------------
   private async Task<int> _ObtainGuestId()
   {
       
       var guestList =await _queries.ReadGuestToList();
       int guestId=-1;
       bool badInput;
       do
       {
           badInput = false;
           Console.WriteLine($"  Select Guest By: ");
           Console.WriteLine($"   1. by Guest Id");
           Console.WriteLine($"   2. by Email");
           Console.WriteLine($"   3. return to main menu");
           
           int option = int.Parse(Console.ReadLine());
           Console.Clear();

           switch (option)
           {
               case 1:
                   Console.WriteLine("\n input Guest Id");
                   guestId=int.Parse(Console.ReadLine());
                   if (!guestList.Exists(x => x.Id == guestId))
                   {
                       badInput = true;
                       Console.WriteLine($"{guestId} is not a valid guest id");
                   } 
                   break; 
               case 2:
                   badInput = true; 
                   Console.WriteLine("\n input email");
                   var email=Console.ReadLine();
                   foreach (var guest in guestList)
                   {
                       if (guest.Email == email)
                       {
                           guestId = guest.Id;
                           badInput = false;
                       }
                   }

                   if (badInput)
                   {
                       Console.WriteLine($"{email} is not a valid guest email");
                   }
                   break; 
               
               case 3:
                   guestId = -1; 
                   break; 
           }
           
       } while (badInput);

       return guestId; 
   }

   private int _GetBookingId()
   {
       string bookingIdstring = "bookings:"; 
       foreach (var booking in _guestBookings)
       {
           bookingIdstring += $"{booking._id}, ";
       }
       Console.WriteLine("Select booking");
       Console.WriteLine(bookingIdstring);
       Console.WriteLine("select -1 to abort:");
       int choosenBooking = int.Parse(Console.ReadLine());

       return choosenBooking; 
   }

   private void _PrintAddOnsList()
   {
       Console.WriteLine("-----------------------------------------");
       foreach (var addon in _addons)
       {
           Console.WriteLine($"id:{addon._id},addOn:{addon._name},price:{addon._price}"); 
       }
       Console.WriteLine("-----------------------------------------");
   }
}