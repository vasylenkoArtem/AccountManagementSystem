using AMS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS.API.Controllers
{
    public class ValuesController : ApiController
    {
        AccountManagementSystemContext _context;

        public ValuesController(AccountManagementSystemContext context)
        {
            _context = context;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            var test = _context.Users.ToArray();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
