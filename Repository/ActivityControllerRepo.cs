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
    public class ActivityControllerRepo{
		
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
		
		public void allocateStudentToActivity(Models.ActivityModel stdAct){
			string sqlInsertActivity = @"INSERT INTO [activityParticipation](activityName,activityDescription,participatingGender,allocatedDate, studentParticipant,addedBy)"+ 
			"VALUES(@activityName,@activityDescription,@participatingGender,@allocatedDate,@studentParticipant,@addedBy)";
			
			SqlConnection con = getConnection();
			SqlCommand cmd = new SqlCommand(sqlInsertActivity, con);
			
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Add("@activityName",SqlDbType.VarChar).Value = stdAct.ActivityName;
			cmd.Parameters.Add("@activityDescription",SqlDbType.VarChar).Value = stdAct.ActivityDescription;
			cmd.Parameters.Add("@participatingGender",SqlDbType.VarChar).Value = stdAct.ParticipatingGender;
			cmd.Parameters.Add("@allocatedDate",SqlDbType.VarChar).Value = stdAct.AllocatedDate;
			cmd.Parameters.Add("@studentParticipant",SqlDbType.Int).Value = stdAct.StudentId;
			cmd.Parameters.Add("@addedBy",SqlDbType.Int).Value = stdAct.UserId;
		
			try{
				cmd.ExecuteNonQuery();
				MessageBox.Show("Activity participation added successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
			}catch(Exception ex){
				MessageBox.Show("Failed to add activity \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
			
		}
		
		public void removeActivityById(int actId){
			string sqlDeleteActivity = @"DELETE FROM [activityParticipation] WHERE studentNumber = '"+actId+"'";
			
			SqlConnection con =  getConnection();
			SqlCommand cmd = new SqlCommand(sqlDeleteActivity, con);
			
			try{
				if(MessageBox.Show("Are you sure you want to remove activity no:"+actId.ToString(), "Remove Activity", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
					cmd.ExecuteNonQuery();
					MessageBox.Show("Activity number:"+actId.ToString()+" removed", "Remove Student", (MessageBoxButtons)MessageBoxButton.OK,MessageBoxIcon.Information);
				}else{
					MessageBox.Show("Activity number:"+actId.ToString()+" not removed", "Remove Room", (MessageBoxButtons)MessageBoxButton.OK,MessageBoxIcon.Information);
				}
			}catch(Exception ex){
				MessageBox.Show("Failed to remove activity \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
			
			
		}
	}
}



