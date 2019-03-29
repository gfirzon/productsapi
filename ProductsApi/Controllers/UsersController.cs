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
            User user =  userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok (user);
            }

        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<int> Post (User user)
        {
            int id = userService.CreateUser(user);

            return id;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, User user)
        {
            int id1 = id;
            //User user1 = userService.UpdateUser.Where(m => m.UserId == user.UserId).FirstOrDefault();
            userService.UpdateUser(user);

            //if (user1 != null)
            //{
            //    user1.UserName = user.UserName;
            //    user1.UserPassword = user.UserPassword;
            //    user1.IsActive = user.IsActive;
            //    user1.RoleID = user.RoleID;
            //    //userService.SaveChanges();
            //}
        }
    }
}
