using InterFaceModul.database.AppContext;
using InterFaceModul.database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace InterFaceModul.Services
{
    public class DatabaseService
    {
        private LocalDbContext _context; // локальная БД
        private Person _person;


        public DatabaseService(LocalDbContext context)
        {
            _context = context;
        }

        // Получение строки таблицы.
        // Входной параметр - первичный ключ, т.е. СУБД будет искать совпадение по Id= первичному ключу в БД.
        public Person GetPersonById(int id)
        {
            var person = new Person();
           var data = (from item in _context.persons
                      where item.Id == (id+1)
                      select item).ToList();

            return data[0]; // Про это костыль потом расскажу
        }

        // Получить всю таблицу БД в виде списка. Т.е каждый кортеж - это элемент коллекции.
        public List<Person> GetAllClients()
        {
            var data = from item in _context.persons
                       select item;
            return data.ToList();
        }


        // Вернуть коллекцию  <string> которая содержит только значение "Паспорт"
        public List<string> GetAllClientsPass()
        {
            var data = from item in _context.persons 
                       select item.Pass;

            return data.ToList();
        }

        // Добавить в БД
        public void Add(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }

        // Удалить из БД -> не реализовано, так что возможно не работает :)
        public void Delete(Person person)
        {
            _context.Remove(person);
            _context.SaveChanges();
        }

        // Изменить кортежь таблицы.
        // 
        public void Update(Person person,int Index)
        {
            var per = _context.persons.Find(Index);
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
                per.Photo = "";


                _context.Update(per);
                _context.SaveChanges();
            }
        }
    }
}
