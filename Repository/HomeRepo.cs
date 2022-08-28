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
			string sqlTotalRoom = @"SELECT COUNT(roomID) FROM [rooms]";
			int numberOfRooms = myHomeMethod.CountRecords(sqlTotalRoom);
			return numberOfRooms;
		}

		public int CountStudents()
		{
			string sqlTotalStudents = @"SELECT COUNT(studentId) FROM [students]";
			int numberOfStuderns = myHomeMethod.CountRecords(sqlTotalStudents);
			return numberOfStuderns;
		}

		public int CountWorkers()
		{
			string sqlTotalUsers = @"SELECT COUNT(userId) FROM [users]";
			string sqlTotalWorkers = @"SELECT COUNT(workerId) FROM [workers]";
			int numberOfSystemUsers = myHomeMethod.CountRecords(sqlTotalUsers);
			int numberOfWorker = myHomeMethod.CountRecords(sqlTotalWorkers);
			return numberOfSystemUsers + numberOfWorker;
		}
		
		
	}
}




