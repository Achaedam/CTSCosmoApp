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
            username = usernameTextBox.Text.ToString();

            if (Utilities.Authenticator.AttemptLogin(username,passwordTextBox.Text.ToString()))
            {
                validLogin = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or Password was incorrect.","Invalid Login Information");
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
