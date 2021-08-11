using AMS.Logic.Queries.UserRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AMS.API.Controllers
{
    [RoutePrefix("rooms")]
    public class RoomsController : ApiController
    {
        private readonly IRoomQueries _roomQueries;

        public RoomsController(IRoomQueries roomQueries)
        {
            _roomQueries = roomQueries;
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetRooms()
        {
            var result = await _roomQueries.GetRooms();

            return Ok(result);
        }

        [Route("{roomId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetRoom(int roomId)
        {
            return null;
        }

        [Route("history")]
        [HttpGet]
        public async Task<IHttpActionResult> GetRoomsHistory()
        {
            return null;
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> AddRoom()
        {
            return null;
        }

        [Route("{roomId}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRoom(int roomId)
        {
            return null;
        }
    }
}
