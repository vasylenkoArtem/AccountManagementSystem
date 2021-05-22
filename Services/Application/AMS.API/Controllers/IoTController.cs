using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AMS.API.Controllers
{
    public class IoTController : ApiController
    {
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetIoTSets()
        {
            return null;
        }

        [Route("{ioTSetId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetIoTSet(int ioTSetId)
        {
            return null;
        }

        [Route("history")]
        [HttpGet]
        public async Task<IHttpActionResult> GetIoTSetIssueHistory()
        {
            return null;
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> AddIoTSet()
        {
            return null;
        }

        [Route("{ioTSetId}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteIoTSet(int ioTSetId)
        {
            return null;
        }

        [Route("issue/{ioTSetId}/request")]
        [HttpPost]
        public async Task<IHttpActionResult> RequestForIoTSetIssue(int computerId)
        {
            return null;
        }

        [Route("issue/{ioTSetId}/approve")]
        [HttpPost]
        public async Task<IHttpActionResult> ApproveIoTSetIssue(int ioTSetId)
        {
            return null;
        }

        [Route("issue/{ioTSetId}/complete")]
        [HttpPost]
        public async Task<IHttpActionResult> CompleteIoTSetIdIssue(int ioTSetId)
        {
            return null;
        }
    }
}
