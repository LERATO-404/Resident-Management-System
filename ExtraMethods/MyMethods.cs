using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Residence_Management_System.ExtraMethods
{
    internal class MyMethods
    {
        
        //gets connection string
        public string GetConnection()
        {
            try
            {
                
                string constring = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                if(constring != null)
                {
                    ConfigurationManager.RefreshSection("MyConnectionString");
                    return ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Connection - Something is wrong with the server/database!!!!" , "Invalid Server/Database", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                    return "";
                }
                
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Connection!!!! \n" + ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString() + "/nThis is an invalid connection" + sqlEx.Message, "Invalid Server/Database", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        /*
        public int GetUserId()
        {
            string sqlId = @"SELECT * FROM [users] WHERE username = @username"; // userName = lblWelcome.Text
            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(sqlId, con);
                using (LandingPage userName = new LandingPage()){
                    cmd.Parameters.AddWithValue("@username", userName.lblWelcomeUsername.Text);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        */

        public int GetUserId()
        {
            
            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                SqlDataAdapter adapt = new SqlDataAdapter();
                DataSet ds = new DataSet();
                using (LandingPage userNm = new LandingPage())
                {
                    string sqlId = @"SELECT * FROM [users] WHERE userName LIKE '" + userNm.lblWelcomeUsername.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqlId, con);
                    adapt.SelectCommand = cmd;
                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(ds);
                    try
                    {
                        int loginID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        return loginID;
                    }
                    finally
                    {
                        adapt.Dispose();
                        ds.Dispose();
                        cmd.Dispose();
                    }
                }   
            }   
        }

        public int CountRecords(string sqlCount)
        {
            try
            {
                int recordsAvailable = 0;
                using (SqlConnection con = new SqlConnection(GetConnection()))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlCount, con))
                    {
                        if (con.State != ConnectionState.Open) {
                            con.Open();
                        }
                        return recordsAvailable = (int)cmd.ExecuteScalar();
                       
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string JobTitleSelected(ComboBox cs)
        {
            string _jobTitle = "Guest";
            if (cs.SelectedIndex == 0)
            {
                _jobTitle = "Full-Time";
            }
            else if (cs.SelectedIndex == 1)
            {
                _jobTitle = "Part-Time";
            }
            else if (cs.SelectedIndex == 2)
            {
                _jobTitle = "Temporary";
            }
            else if (cs.SelectedIndex == 3)
            {
                _jobTitle = "Volunteer";
            }
            return _jobTitle;
        }

    }
}
