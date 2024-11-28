﻿// See https://aka.ms/new-console-template for more information

using app;
using app.Classes;
using app.Menus;
using Npgsql;

Guest _guest;

Database mydb = new Database();
var myconnection = mydb.Connection(); 

await using (var cmd= myconnection.CreateCommand("Select * from sights") )
await using (var reader = await cmd.ExecuteReaderAsync() )
    while (await reader.ReadAsync())
    {
        Console.WriteLine($"id:{reader.GetInt32(0)}, "+
                          $"sight:{reader.GetString(1)}, ");
            
    }



Queries _queries = new Queries(myconnection);

Guest johnny = await _queries.ReadGuestToObject();

Console.WriteLine($"{johnny.Id}, {johnny.Email}, {johnny.FirstName}, {johnny.DateOfBirth}");

Console.WriteLine("OSKAR TEST BRANCH");

MainMenu mainMenu = new MainMenu(_queries);

mainMenu.RunMenu();
