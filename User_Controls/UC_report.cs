﻿using System;
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
    public partial class UC_report : UserControl
    {
        public UC_report()
        {
            InitializeComponent();
        }

        private void UC_report_Load(object sender, EventArgs e)
        {

        }

        private void guna2HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnReserve_Click(object sender, EventArgs e)
        { 
           //string roomTypeReport = @"SELECT r.RoomdId, r.RoomAvailability, Count(rs.StudentId) FROM r.Rooms, rs.Reservations WHERE r.roomId = rs.RoomId";
        }

        private void BarJobType_Click(object sender, EventArgs e)
        {

        }
    }
}
