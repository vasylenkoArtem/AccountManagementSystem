using SmartLab.Logic.Services.UserRoom;
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
    //[Authorize(Roles = "LaboratoryWorker")]
    [RoutePrefix("lock")]
    public class LockController : ApiController
    {
        private readonly IUserRoomService _userRoomService;

        public LockController(IUserRoomService userRoomService)
        {
            _userRoomService = userRoomService;
        }

        [Route("{roomNumber}/unlock-room")]
        public async Task<IHttpActionResult> UnlockRoom(string roomNumber)
        {
            //logic to check personal access to the room

            var canUnlockRoom = await _userRoomService.UnlockRoom(roomNumber);
            if (canUnlockRoom)
            {
                return Ok();
            }

            return BadRequest();

        }

    }
}
