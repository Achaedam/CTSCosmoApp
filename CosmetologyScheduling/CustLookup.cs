using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCCCosmetology;
using System.Data.SqlClient;

namespace CosmetologyScheduling
{
    public partial class CustLookup : Form
    {
        public CustLookup()
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection("Server=tcp:75.177.127.12,1433;Initial Catalog=COSMETOLOGY;User ID=ctsadmin;Password=ctsPROJECT!");
            SqlParameter param = new SqlParameter();

            string queryString = "";

            if (phoneTextBox.Text.ToString() != "")
            {
                string phone = FormatPhone(phoneTextBox.Text.ToString());

                queryString = "SELECT * FROM CUSTOMER WHERE CustPhone=@phone;";

                param.ParameterName = "@phone";
                param.Value = phone;
            }
            else if (emailTextBox.Text.ToString() != "")
            {
                string email = emailTextBox.Text.ToString();

                queryString = "SELECT * FROM CUSTOMER WHERE CustEmail=@email;";

                param.ParameterName = "@email";
                param.Value = email;
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(queryString, conn);

                cmd.Parameters.Add(param);

                rdr = cmd.ExecuteReader();

                List<string> results = new List<string>();
                while (rdr.Read())
                {
                    Customer cust = new Customer(Convert.ToInt32(rdr[0]));
                    custListBox.Items.Add(cust);
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
