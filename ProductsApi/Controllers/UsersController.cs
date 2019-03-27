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
            return userService.GetUser(id);

            if (User == null)
            {
                return NotFound();
            }
            else
            {
                return Ok (User);
            }
            //return new User { UserID = id, UserName = "Olga Kent", UserPassword = "kent.yahoo", IsActive = false };
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
            //userService.UpdateUser(id);
            //update
            //User[id] = value;
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           // userService.
            //User.RemoveAt(id);
        }
    }
}
