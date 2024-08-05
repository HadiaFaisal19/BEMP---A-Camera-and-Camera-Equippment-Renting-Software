using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using ClassLibraryModel;

namespace ClassLibraryDal
{
    public class DalProductDetails
    {
        public static void AddProduct(Product product)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("AddProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PName", product.Name);
            cmd.Parameters.AddWithValue("@PCategory", product.Category);
            cmd.Parameters.AddWithValue("@PBrand", product.Brand);
            cmd.Parameters.AddWithValue("@PPrice", product.Price);
            cmd.Parameters.AddWithValue("@PDescription", product.Description);
            cmd.Parameters.AddWithValue("@IsAvailable", product.IsAvailable);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteProduct(int productId)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PID", productId);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateProduct(Product product)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update_Product", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PID", product.Id);
            cmd.Parameters.AddWithValue("@pName", product.Name);
            cmd.Parameters.AddWithValue("@PCategory", product.Category);
            cmd.Parameters.AddWithValue("@PBrand", product.Brand);
            cmd.Parameters.AddWithValue("@PPrice", product.Price);
            cmd.Parameters.AddWithValue("@PDescription", product.Description);
            cmd.Parameters.AddWithValue("@IsAvailable", product.IsAvailable);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Product> GetAllProducts()
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            List<Product> data = new List<Product>();
            SqlCommand cmd = new SqlCommand("GetAllProducts", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = int.Parse(reader["PID"].ToString()),
                    Name = reader["PName"].ToString(),
                    Category = reader["PCategory"].ToString(),
                    Brand = reader["PBrand"].ToString(),
                    Price = decimal.Parse(reader["PPrice"].ToString()),
                    Description = reader["PDescription"].ToString(),
                    IsAvailable = (bool)reader["IsAvailable"]
                };
                data.Add(product);
            }

            conn.Close();
            return data;
        }

        public static Product GetProductById(int productId)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetProductById", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PID", productId);
            SqlDataReader reader = cmd.ExecuteReader();

            Product product = null;
            if (reader.Read())
            {
                product = new Product
                {
                    Id = int.Parse(reader["PID"].ToString()),
                    Name = reader["PName"].ToString(),
                    Category = reader["PCategory"].ToString(),
                    Brand = reader["PBrand"].ToString(),
                    Price = decimal.Parse(reader["PPrice"].ToString()),
                    Description = reader["PDescription"].ToString(),
                    IsAvailable = (bool)reader["IsAvailable"]
                };
            }

            conn.Close();
            return product;
        }
    }
}
