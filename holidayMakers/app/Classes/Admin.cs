namespace app.Classes
{
    // Klass för att representera tabellen Admins
    public class Admin
    {
        public int Id;
        public string Username;
        public string Password;

        // Konstruktor för att initialisera fälten
        public Admin(int id, string username, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
        }
    }
}