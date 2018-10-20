using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WebAPI.Skilltree.vs17.Controllers
{
    public class ElmahController : ApiController
    {
        [HttpGet]
        [Route("tryElmah/{id:int}")]
        public int tryElmah(int id)
        {
            throw new NotImplementedException();

            if (id > 10)
            {
                throw new Exception("From: throw new Exception");
            }
            return id;
        }
    }

    public class ElmahErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
                Elmah.ErrorSignal
                       .FromCurrentContext()
                       .Raise(actionExecutedContext.Exception);
            base.OnException(actionExecutedContext);
        }
    }
}
