using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Residence_Management_System.ExtraMethods
{

    internal class IsValid
    {
        // Regular expression used to validate a phone number.
        const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

        // Regular expression used to validate a phone number.
        const string reg = @"^[0-9]+$";

        // validate email 
        const string emailReg = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
        const string gmail = "@gmail.com";

        const int phoneLen = 10;
        const int studentNoLen = 8;
        
        public bool IsValidEmailAddress(string email, Label labelSelected)
        {

            bool isEmValid = Regex.IsMatch(email, emailReg);
            string modifiedEmail = email.ToLower();
            if (isEmValid == true && modifiedEmail.Contains(gmail))
            {
                labelSelected.Visible = false;
                return true;
            }
            else
            {
                labelSelected.Visible = true;
                labelSelected.Text = "Invalid Email";
                return false;
            }

        }

        public bool IsValidPhoneNumber(string sourceNum, Label labelSelected)
        {
            bool isPhoneValid = Regex.IsMatch(sourceNum, motif);
            if (isPhoneValid == true && sourceNum.Length == phoneLen)
            {
                labelSelected.Visible = false;
                return true;
            }
            else
            {
                labelSelected.Visible = true;
                labelSelected.Text = "Invalid Phone number";
                return false;
            }
        }

        public bool IsValidStudentNumber(string sourceNum, Label labelSelected)
        {
            bool isStuNoValid = Regex.IsMatch(sourceNum, reg);
            if (isStuNoValid == true && sourceNum.Length == studentNoLen)
            {
                labelSelected.Visible = false;
                return true;
            }
            else
            {
                labelSelected.Visible = true;
                labelSelected.Text = "Invalid student number";
                return false;
            }
        }


    }
}
