using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceModul
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
        public string Email {  get; }

        public Person(string firstName, string lastName, string middleName, string age, string inn, string phone, string address, DateTime dateOfBirth, string Email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.Age = age;
            this.INN = inn;
            this.Phone = phone;
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
            this.Email = Email;
        }
    }
}
