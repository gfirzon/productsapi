using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            List<User> list = new List<User>{
                new User{ UserID = 1, UserName = "Ivan Ivanov", UserPassword = "ivan@gmail.com", IsActive = true },
                new User{ UserID = 2, UserName = "Svetlana Nikitin", UserPassword = "nikitin1212", IsActive = true}

            };
            return list;
        }
        
        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public AcceptedResult<User> Get(int id)
        {
            return new User { UserID = id, UserName = "Olga Kent", UserPassword = "kent.yahoo.com", IsActive = false };
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] User value)
        {
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
