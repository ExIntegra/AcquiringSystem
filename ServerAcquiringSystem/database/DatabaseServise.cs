using InterFaceModul.database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceModul.database
{
    public class DatabaseServise
    {
        private AppDBContext _context;

        public DatabaseServise(AppDBContext context)
        {
            _context = context;
        }

        public Person GetPersonById(int id)
        {
            var data = (from item in _context.clients
                        where item.Id == (id + 1)
                        select item).FirstOrDefault();
            return data;
        }

        public void Add(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }

        public List<string> GetAllClientsPass()
        {
            var data = from item in _context.clients
                       select item.Pass;

            return data.ToList();
        }

        public void Delete(Person person)
        {
            _context.Remove(person);
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            var per = _context.clients.Find(person.Id);
            if (per != null)
            {
                per.FirstName = person.FirstName;
                per.LastName = person.LastName;
                per.MiddleName = person.MiddleName;
                per.Pass = person.Pass;
                per.Phone = person.Phone;
                per.Email = person.Email;
                per.Age = person.Age;
                per.Address = person.Address;
                per.INN = person.INN;

                _context.Update(per);
                _context.SaveChanges();
            }
        }
    }
}