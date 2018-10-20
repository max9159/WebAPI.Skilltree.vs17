using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Skilltree.vs17.Controllers
{

    /// <summary>
    /// Try Exception Handling
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BoomController : ApiController
    {
        /// <summary>
        /// Exception
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">From: throw new Exception</exception>
        [HttpGet]
        [Route("demo0/{id:int}")]
        public int Demo0(int id)
        {
            if (id > 10)
            {
                throw new Exception("From: throw new Exception");
            }
            return id;
        }

        /// <summary>
        /// HttpResponseMessage
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        [HttpGet]
        [Route("demo1")]
        public HttpResponseMessage Demo1()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = new StringContent("From: throw new HttpResponseException");
            throw new HttpResponseException(response);
        }

        /// <summary>
        /// HttpResponseMessage
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("demo2")]
        public HttpResponseMessage Demo2()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = new StringContent("From: HttpResponseMessage Object");
            return response;
        }

        //### HttpError / CreateErrorResponse        
        /// <summary>
        /// Demo3s the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("demo3/{id:int}")]
        public HttpResponseMessage Demo3(int id)
        {
            if (id > 10)
            {
                HttpError error = new HttpError("From: HttpError");
                error["ErrorCode"] = 9487;
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, error);
            }
            var customer = new Customer() { FirstName = "Bruce", LastName = "Chen" };
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        //### HttpResponseException + CreateErrorResponse        
        /// <summary>
        /// Demo4s the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        [HttpGet]
        [Route("demo4/{id:int}")]
        public Customer Demo4(int id)
        {
            if (id > 10)
            {
                string msg = "From: HttpResponseException + Request.CreateErrorResponse";
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, msg));
            }
            var customer = new Customer() { FirstName = "Bruce", LastName = "Chen" };
            return customer;
        }
    }
}
