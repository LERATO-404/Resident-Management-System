using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Residence_Management_System.ExtraMethods;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Reporting.WinForms;

namespace Residence_Management_System.Repository
{
    class ManagerRepo
    {
        private static readonly MyMethods myUserMethod = new MyMethods();
        private readonly Reports.RoomsOccupiedDataSet rrds = new Reports.RoomsOccupiedDataSet();

        public void GenerateBarChart(Chart barChart)
        {
            //string pieQuery = @"SELECT roomAvailability FROM rooms GROUP BY roomAvailability  ";
            string emplCountsql = @"SELECT JobTitle, Count(workerId) AS Number_of_workers FROM workers GROUP BY JobTitle";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(myUserMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(emplCountsql, con)
                {
                    CommandType = CommandType.Text
                };
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                adapt.Fill(dt);
            }

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            barChart.Series[0].Points.DataBindXY(x,y);
            barChart.Series[0].ChartType = SeriesChartType.StackedColumn;
        }


        public void GeneratePieChart(Chart pieChart)
        {
            string pieSql = @"Select rs.recessStatus , count(s.studentId) as NoOFStudents
                                    from reservations rs
                                    inner join students s
                                    on rs.studentId = s.studentId
                                    Group by rs.recessStatus";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(myUserMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(pieSql, con)
                {
                    CommandType = CommandType.Text
                };
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                adapt.Fill(dt);
            }

            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            pieChart.Series[0].Points.DataBindXY(x, y);
            pieChart.Series[0].ChartType = SeriesChartType.Pie;
            pieChart.Legends[0].Enabled = true;
        }

        public void GetRoomsReservationData(ReportViewer rv,ref DataSet dsRoomReserved)
        {
            string sqlRoomReport = @"Select rs.ReservationId, s.studentNo, s.FirstName, s.LastName, r.RoomSymbolCode, r.roomFloor, r.roomType
                                From Reservations rs
                                Inner Join Students s
                                On rs.StudentId = s.StudentId
                                Inner Join Rooms r
                                On rs.RoomId = r.RoomId
                                Order by rs.ReservationId";

            using (SqlConnection con = new SqlConnection(myUserMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(sqlRoomReport, con)
                {
                    CommandType = CommandType.Text
                };
                SqlDataAdapter adapt = new SqlDataAdapter()
                {
                    SelectCommand = cmd
                };
                
                adapt.Fill(dsRoomReserved, "DataSet1");
                ReportDataSource rds = new ReportDataSource("DataSet1", dsRoomReserved.Tables[0]);
                rv.LocalReport.DataSources.Clear();
                rv.LocalReport.DataSources.Add(rds);
                //rv.LocalReport.Refresh();
                cmd.Dispose();
                adapt.Dispose();
                
            }
        }

        public void GenerateRoomReport(ReportViewer rv)
        {

            string sqlRoomReport = @"Select rs.ReservationId, s.studentNo, s.FirstName, s.LastName, r.RoomSymbolCode, r.roomFloor, r.roomType
                                From Reservations rs
                                Inner Join Students s
                                On rs.StudentId = s.StudentId
                                Inner Join Rooms r
                                On rs.RoomId = r.RoomId
                                Order by rs.ReservationId";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(myUserMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(sqlRoomReport, con)
                {
                    CommandType = CommandType.Text
                };
                SqlDataAdapter adapt = new SqlDataAdapter()
                {
                    SelectCommand = cmd
                };
                adapt.Fill(rrds, rrds.Tables[0].TableName);

                ReportDataSource rds = new ReportDataSource("DataSet1", rrds.Tables[0]);
                rv.LocalReport.DataSources.Clear();
                rv.LocalReport.DataSources.Add(rds);
                rv.LocalReport.Refresh();

                ReportParameter dategenerated = new ReportParameter("Today", DateTime.Now.ToString());
                rv.LocalReport.SetParameters(dategenerated);
            }
        }
       
    }
}
