// See https://aka.ms/new-console-template for more information

using app;
using Npgsql;
using System.Collections; 

Console.WriteLine("Hello, World!");

Database mydb = new Database();
var myconnection = mydb.Connection();

var Menu = new RoomSearchMenu(myconnection);
await Menu.Run(); 

// Console.WriteLine("give holiday start yyyy-MM-dd HH:mm ");
// String holidayStart = Console.ReadLine(); 
// String holidayStart = "2024-12-05";  
// Console.WriteLine("give holiday end 'yyyy-MM-dd HH:mm' ");
// String holidayEnd = Console.ReadLine(); 
// String holidayEnd = "2024-12-07"; 




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



