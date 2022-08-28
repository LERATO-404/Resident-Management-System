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
        }

        


        //==========methods============================
        public Boolean isEmpEmptyInput()
        {
            if (String.IsNullOrEmpty(txtEmpFirstName.Text) == true || String.IsNullOrEmpty(txtEmpLastName.Text) == true ||
            String.IsNullOrEmpty(txtEmpEmail.Text) == true || String.IsNullOrEmpty(txtEmpPhoneNo.Text) == true ||
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

        public string jobTypeSelected(ComboBox cs)
        {
            string _jobType = "other";
            if (cs.SelectedIndex == 0)
            {
                _jobType = "Security";
            }
            else if (cs.SelectedIndex == 1)
            {
                _jobType = "Cleaner";
            }
            else if (cs.SelectedIndex == 2)
            {
                _jobType = "Gardener";
            }
            else if (cs.SelectedIndex == 3)
            {
                _jobType = "Constructor";
            }
            return _jobType;
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

        }

       
        private void btnAddEmpl_Click(object sender, EventArgs e)
        {
            string empEmail = txtEmpEmail.Text.Trim();
            string empPhone = txtEmpPhoneNo.Text.Trim();
            if (isEmpEmptyInput() == false && extraMethodIsValid.IsValidEmailAddress(empEmail, lblInvalidEmpEmail) == true && extraMethodIsValid.IsValidPhoneNumber(empPhone, lblInvalidEmpPhone) == true)
            {
                Models.WorkerModel createdWorker = new Models.WorkerModel(txtEmpFirstName.Text.Trim(), txtEmpLastName.Text.Trim(), empEmail, empPhone,dtpEmpDob.Text.Trim(), cBoxGender.Text.Trim(),myMethod.JobTitleSelected(cBoxEmpJobTitle), jobTypeSelected(cBoxEmpJobType), dateStartDate.Text.Trim());
                rpA.AddWorker(createdWorker);
            }
            else
            {
                MessageBox.Show("Please fill all the boxes with * to register your account!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
