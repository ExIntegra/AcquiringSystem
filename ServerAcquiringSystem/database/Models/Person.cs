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
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина имени")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите фамилию")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина Фамилии")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите отчество")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Недопустимая длина Отчества")]

        public string MiddleName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите возраст")]
        [Range(4, 100, ErrorMessage = "Возраст от 4 до 100 лет")]
        public int Age { get; set; }

        [StringLength(12, MinimumLength = 12, ErrorMessage = "Длина ИНН 12 цифр")]
        [Required(ErrorMessage = "Введите ИНН")]
        public string INN { get; set; } = string.Empty;

        [StringLength(10, MinimumLength = 10, ErrorMessage = "Длина серии и номера паспорта 10 цифр")]
        [Required(ErrorMessage = "Введите серию и номер паспорта без проблема")]
        public string Passport { get; set; } = string.Empty;

        [Required(ErrorMessage = "Баланс")]
        [Range(0, 10000, ErrorMessage = "Баланс не меньше 0 и не больше 10000")]
        public int Balance { get; set; }

        [StringLength(4, MinimumLength = 4, ErrorMessage = "Длина пинкода 4 символа")]
        public string Pincode { get; set; } = string.Empty;

        public int AttemptCounter { get; set; } = 3;

        public bool StatusTransactionCard { get; set; } = true;

        [Required(ErrorMessage = "UID")]
        public string Uid { get; set; }
    }
}
