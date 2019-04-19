using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public int CreateUser(User user)
        {
            return userRepository.CreateUser(user);
        }

        public User GetUser(int id)
        {
            return userRepository.GetUser(id);
        }

        public List<User> GetUserList()
        {
            return userRepository.GetUserList();
        }

        public bool UpdateUser(User user)
        {
            bool result = false;

            User dbUser = GetUser(user.UserID);

            if (dbUser != null)
            {
                userRepository.UpdateUser(user);
                result = true;
            }

            return result;

        }

        public List<UserViewModel> GetUserViewModelList()
        {
            return userRepository.GetUserViewModelList();
        }

        public UserViewModel GetUserViewModel(int id)
        {
            return userRepository.GetUserViewModel(id);
        }
    }
}
