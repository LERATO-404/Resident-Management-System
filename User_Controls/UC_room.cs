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
    public partial class UC_room : UserControl
    {
        private readonly ExtraMethods.MyMethods myM = new ExtraMethods.MyMethods();
        private readonly Repository.RoomControllerRepo rRCR = new Repository.RoomControllerRepo();
        public UC_room()
        {
            InitializeComponent();
        }

        public Boolean IsRoomInputEmpty()
        {
            if (String.IsNullOrEmpty(txtRoomIdentifier.Text) == true || String.IsNullOrEmpty(cboxFloor.Text) == true ||
            String.IsNullOrEmpty(cboxRoomType.Text) == true || String.IsNullOrEmpty(cboxRoomAvailability.Text) == true)
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
            
        }
    }
}
