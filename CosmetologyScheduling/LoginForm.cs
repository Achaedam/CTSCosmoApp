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

namespace CosmetologyScheduling
{
    public partial class LoginForm : Form
    {
        bool validLogin = false;
        string username;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text.ToString() != "")
            {
                if (passwordTextBox.Text.ToString() != "")
                {
                    username = usernameTextBox.Text.ToString();
                    validLogin = Utilities.Authenticator.AttemptLogin(username, passwordTextBox.Text.ToString());

                    if (validLogin)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password was incorrect.", "Invalid Login Information");
                        usernameTextBox.Text = "";
                        passwordTextBox.Text = "";
                        usernameTextBox.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("You must enter a password.", "No Password Entered");
                }
            }
            else
            {
                MessageBox.Show("You must enter a username.", "No Username Entered");
            }
        }

        public bool ValidLogin
        {
            get { return validLogin; }
        }

        public string Username
        {
            get { return username; }
        }
    }
}
