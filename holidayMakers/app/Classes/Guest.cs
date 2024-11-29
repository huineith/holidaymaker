using System;
using System.ComponentModel.Design.Serialization;
using System.Threading.Channels;
using app.Menus;

namespace app.Classes
{
    public class Guest
    {
        public List<Guest> guests;
        public int Id;
        public string Email;
        public string FirstName;
        public string LastName;
        public string Phone;
        public string DateOfBirth;
        public DateTime RegDate;
        public string Blocked;
        
        public Queries Queries { get; set; } 

        
        public Guest(int id, string email, string firstName, string lastName, string phone, string dateOfBirth, DateTime regDate, string blocked, Queries queries = null)
        {
            Queries = queries;
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            RegDate = regDate;
            Blocked = blocked;
        }

        public int GuestIDbyEmail(List<Guest> guestlist,string email)
        {
            foreach (var _guest in guestlist)
            {
                if (_guest.Email == email)
                {
                    Console.WriteLine($"ID found!: {_guest.Id}");
                    return _guest.Id;
                }
            }

            throw new Exception();
        }

        public async Task<bool> AlterGuest(List<Guest> guestlist)
        {
            Console.WriteLine("Modify guest data\n");
            Console.WriteLine($"Number of guests in list: {guestlist.Count}");
            Console.WriteLine("Enter the email for the guest you wish to modify");
            string email = Console.ReadLine();

            foreach (var guest in guestlist)
            {
                if (guest.Email == email)
                {
                    Console.WriteLine("Guest found!\n");
                    Console.WriteLine($"id: {guest.Id}\n" +
                                      $"email {guest.Email}\n" +
                                      $"Name: {guest.FirstName}, {guest.LastName}\n" +
                                      $"phoneNr: {guest.Phone}\n" +
                                      $"RegDate: {guest.RegDate}\n" +
                                      $"BirthDate: {guest.DateOfBirth}\n" +
                                      $"Is blocked?: {guest.Blocked}\n"
                        );
                    Console.WriteLine("What data do you wish to change?");
                    Console.WriteLine("1. email\n" +
                                      "2. Phonenumber\n" +
                                      "3. Block user\n");
                    string option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":

                            Console.WriteLine("Enter the new email: ");
                            string newmail = Console.ReadLine();
                            await Queries.ChangeGuestData(guest.Id,newmail,"email");
                            return true;
                            
                        
                        case "2":
                            Console.WriteLine("Enter the new phonenumber");
                            string phonenr = Console.ReadLine();
                            await Queries.ChangeGuestData(guest.Id, phonenr, "phone");
                            return true;
                    }
                }
            }
            Console.WriteLine("Guest not found");
            return false;
        }
    }
}