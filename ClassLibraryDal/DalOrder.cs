using ClassLibraryModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDal
{
    public class DalOrder
    {

        public static void AddOrder(Order order)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            // Add the order
            SqlCommand cmd = new SqlCommand("AddOrder", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CNIC", order.CustomerCnic);
            cmd.Parameters.AddWithValue("@StartDate", order.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", order.EndDate);
            cmd.Parameters.AddWithValue("@StartShift", order.StartShift);
            cmd.Parameters.AddWithValue("@EndShift", order.EndShift);
            cmd.Parameters.AddWithValue("@Status", order.Status);
            cmd.Parameters.AddWithValue("@SubTotal", order.SubTotal);
            cmd.Parameters.AddWithValue("@Discount", order.Discount);
            cmd.Parameters.AddWithValue("@Total", order.Total);
            cmd.Parameters.AddWithValue("@Remarks", order.Remarks);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
