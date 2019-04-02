using Microsoft.Extensions.Configuration;
using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly string connectionString;

        public VendorRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetSection("Data").GetSection("ConnectionString").Value;
        }

        public int CreateVendor(Vendor vendor)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            string query = @"sp_CreateVendor";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@VendorName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = vendor.VendorName,
                Size = vendor.VendorName.Length
            });
            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@VendorPhone",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = vendor.VendorPhone,
                Size = vendor.VendorPhone.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@VendorId",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            });
            cmd.ExecuteNonQuery();

            int vendorId = Convert.ToInt32(cmd.Parameters["@VendorId"].Value);

            cmd.Dispose();
            conn.Close();

            return vendorId;
        }

        public List<Vendor> GetVendorList()
        {
            List<Vendor> list = new List<Vendor>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "sp_GetVendors";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                int id = Convert.ToInt32(reader["VendorId"]);
                string vendorName = reader["VendorName"].ToString();
                string vendorPhone = reader["VendorPhone"].ToString();

                Vendor vendor = new Vendor

                {
                    VendorID = id,
                    VendorName = vendorName,
                    VendorPhone = vendorPhone,

                };
                list.Add(vendor);
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();

            return list;
        }

        public Vendor GetVendor(int id)
        {
            Vendor vendor = null;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "sp_GetVendorByID";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@VendorID";
            param.SqlDbType = System.Data.SqlDbType.Int;
            param.Value = id;
            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == true)
            {
                int vendorID = Convert.ToInt32(reader["VendorID"]);
                string vendorName = reader["VendorName"].ToString();
                string vendorPhone = reader["VendorPhone"].ToString();

                vendor = new Vendor
                {
                    VendorID = id,
                    VendorName = vendorName,
                    VendorPhone = vendorPhone,
                };
            }

            reader.Close();
            cmd.Dispose();
            conn.Close();

            return vendor;
        }

        public void UpdateVendor(Vendor vendor)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            string query = @"sp_UpdateVendor";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@VendorID",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = vendor.VendorID
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@VendorName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = vendor.VendorName,
                Size = vendor.VendorName.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@VendorPhone",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = vendor.VendorPhone,
                Size = vendor.VendorPhone.Length
            });

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

        }
    }

}
