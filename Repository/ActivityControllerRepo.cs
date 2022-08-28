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
    public class ActivityControllerRepo{

        private readonly MyMethods myActMethod = new MyMethods();
        

        public void AllocateStudentToActivity(Models.ActivityModel stdAct){
			string sqlInsertActivity = @"INSERT INTO [activityParticipation](activityName,activityDescription,participatingGender,allocatedDate, studentParticipant,addedBy)"+ 
			"VALUES(@activityName,@activityDescription,@participatingGender,@allocatedDate,@studentParticipant,@addedBy)";
           
            using (SqlConnection con = new SqlConnection(myActMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                
                SqlCommand cmd = new SqlCommand(sqlInsertActivity, con)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@activityName", SqlDbType.VarChar).Value = stdAct.ActivityName;
                cmd.Parameters.Add("@activityDescription", SqlDbType.VarChar).Value = stdAct.ActivityDescription;
                cmd.Parameters.Add("@participatingGender", SqlDbType.VarChar).Value = stdAct.ParticipatingGender;
                cmd.Parameters.Add("@allocatedDate", SqlDbType.VarChar).Value = stdAct.AllocatedDate;
                cmd.Parameters.Add("@studentParticipant", SqlDbType.Int).Value = stdAct.StudentId;
                cmd.Parameters.Add("@addedBy", SqlDbType.Int).Value = stdAct.UserId;

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Activity participation added successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add activity \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    //if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
		}
		
		public void RemoveActivityById(int actId){
			string sqlDeleteActivity = @"DELETE FROM [activityParticipation] WHERE studentNumber = '"+actId+"'";

            using (SqlConnection con = new SqlConnection(myActMethod.GetConnection())) {
                if (con.State != ConnectionState.Open) { con.Open(); }
                
                SqlCommand cmd = new SqlCommand(sqlDeleteActivity, con);

                try
                {
                    if (MessageBox.Show("Are you sure you want to remove activity no:" + actId.ToString(), "Remove Activity", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Activity number:" + actId.ToString() + " removed", "Remove Student", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Activity number:" + actId.ToString() + " not removed", "Remove Room", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to remove activity \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
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



