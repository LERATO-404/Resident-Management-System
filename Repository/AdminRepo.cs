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
    public class AdminRepo{
		
		public static SqlConnection getConnection(){
			
			string constring= @"";
			SqlConnection con = new SqlConnection(constring);
			try{
				
				con.Open();
				
			}catch(SqlException sqlEx){
				MessageBox.Show("Sql Connection! \n"+ sqlEx.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
				
			}
			return con;
		}
		
		
		public void addWorker(Models.WorkerModel wk){
			string sqlInsertWorker = @"INSERT INTO [workers](firstName,lastName,emailAddress,phoneNumber,dOB,jobTitle,jobType,startDate,userId)"+ 
			"VALUES(@firstName,@lastName,@emailAddress,@phoneNumber,@dOB,@jobTitle,@jobType,@userId)";
			
			SqlConnection con = getConnection();
			SqlCommand cmd = new SqlCommand(sqlInsertWorker, con);
			
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Add("@firstName",SqlDbType.VarChar).Value = wk.FirstName;
			cmd.Parameters.Add("@lastName",SqlDbType.VarChar).Value = wk.LastName;
			cmd.Parameters.Add("@EmailAddress",SqlDbType.VarChar).Value = wk.EmailAddress;
			cmd.Parameters.Add("@phoneNumber",SqlDbType.VarChar).Value = wk.PhoneNumber;
			cmd.Parameters.Add("@dob",SqlDbType.Date).Value = wk.DateOfBirth;
			cmd.Parameters.Add("@jobTitle",SqlDbType.VarChar).Value = wk.JobTitle;
			cmd.Parameters.Add("@jobType",SqlDbType.VarChar).Value = wk.JobType;
			cmd.Parameters.Add("@startDate",SqlDbType.VarChar).Value = wk.StartDate;
			cmd.Parameters.Add("@userId",SqlDbType.Int).Value = wk.UserId;
			
			
			try{
				cmd.ExecuteNonQuery();
				MessageBox.Show("Worker added successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
			}catch(Exception ex){
				MessageBox.Show("Failed to add worker \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
		}
		
		public void updateWorker(int wId){
			Models.WorkerModel wkUpdate = new Models.WorkerModel();
			string sqlUpdateWorker = @"UPDATE [rooms] SET firstName=@firstName,lastName=@lastName,emailAddress=@emailAddress,
			phoneNumber=@phoneNumber,
			dOB=@dOB,jobTitle=@jobTitle,
			jobType=@jobType,
			startDate=@startDate WHERE workerId=@workerId";
		
			SqlConnection con = getConnection();
			SqlCommand cmd = new SqlCommand(sqlUpdateWorker, con);
			
			SqlDataAdapter adapt = new SqlDataAdapter();
			adapt.UpdateCommand = new SqlCommand(sqlUpdateWorker, con);
			
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Add("@workerId",SqlDbType.Int).Value = wId;
			cmd.Parameters.Add("@firstName",SqlDbType.VarChar).Value = wkUpdate.FirstName;
			cmd.Parameters.Add("@lastName",SqlDbType.VarChar).Value = wkUpdate.LastName;
			cmd.Parameters.Add("@EmailAddress",SqlDbType.VarChar).Value = wkUpdate.EmailAddress;
			cmd.Parameters.Add("@phoneNumber",SqlDbType.VarChar).Value = wkUpdate.PhoneNumber;
			cmd.Parameters.Add("@dob",SqlDbType.Date).Value = wkUpdate.DateOfBirth;
			cmd.Parameters.Add("@jobTitle",SqlDbType.VarChar).Value = wkUpdate.JobTitle;
			cmd.Parameters.Add("@jobType",SqlDbType.VarChar).Value = wkUpdate.JobType;
			cmd.Parameters.Add("@startDate",SqlDbType.VarChar).Value = wkUpdate.StartDate;
			
			try{
				adapt.UpdateCommand.ExecuteNonQuery();
				MessageBox.Show("Worker details updated successfully", "Update Worker Details", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
			}catch(Exception ex){
				MessageBox.Show("Failed to update worker details \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
			cmd.Dispose();
		}
		
		public void removeWorkerById(int id){
			Models.WorkerModel wkDelete = new Models.WorkerModel();
			string sqlDeleteWorker = @"DELETE FROM [workers] WHERE workerId = '"+id+"'";
			
			SqlConnection con =  getConnection();
			SqlCommand cmd = new SqlCommand(sqlDeleteWorker, con);
			
			try{
				if(MessageBox.Show("Are you sure you want to remove worker:"+id.ToString(), "Remove Room", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
					cmd.ExecuteNonQuery();
					MessageBox.Show("Room number:"+id.ToString()+" removed", "Remove Room", (MessageBoxButtons)MessageBoxButton.OK,MessageBoxIcon.Information);
				}else{
					MessageBox.Show("Room number:"+id.ToString()+" not removed", "Remove Room", (MessageBoxButtons)MessageBoxButton.OK,MessageBoxIcon.Information);
				}
			}catch(Exception ex){
				MessageBox.Show("Failed to remove worker \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
		}
		
		
		public void addStudent(Models.StudentModel std){
			string sqlInsertStudent = @"INSERT INTO [students](firstName,lastName,emailAddress,phoneNumber, gender,dOB,nationality,studentType, courseName,nextOfKinFullName, nextOfKinPhone, userId)"+ 
			"VALUES(@firstName,@lastName,@emailAddress,@phoneNumber,@gender,@dOB,@nationality,@studentType,@courseName,@nextOfKinFullName,@nextOfKinPhone, @userId)";
			
			SqlConnection con =  getConnection();
			SqlCommand cmd = new SqlCommand(sqlInsertStudent, con);
			
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Add("@firstName",SqlDbType.VarChar).Value = std.FirstName;
			cmd.Parameters.Add("@lastName",SqlDbType.VarChar).Value = std.LastName;
			cmd.Parameters.Add("@EmailAddress",SqlDbType.VarChar).Value = std.EmailAddress;
			cmd.Parameters.Add("@phoneNumber",SqlDbType.VarChar).Value = std.PhoneNumber;
			cmd.Parameters.Add("@gender",SqlDbType.VarChar).Value = std.Gender;
			cmd.Parameters.Add("@dob",SqlDbType.Date).Value = std.DateOfBirth;
			cmd.Parameters.Add("@nationality",SqlDbType.VarChar).Value = std.Nationality;
			cmd.Parameters.Add("@studentType",SqlDbType.VarChar).Value = std.StudentType;
			cmd.Parameters.Add("@courseName",SqlDbType.VarChar).Value = std.CourseName;
			cmd.Parameters.Add("@nextOfKinFullName",SqlDbType.VarChar).Value = std.NextOfKinFullName;
			cmd.Parameters.Add("@nextOfKinPhone",SqlDbType.VarChar).Value = std.NextOfKinPhone;
			cmd.Parameters.Add("@userId",SqlDbType.Int).Value = std.UserId;
			
			
			try{
				cmd.ExecuteNonQuery();
				MessageBox.Show("Student added successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
			}catch(Exception ex){
				MessageBox.Show("Failed to add student \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
		}
		
		
		public void updateStudentById(int stUpId){
			Models.StudentModel stUpdate = new Models.StudentModel();
			string sqlUpdateWorker = @"UPDATE [rooms] SET firstName=@firstName,lastName=@lastName,emailAddress=@emailAddress,
			phoneNumber=@phoneNumber,
			gender=@gender,
			dOB=@dOB,nationality=@nationality,
			studentType=@studentType,
			courseName=@courseName,
			nextOfKinFullName=@nextOfKinFullName,
			nextOfKinPhone=@nextOfKinPhone,
			WHERE studentId=@studentId";
		
			SqlConnection con = getConnection();
			SqlCommand cmd = new SqlCommand(sqlUpdateWorker, con);
			
			SqlDataAdapter adapt = new SqlDataAdapter();
			adapt.UpdateCommand = new SqlCommand(sqlUpdateWorker, con);
			
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Add("@studentId",SqlDbType.Int).Value = stUpId;
			cmd.Parameters.Add("@firstName",SqlDbType.VarChar).Value = stUpdate.FirstName;
			cmd.Parameters.Add("@lastName",SqlDbType.VarChar).Value = stUpdate.LastName;
			cmd.Parameters.Add("@EmailAddress",SqlDbType.VarChar).Value = stUpdate.EmailAddress;
			cmd.Parameters.Add("@phoneNumber",SqlDbType.VarChar).Value = stUpdate.PhoneNumber;
			cmd.Parameters.Add("@gender",SqlDbType.VarChar).Value = stUpdate.Gender;
			cmd.Parameters.Add("@dob",SqlDbType.Date).Value = stUpdate.DateOfBirth;
			cmd.Parameters.Add("@nationality",SqlDbType.VarChar).Value = stUpdate.Nationality;
			cmd.Parameters.Add("@studentType",SqlDbType.VarChar).Value = stUpdate.StudentType;
			cmd.Parameters.Add("@courseName",SqlDbType.VarChar).Value = stUpdate.CourseName;
			cmd.Parameters.Add("@nextOfKinFullName",SqlDbType.VarChar).Value = stUpdate.NextOfKinFullName;
			cmd.Parameters.Add("@nextOfKinPhone",SqlDbType.VarChar).Value = stUpdate.NextOfKinPhone;
			
			
			try{
				adapt.UpdateCommand.ExecuteNonQuery();
				MessageBox.Show("Student details updated successfully", "Update Worker Details", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
			}catch(Exception ex){
				MessageBox.Show("Failed to update student details \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
			cmd.Dispose();
		}
		
		
		public void removeStudentById(int stId){
			//Models.StudentModel stDelete = new Models.StudentModel();
			string sqlDeleteStudent = @"DELETE FROM [students] WHERE studentId = '"+stId+"'";
			
			SqlConnection con = getConnection();
			SqlCommand cmd = new SqlCommand(sqlDeleteStudent, con);
			
			try{
				if(MessageBox.Show("Are you sure you want to remove student no:"+stId.ToString(), "Remove Student", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
					cmd.ExecuteNonQuery();
					MessageBox.Show("Student number:"+stId.ToString()+" removed", "Remove Student", (MessageBoxButtons)MessageBoxButton.OK,MessageBoxIcon.Information);
				}else{
					MessageBox.Show("Room number:"+stId.ToString()+" not removed", "Remove Room", (MessageBoxButtons)MessageBoxButton.OK,MessageBoxIcon.Information);
				}
			}catch(Exception ex){
				MessageBox.Show("Failed to student worker \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
		}
	}
}


