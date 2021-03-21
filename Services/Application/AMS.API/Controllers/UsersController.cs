using AMS.Logic.Queries;
using AMS.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AMS.API.Exstensions;

namespace AMS.API.Controllers
{
    //TODO: Configure and check after identity will be connected
    //[Authorize(Roles = "Admin")]
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly IUserQueries _userQueries;
        private readonly IUserService _userService;

        public UsersController(IUserQueries userQueries, IUserService userService)
        {
            _userQueries = userQueries;
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetUsers()
        {
            var users = await _userQueries.GetUsers();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddUser()
        {
            var requestParams = await Request.Content.GetFromBodyAsync<UserBuilderParams>();

            var user = _userService.AddNewUser(requestParams);

            return Ok(user);
        }

    }
}