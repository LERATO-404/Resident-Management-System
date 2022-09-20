﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Residence_Management_System.ExtraMethods;
using Residence_Management_System.Repository;


using Residence_Management_System.Models;

namespace Residence_Management_System.User_Controls
{
    public partial class UC_register : UserControl
    {
        private readonly AdminRepo rpA = new AdminRepo();
        private readonly MyMethods myMethod = new MyMethods();
        private readonly IsValid IsValidInput = new IsValid();


        public UC_register()
        {
            InitializeComponent();
            lblInvalidEmpEmail.Visible = false;
            lblInvalidEmpPhone.Visible = false;
            lblInvalidNOKPhone.Visible = false;
            lblStuInvalidEmail.Visible = false;
            lblStuInvalidPhone.Visible = false;
            lblInvalidStudentNo.Visible = false;

        }

        //==========methods============================
        public Boolean isEmpEmptyInput()
        {
            if ((string.IsNullOrEmpty(txtEmpFirstName.Text) == true) || (string.IsNullOrEmpty(txtEmpLastName.Text) == true) ||
            (string.IsNullOrEmpty(txtEmpEmail.Text) == true) || (string.IsNullOrEmpty(txtEmpPhoneNo.Text) == true) || (string.IsNullOrEmpty(cBoxGender.Text) == true) ||
            (string.IsNullOrEmpty(cBoxEmpJobTitle.Text) == true) || (string.IsNullOrEmpty(cBoxEmpJobType.Text) == true) ||
            (string.IsNullOrEmpty(dtpEmpDob.Text) == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean isStuEmptyInput()
        {
            if (String.IsNullOrEmpty(txtStuFirstName.Text) == true || String.IsNullOrEmpty(txtStuLastName.Text) == true ||
            String.IsNullOrEmpty(txtStuEmail.Text) == true || String.IsNullOrEmpty(txtStuPhoneNo.Text) == true || String.IsNullOrEmpty(dtpStuDob.Text) == true ||
            String.IsNullOrEmpty(cBoxStuGender.Text) == true || String.IsNullOrEmpty(txtStudentNo.Text) == true || String.IsNullOrEmpty(cboxStudentType.Text) == true ||
            String.IsNullOrEmpty(txtCourseName.Text) == true|| String.IsNullOrEmpty(cboxRegistrationStatus.Text) == true||
          String.IsNullOrEmpty(txtStuNextOfKinName.Text) == true|| String.IsNullOrEmpty(txtStuNextOfKinPhone.Text) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearStudent()
        {
            txtStuFirstName.Clear();
            txtStuLastName.Clear();
            txtStuEmail.Clear();
            txtStuPhoneNo.Clear();
            cBoxStuGender.SelectedIndex = -1;
            txtStuNextOfKinName.Clear();
            txtStuNextOfKinPhone.Clear();
            txtStudentNo.Clear();
            cboxStudentType.SelectedIndex = -1;
            cboxRegistrationStatus.SelectedIndex = -1;
        }
        
        public void ClearWorker()
        {
            txtEmpFirstName.Clear();
            txtEmpLastName.Clear();
            txtEmpEmail.Clear();
            txtEmpPhoneNo.Clear();
            cBoxGender.SelectedIndex = -1;
            cBoxEmpJobTitle.SelectedIndex = -1;
            cBoxEmpJobType.SelectedIndex = -1;
        }
        //===================methods===================


        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Student_Click(object sender, EventArgs e)
        {

        }

        private void Employee_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       
        

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            bool studentPhone = IsValidInput.IsValidPhoneNumber(txtStuPhoneNo.Text.Trim(), lblStuInvalidPhone);
            bool nOkPhone = IsValidInput.IsValidPhoneNumber(txtStuNextOfKinPhone.Text.Trim(), lblInvalidNOKPhone);
            bool studentEmail = IsValidInput.IsValidEmailAddress(txtStuEmail.Text.Trim(), lblStuInvalidEmail);
            bool studentNo = IsValidInput.IsValidStudentNumber(txtStudentNo.Text.Trim(), lblInvalidStudentNo);

            if (isStuEmptyInput() == false && studentEmail == true && studentPhone == true && nOkPhone == true && studentNo == true)
            {
                StudentModel createdStudent = new StudentModel(txtStuFirstName.Text.Trim(), txtStuLastName.Text.Trim(), txtStuEmail.Text.Trim(), txtStuPhoneNo.Text.Trim(), cBoxStuGender.Text.Trim(),
                dtpStuDob.Text.Trim(), txtStuNextOfKinName.Text.Trim(), txtStuNextOfKinPhone.Text.Trim(), txtStudentNo.Text.Trim(), cboxStudentType.Text.Trim(), txtCourseName.Text.Trim(), cboxRegistrationStatus.Text.Trim() );
                rpA.AddStudent(createdStudent);
            }
            else
            {
                MessageBox.Show("Please fill all the boxes with * to add a student!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

       
        private void btnAddEmpl_Click(object sender, EventArgs e)
        {
            string empEmail = txtEmpEmail.Text.Trim();
            string empPhone = txtEmpPhoneNo.Text.Trim();

            if (isEmpEmptyInput() == false && IsValidInput.IsValidEmailAddress(empEmail, lblInvalidEmpEmail) == true && IsValidInput.IsValidPhoneNumber(empPhone, lblInvalidEmpPhone) == true)
            {
                
                WorkerModel createdWorker = new WorkerModel(txtEmpFirstName.Text.Trim(), txtEmpLastName.Text.Trim(), empEmail, empPhone,dtpEmpDob.Text, cBoxGender.Text.Trim(),cBoxEmpJobTitle.Text, cBoxEmpJobType.Text, dtpStartDate.Text);
                rpA.AddWorker(createdWorker);
            }
            else
            {
                MessageBox.Show("Please fill all the boxes with * to add a worker!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmployeeIdentifier.Text != "")
                {
                    rpA.RemoveWorkerById(int.Parse(txtEmployeeIdentifier.Text));
                }
                else
                {
                    MessageBox.Show("Please enter the Id of the resource you want to delete!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Id, Please enter Id number (firstcolumn) of the resource you want to delete!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisplayEmployee_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtEmployeeIdentifier.Text) == false)
            {
                WorkerModel viewWorkerDetails = new WorkerModel();
                bool isInputValid = Int32.TryParse(txtEmployeeIdentifier.Text, out int id);
                if(isInputValid == true)
                {
                    rpA.ViewEmployeeDetails(id, viewWorkerDetails);
                    txtEmpFirstName.Text = viewWorkerDetails.FirstName;
                    txtEmpLastName.Text = viewWorkerDetails.LastName;
                    txtEmpEmail.Text = viewWorkerDetails.EmailAddress;
                    txtEmpPhoneNo.Text = viewWorkerDetails.PhoneNumber;
                    dtpEmpDob.Text = viewWorkerDetails.DateOfBirth;
                    cBoxGender.Text = viewWorkerDetails.Gender;
                    cBoxEmpJobTitle.Text = viewWorkerDetails.JobTitle;
                    cBoxEmpJobType.Text = viewWorkerDetails.JobType;
                    dtpStartDate.Text = viewWorkerDetails.StartDate;
                }
                else
                {
                    MessageBox.Show("Invalid worker Id entered!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Please enter the employee Id of the worker you want to view!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string x = ((String.IsNullOrEmpty(txtEmployeeIdentifier.Text) == true) && (isEmpEmptyInput() == true)) ? "Please enter the employee Id of the worker you want to update!.. " : "Please fill all the boxes with *";
            if (String.IsNullOrEmpty(txtEmployeeIdentifier.Text) == false && (isEmpEmptyInput() == false))
            {
                WorkerModel viewWorkerDetails = new WorkerModel(txtEmpFirstName.Text, txtEmpLastName.Text, txtEmpEmail.Text, txtEmpPhoneNo.Text, dtpEmpDob.Text, cBoxGender.Text, cBoxEmpJobTitle.Text, cBoxEmpJobType.Text, dtpStartDate.Text);
                bool isInputValid = Int32.TryParse(txtEmployeeIdentifier.Text, out int id);
                if (isInputValid == true)
                {
                    rpA.UpdateWorker(id, viewWorkerDetails);
                }
                else
                {
                    MessageBox.Show("Invalid worker Id entered!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtStudentIdentifier.Text != "")
                {
                    //string studentToToDelete = rpA.SelectedStudentToDelete(int.Parse(txtStudentIdentifier.Text));
                    //myMethod.RemoveById(int.Parse(txtStudentIdentifier.Text), studentToToDelete);
                    rpA.RemoveStudentById(int.Parse(txtStudentIdentifier.Text));
                }
                else
                {
                    MessageBox.Show("Please enter the Id of the resource you want to delete!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Id, Please enter Id number (firstcolumn) of the resource you want to delete!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisplayStudent_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtStudentIdentifier.Text) == false)
            {
                StudentModel viewStudentDetails = new StudentModel();
                bool isInputValid = Int32.TryParse(txtStudentIdentifier.Text, out int id);
                if (isInputValid == true)
                {
                    rpA.ViewStudentDetails(id, viewStudentDetails);
                    txtStuFirstName.Text = viewStudentDetails.FirstName;
                    txtStuLastName.Text = viewStudentDetails.LastName;
                    txtStuEmail.Text = viewStudentDetails.EmailAddress;
                    txtStuPhoneNo.Text = viewStudentDetails.PhoneNumber;
                    cBoxStuGender.Text = viewStudentDetails.Gender;
                    dtpEmpDob.Text = viewStudentDetails.DateOfBirth;
                    txtStuNextOfKinName.Text = viewStudentDetails.NextOfKinFullName;
                    txtStuNextOfKinPhone.Text = viewStudentDetails.NextOfKinPhone;
                    txtStudentNo.Text = viewStudentDetails.StudentNo;
                    cboxStudentType.Text = viewStudentDetails.StudentType;
                    txtCourseName.Text = viewStudentDetails.CourseName;
                    cboxRegistrationStatus.Text = viewStudentDetails.RegistrationStatus;
                }
                else
                {
                    MessageBox.Show("Invalid student Id entered!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter the student Id of the student you want to view!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            string x = ((String.IsNullOrEmpty(txtStudentIdentifier.Text) == true) && (isStuEmptyInput() == true)) ? "Please enter the student Id of the worker you want to update!.. " : "Please fill all the boxes with *";
            if (String.IsNullOrEmpty(txtStudentIdentifier.Text) == false && (isStuEmptyInput() == false))
            {
                StudentModel updateStudentDetails = new StudentModel(txtStuFirstName.Text, txtStuLastName.Text,
                    txtStuEmail.Text, txtStuPhoneNo.Text, cBoxStuGender.Text, dtpEmpDob.Text, txtStuNextOfKinName.Text,
                    txtStuNextOfKinPhone.Text, txtStudentNo.Text, cboxStudentType.Text, txtCourseName.Text, cboxRegistrationStatus.Text);
                bool isInputValid = Int32.TryParse(txtStudentIdentifier.Text, out int id);
                if (isInputValid == true)
                {
                    rpA.UpdateStudentById(id, updateStudentDetails);
                }
                else
                {
                    MessageBox.Show("Invalid student Id entered!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelEmpInput_Click(object sender, EventArgs e)
        {
            ClearWorker();
        }

        private void btnCancelStudentInput_Click(object sender, EventArgs e)
        {
            ClearStudent();
        }
    }
}
