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
using System.Data.SqlClient;

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

        //The Shown event takes place after the form is first displayed on the screen
        private void Form1_Shown(object sender, EventArgs e)
        {
            Login();

            if (validLogin)
            {
                //Redraw the schedule
                s.Update();

                // Redraw appointments
            }
        }

        //The Paint event takes place any time the form is resized/minimized/maximized
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (validLogin)
            {
                //Redraw schedule
                s.Update();

                // Redraw appointments
            }
        }

        private List<Appointment> FindApptsThisWeek()
        {
            List<Appointment> apptList = new List<Appointment>();

            if ((int)DateTime.Today.DayOfWeek > 4)
            {

            }
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
            if (validLogin && apptGroupBox.Visible == false)
            {
                ShowApptBox();
            }
            else
            {
                HideApptBox();
            }


            LoadServices();



        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            HideApptBox();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            HideApptBox();
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

        private void userInfoButton_Click(object sender, EventArgs e)
        {
            if (validLogin)
            {
                //TODO: Show user info
            }
            else
            {
                Login();
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            if (validLogin)
            {
                nameLabel.Text = "";
                userInfoButton.Text = "&Log In";
                currentUser = null;
                logOutButton.Text = "E&xit";
                validLogin = false;
                HideButtons();
                s.Erase();
            }
            else
            {
                this.Close();
            }
        }

        private void ShowButtons()
        {
            settingsButton.Enabled = true;
            settingsButton.Visible = true;

            adminButton.Enabled = true;
            adminButton.Visible = true;

            apptButton.Enabled = true;
            apptButton.Visible = true;
        }

        private void HideButtons()
        {
            settingsButton.Enabled = false;
            settingsButton.Visible = false;

            adminButton.Enabled = false;
            adminButton.Visible = false;

            apptButton.Enabled = false;
            apptButton.Visible = false;
        }

        private void Login()
        {
            // Create and display login form
            LoginForm login = new LoginForm();

            // Start DialogBox
            login.ShowDialog(this);
            validLogin = login.ValidLogin;
            string username = login.Username;

            if (validLogin)
            {
                currentUser = new User(username);

                // Update name label and buttons
                nameLabel.Text = currentUser.FirstName + " " + currentUser.LastName;
                userInfoButton.Text = "Show &Info";
                logOutButton.Text = "&Log Out";

                //Enable buttons on the form
                ShowButtons();

                
            }

            login.Dispose();
        }

        private void LoadServices()
        {
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection("Server=tcp:75.177.127.12,1433;Initial Catalog=COSMETOLOGY;User ID=ctsadmin;Password=ctsPROJECT!");
            SqlParameter param = new SqlParameter();

            string queryString = "";

            queryString = "SELECT * FROM SALON_SERVICE;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(queryString, conn);

                rdr = cmd.ExecuteReader();

                List<string> results = new List<string>();
                while (rdr.Read())
                {
                    Service sCode = new Service();
                    servicesListBox.Items.Add(sCode.ServiceCode.ToString() + " " + sCode.ServiceName.ToString() + " " + sCode.Cost.ToString() + " " + sCode.EstimatedTime.ToString() + " " + sCode.CanOverlap.ToString());

                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Source: " + ex.Source + "\nMessage: " + ex.Message + "\nStackTrace: " + ex.StackTrace);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Source: " + ex.Source + "\nMessage: " + ex.Message + "\nStackTrace: " + ex.StackTrace);
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                if (conn != null)
                    conn.Close();
            }
        }

    }
}
