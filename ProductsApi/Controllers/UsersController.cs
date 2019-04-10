using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            List<User> list = userService.GetUserList();

            return list;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<User> Get(int id)
        {
            User user = userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        // GET: api/Users/5
        [HttpGet("GetUserIDWithRoleName")]
        public ActionResult<UserViewModel> GetUserIDWithRoleName(int id)
        {
            //[dbo].[sp_GetUserIDWithRoleName]

            UserViewModel user = userService.GetUserViewModel(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        // GET: api/Users/GetUsersListWithRoleName
        [HttpGet("GetUsersListWithRoleName")]
        public ActionResult<IEnumerable<UserViewModel>> GetUsersListWithRoleName()
        {
            //[dbo].[sp_GetUsersListWithRoleName]

            List<UserViewModel> list = userService.GetUserViewModelList();
            //List<User> list = userService.GetUserList();

            return list;
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<int> Post(User user)
        {
            int id = userService.CreateUser(user);

            return id;
        }

        // PUT: api/Users/5
        [HttpPut]
        public ActionResult Put(User user)
        {
            int id = user.UserID;

            User dbUser = userService.GetUser(id);

            if (dbUser != null)
            {
                userService.UpdateUser(user);
                return Ok("User updated....");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
