using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Residence_Management_System.Models
{
	public class ActivityModel{
		
		private int _activityId;
		private string _activityName;
		private string _activityDescription;
		private string _particpatingGender;
		private string _allocatedDate;
		private int _studentId;
		private int _userId;
		
		
		public ActivityModel(){
			
			
		}
		
		public ActivityModel(int anActivityId, string anActivityName, string aAnctivityDescription, string aParticpatingGender ,string anAllocatedDate,  int aStudentId, int aUserId){
			_activityId = anActivityId;
			_activityName = anActivityName;
			_activityDescription = aAnctivityDescription;
			ParticipatingGender = aParticpatingGender;
			_allocatedDate = anAllocatedDate;
			StudentId = aStudentId;
			UserId  = aUserId;
			
		}
		
		public ActivityModel(string anActivityName, string aAnctivityDescription, string aParticpatingGender ,string anAllocatedDate,  int aStudentId, int aUserId){
			_activityName = anActivityName;
			_activityDescription = aAnctivityDescription;
			ParticipatingGender = aParticpatingGender;
			_allocatedDate = anAllocatedDate;
			StudentId = aStudentId;
			UserId  = aUserId;
			
		}
		

		public int ActivityId{
			get {return _activityId;}
			set {_activityId = value;}
		}
		
		
		public string ActivityName{
			get {return _activityName;}
			set {_activityName = value;}
		}
		
		public string ActivityDescription{
			get {return _activityDescription;}
			set {_activityDescription = value;}
		}
		
		public string AllocatedDate{
			get {return _allocatedDate;}
			set {_allocatedDate = value;}
		}
		
		public string ParticipatingGender{
			get {return _particpatingGender;}
			set {
				if(value == "Male" || value =="Female" || value == "Both"){
					_particpatingGender = value;
				}
				else{
					_particpatingGender = null;
				}
			}
		}
		
		// Foreign key 
		[Display(Name = "StudentModel")] 
		public int StudentId { 
			get{ return _studentId; }
			set{ _studentId = value; } 
		} 
	 
		[ForeignKey("studentNumber")] 
		public virtual StudentModel students { get; set; } 
		
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
