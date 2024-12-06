// See https://aka.ms/new-console-template for more information

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

// var myquery = new Queries(myconnection); 
// var menuAddon = new AddonsMenu(myquery);
// await menuAddon.Load();
// await menuAddon.RunMenu(); 
