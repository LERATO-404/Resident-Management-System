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
using Residence_Management_System.Models;

namespace Residence_Management_System.Repository
{
    public class AdminRepo{

        private readonly MyMethods myAdminMethod = new MyMethods();

        public string SelectedEmployeeTable(int id)
        {
            return @"DELETE [workers] WHERE workerId = '" + id + "'";
        }

        public string SelectedStudentToDelete(int id)
        {
            return @"DELETE [students] WHERE studentId = '" + id + "'";
        }

        

        public WorkerModel ViewEmployeeDetails(int id, WorkerModel wkView)
        {
            string sqlEmployee = @"SELECT * FROM [workers] WHERE workerId ='" + id + "'";
            using (SqlConnection con = new SqlConnection(myAdminMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }

                SqlCommand cmd = new SqlCommand(sqlEmployee, con)
                {
                    CommandType = CommandType.Text
                };
                SqlDataReader srd = cmd.ExecuteReader();
                try
                {
                    if (srd.Read())
                    {
                        wkView.FirstName = srd["firstName"].ToString();
                        wkView.LastName = srd["lastName"].ToString();
                        wkView.EmailAddress = srd["emailAddress"].ToString();
                        wkView.PhoneNumber = srd["phoneNumber"].ToString();
                        wkView.DateOfBirth = srd["dOB"].ToString();
                        wkView.Gender = srd["gender"].ToString();
                        wkView.JobType = srd["jobTitle"].ToString();
                        wkView.JobTitle = srd["jobType"].ToString();
                        wkView.StartDate = srd["startDate"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No data found worker Id " + id.ToString(), "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to view worker. No worker in the system to view \n" +ex.Message,"Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    srd.Close();
                    cmd.Dispose();
                }
                return wkView;
            }
        
        }

        public StudentModel ViewStudentDetails(int id, StudentModel stView)
        {
            string sqlStudent = @"SELECT * FROM [students] WHERE studentId = '" + id + "'";
            using (SqlConnection con = new SqlConnection(myAdminMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }

                SqlCommand cmd = new SqlCommand(sqlStudent, con)
                {
                    CommandType = CommandType.Text
                };
                SqlDataReader srd = cmd.ExecuteReader();
                try
                {
                    if (srd.Read())
                    {
                        stView.FirstName = srd["firstName"].ToString();
                        stView.LastName = srd["lastName"].ToString();
                        stView.EmailAddress = srd["emailAddress"].ToString();
                        stView.PhoneNumber = srd["phoneNumber"].ToString();
                        stView.Gender = srd["gender"].ToString();
                        stView.DateOfBirth = srd["dOB"].ToString();
                        stView.NextOfKinFullName = srd["nextOfKinFullName"].ToString();
                        stView.NextOfKinPhone = srd["nextOfKinPhone"].ToString();
                        stView.StudentNo = srd["studentNo"].ToString();;
                        stView.StudentType = srd["studentType"].ToString();
                        stView.CourseName = srd["courseName"].ToString();
                        stView.RegistrationStatus = srd["registrationStatus"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No data found student Id " + id.ToString(), "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to view student. No student in the system to view \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    srd.Close();
                    cmd.Dispose();
                }
                return stView;
            }

        }

        public void AddWorker(WorkerModel wk){
			string sqlInsertWorker = @"INSERT INTO [workers](firstName,lastName,emailAddress,phoneNumber,dOB,gender,jobTitle,jobType,startDate,addedBy)" +
            "VALUES(@firstName,@lastName,@emailAddress,@phoneNumber,@dOB,@gender,@jobTitle,@jobType,@startDate,@addedBy)";

            using (SqlConnection con = new SqlConnection(myAdminMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                

                SqlCommand cmd = new SqlCommand(sqlInsertWorker, con)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = wk.FirstName;
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = wk.LastName;
                cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar).Value = wk.EmailAddress;
                cmd.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = wk.PhoneNumber;
                cmd.Parameters.Add("@dOB", SqlDbType.Date).Value = wk.DateOfBirth;
                cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = wk.Gender;
                cmd.Parameters.Add("@jobTitle", SqlDbType.VarChar).Value = wk.JobTitle;
                cmd.Parameters.Add("@jobType", SqlDbType.VarChar).Value = wk.JobType;
                cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = wk.StartDate;
                cmd.Parameters.Add("@addedBy", SqlDbType.Int).Value = UserId.GetUserId();


                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Worker added successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add worker \n" + ex.Message + wk.UserId.ToString(), "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    //if (con.State == ConnectionState.Open) { con.Close(); }
                }
                
            }
			
		}
		
		public void UpdateWorker(int wId, WorkerModel wkUpdate)
        {
			 
			string sqlUpdateWorker = @"UPDATE [workers] SET firstName=@firstName,lastName=@lastName,emailAddress=@emailAddress,
			phoneNumber=@phoneNumber,dOB=@dOB,gender=@gender,jobTitle=@jobTitle,jobType=@jobType,startDate=@startDate WHERE workerId=@workerId";

            using (SqlConnection con = new SqlConnection(myAdminMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                

                SqlCommand cmd = new SqlCommand(sqlUpdateWorker, con) {
                    CommandType = CommandType.Text
                };
                SqlDataAdapter adapt = new SqlDataAdapter() {
                    UpdateCommand = new SqlCommand(sqlUpdateWorker, con)
                };



                adapt.UpdateCommand.Parameters.Add("@workerId", SqlDbType.Int).Value = wId;
                adapt.UpdateCommand.Parameters.Add("@firstName", SqlDbType.VarChar).Value = wkUpdate.FirstName;
                adapt.UpdateCommand.Parameters.Add("@lastName", SqlDbType.VarChar).Value = wkUpdate.LastName;
                adapt.UpdateCommand.Parameters.Add("@emailAddress", SqlDbType.VarChar).Value = wkUpdate.EmailAddress;
                adapt.UpdateCommand.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = wkUpdate.PhoneNumber;
                adapt.UpdateCommand.Parameters.Add("@dOB", SqlDbType.VarChar).Value = wkUpdate.DateOfBirth;
                adapt.UpdateCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = wkUpdate.Gender;
                adapt.UpdateCommand.Parameters.Add("@jobTitle", SqlDbType.VarChar).Value = wkUpdate.JobTitle;
                adapt.UpdateCommand.Parameters.Add("@jobType", SqlDbType.VarChar).Value = wkUpdate.JobType;
                adapt.UpdateCommand.Parameters.Add("@startDate", SqlDbType.VarChar).Value = wkUpdate.StartDate;

				try
				{
					adapt.UpdateCommand.ExecuteNonQuery();
					MessageBox.Show("Worker details updated successfully", "Update Worker Details", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Failed to update worker details \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
				}
                finally
                {
                    adapt.Dispose();
                    cmd.Dispose();
                    //if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
			
		}
		
		public void RemoveWorkerById(int id){
			
			string sqlDeleteWorker = @"DELETE FROM [workers] WHERE workerId = '"+id+"'";

            using (SqlConnection con = new SqlConnection(myAdminMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
               
                SqlCommand cmd = new SqlCommand(sqlDeleteWorker, con);

                try
                {
                    if (MessageBox.Show("Are you sure you want to remove worker:" + id.ToString(), "Remove Room", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Room number:" + id.ToString() + " removed", "Remove Room", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Room number:" + id.ToString() + " not removed", "Remove Room", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to remove worker \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    //if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
			
		}
		
		
		public void AddStudent(StudentModel std){
			string sqlInsertStudent = @"INSERT INTO [students](firstName,lastName,emailAddress,phoneNumber,gender,dOB,nextOfKinFullName,nextOfKinPhone,studentNo,studentType,courseName,registrationStatus,addedBy)" +
            "VALUES(@firstName,@lastName,@emailAddress,@phoneNumber,@gender,@dOB,@nextOfKinFullName,@nextOfKinPhone,@studentNo,@studentType,@courseName,@registrationStatus,@addedBy)";

            using (SqlConnection con = new SqlConnection(myAdminMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }

                SqlCommand cmd = new SqlCommand(sqlInsertStudent, con)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = std.FirstName;
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = std.LastName;
                cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = std.EmailAddress;
                cmd.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = std.PhoneNumber;
                cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = std.Gender;
                cmd.Parameters.Add("@dob", SqlDbType.Date).Value = std.DateOfBirth;
                cmd.Parameters.Add("@nextOfKinFullName", SqlDbType.VarChar).Value = std.NextOfKinFullName;
                cmd.Parameters.Add("@nextOfKinPhone", SqlDbType.VarChar).Value = std.NextOfKinPhone;
                cmd.Parameters.Add("@studentNo", SqlDbType.VarChar).Value = std.StudentNo;
                cmd.Parameters.Add("@studentType", SqlDbType.VarChar).Value = std.StudentType;
                cmd.Parameters.Add("@courseName", SqlDbType.VarChar).Value = std.CourseName;
                cmd.Parameters.Add("@registrationStatus", SqlDbType.VarChar).Value = std.RegistrationStatus;
                cmd.Parameters.Add("@addedBy", SqlDbType.Int).Value = UserId.GetUserId();


                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student added successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add student \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    //if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
			
		}
		
		
		public void UpdateStudentById(int stUpId, StudentModel stUpdate)
        {
			string sqlUpdateStudent = @"UPDATE [students] SET firstName=@firstName,lastName=@lastName,emailAddress=@emailAddress,
			phoneNumber=@phoneNumber,gender=@gender,dOB=@dOB,nextOfKinFullName=@nextOfKinFullName,nextOfKinPhone=@nextOfKinPhone,studentNo=@studentNo,
			studentType=@studentType,courseName=@courseName,registrationStatus=@registrationStatus WHERE studentId=@studentId";

            using (SqlConnection con = new SqlConnection(myAdminMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                
                SqlCommand cmd = new SqlCommand(sqlUpdateStudent, con) { 
                    CommandType = CommandType.Text
                };

                SqlDataAdapter adapt = new SqlDataAdapter()
                {
                    UpdateCommand = new SqlCommand(sqlUpdateStudent, con)
                };

                adapt.UpdateCommand.Parameters.Add("@studentId", SqlDbType.VarChar).Value = stUpId;
                adapt.UpdateCommand.Parameters.Add("@firstName", SqlDbType.VarChar).Value = stUpdate.FirstName;
                adapt.UpdateCommand.Parameters.Add("@lastName", SqlDbType.VarChar).Value = stUpdate.LastName;
                adapt.UpdateCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = stUpdate.EmailAddress;
                adapt.UpdateCommand.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = stUpdate.PhoneNumber;
                adapt.UpdateCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = stUpdate.Gender;
                adapt.UpdateCommand.Parameters.Add("@dob", SqlDbType.Date).Value = stUpdate.DateOfBirth;
                adapt.UpdateCommand.Parameters.Add("@nextOfKinFullName", SqlDbType.VarChar).Value = stUpdate.NextOfKinFullName;
                adapt.UpdateCommand.Parameters.Add("@nextOfKinPhone", SqlDbType.VarChar).Value = stUpdate.NextOfKinPhone;
                adapt.UpdateCommand.Parameters.Add("@studentNo", SqlDbType.VarChar).Value = stUpdate.StudentNo;
                adapt.UpdateCommand.Parameters.Add("@studentType", SqlDbType.VarChar).Value = stUpdate.StudentType;
                adapt.UpdateCommand.Parameters.Add("@courseName", SqlDbType.VarChar).Value = stUpdate.CourseName;
                adapt.UpdateCommand.Parameters.Add("@registrationStatus", SqlDbType.VarChar).Value = stUpdate.RegistrationStatus;


                try
                {
                    adapt.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Student details updated successfully", "Update Student Details", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update student details \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    //if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
		}
		
		
		public void RemoveStudentById(int stId){
			
			string sqlDeleteStudent = @"DELETE FROM [students] WHERE studentId = '"+stId+"'";
            using (SqlConnection con = new SqlConnection(myAdminMethod.GetConnection()))
            {

                if (con.State != ConnectionState.Open) { con.Open(); }
               
                SqlCommand cmd = new SqlCommand(sqlDeleteStudent, con);
                try
                {
                    if (MessageBox.Show("Are you sure you want to remove student no:" + stId.ToString(), "Remove Student", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Student number:" + stId.ToString() + " removed", "Remove Student", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Room number:" + stId.ToString() + " not removed", "Remove Room", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to student worker \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    //if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
            
		}
	}
}


