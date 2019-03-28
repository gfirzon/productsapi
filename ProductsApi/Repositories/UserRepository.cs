using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;

        public UserRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetSection("Data").GetSection("ConnectionString").Value;

        }

        public int CreateUser(User user)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            string query = @"sp_CreateUser";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@UserName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = user.UserName,
                Size = user.UserName.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@UserPassword",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = user.UserPassword,
                Size = user.UserPassword.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@IsActive",
                SqlDbType = System.Data.SqlDbType.Bit,
                Value = user.IsActive
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@RoleID",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = user.RoleID
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@UserID",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            });

            cmd.ExecuteNonQuery();

            int userId = Convert.ToInt32(cmd.Parameters["@UserId"].Value);

            cmd.Dispose();
            conn.Close();

            return userId;
        }

        public User GetUser(int userId)
        {
            User user = null;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "sp_GetUserByID";

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@UserID";
            param.SqlDbType = System.Data.SqlDbType.Int;
            param.Value = userId;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                int id = Convert.ToInt32(reader["UserID"]);
                string userName = reader["UserName"].ToString();
                string userPassword = reader["UserPassword"].ToString();
                bool isActive = Convert.ToBoolean(reader["isActive"]);
                int roleID = Convert.ToInt32(reader["RoleID"]);

                user = new User
                {
                    UserID = id,
                    UserName = userName,
                    UserPassword = userPassword,
                    IsActive = isActive,
                    RoleID = roleID
                };
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();

            return user;
        }

        public List<User> GetUserList()
        {
            List<User> list = new List<User>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "sp_GetUsers";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read() == true)
            {
                int id = Convert.ToInt32(reader["UserID"]);
                string userName = reader["UserName"].ToString();
                string userPassword = reader["UserPassword"].ToString();
                bool isActive =Convert.ToBoolean(reader["isActive"]);
                int roleID = Convert.ToInt32(reader["RoleID"]);
               
                User user = new User
                {
                    UserID = id,
                    UserName = userName,
                    UserPassword = userPassword,
                    IsActive = isActive,
                    RoleID = roleID
                };
                list.Add(user);
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();

            return list;
        }

        public void UpdateUser(User user)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();

            string query = @"sp_UpdateUser";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@UserID",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = user.UserID
            });


            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@UserName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = user.UserName,
                Size = user.UserName.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@UserPassword",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = user.UserPassword,
                Size = user.UserPassword.Length
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@IsActive",
                SqlDbType = System.Data.SqlDbType.Bit,
                Value = user.IsActive
            });

            cmd.Parameters.Add(new SqlParameter
            {
                ParameterName = "@RoleID",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = user.RoleID
            });
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

        }
    }
}
