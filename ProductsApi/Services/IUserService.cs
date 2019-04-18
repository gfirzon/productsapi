using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Services
{
    public interface IUserService
    {
        List<User> GetUserList();
        User GetUser(int id);
        int CreateUser(User user);
        bool UpdateUser(User user);
        List<UserViewModel> GetUserViewModelList();

        UserViewModel GetUserViewModel(int id);
    }
}

