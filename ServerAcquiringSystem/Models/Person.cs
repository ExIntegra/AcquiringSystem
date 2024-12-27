using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceModul.Models
{
    internal class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }
        public string Age { get; }
        public string INN { get; }
        public string Phone { get; }
        public string Address { get; }
        public DateTime DateOfBirth { get; }
        public string Email { get; }

        public Person(string firstName, string lastName, string middleName, string age, string inn, string phone, string address, DateTime dateOfBirth, string Email)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Age = age;
            INN = inn;
            Phone = phone;
            Address = address;
            DateOfBirth = dateOfBirth;
            this.Email = Email;
        }
    }
}
