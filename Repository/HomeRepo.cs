using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Residence_Management_System.Repository
{
    public class HomeRepo{
	
		public static SqlConnection getConnection()
		{

			string constring = @"";
			SqlConnection con = new SqlConnection(constring);
			try
			{
				con.Open();

			}
			catch (SqlException sqlEx)
			{
                MessageBox.Show("Sql Connectio! \n" + sqlEx.Message, "Error", (MessageBoxButtons)MessageBoxButton.OK, MessageBoxIcon.Error);

			}
			return con;
		}
		public int countRecords(string tableNameSelected)
		{
			try
			{
				int recordsAvailable = 0;
				string sqlTotalRecords = @"SELECT COUNT(*) FROM [tableNameSelected]";
					
				using (SqlConnection con = getConnection())
				{
					using (SqlCommand cmd = new SqlCommand(sqlTotalRecords, con))
					{
						if (con.State != ConnectionState.Open)
							con.Open();
						recordsAvailable = (int)cmd.ExecuteScalar();
						con.Close();
					}
				}  
				return recordsAvailable;
				
			}catch(Exception ex){
				return 0;
			}
		}

		public static void viewTable(string tableNameSelected, DataGridView dgv){
			using (SqlConnection con = getConnection())
			{
				if (con.State != ConnectionState.Open)
					con.Open();
				string sqlQuery = @"Select * FROM [tableNameSelected]";
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				SqlDataAdapter adp = new SqlDataAdapter(cmd);
				DataSet ds = new DataSet();

				adp.SelectCommand = cmd;
				adp.Fill(ds, "KeyInfo");

				dgv.DataSource = ds;
				dgv.DataMember = "KeyInfo";

				if (con.State == ConnectionState.Open)
					con.Close();
			}
		}
	}
}




