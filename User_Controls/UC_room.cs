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
using Residence_Management_System.Models;

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
            String.IsNullOrEmpty(cboxBedandChairUsage.Text) == true || String.IsNullOrEmpty(cboxRecessStatus.Text) == true || String.IsNullOrEmpty(dtpDateMovingIn.Text) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearRoom()
        {
            cboxShowRooms.SelectedIndex = -1;
            txtRoomIdentifier.Clear();
            txtRoomSymbolCode.Clear();
            cboxFloor.SelectedIndex = -1;
            cboxRoomType.SelectedIndex = -1;
            cboxRoomAvailability.SelectedIndex = -1;
        }

        public void ClearReservation()
        {
            cboxShowReservations.SelectedIndex = -1;
            txtReservationIdentifier.Clear();
            txtReserveStudentNo.Clear();
            txtReserveRoomCode.Clear();
            cboxBedandChairUsage.SelectedIndex = -1;
            cboxRecessStatus.SelectedIndex = -1;
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
            ClearReservation();
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
            ClearRoom();
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
                    //string resourceToDelete = rRCR.SelectedRoomToDelete(int.Parse(txtRoomIdentifier.Text));
                    rRCR.RemoveRoomById(int.Parse(txtRoomIdentifier.Text));
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
                RoomModel rm = new RoomModel(txtRoomSymbolCode.Text.Trim(), cboxFloor.Text.Trim(), cboxRoomType.Text.Trim(), cboxRoomAvailability.Text.Trim());
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
            string x = ((String.IsNullOrEmpty(txtRoomIdentifier.Text) == true) && (IsRoomInputEmpty() == true)) ? "Please enter the room Id of the room you want to update!.. " : "Please fill all the boxes with *";
            if (String.IsNullOrEmpty(txtRoomIdentifier.Text) == false && (IsRoomInputEmpty() == false))
            {
                RoomModel updateRoomDetails = new RoomModel(txtRoomSymbolCode.Text, cboxFloor.Text,cboxRoomType.Text, cboxRoomAvailability.Text);
                bool isInputValid = Int32.TryParse(txtRoomIdentifier.Text, out int id);
                if (isInputValid == true)
                {
                    rRCR.UpdateRoomById(id, updateRoomDetails);
                }
                else
                {
                    MessageBox.Show("Invalid room Id entered!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string selecteRoomsThat = rRCR.SelectedRoomsTable(cboxShowRooms, cboxShowRooms.Text);
            if(String.IsNullOrEmpty(selecteRoomsThat) == false)
            {
                myM.ViewTable(dgvRooms, selecteRoomsThat);
            }
            else
            {
                MessageBox.Show("First Select the table you want to view!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
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
                    //string reservationToDelete = rRCR.SelectedReservationToDelete(int.Parse(txtReservationIdentifier.Text));
                    //myM.RemoveById(int.Parse(txtReservationIdentifier.Text), reservationToDelete);
                    rRCR.RemoveReservationbyId(int.Parse(txtReservationIdentifier.Text));
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
                        int roomId = Int32.Parse(txtReserveRoomCode.Text);
                        string roomAvailability = rRCR.GetRoomAvailability(roomId);
                        if (roomAvailability == "Available")
                        {
                            ReservationModel rS = new ReservationModel(Int32.Parse(txtReserveStudentNo.Text), roomId, cboxBedandChairUsage.Text, cboxRecessStatus.Text, DateTime.Today, dtpDateMovingIn.Value);
                            
                            rRCR.ReserveRoomForStudent(rS);
                        }
                        else
                        {
                            MessageBox.Show("Room is not available for reservation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRoomIdentifier.Text) == false)
            {
                RoomModel rm = new RoomModel();
                bool isInputValid = Int32.TryParse(txtRoomIdentifier.Text, out int id);
                if (isInputValid == true)
                {
                    rRCR.ViewRoomDetails(id, rm);
                    txtRoomSymbolCode.Text = rm.RoomSymbolCode;
                    cboxFloor.Text = rm.RoomFloor;
                    cboxRoomType.Text = rm.RoomType;
                    cboxRoomAvailability.Text = rm.RoomAvailability;
                
                }
                else
                {
                    MessageBox.Show("Invalid room Id entered!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter the room Id of the room you want to view!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string x = ((String.IsNullOrEmpty(txtReservationIdentifier.Text) == true) && (IsReservationInputEmpty() == true)) ? "Please enter the reservation Id of the reservation you want to update!.. " : "Please fill all the boxes with *";
            if (String.IsNullOrEmpty(txtReservationIdentifier.Text) == false && (IsReservationInputEmpty() == false))
            {
                ReservationModel updateReservationDetails = new ReservationModel(int.Parse(txtReserveStudentNo.Text),int.Parse(txtReserveRoomCode.Text),cboxBedandChairUsage.Text,cboxRecessStatus.Text,DateTime.Today,dtpDateMovingIn.Value);
                bool isInputValid = Int32.TryParse(txtReservationIdentifier.Text, out int id);
                if (isInputValid == true)
                {
                    rRCR.UpdateReservationDetails(id, updateReservationDetails);
                }
                else
                {
                    MessageBox.Show("Invalid reservation Id entered!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchReservation_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtReservationIdentifier.Text) == false)
            {
                ReservationModel rs = new ReservationModel();
                bool isInputValid = Int32.TryParse(txtReservationIdentifier.Text, out int id);
                if (isInputValid == true)
                {
                    
                    rRCR.ViewReservationDetails(id, rs);
                    txtReserveStudentNo.Text = rs.StudentId.ToString();
                    txtReserveRoomCode.Text = rs.RoomId.ToString();
                    cboxBedandChairUsage.Text = rs.BedAndChairUsage;
                    cboxRecessStatus.Text = rs.RecessStatus;
                    //dtpDateMovingIn.Value = rs.MovedInDate.Date;
                }
                else
                {
                    MessageBox.Show("Invalid reservation Id entered!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter the reservation Id of the reservation you want to view!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
