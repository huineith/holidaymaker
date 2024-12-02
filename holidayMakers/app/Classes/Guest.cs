namespace app.Classes
{
    // Klass för att representera tabellen Guests
    public class Guest
    {
        public int Id;
        public string Email;
        public string FirstName;
        public string LastName;
        public string Phone;
        public DateTime DateOfBirth;
        public DateTime RegDate;
        public bool Blocked;

        // Konstruktor för att initialisera fälten
        public Guest(int id, string email, string firstName, string lastName, string phone, DateTime dateOfBirth, DateTime regDate, bool blocked)
        {
            this.Id = id;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.DateOfBirth = dateOfBirth;
            this.RegDate = regDate;
            this.Blocked = blocked;
        }
    }
}