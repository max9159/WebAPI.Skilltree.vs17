using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.Skilltree.vs17.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Skilltree.vs17.Models;
using RestSharp;

namespace WebAPI.Skilltree.vs17.Controllers.Tests
{
    [TestClass()]
    public class Products1ControllerTests
    {

        [TestMethod()]
        public void GetProducts_id78_returnOneProductObjectTest()
        {
            // arrange
            var expected = 78;

            var client = new RestClient("http://localhost:60839/api/products1/78");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "8b259027-4c03-4d39-be5b-cc4f24d196c7");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            // Execute<T> 執自動進行反序列化
            var responseObj = client.Execute<Product>(request);
            // assert
            // response.Data. <-- 自己點點看，強型別才有辦法驗證
            Assert.AreEqual(expected, responseObj.Data.ProductID);
        }

        [TestMethod()]
        public void GetProductTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutProductTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PatchProductTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostProductTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteProductTest()
        {
            Assert.Fail();
        }
    }
}