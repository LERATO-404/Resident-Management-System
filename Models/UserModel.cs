using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Residence_Management_System.Models
{
    public class UserModel{
	
		private int _id;
		private string _firstName;
		private string _lastName;
		private string _emailAddress;
		private string _phoneNumber;
		private string _dOB;
		private string _jobTitle;
		private string _jobType;
		private string _username;
		private string _password;
		
		public UserModel(){
			
		}
		
		public UserModel(string aUsername,string aPassword){
			_username = aUsername;
			_password = aPassword;
		}
		
		public UserModel(int aId, string aFirstName, string aLstName,string aEmailAddress,string aPhoneNumber,string aDOB,string aJobTitle,string aJobType,string aUsername,string aPassword){
			_id = aId;
			_firstName = aFirstName;
			_lastName = aLstName;
			_emailAddress = aEmailAddress;
			_phoneNumber = aPhoneNumber;
			_dOB = aDOB;
			JobTitle = aJobTitle;
			JobType = aJobType;
			_username = aUsername;
			_password = aPassword;
		}
		
		public UserModel(string aFirstName, string aLstName,string aEmailAddress,string aPhoneNumber,string aDOB,string aJobTitle,string aJobType,string aUsername,string aPassword){
			
			_firstName = aFirstName;
			_lastName = aLstName;
			_emailAddress = aEmailAddress;
			_phoneNumber = aPhoneNumber;
			_dOB = aDOB;
			JobTitle = aJobTitle;
			JobType = aJobType;
			_username = aUsername;
			_password = aPassword;
		}
		
		public int UserId{
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
				if(value == "Residence-Manager" || value =="Room-Controller" || value == "Activity-Controller" || value == "Administrator"){
					_jobType = value;
				}
				else{
					_jobType = "Guest";
				}
			}
		}
		
		public string UserName{
			get {return _username;}
			set {_username = value;}
		}
		
		public string Password{
			get {return _password;}
			set {_password = value;}
		}
	}
}




