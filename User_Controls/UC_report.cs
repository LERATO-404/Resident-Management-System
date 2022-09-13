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
    public partial class UC_report : UserControl
    {
        private readonly ManagerRepo manRepo = new ManagerRepo();
        private readonly LandingPage lanForm = new LandingPage();
        private readonly MyMethods myMethod = new MyMethods();
        private readonly string userRole = UserId.GetUserJobType();


        public UC_report()
        {
            InitializeComponent();
        }

        private void UC_report_Load(object sender, EventArgs e)
        {
            manRepo.GenerateBarChart(chart1);
            manRepo.GeneratePieChart(recessStatusPieChart);
        }

        private void guna2HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
           

        }

        private void BarJobType_Click(object sender, EventArgs e)
        {

        }
    }
}
