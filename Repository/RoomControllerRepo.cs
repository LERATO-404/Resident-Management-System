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
    public class RoomControllerRepo{

        private readonly MyMethods myRoomMethod = new MyMethods();
        private readonly string userRole = UserId.GetUserJobType();

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
                case 6:
                    tname = @"SELECT r.roomId, r.roomSymbolCode, r.roomType, rs.studentId AS OccupantId, s.firstName, s.lastName
                                   FROM Rooms r
                                        INNER JOIN Reservations rs
                                           ON r.roomId = rs.roomId
                                        INNER JOIN Students s
                                           ON  rs.studentId = s.studentId
                                       ORDER BY r.roomId";
                    break;

                default:
                    tname = "";
                    break;
            }
            return tname;
        }
        

        public ReservationModel ViewReservationDetails(int id, ReservationModel reservationView)
        {
            string sqlReservation = @"SELECT * FROM [reservations] WHERE reservationId = '" + id + "'";
            using (SqlConnection con = new SqlConnection(myRoomMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }

                SqlCommand cmd = new SqlCommand(sqlReservation, con)
                {
                    CommandType = CommandType.Text
                };
                SqlDataReader srd = cmd.ExecuteReader();
                try
                {
                    if (srd.Read())
                    {
                        reservationView.StudentId = (int)srd["studentId"];
                        reservationView.RoomId = (int)srd["roomId"];
                        reservationView.BedAndChairUsage = srd["bedAndChairUsage"].ToString();
                        reservationView.RecessStatus = srd["recessStatus"].ToString();
                        reservationView.DateReserved = (DateTime)srd["dateReserved"];
                        reservationView.MovedInDate = (DateTime)srd["MovedInDate"];
;                        
                    }
                    else
                    {
                        MessageBox.Show("No data found reservation Id " + id.ToString(), "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to view reservation. No reservation in the system to view \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    srd.Close();
                    cmd.Dispose();
                }
                return reservationView;
            }

        }

        public RoomModel ViewRoomDetails(int id, RoomModel roomView)
        {
            string sqlStudent = @"SELECT * FROM [rooms] WHERE roomId = '" + id + "'";
            using (SqlConnection con = new SqlConnection(myRoomMethod.GetConnection()))
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
                        roomView.RoomSymbolCode = srd["roomSymbolCode"].ToString();
                        roomView.RoomFloor = srd["roomFloor"].ToString();
                        roomView.RoomType = srd["roomType"].ToString();
                        roomView.RoomAvailability = srd["roomAvailability"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No data found room Id " + id.ToString(), "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to view room. No room in the system to view \n" + ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    srd.Close();
                    cmd.Dispose();
                }
                return roomView;
            }

        }

        public void AddRoom(RoomModel rm){

            if (userRole == "Room-Controller")
            {
                string sqlInsertRoom = @"INSERT INTO [rooms](roomSymbolCode,roomFloor,roomType,roomAvailability,addedBy)" +
            "VALUES(@roomSymbolCode,@roomFloor,@roomType,@roomAvailability,@addedBy)";
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
                    cmd.Parameters.Add("@addedBy", SqlDbType.Int).Value = UserId.GetUserId();

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Room added successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed to add room \nThe Room Symbol Code entered already exist", "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("You don't have the privileges to add a room.\nOnly the room-controller can perform this task", "Not allowed", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
            }

        }
		
		public void UpdateRoomById(int id, RoomModel rmUpdate)
        {
            if (userRole == "Room-Controller")
            {
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


                    adapt.UpdateCommand.Parameters.Add("@roomId", SqlDbType.Int).Value = id;
                    adapt.UpdateCommand.Parameters.Add("@roomSymbolCode", SqlDbType.VarChar).Value = rmUpdate.RoomSymbolCode;
                    adapt.UpdateCommand.Parameters.Add("@roomFloor", SqlDbType.VarChar).Value = rmUpdate.RoomFloor;
                    adapt.UpdateCommand.Parameters.Add("@roomType", SqlDbType.VarChar).Value = rmUpdate.RoomType;
                    adapt.UpdateCommand.Parameters.Add("@roomAvailability", SqlDbType.VarChar).Value = rmUpdate.RoomAvailability;


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
            else
            {
                MessageBox.Show("You don't have the privileges to update a room.\nOnly the room-controller can perform this task", "Not allowed", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
            }
		}
		
        public void RemoveRoomById(int rmId)
        {
            if (userRole == "Room-Controller")
            {
                using (SqlConnection con = new SqlConnection(myRoomMethod.GetConnection()))
                {
                    if (con.State != ConnectionState.Open) { con.Open(); }

                    SqlCommand cmd = new SqlCommand(SelectedRoomToDelete(rmId), con) { };
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
            else
            {
                MessageBox.Show("You don't have the privileges to delete a room.\nOnly the room-controller can perform this task", "Not allowed", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
            }
        }

		public void ReserveRoomForStudent(ReservationModel rms){


            if (userRole == "Room-Controller")
            {
                string sqlInsertReservation = @"INSERT INTO [reservations](studentId,roomId,reservedBy,bedAndChairUsage,recessStatus,dateReserved,MovedInDate)" +
                    "VALUES(@StudentId,@roomId,@reservedBy,@BedAndChairUsage,@recessStatus,@dateReserved,@MovedInDate)";
                using (SqlConnection con = new SqlConnection(myRoomMethod.GetConnection()))
                {
                    if (con.State != ConnectionState.Open) { con.Open(); }

                    SqlCommand cmd = new SqlCommand(sqlInsertReservation, con)
                    {
                        CommandType = CommandType.Text
                    };

                    cmd.Parameters.Add("@StudentId", SqlDbType.Int).Value = rms.StudentId;
                    cmd.Parameters.Add("@roomId", SqlDbType.Int).Value = rms.RoomId;
                    cmd.Parameters.Add("@reservedBy", SqlDbType.Int).Value = UserId.GetUserId();
                    cmd.Parameters.Add("@BedAndChairUsage", SqlDbType.VarChar).Value = rms.BedAndChairUsage;
                    cmd.Parameters.Add("@recessStatus", SqlDbType.VarChar).Value = rms.RecessStatus;
                    cmd.Parameters.Add("@dateReserved", SqlDbType.DateTime).Value = rms.DateReserved;
                    cmd.Parameters.Add("@movedInDate", SqlDbType.DateTime).Value = rms.MovedInDate;


                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Reservation added successfully for student Id:" + rms.StudentId.ToString() + "", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed to add reservation \nInvalid student/room Id", "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cmd.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("You don't have the privileges to reserve a room.\nOnly the room-controller can perform this task", "Not allowed", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
            }
		}
		
		public void UpdateReservationDetails(int rId, ReservationModel rmUpdateReservation)
        {

            if (userRole == "Room-Controller")
            {
                string sqlUpdateReservation = @"UPDATE [reservations] SET studentId=@studentId,roomId=@roomId,bedAndChairUsage=@bedAndChairUsage,recessStatus=@recessStatus,dateReserved=@dateReserved,MovedInDate=@MovedInDate WHERE reservationId=@reservationId";
                using (SqlConnection con = new SqlConnection(myRoomMethod.GetConnection()))
                {
                    if (con.State != ConnectionState.Open) { con.Open(); }

                    SqlCommand cmd = new SqlCommand(sqlUpdateReservation, con)
                    {
                        CommandType = CommandType.Text
                    };

                    SqlDataAdapter adapt = new SqlDataAdapter()
                    {
                        UpdateCommand = new SqlCommand(sqlUpdateReservation, con)
                    };

                    adapt.UpdateCommand.Parameters.Add("@reservationId", SqlDbType.Int).Value = rId;
                    adapt.UpdateCommand.Parameters.Add("@studentId", SqlDbType.Int).Value = rmUpdateReservation.StudentId;
                    adapt.UpdateCommand.Parameters.Add("@roomId", SqlDbType.Int).Value = rmUpdateReservation.RoomId;
                    adapt.UpdateCommand.Parameters.Add("@bedAndChairUsage", SqlDbType.VarChar).Value = rmUpdateReservation.BedAndChairUsage;
                    adapt.UpdateCommand.Parameters.Add("@recessStatus", SqlDbType.VarChar).Value = rmUpdateReservation.RecessStatus;
                    adapt.UpdateCommand.Parameters.Add("@dateReserved", SqlDbType.DateTime).Value = rmUpdateReservation.DateReserved;
                    adapt.UpdateCommand.Parameters.Add("@MovedInDate", SqlDbType.DateTime).Value = rmUpdateReservation.MovedInDate;

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
            else
            {
                MessageBox.Show("You don't have the privileges to update a reservation details.\nOnly the room-controller can perform this task", "Not allowed", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
            }
		}
		
		public void RemoveReservationbyId(int rSR){

            if (userRole == "Room-Controller")
            {
                using (SqlConnection con = new SqlConnection(myRoomMethod.GetConnection()))
                {
                    if (con.State != ConnectionState.Open) { con.Open(); }

                    SqlCommand cmd = new SqlCommand(SelectedReservationToDelete(rSR), con);
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
            else
            {
                MessageBox.Show("You don't have the privileges to delete a reservation.\nOnly the room-controller can perform this task", "Not allowed", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
            }



        }
	}
}



