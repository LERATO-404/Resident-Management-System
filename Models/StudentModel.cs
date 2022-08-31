using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Residence_Management_System.Models
{
	public class StudentModel{
		
		private int _studentId;
		private string _firstName;
		private string _lastName;
		private string _emailAddress;
		private string _phoneNumber;
		private string _gender;
		private string _dOB;
		private string _nextOfKinFullName;
		private string _nextOfKinPhone;
		private int _studentNo;
		private string _studentType;
		private string _courseName;
		private string _registrationStatus;
		private int _userId;
		
		public StudentModel(){
			
		}
		
		public StudentModel(int aStudentId, string aFirstName, string aLstName,string aEmailAddress,string aPhoneNumber,string aGender,string 
		aDOB, string aNextOfKinName, string aNextOfKinPhone, int aStudentNo, string aStudentType, string aCourseName, string aRegistrationStatus){
			_studentId = aStudentId;
			_firstName = aFirstName;
			_lastName = aLstName;
			_emailAddress = aEmailAddress;
			_phoneNumber = aPhoneNumber;
			Gender = aGender;
			_dOB = aDOB;
			_nextOfKinFullName = aNextOfKinName;
			_nextOfKinPhone = aNextOfKinPhone;
			_studentNo = aStudentNo;
			StudentType = aStudentType;
			_courseName = aCourseName;
			RegistrationStatus = aRegistrationStatus;
			//UserId = aUserId;
		}

		public StudentModel(string aFirstName, string aLstName, string aEmailAddress, string aPhoneNumber, string aGender, string
		aDOB, string aNextOfKinName, string aNextOfKinPhone, int aStudentNo, string aStudentType, string aCourseName, string aRegistrationStatus)
		{
			
			_firstName = aFirstName;
			_lastName = aLstName;
			_emailAddress = aEmailAddress;
			_phoneNumber = aPhoneNumber;
			Gender = aGender;
			_dOB = aDOB;
			_nextOfKinFullName = aNextOfKinName;
			_nextOfKinPhone = aNextOfKinPhone;
			_studentNo = aStudentNo;
			StudentType = aStudentType;
			_courseName = aCourseName;
			RegistrationStatus = aRegistrationStatus;
			//Us/UserId = aUserId;
		}

		public int StudentId{
			get {return _studentId;}
			set {_studentId = value;}
		}
		
		public string FirstName{
			get {return _firstName;}
			set {_firstName = value;}
		}
		
		
		public string LastName{
			get {return _lastName;}
			set {_lastName = value;}
		}
		
		public string EmailAddress{
			get {return _emailAddress;}
			set {_emailAddress = value;}
		}
		
		public string PhoneNumber{
			get {return _phoneNumber;}
			set {_phoneNumber = value;}
		}
		
		public string Gender{
			get {return _gender;}
			set { 
				if(value == "Male" || value =="Female"){
					_gender = value;
				}
				else{
					_gender ="";
				}
			}
		}
		
		public string DateOfBirth{
			get {return _dOB;}
			set {_dOB = value;}
		}


		public string NextOfKinFullName
		{
			get { return _nextOfKinFullName; }
			set { _nextOfKinFullName = value; }
		}

		public string NextOfKinPhone
		{
			get { return _nextOfKinPhone; }
			set { _nextOfKinPhone = value; }
		}

		public int StudentNo
		{
			get { return _studentNo; }
			set { _studentNo = value; }
		}

		public string StudentType{
			get {return _studentType;}
			set { 
				if(value == "Freshmen" || value =="Sophomore" || value == "Junior" || value == "Senior"){
					_studentType = value;
				}
				else{
					_studentType ="";
				}
			}
		}
		
		public string CourseName{
			get {return _courseName;}
			set {_courseName = value;}
		}

		public string RegistrationStatus
        {
			get { return _registrationStatus; }
			set
			{
				if (value == "Active" || value == "Not-Active")
				{
					_registrationStatus = value;
				}
				else
				{
					_registrationStatus = "";
				}
			}
		}



		
		// Foreign key 
		//[Display(Name = "UserModel")] 
		public int UserId { 
			get{ return _userId; }
			set{ _userId = value; }
		} 
		//[ForeignKey("UserId")] 
		//public virtual UserModel users { get; set; }*/
	}
}

