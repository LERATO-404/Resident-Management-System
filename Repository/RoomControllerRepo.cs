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
    public class RoomControllerRepo{

        private readonly MyMethods myRoomMethod = new MyMethods();


        public string SelectedRoomToDelete(int id)
        {
            return @"DELETE [rooms] WHERE roomId = '" + id + "'";
        }

        public string SelectedReservationToDelete(int id)
        {
            return @"DELETE [reservations] WHERE reservationId = '" + id + "'";
        }

        public string SelectedRoomsTable(ComboBox cs, string tb)
        {
            int tableSelected = cs.SelectedIndex;
            string tname;
            switch (tableSelected)
            {
                case 0:
                    tname = @"SELECT * FROM [rooms]";
                    break;
                case 1:
                    tname = @"SELECT * FROM [rooms] WHERE roomType LIKE '" + tb + "'";
                    break;
                case 2:
                    tname = @"SELECT * FROM [rooms] WHERE roomType LIKE '" + tb + "'";
                    break;
                case 3:
                    tname = @"SELECT * FROM [rooms] WHERE roomAvailability LIKE '" + tb + "'";
                    break;
                case 4:
                    tname = @"SELECT * FROM [rooms] WHERE roomAvailability LIKE '" + tb + "'";
                    break;
                case 5:
                    tname = @"SELECT * FROM [rooms] WHERE roomAvailability LIKE '" + tb + "'";
                    break;
                default:
                    tname = "";
                    break;
            }
            return tname;
        }

        public string SelectedReservationTable(ComboBox cs, string tb)
        {
            int tableSelected = cs.SelectedIndex;
            string tname;
            switch (tableSelected)
            {
                case 0:
                    tname = @"SELECT * FROM [reservations]";
                    break;
                case 1:
                    tname = @"SELECT * FROM [rooms] WHERE roomType LIKE '" + tb + "'";
                    break;
                case 2:
                    tname = @"SELECT * FROM [rooms] WHERE roomType LIKE '" + tb + "'";
                    break;
                case 3:
                    tname = @"SELECT * FROM [reservations] WHERE recessStatus LIKE '" + tb + "'";
                    break;
                case 4:
                    tname = @"SELECT * FROM [reservations] WHERE recessStatus LIKE '" + tb + "'";
                    break;
                case 5:
                    tname = @"SELECT * FROM [reservations] WHERE recessStatus LIKE '" + tb + "'";
                    break;

                default:
                    tname = "";
                    break;
            }
            return tname;
        }

        public void AddRoom(Models.RoomModel rm){
			string sqlInsertRoom = @"INSERT INTO [rooms](roomSymbolCode,roomFloor,roomType,roomAvailability)" +
            "VALUES(@roomSymbolCode,@roomFloor,@roomType,@roomAvailability)";
            using (SqlConnection con = new SqlConnection(myRoomMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                
                SqlCommand cmd = new SqlCommand(sqlInsertRoom, con)
                {
                    CommandType = CommandType.Text
                };

                cmd.Parameters.Add("@roomSymbolCode", SqlDbType.VarChar).Value = rm.RoomSymbolCode;
                cmd.Parameters.Add("@roomFloor", SqlDbType.VarChar).Value = rm.RoomFloor;
                cmd.Parameters.Add("@roomType", SqlDbType.VarChar).Value = rm.RoomType;
                cmd.Parameters.Add("@roomAvailability", SqlDbType.VarChar).Value = rm.RoomAvailability;
                //cmd.Parameters.Add("@userId", SqlDbType.Int).Value = rm.UserId;

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room added successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add room \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    //if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
		}
		
		public void UpdateRoomById(int id){
			Models.RoomModel rmUpdate = new Models.RoomModel();
			string sqlUpdate = @"UPDATE [rooms] SET roomSymbolCode=@roomSymbolCode,roomFloor=@roomFloor,roomType=@roomType,roomAvailability=@roomAvailability WHERE roomId=@roomId";

            using (SqlConnection con = new SqlConnection(myRoomMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }

                SqlCommand cmd = new SqlCommand(sqlUpdate, con)
                {
                    CommandType = CommandType.Text
                };

                SqlDataAdapter adapt = new SqlDataAdapter()
                {
                    UpdateCommand = new SqlCommand(sqlUpdate, con)
                };
              
                
                cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@roomSymbolCode", SqlDbType.VarChar).Value = rmUpdate.RoomSymbolCode;
                cmd.Parameters.Add("@roomFloor", SqlDbType.VarChar).Value = rmUpdate.RoomFloor;
                cmd.Parameters.Add("@roomType", SqlDbType.VarChar).Value = rmUpdate.RoomType;
                cmd.Parameters.Add("@roomAvailability", SqlDbType.VarChar).Value = rmUpdate.RoomAvailability;


                try
                {

                    adapt.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Room details update successfully", "Update Room", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update room details \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                }
            }
            
		}
		
		public void RemoveRoomById(int rmId){
			string sqlDeleteRoom = @"DELETE FROM [rooms] WHERE roomId = '"+rmId+"'";

            using (SqlConnection con = new SqlConnection(myRoomMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                
                SqlCommand cmd = new SqlCommand(sqlDeleteRoom, con) { };
                try
                {
                    if (MessageBox.Show("Are you sure you want to remove room number:" + rmId.ToString() + "", " Remove Room", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Room number:" + rmId.ToString() + " removed", "Remove Room", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Room number:" + rmId.ToString() + " not removed", "Remove Room", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to remove room \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                }
            }
            
		}
		
		
		public void ReserveRoomForStudent(Models.ReservationModel rms){
            //aStudentNo,aRoomId,aBedAndChairUsage,aRecessStatus, aDateReserved
            string sqlInsertReservation = @"INSERT INTO [reservations](studentId,roomId,bedAndChairUsage,recessStatus,dateReserved)" +
            "VALUES(@StudentNo,@roomId,@aBedAndChairUsage,@recessStatus,@dateReserved)";

            using (SqlConnection con = new SqlConnection(myRoomMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                
                SqlCommand cmd = new SqlCommand(sqlInsertReservation, con)
                {
                    CommandType = CommandType.Text
                };

                cmd.Parameters.Add("@StudentNo", SqlDbType.Int).Value = rms.StudentId;
                cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = rms.RoomId;
                cmd.Parameters.Add("@aBedAndChairUsage", SqlDbType.VarChar).Value = rms.BedAndChairUsage;
                cmd.Parameters.Add("@recessStatus", SqlDbType.VarChar).Value = rms.RecessStatus;
                cmd.Parameters.Add("@dateReserved", SqlDbType.DateTime).Value = rms.DateReserved;


                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Reservation added successfully for student no:" + rms.ToString() + "", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add reservation \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                }
            }
            
		}
		
		public void UpdateReservationDetails(int rId){
			Models.ReservationModel rmUpdateReservation = new Models.ReservationModel();
			string sqlUpdateReservation = @"UPDATE [reservation] SET recessStatus=@recessStatus WHERE reservationId=@reservationId";

            using (SqlConnection con = new SqlConnection(myRoomMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
            
                SqlCommand cmd = new SqlCommand(sqlUpdateReservation, con)
                {
                    CommandType = CommandType.Text
                }; 

                SqlDataAdapter adapt = new SqlDataAdapter() {
                    UpdateCommand = new SqlCommand(sqlUpdateReservation, con)
                };
                
                cmd.Parameters.Add("@reservationId", SqlDbType.Int).Value = rId;
                cmd.Parameters.Add("@recessStatus", SqlDbType.VarChar).Value = rmUpdateReservation.RecessStatus;

                try
                {

                    adapt.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Reservation no:" + rId + " updated successfully", "Update Room", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update reservation \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                }
            }
            
		}
		
		public void RemoveStudentFromReservation(int rSR){
			string sqlDeleteReservation = @"DELETE FROM [reservation] WHERE reservationId = '"+rSR+"'";

            using (SqlConnection con = new SqlConnection(myRoomMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
           
                SqlCommand cmd = new SqlCommand(sqlDeleteReservation, con);
                try
                {
                    if (MessageBox.Show("Are you sure you want to remove reservation number:" + rSR.ToString() + "", " Remove Reservation", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Reservation number:" + rSR.ToString() + " removed", "Remove Reservation", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Reservation number:" + rSR.ToString() + " not removed", "Remove Reservation", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to remove reservation \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                }
            }
            
		}
	}
}



