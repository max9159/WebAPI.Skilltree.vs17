using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Clean.Controllers
{
    [RoutePrefix("ModelBinding")]
    public class ModelBindingController : ApiController
    {
        [HttpGet, HttpPost]
        [Route("SampleBinding")]
        public string SampleBinding(int id)
        {
            return id.ToString();
        }

        [HttpGet]
        [Route("OptionParams")]
        public string OptionParams(int? id = null)
        {
            if (id == null)
            {
                return "id 不得為空！";
            }
            return id.ToString();
        }

        [HttpPost]
        [Route("idFromBody")]
        public string idFromBody([FromBody]int id)
        {
            return id.ToString();
        }

        [HttpGet, HttpPost]
        [Route("idUriNameBody")]
        public string idUriNameBody(int id, [FromBody]string name)
        {
            return $"Id:{id}, name:{name}";
        }

        [HttpPost]
        [Route("Customer")]
        public string Customer(Customer customer)
        {
            return customer.ToString();
        }

        [HttpPost]
        [Route("MultiCustomer")]
        public string MultiCustomer(CustomerS CustomerS)
        {
            return $"{CustomerS.cus1.ToString()}, {CustomerS.cus2.ToString()}";
        }
    }
    public class CustomerS
    {
        public Customer cus1{ get; set; }
        public Customer cus2 { get; set; }

    }


    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}";
        }
    }
}
