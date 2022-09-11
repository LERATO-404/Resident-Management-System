using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Residence_Management_System.ExtraMethods
{
    internal class MyMethods
    {

        //gets connection string
        public string GetConnection()
        {
            try
            {
                
                string constring = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                if(constring != null)
                {
                    ConfigurationManager.RefreshSection("MyConnectionString");
                    return ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Connection - Something is wrong with the server/database!!!!" , "Invalid Server/Database", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                    return "";
                }
                
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Connection!!!! \n" + ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString() + "/nThis is an invalid connection" + sqlEx.Message, "Invalid Server/Database", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public bool CheckIdRecordExist(string selectedTable)
        {
            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                SqlDataAdapter adp = new SqlDataAdapter(selectedTable, con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    dt.Dispose();
                    adp.Dispose();
                }
            }
            return false;
        }
        
        

        public int CountRecords(string sqlCount)
        {
            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                using (SqlCommand cmd = new SqlCommand(sqlCount, con))
                {
                    if (con.State != ConnectionState.Open){con.Open();}
                    try
                    {
                        return (int)cmd.ExecuteScalar();
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }
        }

        public void ViewTable(DataGridView dgv, string selectTable)
        {
            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }

                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(selectTable, con);
                SqlDataAdapter adapt = new SqlDataAdapter()
                {
                    SelectCommand = cmd
                };
                try
                {
                    adapt.Fill(ds, "Info");
                    dgv.DataSource = ds;
                    dgv.DataMember = "Info";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please select the table you want to display"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ds.Dispose();
                    cmd.Dispose();
                    adapt.Dispose();
                    //if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
        }

        public void RemoveById(int id, string sqlDeleteResource)
        {
            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlDataAdapter adapt = new SqlDataAdapter()
                {
                    DeleteCommand = new SqlCommand(sqlDeleteResource, con)
                };
                try
                {
                    if (MessageBox.Show("Are you sure you want to delete id number:" + id.ToString(), "Remove Resource", (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int deletedResource = adapt.DeleteCommand.ExecuteNonQuery();
                        if (deletedResource > 0)
                        {
                            MessageBox.Show("Id number:" + id.ToString() + " removed", "Remove Resource", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Id not found", "Id not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Id number:" + id.ToString() + " not removed", "Remove Resource", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to remove resource.Please Display the table you want to delete a resource From \n", "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    adapt.Dispose();
                    //if (con.State == ConnectionState.Open) { con.Close(); }
                }
            }
        }

        public string JobTitleSelected(ComboBox cs)
        {
            string _jobTitle = "Guest";
            if (cs.SelectedIndex == 0)
            {
                _jobTitle = "Full-Time";
            }
            else if (cs.SelectedIndex == 1)
            {
                _jobTitle = "Part-Time";
            }
            else if (cs.SelectedIndex == 2)
            {
                _jobTitle = "Temporary";
            }
            else if (cs.SelectedIndex == 3)
            {
                _jobTitle = "Volunteer";
            }
            return _jobTitle;
        }

        
        public bool CheckIfIdExist(string query)
        {
            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader myReader = cmd.ExecuteReader();

                try
                {
                    //cmd.ExecuteNonQuery();
                    if (myReader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Id does not exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + GetConnection().ToString());   
                }
                finally
                {
                    myReader.Close();
                    cmd.Dispose();
                }
                return false;
            }
           
        }
    }   
}
