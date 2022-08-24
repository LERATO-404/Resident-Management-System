using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Windows.Forms;

namespace Residence_Management_System
{
    public partial class Register : Form
    {

        // Regular expression used to validate a phone number.
        const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

        // validate email
        const string emailReg = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

        public Register()
        {
            InitializeComponent();
            lblInvalidEmail.Visible = false;
            lblInvalidPhone.Visible = false;
        }

        /*===========================method=========================*/
        public Boolean isEmptyInput()
        {
            if (String.IsNullOrEmpty(txtFirstName.Text) == true || String.IsNullOrEmpty(txtLastName.Text) == true ||
            String.IsNullOrEmpty(txtEmailAddress.Text) == true || String.IsNullOrEmpty(txtPhoneNumber.Text) == true ||
            String.IsNullOrEmpty(dtpDob.Text) == true || String.IsNullOrEmpty(txtRegisterUsername.Text) == true ||
            String.IsNullOrEmpty(txtRegisterPassword.Text) == true ){
                return true;
            }
            else
            {
                return false;
            }
        }

        private void clearRegister()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmailAddress.Clear();
            txtPhoneNumber.Clear();
            dtpDob.Text = "";
            cBoxJobTitle.SelectedIndex = -1;
            cBoxJobType.SelectedIndex = -1;
            txtRegisterUsername.Clear();
            txtRegisterPassword.Clear();
        }

        public string jobTypeSelected()
        {
            string _jobType = "Guest";
            if (cBoxJobType.SelectedIndex == 0)
            {
                _jobType = "Residence-Manager";
            }
            else if (cBoxJobType.SelectedIndex == 1)
            {
                _jobType = "Administrator";
            }
            else if (cBoxJobType.SelectedIndex == 2)
            {
                _jobType = "Room-Controller";
            }
            else if (cBoxJobType.SelectedIndex == 3)
            {
                _jobType = "Activity-Controller";
            }
            return _jobType;
        }


        public string jobTitleSelected()
        {
            string _jobTitle = "Guest";
            if (cBoxJobTitle.SelectedIndex == 0)
            {
                _jobTitle = "Full-Time";
            }
            else if (cBoxJobTitle.SelectedIndex == 1)
            {
                _jobTitle = "Part-Time";
            }
            else if (cBoxJobTitle.SelectedIndex == 2)
            {
                _jobTitle = "Temporary";
            }
            else if (cBoxJobTitle.SelectedIndex == 3)
            {
                _jobTitle = "Volunteer";
            }
            return _jobTitle;

      
        }

        public bool IsValidEmailAddress(string email)
        {
            
            bool isEmValid = Regex.IsMatch(email, emailReg);
            if (isEmValid == true)
            {
                return true;
            }
            else
            {
                lblInvalidEmail.Visible = true;
                lblInvalidEmail.Text = "Invalid Email";
                return false;
            } 
           
        }

        

        public bool IsValidPhoneNumber(string sourceNum)
        {
            bool isPhoneValid = Regex.IsMatch(sourceNum, motif);
            if (isPhoneValid == true &&  sourceNum.Length == 10)
            {
                return true;
            }
            else
            {
                lblInvalidPhone.Visible = true;
                lblInvalidPhone.Text = "Invalid Phone number";
                return false;
            }
        }

        /*===========================method=========================*/

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

       
        private void label5_Click(object sender, EventArgs e)

        {
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string usEmail = txtEmailAddress.Text.Trim();
            string usPhone = txtPhoneNumber.Text.Trim();
            if (isEmptyInput() == false && IsValidEmailAddress(usEmail) == true && IsValidPhoneNumber(usPhone) == true)
            {
                
                Models.UserModel us = new Models.UserModel(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), usEmail,
                usPhone, dtpDob.Text, jobTitleSelected().Trim(), jobTypeSelected().Trim(),
                txtRegisterUsername.Text.Trim(), txtRegisterPassword.Text.Trim());
                Repository.UserRepo.addUser(us);
                
             
            }
            else
            {
                MessageBox.Show("Please fill all the boxes with * to register your account!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
