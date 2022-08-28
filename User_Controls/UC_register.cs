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
            if (String.IsNullOrEmpty(txtEmpFirstName.Text) == true || String.IsNullOrEmpty(txtEmpLastName.Text) == true ||
            String.IsNullOrEmpty(txtEmpEmail.Text) == true || String.IsNullOrEmpty(txtEmpPhoneNo.Text) == true || String.IsNullOrEmpty(cBoxGender.Text) == true ||
            String.IsNullOrEmpty(cBoxEmpJobTitle.Text) == true || String.IsNullOrEmpty(cBoxEmpJobType.Text) == true ||
            String.IsNullOrEmpty(dtpEmpDob.Text) == true)
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
                Models.StudentModel createdStudent = new Models.StudentModel(txtEmpFirstName.Text.Trim(), txtEmpLastName.Text.Trim(), txtStuEmail.Text.Trim(), txtStuPhoneNo.Text.Trim(), cBoxStuGender.Text.Trim(),
                dtpStuDob.Text.Trim(), cBoxStuNationality.Text.Trim(), cboxStudentType.Text.Trim(), txtCourseName.Text.Trim(), txtStuNextOfKinName.Text.Trim(), txtStuNextOfKinPhone.Text.Trim());
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
                Models.WorkerModel createdWorker = new Models.WorkerModel(txtEmpFirstName.Text.Trim(), txtEmpLastName.Text.Trim(), empEmail, empPhone,dtpEmpDob.Text.Trim(), cBoxGender.Text.Trim(),cBoxEmpJobTitle.Text.Trim(), cBoxEmpJobType.Text.Trim(), dateStartDate.Text.Trim());
                rpA.AddWorker(createdWorker);
            }
            else
            {
                MessageBox.Show("Please fill all the boxes with * to add a worker!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
