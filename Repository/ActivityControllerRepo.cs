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
    public class ActivityControllerRepo{

        private readonly MyMethods myActMethod = new MyMethods();

        public string SelecteTable(int id)
        {
            return "SELECT * FROM [students] WHERE studentId = '" + id + "'";
        }
        public void AllocateStudentToActivity(ActivityModel stdAct){
			string sqlInsertActivity = @"INSERT INTO [activityParticipation](studentParticipating,semesterParticipating,totalPoints,allocatedDate, addedBy)"+
            "VALUES(@studentParticipating,@semesterParticipating,@totalPoints,@allocatedDate, @addedBy)";

            using (SqlConnection con = new SqlConnection(myActMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                
                SqlCommand cmd = new SqlCommand(sqlInsertActivity, con)
                {
                    CommandType = CommandType.Text
                };
                
                cmd.Parameters.Add("@studentParticipating", SqlDbType.Int).Value = stdAct.StudentId;
                cmd.Parameters.Add("@semesterParticipating", SqlDbType.VarChar).Value = stdAct.SemesterParticipating;
                cmd.Parameters.Add("@totalPoints", SqlDbType.Int).Value = stdAct.TotalPoints;
                cmd.Parameters.Add("@allocatedDate", SqlDbType.VarChar).Value = stdAct.AllocatedDate;
                cmd.Parameters.Add("@addedBy", SqlDbType.Int).Value = myActMethod.GetUserId("sa");
                

               
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


        public void AddTotalPoints(ActivityModel stdAct)
        {
           
            string sqlInsertPoints = @"INSERT INTO [points](studentId, totalPoint)" +
            "VALUES(@studentId, @totalPoint)";

            using (SqlConnection con = new SqlConnection(myActMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }

               
                SqlCommand cmd2 = new SqlCommand(sqlInsertPoints, con)
                {
                    CommandType = CommandType.Text
                };
                
                cmd2.Parameters.Add("@studentId", SqlDbType.VarChar).Value = stdAct.StudentId;
                cmd2.Parameters.Add("@totalPoint", SqlDbType.VarChar).Value = stdAct.TotalPoints;

                try
                {
                    cmd2.ExecuteNonQuery();
                    //MessageBox.Show("Activity participation added successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Failed to add activity \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd2.Dispose();
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



