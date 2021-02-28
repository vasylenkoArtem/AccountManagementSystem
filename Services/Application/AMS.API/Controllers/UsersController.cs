using SmartLab.Logic.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AMS.API.Controllers
{
    //TODO: Configure and check after identity will be connected
    //[Authorize(Roles = "Admin")]
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly IUserQueries _userQueries;

        public UsersController(IUserQueries userQueries)
        {
            _userQueries = userQueries;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetUsers()
        {
            var users = await _userQueries.GetUsers();

            return Ok(users);
        }

    }
}