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
        Customer cust;

        public Form1()
        {
            InitializeComponent();
        }

        //The Shown event takes place after the form is first displayed on the screen
        private void Form1_Shown(object sender, EventArgs e)
        {
            Login();

            FindApptsThisWeek();

            if (validLogin)
            {
                //Redraw the schedule
                s.Update();

                // Redraw appointments
                DrawAppointments(FindApptsThisWeek());
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
                DrawAppointments(FindApptsThisWeek());
            }
        }

        private List<Appointment> FindApptsThisWeek()
        {
            DateTime targetWeek;
            List<string> jobs = new List<string>();
            List<Appointment> apptList = new List<Appointment>();

            if ((int)DateTime.Today.DayOfWeek > 4)
            {
                targetWeek = FindNextSunday();
            }
            else
            {
                targetWeek = FindThisSunday();
            }

            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection("Server=tcp:cts.chiltonit.com,1433;Initial Catalog=COSMETOLOGY;User ID=ctsuser;Password=ctsPROJECT!");

            string queryString = "SELECT JobNumber from APPOINTMENT WHERE StartTime>@start AND StartTime<@end;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(queryString, conn);

                cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = targetWeek;
                cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = targetWeek.AddDays(5);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    jobs.Add(rdr[0].ToString());
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

            foreach (string value in jobs)
            {
                apptList.Add(new Appointment(int.Parse(value)));
            }

            return apptList;
        }

        private void DrawAppointments(List<Appointment> appList)
        {
            foreach (Appointment app in appList)
            {
                app.Draw(s);
            }
        }

        private DateTime FindNextSunday()
        {
            DateTime finish = DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek);
            return finish;
        }

        private DateTime FindThisSunday()
        {
            DateTime finish = DateTime.Today.AddDays((int)DateTime.Today.DayOfWeek * -1);
            return finish;
        }

        private void ShowApptBox()
        {
            apptGroupBox.Enabled = true;
            apptGroupBox.Visible = true;

            LoadServices();
            startDatePicker.Value = DateTime.Now;
            startTimePicker.Value = DateTime.Now;
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
                cust = custLookup.Cust;
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

        private void LoadStylist()
        {
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection("Server=tcp:cts.chiltonit.com,1433;Initial Catalog=COSMETOLOGY;User ID=ctsuser;Password=ctsPROJECT!");
            SqlParameter param = new SqlParameter();

            string queryString = "";

            queryString = "INSERT INTO APPOINTMENT ;";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(queryString, conn);

                rdr = cmd.ExecuteReader();

                List<string> results = new List<string>();
                while (rdr.Read())
                {
                    User stylistName = new User(rdr[0].ToString());
                    stylistDropDown.Items.Add(stylistName.FirstName + stylistName.LastName);
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

        private void LoadServices()
        {
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection("Server=tcp:cts.chiltonit.com,1433;Initial Catalog=COSMETOLOGY;User ID=ctsuser;Password=ctsPROJECT!");
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
                    Service sCode = new Service(Convert.ToString(rdr[0]));
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
