using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            /*        private TextBox DateSetInput;
        private TextBox AdressInput;
        private TextBox pasportInput;
        private TextBox INNInput;
        private TextBox lastNameInput;
        private TextBox nameInput;
            */

            //Person person = new Person();
            string firstName = nameInput.Text;
            string lastName = lastNameInput.Text;
            string middleName = middleNameInput.Text;
            string pasport = pasportInput.Text;
            string INN = INNInput.Text;
            string phone = phoneInput.Text;
            string email = emailInput.Text;
            string age = AgeInput.Text;
            string DateOfBirth = DateOfBirthInput.Text;
            string format = "dd.MM.yyyy";
            DateTime dataValue;
            try
            {
                dataValue = DateTime.ParseExact(DateOfBirth, format, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ld");
            }

            //Person person = new Person(firstName, lastName, middleName, age, INN, phone, email, dataValue, email);
        }
    }
}
