﻿using AMS.Logic.Queries;
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

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> AddUser()
        {
            var requestParams = new UserBuilderParams();

            var user = await _userService.AddNewUser(requestParams);

            return Ok(user);
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
            return null;
        }
    }
}