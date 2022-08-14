using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Residence_Management_System.Models
{
	public class ReservationModel{
	
		private int _reservationId;
		private int _studentId; //Fk
		private int _roomId; //Fk
		private int _reservedBy; //Fk
		private string _recessStatus;
		private string _gender;
		private string _dateReserved;
		
		
		public ReservationModel(){
			
			
		}
		
		public ReservationModel(int aStudent, int aRoom, int aUser, string aRecessStatus, string aGender, string aDateReserved){
			
			StudentId = aStudent;
			RoomId = aRoom;
			UserId = aUser;
			RecessStatus = aRecessStatus;
			Gender = aGender;
			_dateReserved = aDateReserved;
		}
		
		public ReservationModel(int aReservetion, int aStudent, int aRoom, int aUser, string aRecessStatus,string aGender, string aDateReserved){
			_reservationId = aReservetion;
			StudentId = aStudent;
			RoomId = aRoom;
			UserId = aUser;
			RecessStatus = aRecessStatus;
			Gender = aGender;
			_dateReserved = aDateReserved;
		}
		
		
		public int ReservatioId{
			get {return _reservationId;}
			set {_reservationId = value;}
		}
		
		public string RecessStatus{
			get {return _recessStatus;}
			set {
				if(value == "staying" || value =="leaving"){
					_recessStatus = value;
				}
				else{
					_recessStatus = null;
				}
			}
		}
		
		public string Gender
		{
			get { return _gender; }
			set
			{
				if (value == "Male" || value == "Female")
				{
					_gender = value;
				}
				else
				{
					_gender = "";
				}
			}
		}
		
		public string DateReserved{
			get {return _dateReserved;}
			set {_dateReserved = value;}
		}
		
		// Foreign key 
		[Display(Name = "StudentModel")] 
		public int StudentId { 
			get{ return _studentId; }
			set{ _studentId = value; }
		} 
	 
		[ForeignKey("StudentId")] 
		public virtual StudentModel students { get; set; } 
		
		// Foreign key 
		[Display(Name = "UserModel")] 
		public int UserId { 
			get{ return _reservedBy; } 
			set{ _reservedBy = value; } 
		} 
		[ForeignKey("UserId")] 
		public virtual UserModel users { get; set; }
		
		// Foreign key 
		[Display(Name = "RoomModel")] 
		public int RoomId { 
			get{ return _roomId; } 
			set{ _roomId = value; } 
		} 
		[ForeignKey("RoomId")] 
		public virtual RoomModel rooms { get; set; }
		
	}
}
