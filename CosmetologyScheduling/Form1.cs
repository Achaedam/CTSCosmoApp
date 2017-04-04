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
    public partial class Form1 : Form
    {
        Schedule s = new Schedule();
        bool validLogin;
        User currentUser;

        public Form1()
        {
            InitializeComponent();
        }

        //The Shown even takes place after the form is first displayed on the screen
        private void Form1_Shown(object sender, EventArgs e)
        {
            // Create and display login form
            LoginForm login = new LoginForm();

            // Start DialogBox
            login.ShowDialog(this);
            validLogin = login.ValidLogin;
            currentUser = new User(login.Username);

            // Update name label
            nameLabel.Text = currentUser.FirstName + " " + currentUser.LastName;

            if (validLogin)
            {
                if (currentUser != null)
                    MessageBox.Show("You are logged in");

                //Redraw the schedule
                s.Update();
            }
        }

        //The Paint event takes place any time the form is resized/minimized/maximized
        private void Form1_Resize(object sender, EventArgs e)
        {
            //Redraw the schedule
            s.Update();
        }

        private void ShowApptBox()
        {
            apptGroupBox.Enabled = true;
            apptGroupBox.Visible = true;
        }

        private void HideApptBox()
        {
            apptGroupBox.Enabled = false;
            apptGroupBox.Visible = false;
            s.Update();
        }

        private void apptButton_Click(object sender, EventArgs e)
        {
            ShowApptBox();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            HideApptBox();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            HideApptBox();
        }

        private void DrawAppointment(Appointment app)
        {
            //TODO: Figure this out
        }

        private void searchCustButton_Click(object sender, EventArgs e)
        {
            CustLookup custLookup = new CustLookup();

            if (custLookup.ShowDialog(this) == DialogResult.OK)
            {

            }
            else
            {

            }

            custLookup.Dispose();
        }
    }
}
