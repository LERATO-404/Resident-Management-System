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
    public class HomeRepo{

        private readonly MyMethods myHomeMethod = new MyMethods();
        public string SelectedTable(ComboBox cs)
		{
			
			int tableSelected = cs.SelectedIndex;

			string tname;
			switch (tableSelected)
			{
				case 0:
					tname = @"SELECT * FROM [users]";
					break;
				case 1:
					tname = @"SELECT * FROM [rooms]";
					break;
				case 2:
					tname = @"SELECT * FROM [workers]";
					break;
				case 3:
					tname = @"SELECT * FROM [students]";
					break;
				case 4:
					tname = @"SELECT * FROM [reservations]";
					break;
				case 5:
					tname = @"SELECT * FROM [activityParticipation]";
					break;
				case 6:
					tname = @"SELECT * FROM [points]";
					break;
				default:
					tname = "";
					break;
			}
			return tname;
		}

		public string SelectedTableToDeleteResource(ComboBox cs, int id)
		{

			int tableSelected = cs.SelectedIndex;

			string tname;
			switch (tableSelected)
			{
				case 0:
					tname = @"DELETE [users] WHERE userId = '" + id + "'";
					break;
				case 1:
					tname = @"DELETE [rooms] WHERE roomId = '" + id + "'";
					break;
				case 2:
					tname = @"DELETE  [workers] WHERE workerId = '" + id + "'";
					break;
				case 3:
					tname = @"DELETE  [students] WHERE studentId = '" + id + "'";
					break;
				case 4:
					tname = @"DELETE  [reservations] WHERE reservationId = '" + id + "'";
					break;
				case 5:
					tname = @"DELETE  [activityParticipation] WHERE activityId = '" + id + "'";
					break;
				case 6:
					tname = @"DELETE  [points] WHERE pointsId = '" + id + "'";
					break;
				default:
					tname = "";
					break;
			}
			return tname;
		}

		public int CountRoom()
        {
			string sqlTotalRoom = @"SELECT COUNT(*) FROM [rooms]";
			int numberOfRooms = myHomeMethod.CountRecords(sqlTotalRoom);
			return numberOfRooms;
		}

		public int CountStudents()
		{
			string sqlTotalStudents = @"SELECT COUNT(*) FROM [studens]";
			int numberOfRooms = myHomeMethod.CountRecords(sqlTotalStudents);
			return numberOfRooms;
		}

		public int CountWorkers()
		{
			string sqlTotalWorkers = @"SELECT COUNT(*) FROM [users]";
			int numberOfRooms = myHomeMethod.CountRecords(sqlTotalWorkers);
			return numberOfRooms;
		}
		



        public void ViewTable(ComboBox viewCB, DataGridView dgv)
		{
			using (SqlConnection con = new SqlConnection(myHomeMethod.GetConnection()))
			{
				if (con.State != ConnectionState.Open) { con.Open(); }

				string sqlUsers = SelectedTable(viewCB);
				
				DataSet ds = new DataSet();
				SqlCommand cmd = new SqlCommand(sqlUsers, con);
				SqlDataAdapter adapt = new SqlDataAdapter()
				{
					SelectCommand = cmd
				};
				try
				{
					adapt.Fill(ds, "UserInfo");
					dgv.DataSource = ds;
					dgv.DataMember = "UserInfo";
				}
				catch (Exception)
				{
					MessageBox.Show("Please select the table you want to display", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					ds.Dispose();
					cmd.Dispose();
					adapt.Dispose();
					//if (con.State == ConnectionState.Open) { con.Close(); }
				}
			}

			
			

		}

		public void RemoveById(ComboBox cbDel,int id)
		{
			string sqlDeleteResource = SelectedTableToDeleteResource(cbDel, id);
            using (SqlConnection con = new SqlConnection(myHomeMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlDataAdapter adapt = new SqlDataAdapter() { 
					DeleteCommand = new SqlCommand(sqlDeleteResource, con)
				};
				try
				{
					if (MessageBox.Show("Are you sure you want to delete id number:" + id.ToString(), "Remove Resource", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{	
						int deletedResource = adapt.DeleteCommand.ExecuteNonQuery();
						if(deletedResource > 0)
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
	}
}




