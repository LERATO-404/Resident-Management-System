using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Residence_Management_System
{
    public partial class Login : Form
    {
        private Repository.UserRepo uR = new Repository.UserRepo();
        public Login()
        {
            InitializeComponent();
            
        }


        /*=====================method==============*/

        public Boolean isEmptyInput()
        {
            if (String.IsNullOrEmpty(txtUsername.Text) == true || String.IsNullOrEmpty(txtPassword.Text) == true )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void clearLogin()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
        /*=============================method===================*/

        private void signInbtn_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            try
            {
                if (isEmptyInput() == false)
                {
                    uR.LoginUser(username, password);
                    //clearLogin();
                }
                else
                {
                    MessageBox.Show("Please enter your username and password to log in!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            //this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
