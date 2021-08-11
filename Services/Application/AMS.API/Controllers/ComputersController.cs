using AMS.Domain;
using SmartLab.Logic.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AMS.API.Controllers
{
    //[EnableCors(origins: "http://localhost:3000/", headers: "*", methods: "*")]
    [RoutePrefix("computers")]
    public class ComputersController : ApiController
    {
        private readonly IComputerQueries _computerQueries;

        public ComputersController(IComputerQueries computerQueries)
        {
            _computerQueries = computerQueries;
        }
      
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetComputers()
        {
            return Ok(await _computerQueries.GetComputers());
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
