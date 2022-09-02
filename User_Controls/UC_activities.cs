using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Residence_Management_System.Models;
using Residence_Management_System.ExtraMethods;
using Residence_Management_System.Repository;

namespace Residence_Management_System.User_Controls
{
    public partial class UC_activities : UserControl
    {
        private readonly MyMethods myActMethod = new MyMethods();
        private readonly ActivityControllerRepo actREpo = new ActivityControllerRepo();

        public UC_activities()
        {
            InitializeComponent();
        }

        private void UC_activities_Load(object sender, EventArgs e)
        {

        }

        public int SortsActivityAccumulatedPoints()
        {
            return 10;
        }

       

        public string semesterParticipating(ComboBox cBox)
        {
            string textSelected = "";
            int selection = cBox.SelectedIndex;
            switch (selection)
            {
                case 0:
                    textSelected = cBox.SelectedText;
                    break;
                case 1:
                    textSelected = cBox.SelectedText;
                    break;
                case 2:
                    textSelected = cBox.SelectedText;
                    break;
                default:
                    break;
            }
            return textSelected;
        }

        public bool IsActivityInputEmpty()
        {
            string x = ((String.IsNullOrEmpty(txtActStudentNo.Text) == true || String.IsNullOrEmpty(cboxSemesterParticipating.Text) == true)) ? "Enter student Id of the student you want to allocate to activies " : "Please select the semester the student will be participating in the activitie(s)";

            if (String.IsNullOrEmpty(txtActStudentNo.Text) == true || String.IsNullOrEmpty(cboxSemesterParticipating.Text) == true)
            {
                if(int.TryParse(txtActStudentNo.Text, out int id) == false){
                    if(myActMethod.CheckIfIdExist(actREpo.SelecteTable(id)) == false)
                    {
                        //MessageBox.Show("Student Id"+id.ToString()+" was not found", "Id Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return true;
                }
            }
            else
            {
                MessageBox.Show(x, "Input not entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        
        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            
            if (IsActivityInputEmpty() == false)
            {
                try
                {
                    ActivityModel createAct = new ActivityModel(int.Parse(txtActStudentNo.Text),cboxSemesterParticipating.Text, SortsActivityAccumulatedPoints(), DateTime.Today.ToString());
                    actREpo.AllocateStudentToActivity(createAct);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add a student participation points "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            
        }
    }
}
