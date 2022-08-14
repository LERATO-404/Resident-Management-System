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
    public class RoomControllerRepo{
		
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
		
		public void addRoom(Models.RoomModel rm){
			string sqlInsertRoom = @"INSERT INTO [rooms](roomFloor,roomType,bedUsed,chairUsed,roomStatus,userId)"+ 
			"VALUES(@roomFloor,@roomType,@bedUsed,@chairUsed,@roomStatus,@userId)";
			
			SqlConnection con = getConnection();
			SqlCommand cmd = new SqlCommand(sqlInsertRoom, con);
			
			
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Add("@roomFloor",SqlDbType.VarChar).Value = rm.RoomFloor;
			cmd.Parameters.Add("@roomType",SqlDbType.VarChar).Value = rm.RoomType;
			cmd.Parameters.Add("@bedUsed",SqlDbType.VarChar).Value = rm.BedUsed;
			cmd.Parameters.Add("@chairUsed",SqlDbType.VarChar).Value = rm.ChairUsed;
			cmd.Parameters.Add("@roomStatus",SqlDbType.VarChar).Value = rm.RoomStatus;
			cmd.Parameters.Add("@userId",SqlDbType.Int).Value = rm.UserId;
			
			try{
				cmd.ExecuteNonQuery();
				MessageBox.Show("Room added successfully", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
			}catch(Exception ex){
				MessageBox.Show("Failed to add room \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
			 
		}
		
		public void updateRoomById(int id){
			Models.RoomModel rmUpdate = new Models.RoomModel();
			string sqlUpdate = @"UPDATE [rooms] SET roomFloor=@roomFloor,roomType=@roomType,bedUsed=@bedUsed,chairUsed=@chairUsed,roomStatus=@roomStatus WHERE roomId=@roomId";
		
			SqlConnection con = getConnection();
			SqlCommand cmd = new SqlCommand(sqlUpdate, con);
			
			SqlDataAdapter adapt = new SqlDataAdapter();
			adapt.UpdateCommand = new SqlCommand(sqlUpdate, con);
			
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Add("@roomId",SqlDbType.Int).Value = id;
			cmd.Parameters.Add("@roomFloor",SqlDbType.VarChar).Value = rmUpdate.RoomFloor;
			cmd.Parameters.Add("@roomType",SqlDbType.VarChar).Value = rmUpdate.RoomType;
			cmd.Parameters.Add("@bedUsed",SqlDbType.VarChar).Value = rmUpdate.BedUsed;
			cmd.Parameters.Add("@chairUsed",SqlDbType.VarChar).Value = rmUpdate.ChairUsed;
			cmd.Parameters.Add("@roomStatus",SqlDbType.VarChar).Value = rmUpdate.RoomStatus;
			
				
			try{
				
				adapt.UpdateCommand.ExecuteNonQuery();
				MessageBox.Show("Room details update successfully", "Update Room", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
			}catch(Exception ex){
				MessageBox.Show("Failed to update room details \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
			cmd.Dispose();
		}
		
		public void removeRoomById(int rmId){
			string sqlDeleteRoom = @"DELETE FROM [rooms] WHERE roomId = '"+rmId+"'";
			
			SqlConnection con = getConnection();
			SqlCommand cmd = new SqlCommand(sqlDeleteRoom, con);
			
			try{
				if(MessageBox.Show("Are you sure you want to remove room number:"+rmId.ToString()+""," Remove Room", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
					cmd.ExecuteNonQuery();
					MessageBox.Show("Room number:"+rmId.ToString()+" removed", "Remove Room", (MessageBoxButtons)MessageBoxButton.OK,MessageBoxIcon.Information);
				}else{
					MessageBox.Show("Room number:"+rmId.ToString()+" not removed", "Remove Room", (MessageBoxButtons)MessageBoxButton.OK,MessageBoxIcon.Information);
				}
			}catch(Exception ex){
				MessageBox.Show("Failed to remove room \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
		}
		
		
		public void reserveRoomForStudent(Models.ReservationModel rms){
			string sqlInsertReservation = @"INSERT INTO [reservations](studentId,roomId,reservedBy,recessStatus,gender,dateReserved)"+ 
			"VALUES(@studentId,@roomId,@reservedBy,@recessStatus,@gender,@dateReserved)";
			
			SqlConnection con =  getConnection();
			SqlCommand cmd = new SqlCommand(sqlInsertReservation, con);
			
			
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Add("@studentId",SqlDbType.VarChar).Value = rms.StudentId;
			cmd.Parameters.Add("@roomId",SqlDbType.VarChar).Value = rms.RoomId;
			cmd.Parameters.Add("@reservedBy",SqlDbType.VarChar).Value = rms.UserId;
			cmd.Parameters.Add("@recessStatus",SqlDbType.VarChar).Value = rms.RecessStatus;
			cmd.Parameters.Add("@gender",SqlDbType.VarChar).Value = rms.Gender;
			cmd.Parameters.Add("@dateReserved",SqlDbType.VarChar).Value = rms.DateReserved;
			
			
			try{
				cmd.ExecuteNonQuery();
				MessageBox.Show("Reservation added successfully for student no:"+rms.ToString()+"", "Information", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
			}catch(Exception ex){
				MessageBox.Show("Failed to add reservation \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
		}
		
		public void updateReservationDetails(int rId){
			Models.ReservationModel rmUpdateReservation = new Models.ReservationModel();
			string sqlUpdateReservation = @"UPDATE [reservation] SET recessStatus=@recessStatus WHERE reservationId=@reservationId";
		
			SqlConnection con =  getConnection();
			SqlCommand cmd = new SqlCommand(sqlUpdateReservation, con);
			
			SqlDataAdapter adapt = new SqlDataAdapter();
			adapt.UpdateCommand = new SqlCommand(sqlUpdateReservation, con);
			
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Add("@reservationId",SqlDbType.Int).Value = rId;
			cmd.Parameters.Add("@recessStatus",SqlDbType.VarChar).Value = rmUpdateReservation.RecessStatus;

			try{
				
				adapt.UpdateCommand.ExecuteNonQuery();
				MessageBox.Show("Reservation no:"+rId+" updated successfully", "Update Room", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
			}catch(Exception ex){
				MessageBox.Show("Failed to update reservation \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
			cmd.Dispose();
		}
		
		public void removeStudentFromReservation(int rSR){
			string sqlDeleteReservation = @"DELETE FROM [reservation] WHERE reservationId = '"+rSR+"'";
			
			SqlConnection con =  getConnection();
			SqlCommand cmd = new SqlCommand(sqlDeleteReservation, con);
			
			try{
				if(MessageBox.Show("Are you sure you want to remove reservation number:"+rSR.ToString()+""," Remove Reservation", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
					cmd.ExecuteNonQuery();
					MessageBox.Show("Reservation number:"+rSR.ToString()+" removed", "Remove Reservation", (MessageBoxButtons)MessageBoxButton.OK,MessageBoxIcon.Information);
				}else{
					MessageBox.Show("Reservation number:"+rSR.ToString()+" not removed", "Remove Reservation", (MessageBoxButtons)MessageBoxButton.OK,MessageBoxIcon.Information);
				}
			}catch(Exception ex){
				MessageBox.Show("Failed to remove reservation \n"+ ex.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
			}
			if (con.State == ConnectionState.Open)
				con.Close();
		}
	}
}


