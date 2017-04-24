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
        
        List<User> stylistList;
        List<Service> serviceList;

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
                app.Draw(s, FindColorByStylist(app));
            }
        }

        private Color FindColorByStylist(Appointment app)
        {
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

            return Color.FromArgb(r, g, b);
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
        }

        private void HideApptBox()
        {
            apptGroupBox.Enabled = false;
            apptGroupBox.Visible = false;
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
            Appointment appt = new Appointment();

            appt.Stylist = apptStylist;
            appt.Cust = cust;
            appt.Serv = apptServ;
            appt.StartTime = startDatePicker.Value.Date.Add(startTimePicker.Value.TimeOfDay);
            appt.StationNumber = Convert.ToInt32(stationComboBox.Items[stationComboBox.SelectedIndex]);
            appt.EmployeeObserving = empObservingTextBox.Text.ToString();

            if (appt.SendToDB())
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
            CustLookup custLookup = new CustLookup();

            custLookup.ShowDialog();

            cust = custLookup.Cust;
            customerNameTextBox.Text = cust.FirstName + " " + cust.LastName;

            custLookup.Dispose();
        }

        private void userInfoButton_Click(object sender, EventArgs e)
        {
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
            CustCreate custCreate = new CustCreate();

            custCreate.ShowDialog();

            cust = custCreate.NewCust;
            customerNameTextBox.Text = cust.FirstName + " " + cust.LastName;

            custCreate.Dispose();
        }

        private void stylistDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            apptStylist = stylistList[stylistDropDown.SelectedIndex];
        }

        private void servicesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            apptServ = serviceList[servicesListBox.SelectedIndex];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadServices();
            LoadStylist();

            startDatePicker.Value = DateTime.Now;
            startTimePicker.Value = DateTime.Now;
        }
    }
}
