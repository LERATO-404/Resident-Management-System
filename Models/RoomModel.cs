using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Residence_Management_System.Models
{
	public class RoomModel{
		
		private int _roomID;
		private string _roomFloor;
		private string _roomType;
		private string _bedUsed;
		private string _chairUsed;
		private string _roomStatus;
		private int _userId;
		
		
		public RoomModel(){
			
		}
		
		public RoomModel(int aRoomId, string aRoomFloor, string aRoomType,string aBedUsed,string aChairUsed,string aRoomStatus, int aUserId){
			_roomID = aRoomId;
			RoomFloor = aRoomFloor;
			RoomType = aRoomType;
			BedUsed = aBedUsed;
			ChairUsed = aChairUsed;
			RoomStatus = aRoomStatus;
			UserId = aUserId;
		}
		
		public RoomModel(string aRoomFloor, string aRoomType,string aBedUsed,string aChairUsed,string aRoomStatus, int aUserId){
			RoomFloor = aRoomFloor;
			RoomType = aRoomType;
			BedUsed = aBedUsed;
			ChairUsed = aChairUsed;
			RoomStatus = aRoomStatus;
			UserId = aUserId;
			/*
			_roomFloor = aRoomFloor;
			_roomType = aRoomType;
			_bedUsed = aBedUsed;
			_chairUsed = aChairUsed;
			_roomStatus = aRoomStatus;*/
		}
		
		public int RoomId{
			get {return _roomID;}
			set {_roomID = value;}
		}
		
		
		public string RoomFloor{
			get {return _roomFloor;}
			set {
				if(value == "Floor-1" || value =="Floor-2" || value == "Floor-3" || value == "Floor-4"){
					_roomFloor = value;
				}
				else{
					_roomFloor = null;
				}
			}
		}
		
		public string RoomType{
			get {return _roomType;}
			set {
				if(value == "Single" || value =="Shared"){
					_roomType = value;
				}
				else{
					_roomType = null;
				}
			}
		}
		
		public string BedUsed{
			get {return _bedUsed;}
			set {
				if(value == "Residence-Bed" || value =="Student-Bed"){
					_bedUsed = value;
				}
				else{
					_bedUsed = null;
				}
			}
		}
		
		public string ChairUsed{
			get {return _chairUsed;}
			set {
				if(value == "Residence-Chair" || value =="Student-Chair"){
					_chairUsed = value;
				}
				else{
					_chairUsed = null;
				}
			}
		}
		
		public string RoomStatus{
			get {return _roomStatus;}
			set {
				if(value == "Fully-Occupied" || value =="Not-Fully-Occupied" || value == "Occupied"){
					_roomStatus = value;
				}
				else{
					_roomStatus = null;
				}
			}
		}
		
		// Foreign key 
		[Display(Name = "UserModel")] 
		public int UserId { 
			get{ return _userId; }
			set{ _userId = value; }
		} 
		[ForeignKey("UserId")] 
		public virtual UserModel users { get; set; } 

	}
}

