using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AMS.API.Controllers
{
    public class ComputersController : ApiController
    {
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetComputers()
        {
            return null;
        }

        [Route("{computerId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetComputer(int computerId)
        {
            return null;
        }

        [Route("history")]
        [HttpGet]
        public async Task<IHttpActionResult> GetComputerIssueHistory()
        {
            return null;
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> AddComputer()
        {
            return null;
        }

        [Route("{computerId}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteComputer(int computerId)
        {
            return null;
        }

        [Route("issue/{computerId}/request")]
        [HttpPost]
        public async Task<IHttpActionResult> RequestForComputerIssue(int computerId)
        {
            return null;
        }

        [Route("issue/{computerId}/approve")]
        [HttpPost]
        public async Task<IHttpActionResult> ApproveComputerIssue(int computerId)
        {
            return null;
        }

        [Route("issue/{computerId}/complete")]
        [HttpPost]
        public async Task<IHttpActionResult> CompleteComputerIssue(int computerId)
        {
            return null;
        }

    }
}
