using System;
using System.Collections.Generic;
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

        public List<User> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}
