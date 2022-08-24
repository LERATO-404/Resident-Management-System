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

namespace Residence_Management_System.Repository
{

	
	public class UserRepo{
		
		public static ProtectPassword userPasswordProtect = new ProtectPassword();
		

		public static SqlConnection getConnection(){
			
			string constring= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\App_Data\ResidenceManagementSystemDB.mdf;Integrated Security=True";
			SqlConnection con = new SqlConnection(constring);
			try{
				con.Open();
				
			}catch(SqlException sqlEx){
				MessageBox.Show("Sql Connectio! \n"+ sqlEx.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
				
			}
			return con;
		}
		

		public static void addUser(Models.UserModel usM){
			//encrypt password before inserting into USERS TABLE
			//string encodedUserPassword = userPasswordProtect.encryptPassword(txtPassword.Text); //do this inside button register
					
			//string sqlInsert = @"Insert into [users] "+
			//"Values (@firstName, @lastName, @EmailAddress, @phoneNumber, @dob, @jobTitle, @jobType, @username, @password)";
			
			string sqlInsert = @"INSERT INTO [users](firstName,lastName,emailAddress,phoneNumber,dOB,jobTitle,jobType,username ,password)"+
				"VALUES(@firstName,@lastName,@emailAddress,@phoneNumber,@dOB,@jobTitle,@jobType,@username ,@password)";

			using (SqlConnection con = getConnection())
            {
				SqlCommand cmd = new SqlCommand(sqlInsert, con);

				cmd.CommandType = CommandType.Text;
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
					MessageBox.Show("Unsername already taken", "Error", (MessageBoxButtons)MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				if (con.State == ConnectionState.Open)
					con.Close();
			}
				
		}
		
		public static void loginUser(string username, string password)
		{
			try
			{
				using(SqlConnection con = getConnection())
                {
					if (String.IsNullOrEmpty(username) == false || String.IsNullOrEmpty(password) == false)
					{
						//encrypt password entered when logging in
						string encodedUserPasswordBeforLogin = userPasswordProtect.encryptPassword(password);
						string query = "SELECT * from [users] WHERE username ='" + username + "' AND password ='" + encodedUserPasswordBeforLogin + "'";

						// if the password entered in the textbox is not equal to decrypted found in the db
						if (password == userPasswordProtect.decryptPassword(encodedUserPasswordBeforLogin))
						{
							SqlCommand cmd = new SqlCommand(query, con);
							SqlDataAdapter adp = new SqlDataAdapter(cmd);
							SqlDataReader myReader = cmd.ExecuteReader();

							if (myReader.HasRows)
							{
								LandingPage landingP = new LandingPage();
								landingP.Show(); //show landing page
								landingP.lblWelcomeUsername.Text = username;
								myReader.Close();
							}
							else
							{
								MessageBox.Show("Sorry, Username and password you entered doesn't belong to an account. Please double-check.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
						if (con.State == ConnectionState.Open)
							con.Close();
					}
					else
					{
						MessageBox.Show("Username or Password is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				
			}catch(Exception ex){
				//throw new "Program failed "+ ex.Message;
			}
			
		}
	}
}



