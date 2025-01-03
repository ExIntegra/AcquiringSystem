using InterFaceModul.database;
using InterFaceModul.database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace InterFaceModul
{
    public partial class AddedClient : Form
    {
        private DatabaseServise _databaseServise;
        private Person _selectedPerson;
        bool Add = false;


        public AddedClient(DatabaseServise databaseServise)
        {
            _databaseServise = databaseServise;
            InitializeComponent();
            Add = true;
            addClientButton.Text = "Добавить";
        }

        public AddedClient(DatabaseServise databaseService, int SelectedIndex) //редактирование
        {
            InitializeComponent();

            _databaseServise = databaseService;

            Add = false;
            _selectedPerson = databaseService.GetPersonById(SelectedIndex);

            nameInput.Text = _selectedPerson.FirstName;
            lastNameInput.Text = _selectedPerson.LastName;
            middleNameInput.Text = _selectedPerson.MiddleName;
            phoneInput.Text = _selectedPerson.Phone;
            emailInput.Text = _selectedPerson.Email;
            if (_selectedPerson.Email != null)
            {
                passInput.Text = Convert.ToString(_selectedPerson.Pass);
            }
            else
            {
                emailInput.Text = null;
            }

            if (_selectedPerson.Age != null)
            {
                AgeInput.Text = Convert.ToString(_selectedPerson.Age);
            }
            else
            {
                AgeInput.Text = null;
            }

            if (_selectedPerson.INN != null)
            {
                INNInput.Text = Convert.ToString(_selectedPerson.INN);
            }
            else
            {
                INNInput.Text = null;
            }

            addClientButton.Text = "Изменить";
        }

        private void CancelClient_Click(object sender, EventArgs e) //отмена
        {
            Close();
        }

        private void addClientButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameInput.Text) ||
                string.IsNullOrWhiteSpace(lastNameInput.Text) ||
                string.IsNullOrWhiteSpace(phoneInput.Text) ||
                string.IsNullOrWhiteSpace(emailInput.Text) ||
                string.IsNullOrWhiteSpace(passInput.Text) ||
                string.IsNullOrWhiteSpace(AgeInput.Text) ||
                string.IsNullOrWhiteSpace(INNInput.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var validationResults = new List<ValidationResult>();
           AppDBContext context = new AppDBContext();
            Person person = new Person()
            {
                FirstName = nameInput.Text,
                LastName = lastNameInput.Text,
                MiddleName = middleNameInput.Text,
                Phone = phoneInput.Text,
                Email = emailInput.Text,
                Pass = passInput.Text,
                Age = AgeInput.Text,
                INN = INNInput.Text,
            };
                
            var validationContext = new ValidationContext(person);
            bool isValid = Validator.TryValidateObject(person, validationContext, validationResults, true);

            if (!isValid)
            {
                StringBuilder errorMessage = new StringBuilder("Please correct the following errors:\n");
                foreach (var validationResult in validationResults)
                {
                    errorMessage.AppendLine(validationResult.ErrorMessage);
                }
                MessageBox.Show(errorMessage.ToString(), "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                person.Id = _selectedPerson?.Id ?? 0;

                if(Add == true)
                {
                    _databaseServise.Add(person);
                    Close();
                }
                else
                {
                    _databaseServise.Update(person);
                    Close();
                }
            }
        }
    }
}
