namespace app.RoomSearch;
using Npgsql; 
public class RoomSearchMenu
{
    private RoomTable _roomInfoTable; 
    public RoomSearchMenu(NpgsqlDataSource database)
    {


        DateTime holidayStart = inputDateTime(DateTime.Now, "Input holiday start date yyyy-MM-dd HH:mm ");
        DateTime holidayEnd = inputDateTime(holidayStart, "Input holiday end date 'yyyy-MM-dd HH:mm' ");
        _roomInfoTable=new RoomTable(database, holidayStart, holidayEnd);
    }

    public async Task Run()
    {   
        var run = true;
        await _roomInfoTable.Load();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("THIS IS THE Room MENU");
        Console.ResetColor();
        
        
        while(run)
        {
            
        Console.WriteLine($"   1. Add Filter\u001b[0m");
        Console.WriteLine($"   2. List and Remove Filter\u001b[0m");
        Console.WriteLine($"   3. Remove All Filters\u001b[0m");
        Console.WriteLine($"   4. Order By\u001b[0m");
        Console.WriteLine($"   5. Show matching Rooms\u001b[0m");
        Console.WriteLine($"   6. Go back.");
        Console.WriteLine("\n");
        int option = int.Parse(Console.ReadLine());
        Console.Clear();
        
        switch (option)
        {
            case 1:
                bool runFiltersSubMenu = true;
                while (runFiltersSubMenu)
                {

                    
                    Console.WriteLine("Choose filter type\n");
                    Console.WriteLine($"   1. Location ");
                    Console.WriteLine($"   2. Sights ");
                    Console.WriteLine($"   3. Facilities");
                    Console.WriteLine($"   4. Group Size");
                    Console.WriteLine($"   5. Go back.");
                    Console.WriteLine("\n");
                    int filterType = int.Parse(Console.ReadLine());


                    int index;
                    switch (filterType)
                    { 
                        case 1:
                            Console.Clear();
                            index = 0;
                            Console.WriteLine("Locations:\n");
                            foreach (var location in _roomInfoTable.LocationList)
                            {
                                Console.WriteLine($"{index}. {location.InfoString()}");
                                index += 1;
                            }
                            Console.WriteLine("choose one location by index:");
                            int locationIndex = int.Parse(Console.ReadLine());
                            _roomInfoTable.AddFilter(new LocationFilter( _roomInfoTable.LocationList[locationIndex]));
                            Console.WriteLine("Filter added \n");
                            break;
                        case 2: 
                            Console.Clear();
                            index = 1;
                            Console.WriteLine("Sights:\n");
                            var sights = Enum.GetValues(typeof(Sight));
                            foreach (var sight in sights)
                            {
                                Console.WriteLine($"{index}. {sight}");
                                index += 1;
                            }
                            Console.WriteLine("choose a sight by index:");
                            int sightIndex = int.Parse(Console.ReadLine());
                            Console.WriteLine("give maximum acceptable distance from room in meters:");
                            double distance = double.Parse(Console.ReadLine());
                            _roomInfoTable.AddFilter(new SightsFilter((Sight)sightIndex, distance ));
                            Console.WriteLine("Filter added \n");
                            break; 
                        case 3: 
                            Console.Clear();
                            index = 1;
                            Console.WriteLine("Sights:\n");
                            var facilities = Enum.GetValues(typeof(Facility));
                            foreach (var fac in facilities)
                            {
                                Console.WriteLine($"{index}. {fac}");
                                index += 1;
                            }
                            Console.WriteLine("choose a facility by index:");
                            int facilityIndex = int.Parse(Console.ReadLine());
                            _roomInfoTable.AddFilter(new FacilityFilter((Facility)facilityIndex));
                            Console.WriteLine("Filter added \n");
                            break;
                        case 4: 
                            Console.Clear();
                            Console.WriteLine("Input group size");
                            int groupSize= int.Parse(Console.ReadLine());
                            _roomInfoTable.AddFilter(new GroupSizeFilter(groupSize));
                            break;
                        case 5:
                            runFiltersSubMenu = false;
                            Console.Clear();
                                
                            break;
                    }
                }

                break;
            case 2:
                Console.Clear();
                _roomInfoTable.PrintFilterInfo();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("choose filter to be removed by index, write -1 to go back");
                int filterRemovalIndex = int.Parse(Console.ReadLine());
                if (filterRemovalIndex < 0)
                {
                    
                }
                else
                {
                    _roomInfoTable.RemoveFilter(filterRemovalIndex);
                }
                break; 
            case 3:
                
                _roomInfoTable.ClearFilters();
                break;
            case 4:
                Console.Clear();
                Console.WriteLine("Order by");
                Console.WriteLine($"   1. Room Id");
                Console.WriteLine($"   2. Room price");
                Console.WriteLine($"   3. Room rating");
                Console.WriteLine($"   4. Go back.");
                Console.WriteLine("\n");
                int orderOption = int.Parse(Console.ReadLine());
                Console.Clear();
                string ansDesc;
                switch (orderOption)
                {
                    case 1: 
                    Console.WriteLine("Order in desending order y/n?");
                    ansDesc = Console.ReadLine();
                    if (ansDesc == "y" || ansDesc == "yes")
                    {
                        _roomInfoTable.OrderById(true);            
                    }
                    else
                    {
                        _roomInfoTable.OrderById();   
                    }
                    break;
                    case 2: 
                        Console.WriteLine("Order in desending order y/n?");
                        ansDesc = Console.ReadLine();
                        if (ansDesc == "y" || ansDesc == "yes")
                        {
                            _roomInfoTable.OrderByPrice(true);            
                        }
                        else
                        {
                            _roomInfoTable.OrderByPrice();   
                        }
                        break;
                        case 3: 
                        Console.WriteLine("Order in desending order y/n?");
                        ansDesc = Console.ReadLine();
                        if (ansDesc == "y" || ansDesc == "yes")
                        {
                            _roomInfoTable.OrderByRating(true);            
                        }
                        else
                        {
                            _roomInfoTable.OrderByRating();   
                        }
                        break;
                }
                break; 
            case 5:
                Console.WriteLine("\n \n");
                _roomInfoTable.PrintInfo();
                Console.WriteLine("-------------------------------------");
                break; 
            case 6: run = false;
                break; 
                
        }
        
        
        
        
        }

       

    }


    private DateTime inputDateTime(DateTime compareDate,string promptMessage)
    {
        bool inCorrectInput;
        DateTime date=DateTime.MinValue;//place holder Value 
        do
        {
            inCorrectInput = false;
            Console.WriteLine(promptMessage);
            String holidayStart = Console.ReadLine();
            try
            {
                date = DateTime.Parse(holidayStart);
                if (DateTime.Compare(date, compareDate) < 0)
                {
                    Console.WriteLine($"\n input a date later than {compareDate.ToString("yyyy-MM-dd hh:mm")}");
                    inCorrectInput = true;
                } ; 

            }
            catch (FormatException e)
            {
                Console.WriteLine("\n Please input in correct Format");
                inCorrectInput = true;
            }
        } while (inCorrectInput);

        return date; 
    }
    
    
}