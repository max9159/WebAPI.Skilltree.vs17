using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebAPI.Skilltree.vs17.Controllers
{
    public class Elmah404Controller : ApiController
    {
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, HttpPatch]
        public IHttpActionResult NotFound(string path)
        {
            // 404 to ELMAH or Logger
            Elmah.ErrorSignal.FromCurrentContext().Raise(
                new HttpException(404, "404 Not Found: /" + path));
            return NotFound();
        }
    }
}
