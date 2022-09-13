using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using Residence_Management_System.ExtraMethods;
using Residence_Management_System.Reports;

namespace Residence_Management_System.Reports
{
    public partial class UC_RoomReport : UserControl
    {
        private readonly Repository.ManagerRepo manRepo = new Repository.ManagerRepo();
        //report size = 6,88976in, 2,15625in

        public UC_RoomReport()
        {
            InitializeComponent();
            
        }

        private void UC_RoomReport_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer1.LocalReport;

            localReport.ReportPath = "Reports\\RoomsOccupiedReport.rdlc";


            DataSet dataset = new DataSet("RoomsOccupiedDataSet");

            manRepo.GetRoomsReservationData(reportViewer1,ref dataset);

            ReportParameter rpDateGenerated = new ReportParameter();
            string dateGenerated = DateTime.Now.ToString();
            rpDateGenerated.Name = "DateGenerated";
            rpDateGenerated.Values.Add(dateGenerated);

            localReport.SetParameters(new ReportParameter[] {rpDateGenerated });

            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
