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
		private int _studentId; //Fk -student number 
		private int _roomId; //Fk - room symbol
		private int _reservedBy; //Fk -- addedby
		private string _bedAndChairUsage;
		private string _recessStatus;
		private string _dateReserved;
		
		
		public ReservationModel(){
			
			
		}
		
		public ReservationModel(int aReservationId, int aStudentNo, int aRoomId, int aUser, string aBedAndChairUsage, string aRecessStatus, string aDateReserved){
			_reservationId  = aReservationId;
			_studentId = aStudentNo;
			_roomId  = aRoomId;
			_reservedBy  = aUser;
			BedAndChairUsage = aBedAndChairUsage;
			RecessStatus = aRecessStatus;
			_dateReserved = aDateReserved;
		}

		public ReservationModel(int aStudentNo, int aRoomId, string aBedAndChairUsage, string aRecessStatus, string aDateReserved)
		{
			StudentId = aStudentNo;
			_roomId = aRoomId;
			//_reservedBy = aUser;
			BedAndChairUsage = aBedAndChairUsage;
			RecessStatus = aRecessStatus;
			_dateReserved = aDateReserved;
		}


		public int ReservatioId{
			get {return _reservationId;}
			set {_reservationId = value;}
		}

		public int StudentId
		{
			get { return _studentId; }
			set { _studentId = value; }
		}

		public int RoomId
		{
			get { return _roomId; }
			set { _roomId = value; }
		}

		public string BedAndChairUsage
		{
		
			get { return _bedAndChairUsage; }
			set { 
				if(value == "R:Bed-Chair" || value == "S:Bed-Chair" || value == "R:Bed-S:Chair" || value == "R:Chair-S:Bed")
                {
					_bedAndChairUsage = value;
                }
                else
                {
					_bedAndChairUsage = null;
                }
			}
		}

		public string RecessStatus{
			get {return _recessStatus;}
			set {
				if(value == "staying" || value =="leaving" || value == "not-sure")
				{
					_recessStatus = value;
				}
				else{
					_recessStatus = null;
				}
			}
		}
		
		public string DateReserved{
			get {return _dateReserved;}
			set {_dateReserved = value;}
		}
		

		/*
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
		*/
	}
}
