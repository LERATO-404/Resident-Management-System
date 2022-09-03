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

        public int HighPerformance()
        {
            
            if(checkboxSoccer.Checked == true|| checkboxRugby.Checked == true || checkboxCricket.Checked == true || checkboxNetball.Checked == true || checkboxHockey.Checked == true)
            {
                return 10;
            }
            return 0;
        }

        public int Competitive()
        {

            if (checkboxSwimming.Checked == true || checkboxKarate.Checked == true || checkboxCycling.Checked == true || checkboxGolf.Checked == true || checkboxSquash.Checked == true)
            {
                return 10;
            }
            return 0;
        }

        public int Recreational()
        {

            if (checkboxEsport.Checked == true || checkboxDance.Checked == true || checkboxDIYCraft.Checked == true || checkboxEasterdayhunt.Checked == true || checkboxCharityWalks.Checked == true)
            {
                return 5;
            }
            return 0;
        }

        public int Wellbeing()
        {

            if (checkboxYoga.Checked == true || checkboxGym.Checked == true || checkboxOther.Checked == true)
            {
                return 5;
            }
            return 0;
        }

        public int ActivityAccumulatedPoints()
        {
            int totalPoint = HighPerformance() + Competitive() + Recreational() + Wellbeing();
            return totalPoint;
        }

       

        public string semesterParticipating(ComboBox cBox)
        {
            string textSelected = "";
            int selection = cBox.SelectedIndex;
            switch (selection)
            {
               
                case 0:
                    textSelected = "First-Semester";
                    break;
                case 1:
                    textSelected = "Second-Semester";
                    break;
                case 2:
                    textSelected = "Both-Semesters";
                    break;
                default:
                    break;
            }
            return textSelected;
        }

        public bool IsActivityInputEmpty()
        {
            //string x = (String.IsNullOrEmpty(txtActStudentNo.Text) == true || String.IsNullOrEmpty(semesterParticipating(cboxSemesterParticipating)) == true) ? "Enter student Id of the student you want to allocate to activies " : "Please select the semester the student will be participating in the activitie(s)";

            if (String.IsNullOrEmpty(txtActStudentNo.Text) == true || String.IsNullOrEmpty(cboxSemesterParticipating.Text) == true)
            {
                return true;
            }
            else
            {
                //MessageBox.Show(x, "Input not entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
        }

        
        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            
            if (IsActivityInputEmpty() == false)
            {
                try
                {
                    
                    ActivityModel createAct = new ActivityModel(int.Parse(txtActStudentNo.Text), semesterParticipating(cboxSemesterParticipating), ActivityAccumulatedPoints(), DateTime.Today.ToString());
                    actREpo.AllocateStudentToActivity(createAct);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add a student participation points  "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }else
            {
                MessageBox.Show("Please enter both the student Id semester participating " , "No input entered", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        

        private void btnDisplayActivities_Click(object sender, EventArgs e)
        {
            string selecteT = actREpo.SelectedTable(cboxShowActivities);
            myActMethod.ViewTable(dgvActivities, selecteT);
        }

        private void btnDeleteActivity_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtActivityIdentifier.Text != "")
                {
                    string resourceToDelete = actREpo.SelectedTableToDeleteResource(int.Parse(txtActivityIdentifier.Text));
                    myActMethod.RemoveById(int.Parse(txtActivityIdentifier.Text), resourceToDelete);
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
    }
}
