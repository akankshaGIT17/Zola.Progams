using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Zola.Web.Controllers
{
    public class PharmaController : ApiController
    {
        // GET api/<controller>
        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/all")]
        public IHttpActionResult GetAll()
        {
            return Ok("New server time is" + DateTime.Now.ToString());
        }

        [Authorize]
        [HttpGet]
      //  [Route("api/data/getAuth")]
        // GET api/<controller>/5
        public IHttpActionResult GetAuthenticated()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello" + identity.Name);
        }
        [Authorize(Roles ="admin")]
        [HttpGet]
        [Route("api/data/getAdminAuth")]
        // POST api/<controller>
        public IHttpActionResult GetAdminAuthenticated()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
            return Ok("Hello " + identity.Name + " Role " + string.Join(",", roles.ToList()));
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}