﻿using System;
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
    public partial class UC_room : UserControl
    {
        private readonly MyMethods myM = new MyMethods();
        private readonly HomeRepo rH = new HomeRepo();
        private readonly RoomControllerRepo rRCR = new RoomControllerRepo();
        public UC_room()
        {
            InitializeComponent();
        }

        public Boolean IsRoomInputEmpty()
        {
            if (String.IsNullOrEmpty(txtRoomSymbolCode.Text) == true || String.IsNullOrEmpty(cboxFloor.Text) == true ||
            String.IsNullOrEmpty(cboxRoomType.Text) == true || String.IsNullOrEmpty(cboxRoomAvailability.Text) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean IsReservationInputEmpty()
        {
            
            if (String.IsNullOrEmpty(txtReserveStudentNo.Text) == true || String.IsNullOrEmpty(txtReserveRoomCode.Text) == true ||
            String.IsNullOrEmpty(cboxBedandChairUsage.Text) == true || String.IsNullOrEmpty(cboxRecessStatus.Text) == true || String.IsNullOrEmpty(dtpDateAllocated.Text) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Rooms_Click(object sender, EventArgs e)
        {

        }

        private void AddStudentGB_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }


       
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRoomIdentifier.Text != "")
                {
                    string resourceToDelete = rRCR.SelectedRoomToDelete(int.Parse(txtRoomIdentifier.Text));
                    myM.RemoveById(int.Parse(txtRoomIdentifier.Text), resourceToDelete);
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void addRoombtn_Click(object sender, EventArgs e)
        {
            if(IsRoomInputEmpty() == false)
            {
                Models.RoomModel rm = new Models.RoomModel(txtRoomSymbolCode.Text.Trim(), cboxFloor.Text.Trim(), cboxRoomType.Text.Trim(), cboxRoomAvailability.Text.Trim());
                rRCR.AddRoom(rm); 
            }
            else
            {
                MessageBox.Show("Please fill all the boxes with * to add a room!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Allocation_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void updateRoombtn_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string selecteRoomsThat = rRCR.SelectedRoomsTable(cboxShowRooms, cboxShowRooms.Text);
            myM.ViewTable(dgvRooms, selecteRoomsThat);
        }

       
        private void btnDisplayReservations_Click(object sender, EventArgs e)
        {
            string selecteReservationThat = rRCR.SelectedReservationTable(cboxShowReservations, cboxShowReservations.Text);
            myM.ViewTable(dgvReservations, selecteReservationThat);
        }

        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReservationIdentifier.Text != "")
                {
                    string reservationToDelete = rRCR.SelectedReservationToDelete(int.Parse(txtReservationIdentifier.Text));
                    myM.RemoveById(int.Parse(txtReservationIdentifier.Text), reservationToDelete);
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

        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (IsReservationInputEmpty() == false)
            {
                string x = ((rH.CountRoom() != 0) || (rH.CountStudents() != 0)) ? "You do not have rooms available for reservation " : "First register a student to reserve a room for";
                if ((rH.CountRoom() != 0) && (rH.CountStudents() != 0))
                {
                    try
                    {


                        Models.ReservationModel rS = new Models.ReservationModel(Int32.Parse(txtReserveStudentNo.Text), Int32.Parse(txtRoomSymbolCode.Text), cboxBedandChairUsage.Text, cboxRecessStatus.Text, dtpDateAllocated.Text);

                        if (rS != null)
                        {
                            rRCR.ReserveRoomForStudent(rS);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a reservation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed to add a reservation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                    
                else
                {
                    MessageBox.Show(x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please fill all the boxes with * to add a reservation!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
