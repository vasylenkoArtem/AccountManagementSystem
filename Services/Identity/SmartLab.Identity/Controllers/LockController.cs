using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS.Identity.Controllers
{
    [Authorize(Roles = "LaboratoryWorker")]
    [RoutePrefix("lock")]
    public class LockController : ApiController
    {
        [Route("{roomId}/unlock-room")]
        public IHttpActionResult UnlockRoom(string roomId)
        {
            //logic to check personal access to the room
            return Ok();
        }

    }
}
