using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MessageBox = System.Windows.Forms.MessageBox;
using Residence_Management_System.ExtraMethods;

namespace Residence_Management_System.Repository
{
    class ManagerRepo
    {
        /*
        private readonly MyMethods myAdminMethod = new MyMethods();
        public void loadRoomReport()
        {
            string sqlRoomType = @"SELECT r.roomId, r.roomSymbolCode, r.roomType, rs.studentId AS OccupantId, s.firstName, s.lastName
                                   FROM Rooms r
                                        INNER JOIN Reservations rs
                                           ON r.roomId = rs.roomId
                                        INNER JOIN Students s
                                           ON  rs.studentId = s.studentId
                                       GROUP BY r.roomId";
            using (SqlConnection con = new SqlConnection(myAdminMethod.GetConnection()))
            {
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(sqlRoomType, con)
                {
                    CommandType = CommandType.Text
                };
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
            }

        }*/
    }
}
