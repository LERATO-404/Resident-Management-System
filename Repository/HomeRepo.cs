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
    public class HomeRepo{
	
		public static SqlConnection getConnection()
		{

			string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\App_Data\ResidenceManagementSystemDB.mdf;Integrated Security=True"; ;
			SqlConnection con = new SqlConnection(constring);
			try
			{
				con.Open();

			}
			catch (SqlException sqlEx)
			{
                MessageBox.Show("Sql Connectio! \n" + sqlEx.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);

			}
			return con;
		}


		public string selectedTable(ComboBox cs)
		{
			
			int tableSelected = cs.SelectedIndex;

			string tname = "";
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

		public int countRecords(string sqlCount)
		{
			try
			{
				int recordsAvailable = 0;
				using (SqlConnection con = getConnection())
				{
					using (SqlCommand cmd = new SqlCommand(sqlCount, con))
					{
						if (con.State != ConnectionState.Open)
							con.Open();
						recordsAvailable = (int)cmd.ExecuteScalar();
						con.Close();
					}
				}
				return recordsAvailable;

			}
			catch (Exception ex)
			{
				return 0;
			}
		}

		public int countRoom()
        {
			string sqlTotalRoom = @"SELECT COUNT(*) FROM [rooms]";
			int numberOfRooms =  countRecords(sqlTotalRoom);
			return numberOfRooms;
		}

		public int countStudents()
		{
			string sqlTotalStudents = @"SELECT COUNT(*) FROM [studens]";
			int numberOfRooms = countRecords(sqlTotalStudents);
			return numberOfRooms;
		}

		public int countWorkers()
		{
			string sqlTotalWorkers = @"SELECT COUNT(*) FROM [users]";
			int numberOfRooms = countRecords(sqlTotalWorkers);
			return numberOfRooms;
		}

		public void viewTable(ComboBox viewCB, DataGridView dgv)
		{
			using (SqlConnection con = getConnection())
			{
				if (con.State != ConnectionState.Open)
					con.Open();

				string sqlUsers = selectedTable(viewCB);
				SqlDataAdapter adapt = new SqlDataAdapter();
				DataSet ds = new DataSet();
				SqlCommand cmd = new SqlCommand(sqlUsers, con);
				adapt.SelectCommand = cmd;
				adapt.Fill(ds, "UserInfo");
				dgv.DataSource = ds;
				dgv.DataMember = "UserInfo";
				if (con.State == ConnectionState.Open)
					con.Close();
			}
		}
	}
}




