// See https://aka.ms/new-console-template for more information

using app;
using Npgsql;

Console.WriteLine("Hello, World!");

Database mydb = new Database();
var myconnection = mydb.Connection();

var queryOnRoom = new RoomQueries(myconnection); 
    queryOnRoom.AddSightsFilter(Sights.Beach);
    queryOnRoom.AddSightsFilter(Sights.Beach,FilterTypes.SmallerThan,500);
    queryOnRoom.AddFacilityFilter(Facilities.Pool);
    // //queryOnRoom.AddFacilityFilter("Restaurant");
    // queryOnRoom.Order("id");
    queryOnRoom.Query();
    
    // await using (var cmd= myconnection.CreateCommand("Select * from sights") )
    // await using (var reader = await cmd.ExecuteReaderAsync() )
    //     while (await reader.ReadAsync())
    //     {
    //         Console.WriteLine($"id:{reader.GetInt32(0)}, "+
    //                           $"sight:{reader.GetString(1)}, ");
    //         
    //     }
