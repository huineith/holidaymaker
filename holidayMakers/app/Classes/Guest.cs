using System;

namespace app.Classes
{
    public class Guest
    {
        
        public int Id;
        public string Email;
        public string FirstName;
        public string LastName;
        public string Phone;
        public string DateOfBirth;
        public DateTime RegDate;
        public string Blocked;

        
        public Guest(int id, string email, string firstName, string lastName, string phone, string dateOfBirth, DateTime regDate, string blocked)
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