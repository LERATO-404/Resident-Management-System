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
    public partial class UC_home : UserControl
    {
        public Repository.HomeRepo rph = new Repository.HomeRepo();
  
        public UC_home()
        {
            InitializeComponent();
            lblTotalEmployees.Text = rph.countWorkers().ToString();
            lblTotalRooms.Text = rph.countRoom().ToString();
            lblTotalStudent.Text = rph.countStudents().ToString();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
           
			rph.viewTable(cboxViewTable,dgvShowTable);
        }

        private void UC_home_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtIdentifier.Text != "")
                {
                    //label5.Text = rph.selectedTableToDeleteResource(cboxViewTable, txtIdentifier.Text);
                    rph.removeById(cboxViewTable, int.Parse(txtIdentifier.Text));

                }
                else
                {
                    MessageBox.Show("Please enter the Id of the resource you want to delete!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exhomeDelete)
            {
                MessageBox.Show("Invalid Id, Please enter Id number (firstcolumn) of the resource you want to delete!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
