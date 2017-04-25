// This file is an even mixture of both of us

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
        List<Customer> results;
        Customer cust;

        public CustLookup()
        {
            InitializeComponent();
        }

        // Anthony's code
        private string FormatPhone(string phone)
        {
            //Creates a Regular Expression to remove symbols from phone number
            Regex rgx = new Regex("[() -]");
            string phoneFixed = rgx.Replace(phone, "");

            //Returns the fixed phone number
            return phoneFixed;
        }

        // mostly anthony
        private void searchButton_Click(object sender, EventArgs e)
        {
            // This method queries the database for customers based on their phone or email
            SqlDataReader rdr = null;
            SqlConnection conn = new SqlConnection("Server=tcp:cts.chiltonit.com,1433;Initial Catalog=COSMETOLOGY;User ID=ctsuser;Password=ctsPROJECT!");
            SqlParameter param = new SqlParameter();

            string phone = FormatPhone(phoneTextBox.Text.ToString());

            string queryString = "";

            if (!string.IsNullOrEmpty(phone))
            {
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

                results = new List<Customer>();
                while (rdr.Read())
                {
                    results.Add(new Customer(Convert.ToInt32(rdr[0])));
                }

                for (int counter = 0; counter < results.Count; counter++)
                {
                    outputListView.Items.Add(results[counter].FirstName);
                    outputListView.Items[counter].SubItems.Add(results[counter].LastName);
                    outputListView.Items[counter].SubItems.Add(EditPhone(results[counter].Phone));
                    outputListView.Items[counter].SubItems.Add(results[counter].Email);
                    outputListView.Items[counter].SubItems.Add(results[counter].Address);
                    outputListView.Items[counter].SubItems.Add(results[counter].City);
                    outputListView.Items[counter].SubItems.Add(results[counter].State);
                    outputListView.Items[counter].SubItems.Add(results[counter].Zip);
                    outputListView.Items[counter].SubItems.Add(results[counter].IsBanned.ToString());
                    outputListView.Items[counter].SubItems.Add(results[counter].Memo);
                    ResizeListViewColumns(outputListView);
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

        // Most of the rest is Scott's code
        private string EditPhone(string x)
        {
            //(333)333-3333
            string y = x;
            y = y.Insert(0, "(");
            y = y.Insert(4, ")");
            y = y.Insert(8, "-");
            return y;
        }

        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void outputListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            submitButton.Enabled = true;
            cust = results[outputListView.SelectedIndices[0]];
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        public Customer Cust
        {
            get { return cust; }
        }
    }
}
