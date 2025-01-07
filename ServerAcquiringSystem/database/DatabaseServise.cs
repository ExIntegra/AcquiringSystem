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

        public Person GetPersonById(int id) //получение клиента по айди
        {
            Person data = _context.clients.ElementAt(id);
            return data;
        }

        public void Add(Person person) //добавление клиента
        {
            _context.clients.Add(person);
            _context.SaveChanges();
        }

        public List<string> GetAllClientsPass()
        {
            var data = from item in _context.clients select item.Passport;
            return data.ToList();
        }

        public void Delete(Person deletePerson) //удаление клиента
        {
            var per = _context.clients.Find(deletePerson.Id);
            if (per != null)
            {
                _context.clients.Remove(deletePerson);
                _context.SaveChanges();
            }
        }

        public void Update(Person person) //обновление данных клиента
        {
            var per = _context.clients.Find(person.Id);
            if (per != null) //если клиент найден
            {
                per.uid = person.uid;
                per.pincode = person.pincode;
                per.balance = person.balance;
                per.FirstName = person.FirstName;
                per.LastName = person.LastName;
                per.MiddleName = person.MiddleName;
                per.Passport = person.Passport;
                per.Phone = person.Phone;
                per.Email = person.Email;
                per.Age = person.Age;
                per.Address = person.Address;
                per.INN = person.INN;

                _context.clients.Update(per);
                _context.SaveChanges();
            }
        }

        public string transaction(string uid,       ///< uid уникальный номер банковской карты
                                  string pincode,   ///< пинкод карты
                                  int price)        ///< стоимость покупки
        {
            var per = _context.clients.FirstOrDefault(person => person.uid == uid); //ищем в БД клиента с uid, который поступает в серсис из терминала

            if (per != null) //если клиент найдет, то обрабатываем платеж
            {
                //если пинкод верный, стоимость меньше баланса, карта не заблокирована, то проводим оплату и возращаем accept
                if (pincode == per.pincode && price <= per.balance && per.statusTransactionCard)
                {
                    per.balance -= price;
                    _context.clients.Update(per);
                    _context.SaveChanges();
                    return "accept";
                }

                //если карта заблокирована, то оплата не происходит
                else if (per.statusTransactionCard == false) return "blocked";

                //если количество попыток ввода 0 или меньше, то блокируем карту для оплаты
                else if (per.attemptCounter <= 0)
                {
                    per.statusTransactionCard = false;
                    _context.clients.Update(per);
                    _context.SaveChanges();
                    return "blocked";
                }

                //ели неверный пинкод, то уменьшаем количество попыток ввода пинкода на одну
                else if (pincode != per.pincode)
                {
                    per.attemptCounter--;
                    _context.clients.Update(per);
                    _context.SaveChanges();
                    return "pincode";
                }

                //если не хватает денег на балансе
                else if (price > per.balance) return "money";

                //если ни одно условие не подошло
                else return "error";
            }
            else
            {
                return "error";
            }
        }
    }
}