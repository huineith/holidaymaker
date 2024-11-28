using System;

namespace app.Classes
{
    public class Guest
    {
        // Fält av Guest-klassen
        public int Id;
        public string Email;
        public string FirstName;
        public string LastName;
        public string Phone;
        public DateTime DateOfBirth;
        public DateTime RegDate;
        public bool Blocked;

        // Konstruktor för Guest
        public Guest(int id, string email, string firstName, string lastName, string phone, DateTime dateOfBirth, DateTime regDate, bool blocked)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            RegDate = regDate;
            Blocked = blocked;
        }
    }
}