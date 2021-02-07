using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SmartLab.API.Controllers
{
    public class RoomsController : ApiController
    {
        [HttpPost]
        [Route("{audienceId}")]
        [Authorize] //[Authorize(Roles = "InternalUser")]
        public async Task<IHttpActionResult> UnlockAudience(int audienceId)
        {
            return Ok(true);
        
        }
    }
}
