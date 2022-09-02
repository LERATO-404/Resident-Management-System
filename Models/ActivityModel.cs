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
		private int _studentId;
		private string _semesterParticipating;
		private int _totalPoints;
		private string _allocatedDate;
		private int _userId;


		public ActivityModel(){
			
			
		}
		
		public ActivityModel(int anActivityId, int aStudentId,string aSemesterParticipating, int aTotalPoint, string anAllocatedDate){
			_activityId = anActivityId;
			StudentId = aStudentId;
			SemesterParticipating = aSemesterParticipating;
			_totalPoints = aTotalPoint;
			_allocatedDate = anAllocatedDate;
			//UserId  = aUserId;
			
		}

		public ActivityModel(int aStudentId, string aSemesterParticipating, int aTotalPoint, string anAllocatedDate)
		{
			StudentId = aStudentId;
			SemesterParticipating = aSemesterParticipating;
			_totalPoints = aTotalPoint;
			_allocatedDate = anAllocatedDate;
			//UserId = aUserId;

		}

		public ActivityModel(int aStudentId, int aTotalPoints)
		{
			StudentId = aStudentId;
			_totalPoints = aTotalPoints;
		}


		public int ActivityId{
			get {return _activityId;}
			set {_activityId = value;}
		}
		
		public string AllocatedDate
		{
			get {return _allocatedDate;}
			set {_allocatedDate = value;}
		}

		public int TotalPoints
		{
			get { return _totalPoints; }
			set { _totalPoints = value; }
		}

		public string SemesterParticipating{
			get {return _semesterParticipating;}
			set {
				if(value == "First-Semester" || value == "Second-Semester" || value == "Both-Semesters")
				{
					_semesterParticipating = value;
				}
				else{
					_semesterParticipating = "";
				}
			}
		}

		// Foreign key 
		public int StudentId { 
			get{ return _studentId; }
			set{ _studentId = value; } 
		} 
	 
		[ForeignKey("StudentId")] 
		public virtual StudentModel StudentModel { get; set; } 
		
		// Foreign key 
		public int UserId { 
			get{ return _userId; }
			set{ _userId = value; }
		} 
		[ForeignKey("UserId")] 
		public virtual UserModel UserModel { get; set; } 
		
	}
}
