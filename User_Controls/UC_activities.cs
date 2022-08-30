using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Residence_Management_System.User_Controls
{
    public partial class UC_activities : UserControl
    {
        private readonly Repository.ActivityControllerRepo actREpo = new Repository.ActivityControllerRepo();
        public UC_activities()
        {
            InitializeComponent();
        }

        private void UC_activities_Load(object sender, EventArgs e)
        {

        }

        public string sportsActivitySelected()
        {
            return "";
        }

        public string sportTypeDescription()
        {
            return "";
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

        public void IsChecked()
        {
            var sportChecked = sportsActivitySelected().Split(',');
            checkedListBox1.Items.Clear();
            checkedListBox1.Items.AddRange(sportChecked);
            
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            Models.ActivityModel actModParticipation = new Models.ActivityModel(sportsActivitySelected(),sportTypeDescription(),
                semesterParticipating(cboxSemesterParticipating),DateTime.Now,int.Parse(txtActStudentNo.Text));
            IsChecked();
            for (int i  = 0; i < checkedListBox1.Items.Count-1; i++)
            {
                //Models.ActivityModel actModParticipation = new Models.ActivityModel(checkedListBox1.GetItemCheckState(i).ToString(), sportTypeDescription(),
                //semesterParticipating(cboxSemesterParticipating), DateTime.Now, int.Parse(txtActStudentNo.Text));
                //actREpo.AllocateStudentToActivity(actModParticipation);
            }
            

            Models.ActivityModel actModPoints = new Models.ActivityModel(int.Parse(txtActStudentNo.Text), int.Parse(lblTotalPoints.Text));
            actREpo.AddTotalPoints(actModPoints);
        }
    }
}
