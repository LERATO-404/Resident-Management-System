using System;
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



namespace Residence_Management_System.User_Controls
{
    public partial class UC_register : UserControl
    {
        private readonly AdminRepo rpA = new AdminRepo();
        private readonly MyMethods myMethod = new MyMethods();
        private readonly IsValid extraMethodIsValid = new IsValid();


        public UC_register()
        {
            InitializeComponent();
            lblInvalidEmpEmail.Visible = false;
            lblInvalidEmpPhone.Visible = false;
            lblInvalidNOKPhone.Visible = false;
            lblStuInvalidEmail.Visible = false;
            lblStuInvalidPhone.Visible = false;

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
            String.IsNullOrEmpty(cBoxStuGender.Text) == true || String.IsNullOrEmpty(cBoxStuTitle.Text) == true || String.IsNullOrEmpty(cBoxStuNationality.Text) == true ||
            String.IsNullOrEmpty(txtStudentNo.Text) == true || String.IsNullOrEmpty(cboxStudentType.Text) == true || String.IsNullOrEmpty(txtCourseName.Text) == true|| 
            String.IsNullOrEmpty(cboxRegistrationStatus.Text) == true|| String.IsNullOrEmpty(txtStuNextOfKinName.Text) == true|| 
            String.IsNullOrEmpty(txtStuNextOfKinPhone.Text) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string stuPhone = txtStuPhoneNo.Text.Trim();
            string nxtOfKinPhone = txtStuNextOfKinPhone.Text.Trim();
            string stuEmail = txtStuEmail.Text.Trim();

            if(isStuEmptyInput() == false && extraMethodIsValid.IsValidEmailAddress(stuEmail, lblStuInvalidEmail) == true && extraMethodIsValid.IsValidPhoneNumber(stuPhone, lblStuInvalidPhone) == true && extraMethodIsValid.IsValidPhoneNumber(nxtOfKinPhone, lblInvalidNOKPhone))
            {
                Models.StudentModel createdStudent = new Models.StudentModel(txtStuFirstName.Text.Trim(), txtStuLastName.Text.Trim(), txtStuEmail.Text.Trim(), txtStuPhoneNo.Text.Trim(), cBoxStuGender.Text.Trim(),
                dtpStuDob.Text.Trim(), cBoxStuNationality.Text.Trim(),int.Parse(txtStudentNo.Text), cboxStudentType.Text.Trim(), txtCourseName.Text.Trim(), txtStuNextOfKinName.Text.Trim(), txtStuNextOfKinPhone.Text.Trim());
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

            if (isEmpEmptyInput() == false && extraMethodIsValid.IsValidEmailAddress(empEmail, lblInvalidEmpEmail) == true && extraMethodIsValid.IsValidPhoneNumber(empPhone, lblInvalidEmpPhone) == true)
            {
                
                Models.WorkerModel createdWorker = new Models.WorkerModel(txtEmpFirstName.Text.Trim(), txtEmpLastName.Text.Trim(), empEmail, empPhone,dtpEmpDob.Text, cBoxGender.Text.Trim(),cBoxEmpJobTitle.Text.Trim(), cBoxEmpJobType.Text.Trim(), dtpStartDate.Text);
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
                    string employeeToToDelete = rpA.SelectedEmployeeToDelete(int.Parse(txtEmployeeIdentifier.Text));
                    myMethod.RemoveById(int.Parse(txtEmployeeIdentifier.Text), employeeToToDelete);
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
                Models.WorkerModel viewWorkerDetails = new Models.WorkerModel();
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
                Models.WorkerModel viewWorkerDetails = new Models.WorkerModel(txtEmpFirstName.Text, txtEmpLastName.Text, txtEmpEmail.Text, txtEmpPhoneNo.Text, dtpEmpDob.Text, cBoxGender.Text, cBoxEmpJobTitle.Text, cBoxEmpJobType.Text, dtpStartDate.Text);
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
    }
}
