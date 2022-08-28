using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Residence_Management_System.Repository;
using Residence_Management_System.ExtraMethods;

namespace Residence_Management_System.User_Controls
{
    public partial class UC_home : UserControl
    {
        private readonly HomeRepo rph = new HomeRepo();
        private readonly MyMethods myM = new MyMethods();

        public UC_home()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            string selecteT = rph.SelectedTable(cboxViewTable);
            myM.ViewTable(dgvShowTable,selecteT);
        }

        private void UC_home_Load(object sender, EventArgs e)
        {
            
            lblTotalRooms.Text = rph.CountRoom().ToString();
            lblTotalStudent.Text = rph.CountStudents().ToString();
            lblTotalEmployees.Text = rph.CountWorkers().ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            { 
                if (txtIdentifier.Text != "")
                {
                    string resourceToDelete = rph.SelectedTableToDeleteResource(cboxViewTable, int.Parse(txtIdentifier.Text));
                    myM.RemoveById(int.Parse(txtIdentifier.Text), resourceToDelete);
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
