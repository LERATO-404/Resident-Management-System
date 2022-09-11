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
        private readonly string userRole = UserId.GetUserJobType();


        public string SelectedTable(ComboBox cs)
        {

            int tableSelected = cs.SelectedIndex;

            string tname;
            switch (tableSelected)
            {
                case 0:
                    tname = @"SELECT * FROM [activityParticipation]";
                    break;
                case 1:
                    tname = @"SELECT a.activityId, a.totalPoints AS Points, s.firstName, s.lastName
                                   FROM activityParticipation a
                                        INNER JOIN students s
                                           ON  a.studentParticipant = s.studentId
                                       ORDER BY a.activityId"; 
                    break;
                default:
                    tname = "";
                    break;
            }
            return tname;
        }

        public string SelectedTableToDeleteResource(int id)
        {
            return @"DELETE  [activityParticipation] WHERE activityId = '" + id + "'";
        }




        public void AllocateStudentToActivity(ActivityModel stdAct){
            if(userRole == "Activity-Controller")
            {
                string sqlInsertActivity = @"INSERT INTO [activityParticipation](studentParticipant,semesterParticipating,totalPoints,allocatedDate, addedBy)" +
                "VALUES(@studentParticipant,@semesterParticipating,@totalPoints,@allocatedDate, @addedBy)";

                using (SqlConnection con = new SqlConnection(myActMethod.GetConnection()))
                {
                    if (con.State != ConnectionState.Open) { con.Open(); }

                    SqlCommand cmd = new SqlCommand(sqlInsertActivity, con)
                    {
                        CommandType = CommandType.Text
                    };


                    cmd.Parameters.Add("@studentParticipant", SqlDbType.Int).Value = stdAct.StudentId;
                    cmd.Parameters.Add("@semesterParticipating", SqlDbType.VarChar).Value = stdAct.SemesterParticipating;
                    cmd.Parameters.Add("@totalPoints", SqlDbType.Int).Value = stdAct.TotalPoints;
                    cmd.Parameters.Add("@allocatedDate", SqlDbType.VarChar).Value = stdAct.AllocatedDate;
                    cmd.Parameters.Add("@addedBy", SqlDbType.Int).Value = UserId.GetUserId();



                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Activity participation added successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed to add activity student Id:" + stdAct.StudentId + " was not found", "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cmd.Dispose();
                        //if (con.State == ConnectionState.Open) { con.Close(); }
                    }
                }
            }
            else
            {
                MessageBox.Show("You don't have the privilages to allocate student to activities only the activity-controller can allocate", "Not allowed", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
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

        public void RemoveById(int id)
        {
            if (userRole == "Activity-Controller")
            {
                using (SqlConnection con = new SqlConnection(myActMethod.GetConnection()))
                {
                    if (con.State != ConnectionState.Open) { con.Open(); }
                    SqlDataAdapter adapt = new SqlDataAdapter()
                    {
                        DeleteCommand = new SqlCommand(SelectedTableToDeleteResource(id), con)
                    };
                    try
                    {
                        if (MessageBox.Show("Are you sure you want to delete id number:" + id.ToString(), "Remove Resource", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int deletedResource = adapt.DeleteCommand.ExecuteNonQuery();
                            if (deletedResource > 0)
                            {
                                MessageBox.Show("Id number:" + id.ToString() + " removed", "Remove Resource", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Id not found", "Id not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Id number:" + id.ToString() + " not removed", "Remove Resource", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed to remove resource.Please Display the table you want to delete a resource From \n", "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        adapt.Dispose();
                        //if (con.State == ConnectionState.Open) { con.Close(); }
                    }
                }
            }
            else
            {
                MessageBox.Show("You don't have the privilages to delete student activity points activities.\nOnly the activity-controller can perform this task", "Not allowed", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
            }
        }
    }
}



