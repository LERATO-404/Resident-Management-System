using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using Residence_Management_System.ExtraMethods;

namespace Residence_Management_System.Repository
{
	public class UserRepo{
		
		public static readonly ProtectPassword userPasswordProtect = new ProtectPassword();
        private readonly MyMethods myUserMethod = new MyMethods();
        public void AddUser(Models.UserModel usM){
			
			string sqlInsert = @"INSERT INTO [users](firstName,lastName,emailAddress,phoneNumber,dOB,jobTitle,jobType,username ,password)"+
				"VALUES(@firstName,@lastName,@emailAddress,@phoneNumber,@dOB,@jobTitle,@jobType,@username ,@password)";

            using (SqlConnection con = new SqlConnection(myUserMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(sqlInsert, con) {
                    CommandType = CommandType.Text
                };

                cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = usM.FirstName;
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = usM.LastName;
                cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = usM.EmailAddress;
                cmd.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = usM.PhoneNumber;
                cmd.Parameters.Add("@dob", SqlDbType.Date).Value = usM.DateOfBirth;
                cmd.Parameters.Add("@jobTitle", SqlDbType.VarChar).Value = usM.JobTitle;
                cmd.Parameters.Add("@jobType", SqlDbType.VarChar).Value = usM.JobType;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = usM.UserName;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = userPasswordProtect.encryptPassword(usM.Password);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account created successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unsername already taken\n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                }
            }	
		}
		
		public void LoginUser(string username, string password)
		{

            using (SqlConnection con = new SqlConnection(myUserMethod.GetConnection()))
            { 
                if (String.IsNullOrEmpty(username) == false || String.IsNullOrEmpty(password) == false)
                {
                    if (con.State != ConnectionState.Open) { con.Open(); }
                    //encrypt password entered when logging in
                    string encodedUserPasswordBeforLogin = userPasswordProtect.encryptPassword(password);
                    string query = "SELECT * from [users] WHERE username ='" + username + "' AND password ='" + encodedUserPasswordBeforLogin + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader myReader = cmd.ExecuteReader();

                    try
                    {
                        //cmd.ExecuteNonQuery();
                        if (myReader.HasRows)
                        {
                            LandingPage landingP = new LandingPage();
                            landingP.Show(); //show landing page
                            landingP.lblWelcomeUsername.Text = username;
                            myReader.Close();
                        }
                        else
                        {
                            myReader.Close();
                            MessageBox.Show("Sorry, Username and password you entered doesn't belong to an account. Please double-check.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + myUserMethod.GetConnection().ToString());
                        myReader.Close();
                    }
                    finally
                    {
                        myReader.Close();
                        cmd.Dispose();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Username or Password is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
		}
	}
}



