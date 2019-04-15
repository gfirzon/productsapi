using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connectionString;
        public ProductRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetSection("Data").GetSection("ConnectionString").Value;
        }

        public int CreateProduct(Product product)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            string query = @"sp_CreateProduct";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = product.ProductName,
                Size = product.ProductName.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductDescription",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = product.ProductDescription,
                Size = product.ProductDescription.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@UnitsInStock",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = product.UnitsInStock
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@SellPrice",
                SqlDbType = System.Data.SqlDbType.Decimal,
                Value = product.SellPrice
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@DiscountPercentage",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = product.DiscountPercentage
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@UnitsMax",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = product.UnitsMax
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductID",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            });

            cmd.ExecuteNonQuery();

            int productId = Convert.ToInt32(cmd.Parameters["@ProductID"].Value);

            cmd.Dispose();
            conn.Close();

            return productId;
        }

        public Product GetProduct(int productId)
        {
            Product product = null;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "sp_GetProductByID";

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@ProductID";
            param.SqlDbType = System.Data.SqlDbType.Int;
            param.Value = productId;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                int id = Convert.ToInt32(reader["ProductID"]);
                string productName = reader["ProductName"].ToString();
                string productDescription = reader["ProductDescription"].ToString();
                int unitsInStock = Convert.ToInt32(reader["UnitsInStock"]);
                decimal sellPrice = Convert.ToDecimal(reader["SellPrice"]);
                int discountPercentage = Convert.ToInt32(reader["DiscountPercentage"]);
                int unitsMax = Convert.ToInt32(reader["UnitsMax"]);

                product = new Product
                {
                    ProductID = id,
                    ProductName = productName,
                    ProductDescription = productDescription,
                    UnitsInStock = unitsInStock,
                    SellPrice = sellPrice,
                    DiscountPercentage = discountPercentage,
                    UnitsMax = unitsMax
                };
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();

            return product;
        }

        public List<Product> GetProductList()
        {
            List<Product> list = new List<Product>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "sp_GetProducts";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                int id = Convert.ToInt32(reader["ProductID"]);
                string productName = reader["ProductName"].ToString();
                string productDescription = reader["ProductDescription"].ToString();
                int unitsInStock = Convert.ToInt32(reader["UnitsInStock"]);
                decimal sellPrice = Convert.ToDecimal(reader["SellPrice"]);
                int discountPercentage = Convert.ToInt32(reader["DiscountPercentage"]);
                int unitsMax = Convert.ToInt32(reader["UnitsMax"]);


                Product product = new Product
                {
                    ProductID = id,
                    ProductName = productName,
                    ProductDescription = productDescription,
                    UnitsInStock = unitsInStock,
                    SellPrice = sellPrice,
                    DiscountPercentage = discountPercentage,
                    UnitsMax = unitsMax
                };
                list.Add(product);
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();

            return list;
        }


        public void UpdateProduct(Product product)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            string query = @"sp_UpdateProduct";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductID",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = product.ProductID
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = product.ProductName,
                Size = product.ProductName.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@ProductDescription",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = product.ProductDescription,
                Size = product.ProductDescription.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@UnitsInStock",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = product.UnitsInStock
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@SellPrice",
                SqlDbType = System.Data.SqlDbType.Decimal,
                Value = product.SellPrice
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@DiscountPercentage",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = product.DiscountPercentage
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@UnitsMax",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = product.UnitsMax
            });

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }
    }
    
}
