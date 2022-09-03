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
		private DateTime _dateReserved;
		private DateTime _movedInDate;
		
		
		public ReservationModel(){
			
			
		}
		
		public ReservationModel(int aReservationId, int aStudentNo, int aRoomId, string aBedAndChairUsage, string aRecessStatus, DateTime aDateReserved, DateTime aMovedInDate)
		{
			_reservationId  = aReservationId;
			_studentId = aStudentNo;
			_roomId  = aRoomId;
			BedAndChairUsage = aBedAndChairUsage;
			RecessStatus = aRecessStatus;
			_dateReserved = aDateReserved;
			_movedInDate = aMovedInDate;
		}

		public ReservationModel(int aStudentNo, int aRoomId, string aBedAndChairUsage, string aRecessStatus, DateTime aDateReserved, DateTime aMovedInDate)
		{
			StudentId = aStudentNo;
			RoomId = aRoomId;
			BedAndChairUsage = aBedAndChairUsage;
			RecessStatus = aRecessStatus;
			_dateReserved = aDateReserved;
			_movedInDate = aMovedInDate;
		}


		public int ReservatioId{
			get {return _reservationId;}
			set {_reservationId = value;}
		}

		public string BedAndChairUsage
		{
		
			get { return _bedAndChairUsage; }
			set { 
				if(value == "S:Bed-Chair" || value == "R:Bed-S:Chair" || value == "R:Chair-S:Bed" || value == "R:Bed-Chair")
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
		
		public DateTime DateReserved
		{
			get {return _dateReserved;}
			set {_dateReserved = value;}
		}
		

		public DateTime MovedInDate
		{
			get { return _movedInDate; }
			set { _movedInDate = value; }
		}


		// Foreign key 
		//[Display(Name = "StudentModel")] 
		public int StudentId { 
			get{ return _studentId; }
			set{ _studentId = value; }
		} 
	 
		[ForeignKey("StudentId")] 
		public virtual StudentModel student { get; set; } 
		
		// Foreign key 
		//[Display(Name = "UserModel")] 
		public int UserId { 
			get{ return _reservedBy; } 
			set{ _reservedBy = value; } 
		} 
		[ForeignKey("UserId")] 
		public virtual UserModel usermodel { get; set; }
		
		// Foreign key 
		//[Display(Name = "RoomModel")] 
		public int RoomId { 
			get{ return _roomId; } 
			set{ _roomId = value; } 
		} 
		[ForeignKey("RoomId")] 
		public virtual RoomModel roommodel { get; set; }
		
	}
}
