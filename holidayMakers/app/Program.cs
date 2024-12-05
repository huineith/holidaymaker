// See https://aka.ms/new-console-template for more information

using app.RoomSearch;
using app;
using Npgsql;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;

Console.WriteLine("Hello, World!");

EnvDatabase mydb = new EnvDatabase();
var myconnection = mydb.Connection();

var Menu = new RoomSearchMenu(myconnection);
await Menu.Run(); 

// Console.WriteLine("give holiday start yyyy-MM-dd HH:mm ");
// String holidayStart = Console.ReadLine(); 
// String holidayStart = "2024-12-05 12:00";  
// Console.WriteLine("give holiday end 'yyyy-MM-dd HH:mm' ");
// String holidayEnd = Console.ReadLine(); 
// String holidayEnd = "2025-01-07 11:00";




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



