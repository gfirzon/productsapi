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
            ActionResult actionResult = null;

            try
            {
                List<User> list = userService.GetUserList();
                if (list != null)
                {
                    actionResult = Ok(list);
                }
                else
                {
                    actionResult = NotFound();
                }
            }
            catch (Exception ex)
            {
                string message = $"Unable to process update request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);

            }

            return actionResult;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        //[HttpGet("{id}", Name = "Get")]
        public ActionResult<User> Get(int id)
        {
            ActionResult actionResult = null;

            try
            {
                User user = userService.GetUser(id);

                if (user != null)
                {
                    actionResult = Ok(user);
                }
                else
                {
                    actionResult = NotFound();
                }
            }
            catch (Exception ex)
            {
                string message = $"Unable to process update request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return actionResult;
        }

        // GET: api/Users/5
        [HttpGet("GetUserIDWithRoleName")]
        public ActionResult<UserViewModel> GetUserIDWithRoleName(int id)
        {
            ActionResult actionResult = null;

            try
            {
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
            catch (Exception ex)
            {
                string message = $"Unable to process update request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return actionResult;
        }

        // GET: api/Users/GetUsersListWithRoleName
        [HttpGet("GetUsersListWithRoleName")]
        public ActionResult<IEnumerable<UserViewModel>> GetUsersListWithRoleName()
        {
            ActionResult actionResult = null;

            try
            {
                List<UserViewModel> list = userService.GetUserViewModelList();
                if (list != null)
                {
                    actionResult = Ok(list);
                }
                else
                {
                    actionResult = NotFound();
                }
            }
            catch (Exception ex)
            {
                string message = $"Unable to process update request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return actionResult;
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<int> Post(User user)
        {
            ActionResult actionResult = null;

            try
            {
                int id = userService.CreateUser(user);

                if (id != 0)
                {
                    actionResult = Ok(user);
                }
                else
                {
                    actionResult = NotFound();
                }
            }
            catch (Exception ex)
            {
                string message = $"Unable to process update request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return actionResult;
        }

        // PUT: api/Users/5
        [HttpPut]
        public ActionResult Put(User user)
        {
            ActionResult actionResult = null;

            try
            {
                bool isUpdated = userService.UpdateUser(user);

                if (isUpdated == true)
                {
                    actionResult = Ok("Product updated....");
                }
                else
                {
                    actionResult = NotFound();
                }
            }
            catch (Exception ex)
            {
                //string message = string.Format("Unable to process update request: {0}", ex.Message);
                string message = $"Unable to process update request: {ex.Message}";
                actionResult = StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return actionResult;
        }
    }
}
