﻿// See https://aka.ms/new-console-template for more information

using app;
using app.Classes;
using app.Menus;
using Npgsql;

Guest _guest;

Database mydb = new Database();
var myconnection = mydb.Connection(); 


MainMenu mainMenu = new MainMenu(myconnection);
bool run = true;
while (run)
{
    run = await mainMenu.RunMenu();
    
}

