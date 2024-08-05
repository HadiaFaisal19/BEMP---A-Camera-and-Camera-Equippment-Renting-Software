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
    public class DalCustomer
    {
        public static void AddCustomer(Customer customer)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("AddCustomer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CNIC", customer.CustomerCnic);
            cmd.Parameters.AddWithValue("@CName", customer.CustomerName);
            cmd.Parameters.AddWithValue("@CContact", customer.CustomerContact);
            cmd.Parameters.AddWithValue("@CDOB", customer.Dob);
            cmd.Parameters.AddWithValue("@CRName", customer.ReferenceName);
            cmd.Parameters.AddWithValue("@CRContact", customer.ReferenceContact);
            cmd.Parameters.AddWithValue("@PictureUrl", customer.PictureUrl);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteCustomer(string customerCnic)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteCustomer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CNIC", customerCnic);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateCustomer(Customer customer)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update_Customer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CNIC", customer.CustomerCnic);
            cmd.Parameters.AddWithValue("@CName", customer.CustomerName);
            cmd.Parameters.AddWithValue("@CContact", customer.CustomerContact);
            cmd.Parameters.AddWithValue("@CDOB", customer.Dob);
            cmd.Parameters.AddWithValue("@CRName", customer.ReferenceName);
            cmd.Parameters.AddWithValue("@CRContact", customer.ReferenceContact);
            cmd.Parameters.AddWithValue("@PictureUrl", customer.PictureUrl);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Customer> GetAllCustomers()
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            List<Customer> data = new List<Customer>();
            SqlCommand cmd = new SqlCommand("GetAllCustomers", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Customer Customer = new Customer
                {
                    CustomerCnic = reader["CNIC"].ToString(),
                    CustomerName = reader["CName"].ToString(),
                    CustomerContact = reader["CContact"].ToString(),
                    Dob = DateTime.Parse(reader["CDOB"].ToString()),
                    ReferenceName = reader["CRName"].ToString(),
                    ReferenceContact = reader["CRContact"].ToString(),
                    PictureUrl = reader["PictureUrl"].ToString(),
                };
                data.Add(Customer);
            }

            conn.Close();
            return data;
        }

        public static Customer GetCustomerById(string CustomerId)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetCustomerById", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CNIC", CustomerId);
            SqlDataReader reader = cmd.ExecuteReader();

            Customer Customer = null;
            if (reader.Read())
            {
                Customer = new Customer
                {
                    CustomerCnic = reader["CNIC"].ToString(),
                    CustomerName = reader["CName"].ToString(),
                    CustomerContact = reader["CContact"].ToString(),
                    Dob = DateTime.Parse(reader["CDOB"].ToString()),
                    ReferenceName = reader["CRName"].ToString(),
                    ReferenceContact = reader["CRContact"].ToString(),
                    PictureUrl = reader["PictureUrl"].ToString(),
                };
            }

            conn.Close();
            return Customer;
        }
    }
}
