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

        [Required (ErrorMessage ="Enter Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter LastName")]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Age { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string INN { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Pass { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
