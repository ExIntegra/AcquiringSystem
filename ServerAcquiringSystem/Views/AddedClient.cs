using InterFaceModul.database.Models;
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
            ApplicationContext context = new ApplicationContext();
            context.Add(new Person()
            {
                FirstName = nameInput.Text,
                LastName = lastNameInput.Text,
                MiddleName = middleNameInput.Text,
                Pass = passInput.Text,
                Phone = phoneInput.Text,
                Email = emailInput.Text,
                Age = AgeInput.Text,
                INN = INNInput.Text
            });
        }
    }
}
