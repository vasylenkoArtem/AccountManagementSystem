using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AMS.API.Controllers
{
    public class RoomsController : ApiController
    {
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetRooms()
        {
            return null;
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
