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
        Repository.HomeRepo rph = new Repository.HomeRepo();
        public UC_home()
        {
            InitializeComponent();
            lblTotalEmployees.Text = rph.countWorkers().ToString();
            lblTotalRooms.Text = rph.countRoom().ToString();
            lblTotalStudent.Text = rph.countStudents().ToString();
        }

		private void btnDisplay_Click(object sender, EventArgs e)
        {
            Repository.HomeRepo us = new Repository.HomeRepo();
			us.viewTable(cboxViewTable,dgvShowTable);
        }
    }
}
