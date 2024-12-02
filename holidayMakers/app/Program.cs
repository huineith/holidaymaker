using app.Menus;
using app.Database;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skapar en ny databasanslutning med konfigurationen
            DatabaseConfig dbConfig = new DatabaseConfig("localhost", "5544", "postgres", "abc123", "postgres_connector");

            // Initialiserar huvudmenyn och kör den
            MainMenu mainMenu = new MainMenu(dbConfig.Connection());
            mainMenu.RunMenu();
        }
    }
}