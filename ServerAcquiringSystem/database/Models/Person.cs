using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceModul.database.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите отчество")]
        public string MiddleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите возраст")]
        public string Age { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите ИНН")]
        public string INN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите серию и номер паспорта без проблема")]
        public string Pass { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите телефон")]
        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите email")]
        public string Email { get; set; } = string.Empty;

        public int balance { get; set; } = 0;

        public string pincode { get; set; } = string.Empty;

        public int attemptCounter { get; set; } = 3;

        public bool statusTransactionCard { get; set; } = true;

        public string uid { get; set; } = string.Empty;
    }
}
