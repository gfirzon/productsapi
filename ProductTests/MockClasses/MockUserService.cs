using ProductsApi.Models;
using ProductsApi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductTests.MockClasses
{
    public class MockUserService : IUserService
    {
        public int CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserList()
        {
            return new List<User> {
                new User{
                    UserID = 1,
                    RoleID = 1,
                    IsActive = true,
                    UserName="lala@lala.com",
                    UserPassword = "lalala"
                },
                new User{
                    UserID = 2,
                    RoleID = 2,
                    IsActive = true,
                    UserName="lala@lala.com",
                    UserPassword = "lalala"
                },
            };
        }

        public UserViewModel GetUserViewModel(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserViewModel> GetUserViewModelList()
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
