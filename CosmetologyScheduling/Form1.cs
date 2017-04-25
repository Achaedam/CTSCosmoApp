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
        // Objects necessary for form function
        Schedule s = new Schedule();
        bool validLogin;
        User currentUser;
        
        // List objects for loading Users and Services from DBMS
        List<User> stylistList;
        List<Service> serviceList;

        // Objects for creating appointments
        User apptStylist;
        Customer cust;
        Service apptServ;

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

        //The Resize event takes place any time the form is resized/minimized/maximized
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
            // Object declaration
            DateTime targetWeek;
            List<string> jobs = new List<string>();
            List<Appointment> apptList = new List<Appointment>();

            // Determining whether the work week (Tues-Thur) is over
            if ((int)DateTime.Today.DayOfWeek > 4)
            {
                targetWeek = FindNextSunday();
            }
            else
            {
                targetWeek = FindThisSunday();
            }

            // Creating SqlConnection and SqlReader objects for database query
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection("Server=tcp:cts.chiltonit.com,1433;Initial Catalog=COSMETOLOGY;User ID=ctsuser;Password=ctsPROJECT!");
            // String to find appointments from the selected week
            string queryString = "SELECT JobNumber from APPOINTMENT WHERE StartTime>@start AND StartTime<@end;";

            try
            {
                // Beginning SqlConnection
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

            // Adding appointment objects to apptList
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
                app.Draw(s, FindColorByStylist(app));
            }
        }

        private Color FindColorByStylist(Appointment app)
        {
            // This method creates a unique RGB color for each stylist based on their username
            // The R value is the int value of the first character
            // The G value is the int value of the last character
            // The B value is the int value of the sum of all the characters, mod 256 (my favorite one)

            int index = 0;

            foreach (User stylist in stylistList)
            {
                if (stylist.Username == app.Stylist.Username)
                {
                    index = stylistList.IndexOf(stylist);
                }
            }

            int r = (int)stylistList[index].Username.ToCharArray()[0];
            int g = (int)stylistList[index].Username.ToCharArray()[stylistList[index].Username.ToCharArray().Length - 1];
            int b = 0;
            for (int i = 0; i < stylistList[index].Username.ToCharArray().Length; i++)
            {
                b += (int)stylistList[index].Username.ToCharArray()[i];
            }

            b = b % 256;

            return Color.FromArgb(178, r, g, b);
        }

        private DateTime FindNextSunday()
        {
            DateTime finish = DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek); // Math to find the date of next Sunday
            return finish;
        }

        private DateTime FindThisSunday()
        {
            DateTime finish = DateTime.Today.AddDays((int)DateTime.Today.DayOfWeek * -1); // Math to find the date of last Sunday
            return finish;
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

            // Clearing all entries in the apptGroupBox
            stylistDropDown.SelectedIndex = -1;
            cust = null;
            apptStylist = null;
            apptServ = null;
            customerNameTextBox.Text = "";
            servicesListBox.SelectedIndex = -1;
            stationComboBox.SelectedIndex = -1;
            empObservingTextBox.Text = "";

            // Updating the schedule and appointments drawn on the form
            s.Update();
            DrawAppointments(FindApptsThisWeek());
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
            // This method creates a new appointment object, assigns the necessary values, and sends it to the database
            Appointment appt = new Appointment();

            appt.Stylist = apptStylist;
            appt.Cust = cust;
            appt.Serv = apptServ;
            appt.StartTime = startDatePicker.Value.Date.Add(startTimePicker.Value.TimeOfDay);
            appt.StationNumber = Convert.ToInt32(stationComboBox.Items[stationComboBox.SelectedIndex]);
            appt.EmployeeObserving = empObservingTextBox.Text.ToString();

            if (appt.SendToDB()) // The Appointment.SendToDB() method returns true if the command completed successfully
            {
                HideApptBox();
            }
            else
            {
                MessageBox.Show("Error communicating with server. Please try again later.");
            }

            

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            HideApptBox();
        }

        private void searchCustButton_Click(object sender, EventArgs e)
        {
            // This method creates a new instance of the CustLookup form and saves the data from the form
            CustLookup custLookup = new CustLookup();

            custLookup.ShowDialog();

            cust = custLookup.Cust;
            if (cust != null) // In the event that the Cancel button is hit, cust will be null
                customerNameTextBox.Text = cust.FirstName + " " + cust.LastName;

            custLookup.Dispose();
        }

        private void userInfoButton_Click(object sender, EventArgs e)
        {
            // This method handles the userInfo/Login buttons. They are the same button under different conditions

            if (validLogin)
            {
                MessageBox.Show("Name: " + currentUser.FirstName + " " + currentUser.LastName +
                                "\nUsername: " + currentUser.Username +
                                "\nID Number: " + currentUser.IDNumber +
                                "\nStylist: " + currentUser.IsStylist.ToString() +
                                "\nAdmin: " + currentUser.IsAdmin.ToString());
            }
            else
            {
                Login();
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            // This method handles the logout/exit buttons
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
            // This method queries the database for all current stylists
            if (stylistList == null)
            {
                SqlDataReader rdr = null;
                SqlConnection conn = new SqlConnection("Server=tcp:cts.chiltonit.com,1433;Initial Catalog=COSMETOLOGY;User ID=ctsuser;Password=ctsPROJECT!");
                SqlParameter param = new SqlParameter();

                string queryString = "";

                queryString = "SELECT * FROM EMPLOYEE;";

                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(queryString, conn);

                    rdr = cmd.ExecuteReader();

                    stylistList = new List<User>();
                    while (rdr.Read())
                    {
                        stylistList.Add(new User(rdr[0].ToString()));
                    }

                    foreach (User stylistName in stylistList)
                    {
                        stylistDropDown.Items.Add(stylistName.FirstName + " " + stylistName.LastName);
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

        private void LoadServices()
        {
            // This method queries the database for all current services
            if (serviceList == null)
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

                    serviceList = new List<Service>();
                    while (rdr.Read())
                    {
                        serviceList.Add(new Service(rdr[0].ToString()));
                    }

                    foreach (Service sCode in serviceList)
                    {
                        servicesListBox.Items.Add(sCode.ServiceName.ToString());
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

        private void createCustButton_Click(object sender, EventArgs e)
        {
            // This method creates a new instance of the CustCreate form
            CustCreate custCreate = new CustCreate();

            custCreate.ShowDialog();

            cust = custCreate.NewCust;
            if (cust != null) // In the event that the cancel button is pressed, cust will be null
                customerNameTextBox.Text = cust.FirstName + " " + cust.LastName;
    
            custCreate.Dispose();
        }

        private void stylistDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stylistDropDown.SelectedIndex > -1)
                apptStylist = stylistList[stylistDropDown.SelectedIndex];
        }

        private void servicesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (servicesListBox.SelectedIndex > -1)
                apptServ = serviceList[servicesListBox.SelectedIndex];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // This method loads the services and stylists before the form appears on screen
            // Possible cause of lag before shown event
            LoadServices();
            LoadStylist();

            startDatePicker.Value = DateTime.Now;
            startTimePicker.Value = DateTime.Now;
        }
    }
}
