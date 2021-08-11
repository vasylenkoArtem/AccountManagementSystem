using SmartLab.Logic.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AMS.API.Controllers
{
    [RoutePrefix("history")]
    public class HistoryController : ApiController
    {
        private readonly IHistoryQueries _historyQueries;

        public HistoryController(IHistoryQueries historyQueries)
        {
            _historyQueries = historyQueries;
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> GetHistory()
        {
            var result = await _historyQueries.GetHistory();

            return Ok(result);
        }
    }
}
