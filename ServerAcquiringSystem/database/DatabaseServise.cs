using InterFaceModul.database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceModul.database
{
    internal class DatabaseServise
    {
        private ApplicationContext _context;
        private Person _person;

        public DatabaseServise(ApplicationContext contex)
        {
            _context = contex;
        }

        public void TakeModels(Person person)
        {   
            _person = person;
        }

        public void Add()
        {
            _context.Add(_person);
            _context.SaveChanges();
        }

        public void Delete() 
        {
            _context.Remove(_person);
            _context.SaveChanges();
        }

        public void Update()
        {
            _context.Update(_person);
            _context.SaveChanges();
        }
    }
}
