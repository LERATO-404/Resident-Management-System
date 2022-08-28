using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Residence_Management_System.Models
{
	public class WorkerModel{
		
		private int _id;
		private string _firstName;
		private string _lastName;
		private string _emailAddress;
		private string _phoneNumber;
		private string _dOB;
        private string _gender;
        private string _jobTitle;
		private string _jobType;
		private string _startDate;
		private int _userId; // addedBy
		
		
		
		public WorkerModel(){
			
		}
		
		public WorkerModel(int aId, string aFirstName, string aLstName,string aEmailAddress,string aPhoneNumber,string aDOB,string aGender,string aJobTitle,string aJobType, string aStartDate, int aUserId){
			_id = aId;
			_firstName = aFirstName;
			_lastName = aLstName;
			_emailAddress = aEmailAddress;
			_phoneNumber = aPhoneNumber;
			_dOB = aDOB;
			Gender = aGender;
			JobTitle = aJobTitle;
			JobType = aJobType;
			_startDate = aStartDate;
			UserId = aUserId;
			
		}
		
		public WorkerModel(string aFirstName, string aLastName,string aEmailAddress,string aPhoneNumber,string aDOB, string aGender, string aJobTitle,string aJobType, string aStartDate){
			
			_firstName = aFirstName;
			_lastName = aLastName;
			_emailAddress = aEmailAddress;
			_phoneNumber = aPhoneNumber;
			_dOB = aDOB;
            Gender = aGender;
            JobTitle = aJobTitle;
			JobType = aJobType;
			_startDate = aStartDate;
			//UserId = aUserId;
		}
		
		public int WorkerId{
			get {return _id;}
			set {_id = value;}
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
		
		public string DateOfBirth{
			get {return _dOB;}
			set {_dOB = value;}
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

        public string JobTitle{
			get {return _jobTitle;}
			set {
				if(value == "Full-Time" || value =="Part-Time" || value == "Temporary" || value == "Volunteer"){
					_jobTitle = value;
				}
				else{
					_jobTitle = "Guest";
				}
			}
		}
		
		public string JobType{
			get {return _jobType;}
			set {
				if(value == "Security" || value =="Cleaner" || value == "Gardener" || value == "Constructor"){
					_jobType = value;
				}
				else{
					_jobType = "other";
				}
			}
		}
		
		public string StartDate{
			get {return _startDate;}
			set { _startDate = value; }
		}
		
		
		[ForeignKey("UserModel")]
		public int UserId { 
			get{ return _userId; }
			set{ _userId = value; }
		} 
		public virtual UserModel UserModel { get; set; }
		
	}
}

