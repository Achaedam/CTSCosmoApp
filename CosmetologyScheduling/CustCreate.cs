using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCCCosmetology;
using System.Text.RegularExpressions;

namespace CosmetologyScheduling
{
    public partial class CustCreate : Form
    {
        Customer newCust;
        public CustCreate()
        {
            InitializeComponent();
        }

        private string FormatPhone(string phone)
        {
            //Creates a Regular Expression to remove symbols from phone number
            Regex rgx = new Regex("[() -]");
            string phoneFixed = rgx.Replace(phone, "");

            //Returns the fixed phone number
            return phoneFixed;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string phone = FormatPhone(phoneTextBox.Text.ToString());

            if (!string.IsNullOrEmpty(firstNameTextBox.Text.ToString()))
            {
                if (!string.IsNullOrEmpty(lastNameTextBox.Text.ToString()))
                {
                    if (!string.IsNullOrEmpty(phone))
                    {
                        newCust = new Customer();

                        newCust.FirstName = firstNameTextBox.Text.ToString();
                        newCust.LastName = lastNameTextBox.Text.ToString();
                        newCust.Phone = phone;
                        newCust.Email = emailTextBox.Text.ToString();
                        newCust.Address = addressTextBox.Text.ToString();
                        newCust.City = cityTextBox.Text.ToString();
                        newCust.State = stateTextBox.Text.ToString();
                        newCust.Zip = zipTextBox.Text.ToString();

                        if (newCust.SendToDB())
                        {
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("There was an error in communicating with the database. Please try again later.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phone Number field is required.");
                    }
                }
                else
                {
                    MessageBox.Show("Last Name field is required.");
                }
            }
            else
            {
                MessageBox.Show("First Name field is required.");
            }
        }

        public Customer NewCust
        {
            get { return newCust; }
        }
    }
}
