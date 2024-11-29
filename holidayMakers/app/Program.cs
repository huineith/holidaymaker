﻿// See https://aka.ms/new-console-template for more information

using app;
using app.Classes;
using app.Menus;
using Npgsql;

Guest _guest;

Database mydb = new Database();
var myconnection = mydb.Connection(); 


Queries _queries = new Queries(myconnection);

Console.WriteLine("OSKAR TEST BRANCH");

MainMenu mainMenu = new MainMenu(_queries);
bool run = true;
while (run)
{
    await mainMenu.RunMenu();
}