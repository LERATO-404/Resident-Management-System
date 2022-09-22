﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Residence_Management_System.ExtraMethods;


namespace Residence_Management_System
{
    public partial class LandingPage : Form
    {
        private readonly string userRole = UserId.GetUserJobType();
        bool sideBarExpand;
        public LandingPage()
        {
            InitializeComponent();
            User_Controls.UC_home uch = new User_Controls.UC_home();
            addUserControl(uch);
            if (userRole == "Residence-Manager")
            {
                iconButton1.Visible = true;
            }
            else
            {
                iconButton1.Visible = false;
            }
        }

        //*********************methods****************

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            tabsContainer.Controls.Clear();
            tabsContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

       

        private void LandingPage_Load(object sender, EventArgs e)
        {
            
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sideBarTimer_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand)
            {
                sideBarContainer.Width -= 10;
                if(sideBarContainer.Width == sideBarContainer.MinimumSize.Width)
                {
                    sideBarExpand = false;
                    sideBarTimer.Stop();
                }
            }
            else
            {

                sideBarContainer.Width += 10;
                if (sideBarContainer.Width == sideBarContainer.MaximumSize.Width)
                {
                    sideBarExpand = true;
                    sideBarTimer.Stop();
                }

            }

        }

       

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            sideBarTimer.Start();

            
        }


        private void guna2PictureBox2_Click_1(object sender, EventArgs e)
        {
            sideBarTimer.Start();
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            User_Controls.UC_home uch = new User_Controls.UC_home();
            addUserControl(uch);
        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            User_Controls.UC_register ucR = new User_Controls.UC_register();
            addUserControl(ucR);
        }

        private void roombtn_Click(object sender, EventArgs e)
        {
            User_Controls.UC_room ucRoom = new User_Controls.UC_room();
            addUserControl(ucRoom);
        }

        private void activitiesbtn_Click(object sender, EventArgs e)
        {
            User_Controls.UC_activities ucAct = new User_Controls.UC_activities();
            addUserControl(ucAct);
        }

        private void reporbtn_Click(object sender, EventArgs e)
        {
            User_Controls.UC_report ucReport = new User_Controls.UC_report();
            addUserControl(ucReport);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login toLogOff = new Login();
            toLogOff.Show();
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Reports.UC_RoomReport ucRR = new Reports.UC_RoomReport();
            addUserControl(ucRR);
        }
    }
}