using InterFaceModul.database.AppContext;
using InterFaceModul.database.Models;
using InterFaceModul.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace InterFaceModul
{
    public partial class AddedClient : Form
    {
        private DatabaseService _databaseService;
        private Person selectedPerson;
        bool Add = false;

        public AddedClient()
        {

            InitializeComponent();
        }

        public AddedClient(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            Add=true;
            addClientButton.Text = "Добавить";
        }
        public AddedClient(DatabaseService databaseService,int Selectedindex)
        {
            Add = false;
            InitializeComponent();
            _databaseService =databaseService;
            selectedPerson = new Person();
            selectedPerson= databaseService.GetPersonById(Selectedindex);
            nameInput.Text = selectedPerson.FirstName;
            lastNameInput.Text = selectedPerson.LastName;
            middleNameInput.Text = selectedPerson.MiddleName;
            passInput.Text = selectedPerson.Pass;
            phoneInput.Text = selectedPerson.Phone;
            emailInput.Text = selectedPerson.Email;
            AgeInput.Text = selectedPerson.Age;
            AdressInput.Text = selectedPerson.Address;
            INNInput.Text = selectedPerson.INN;

            addClientButton.Text = "Изменить";
            // Photo = "";
        }

        private void CancelClient_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addClientButton_Click(object sender, EventArgs e)
        {
            var validationResults = new List<ValidationResult>();
            LocalDbContext context = new LocalDbContext();
            Person person = new Person()
            {
                FirstName = nameInput.Text,
                LastName = lastNameInput.Text,
                MiddleName = middleNameInput.Text,
                Pass = passInput.Text,
                Phone = phoneInput.Text,
                Email = emailInput.Text,
                Age = AgeInput.Text,
                Address = AdressInput.Text,
                INN = INNInput.Text,
                Photo = "",
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
                MessageBox.Show(errorMessage.ToString(), "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                if (Add == true)
                    _databaseService.Add(person);
                else
                {
                    person.Id= selectedPerson.Id;
                    _databaseService.Update(person,selectedPerson.Id);
                }
                Close();

            }

        }
    }
}
