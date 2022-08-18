using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Residence_Management_System
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
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
                _jobType = "Resident Manager";
            }
            else if (cBoxJobType.SelectedIndex == 1)
            {
                _jobType = "Admin";
            }
            else if (cBoxJobType.SelectedIndex == 2)
            {
                _jobType = "Room Controller";
            }
            else if (cBoxJobType.SelectedIndex == 3)
            {
                _jobType = "Activity Controller";
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

        /*===========================method=========================*/

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEmptyInput() == false)
                {
                    Models.UserModel us = new Models.UserModel(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtEmailAddress.Text.Trim(),
                    txtPhoneNumber.Text.Trim(), dtpDob.Text, jobTitleSelected().Trim(), jobTypeSelected().Trim(),
                    txtRegisterUsername.Text.Trim(), txtRegisterPassword.Text.Trim());
                    Repository.UserRepo.addUser(us);
                    clearRegister();

                }
                else
                {
                    MessageBox.Show("Please fill all the boxes with * to register your account!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //make username unique when creating a USER TABLE
                MessageBox.Show("Unsername already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegisterUsername.Clear();
                txtRegisterUsername.Focus();
            }
        }
    }
}
