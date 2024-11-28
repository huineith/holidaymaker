namespace app.Classes
{
    public class Admin
    {
        // Fält av Admin-klassen
        public int Id;
        public string Username;
        public string Password;

        // Konstruktor för Admin
        public Admin(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
    }
}