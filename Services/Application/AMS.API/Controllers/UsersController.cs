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
using System.Web.Http.Cors;
using Newtonsoft.Json;
using AMS.Domain;

namespace AMS.API.Controllers
{
   
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly IUserQueries _userQueries;
        private readonly IUserService _userService; //баг с DI

        public UsersController(IUserQueries userQueries, IUserService userService)
        {
            _userQueries = userQueries;
            _userService = userService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUsers()
        {
            var users = await _userQueries.GetUsers();

            return Ok(users);
        }

        [Route("{userId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserDetails(int userId)
        {
            return null;
        }

        [Route("")]
        [HttpPost]
        public async Task<User> AddUser()
        {
            var requestContent = Request.Content;
            var jsonContent = await requestContent.ReadAsStringAsync();
            var requestParams = JsonConvert.DeserializeObject<UserBuilderParams>(jsonContent);

            var user = await _userService.AddNewUser(requestParams);

            return user;
        }

        [Route("history")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUsersHistory()
        {
            return null;
        }

        [Route("{userId}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteUser(userId);

            return Ok();
        }
    }
}