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
		private string _roomSymbolCode;
		private string _roomFloor;
		private string _roomType;
		private string _roomAvailability;
		private int _userId;
		
		
		public RoomModel(){
			
		}
		
		public RoomModel(int aRoomId,string aRoomSymbol, string aRoomFloor, string aRoomType,string aRoomAvailability, int aUserId){
			_roomID = aRoomId;
			_roomSymbolCode = aRoomSymbol;
			RoomFloor = aRoomFloor;
			RoomType = aRoomType;
			RoomAvailability= aRoomAvailability;
			UserId = aUserId;
		}

		public RoomModel(string aRoomSymbol, string aRoomFloor, string aRoomType, string aRoomAvailability)
		{
			_roomSymbolCode = aRoomSymbol;
			RoomFloor = aRoomFloor;
			RoomType = aRoomType;
			RoomAvailability = aRoomAvailability;
			//UserId = aUserId;
		}

		public int RoomId{
			get {return _roomID;}
			set {_roomID = value;}
		}

		public string RoomSymbolCode
        {
            get {return _roomSymbolCode; }
            set { _roomSymbolCode = value; }
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
		
		public string RoomAvailability{
			get {return _roomAvailability; }
			set {
				if(value == "Available" || value =="Not-Available"){
					_roomAvailability = value;
				}
				else{
					_roomAvailability = null;
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

