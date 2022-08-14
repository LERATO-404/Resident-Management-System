using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Residence_Management_System.Models
{
	public class PointsModel{
		
		private int _pointsId;
		private int _studentId; //FK
		private int _totalPoints;
			
		public PointsModel(){
			
		}
		
		public PointsModel(int aPointId, int aStudentId, int aTotalPoints ){
			_pointsId = aPointId;
			StudentId = aStudentId;
			_totalPoints = aTotalPoints;
		}
		
		public PointsModel(int aStudentId, int aTotalPoints ){
			
			StudentId = aStudentId;
			_totalPoints = aTotalPoints;
		}
		
		public int PointsId{
			get {return _pointsId;}
			set {_pointsId = value;}
		}
		
		public int TotalPoints{
			get {return _totalPoints;}
			set {_totalPoints = value;}
		}
		
		// Foreign key 
		[Display(Name = "StudentModel")] 
		public int StudentId { 
			get{ return _studentId; }
			set{ _studentId = value; }
		} 
	 
		[ForeignKey("StudentId")] 
		public virtual StudentModel students { get; set; } 
		
	}
}
