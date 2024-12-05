using System.Threading.Channels;

namespace app;
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

    public async Task Load()
    {
        _addons =await _queries.ReadAddons();
    }

   public async Task RunMenu()
   {
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
            Console.WriteLine("\n \n");
            Console.WriteLine($"   1. List Bookings");
            Console.WriteLine($"   2. add Addons");
            Console.WriteLine($"   3. Alter Addons");
            Console.WriteLine($"   4. Remove Addons ");
            Console.WriteLine($"   5. Go back.");
            Console.WriteLine("\n");
            run = false; 
        }
        

    }

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
           Console.WriteLine($"   3. return To main Menu");
           
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
}