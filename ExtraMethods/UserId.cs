﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using Residence_Management_System.ExtraMethods;

namespace Residence_Management_System
{
    public class UserId
    {
        private  static readonly MyMethods myUserMethod = new MyMethods();
        public static int GetUserId()
        {
            string sqlId = @"SELECT * FROM [users] WHERE username = @username"; // userName = lblWelcome.Text
            using (SqlConnection con = new SqlConnection(myUserMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(sqlId, con);
                cmd.Parameters.AddWithValue("@username", Repository.UserRepo.userLoggedIn);
                try
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                finally
                {
                    cmd.Dispose();

                }
            }
        }

        public static String GetUserJobType()
        {
            string sqlId = @"SELECT jobType  FROM [users] WHERE username = @username"; // userName = lblWelcome.Text
            using (SqlConnection con = new SqlConnection(myUserMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(sqlId, con);
                cmd.Parameters.AddWithValue("@username", Repository.UserRepo.userLoggedIn);
                try
                {
                    return cmd.ExecuteScalar().ToString();
                }
                finally
                {
                    cmd.Dispose();

                }
            }
        }

        
    }
    
}