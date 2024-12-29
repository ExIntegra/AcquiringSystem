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

namespace InterFaceModul
{
    public partial class AddedClient : Form
    {
        public AddedClient()
        {
            InitializeComponent();
        }

        private void CancelClient_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addClientButton_Click(object sender, EventArgs e)
        {
            var validationResults = new List<ValidationResult>();
            ApplicationContext context = new ApplicationContext();
            Person person = new Person()
            {
                FirstName = nameInput.Text,
                LastName = lastNameInput.Text,
                MiddleName = middleNameInput.Text,
                Pass = passInput.Text,
                Phone = phoneInput.Text,
                Email = emailInput.Text,
                Age = AgeInput.Text,
                INN = INNInput.Text
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
                context.Add(person);
            }

        }
    }
}
