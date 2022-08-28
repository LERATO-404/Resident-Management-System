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
using Residence_Management_System.ExtraMethods;
using Residence_Management_System.Repository;


namespace Residence_Management_System
{
    public partial class Register : Form
    {
        private readonly UserRepo uR = new UserRepo();
        private readonly MyMethods myMethod = new MyMethods();
        private readonly IsValid extraMethodIsValid = new IsValid();
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

        private void ClearRegister()
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

        public string JobTypeSelected()
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
            if (isEmptyInput() == false && extraMethodIsValid.IsValidEmailAddress(usEmail,lblInvalidEmail) == true && extraMethodIsValid.IsValidPhoneNumber(usPhone,lblInvalidPhone) == true)
            {
                Models.UserModel us = new Models.UserModel(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), usEmail,
                usPhone, dtpDob.Text, myMethod.JobTitleSelected(cBoxJobTitle).Trim(), JobTypeSelected().Trim(),
                txtRegisterUsername.Text.Trim(), txtRegisterPassword.Text.Trim());
                uR.AddUser(us);
            }
            else
            {
                MessageBox.Show("Please fill all the boxes with * to register your account!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
