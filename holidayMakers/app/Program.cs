// See https://aka.ms/new-console-template for more information

using app;
using Npgsql;
using System.Collections; 

Console.WriteLine("Hello, World!");

Database mydb = new Database();
var myconnection = mydb.Connection();

// Console.WriteLine("give holiday start yyyy-MM-dd HH:mm ");
// String holidayStart = Console.ReadLine(); 
String holidayStart = "2024-12-05";  
// Console.WriteLine("give holiday end 'yyyy-MM-dd HH:mm' ");
// String holidayEnd = Console.ReadLine(); 
String holidayEnd = "2024-12-07"; 


var roomTable = new RoomTable(myconnection,holidayStart,holidayEnd);

await roomTable._Load();

roomTable.AddFilter(new FacilityFilter(Facility.Pool)); 
roomTable.AddFilter(new SightsFilter(Sight.Beach, 300 ));
roomTable.PrintInfo();

roomTable.PrintFilterInfo();
// roomTable.RemoveFilter(2);
// roomTable.PrintInfo();

// List<int> myList = new List<int>() { 2, 1, 3 };
//
// myList.Sort((x,y)=> y.CompareTo(x));
//
// foreach (var i in myList)
// {
//     Console.WriteLine(i);
// }




// FacilityFilter myFirstFilter = new FacilityFilter();
// myFirstFilter.RequiredFacilities.Add(Facility.Pool);


// for (int i = 2; i < 5; i++)
// {
//     try
//     {
//         int a = dict[i]; 
//         Console.WriteLine($"val: {a}");
//     }
//     catch (KeyNotFoundException e)
//     {
//         Console.WriteLine("skip");
//     }
//
//  
// }



//
// var queryOnRoom = new RoomQueries(myconnection); 
//     // queryOnRoom.AddSightsFilter(Sights.Beach);
//     queryOnRoom.AddSightsFilter(Sights.Beach,FilterTypes.SmallerThan,500);
//     queryOnRoom.AddFacilityFilter(Facilities.Pool);
//     // //queryOnRoom.AddFacilityFilter("Restaurant");
//     // queryOnRoom.Order("id");
//     queryOnRoom.Query();
//     
    // await using (var cmd= myconnection.CreateCommand("Select * from sights") )
    // await using (var reader = await cmd.ExecuteReaderAsync() )
    //     while (await reader.ReadAsync())
    //     {
    //         Console.WriteLine($"id:{reader.GetInt32(0)}, "+
    //                           $"sight:{reader.GetString(1)}, ");
    //         
    //     }
