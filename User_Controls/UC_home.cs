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

namespace Residence_Management_System.User_Controls
{
    public partial class UC_home : UserControl
    {
        private readonly HomeRepo rph = new HomeRepo();
        

        public UC_home()
        {
            InitializeComponent();
            lblTotalEmployees.Text = rph.CountWorkers().ToString();
            lblTotalRooms.Text = rph.CountRoom().ToString();
            lblTotalStudent.Text = rph.CountStudents().ToString();
            
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
           
			rph.ViewTable(cboxViewTable,dgvShowTable);
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
                    rph.RemoveById(cboxViewTable, int.Parse(txtIdentifier.Text));
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
