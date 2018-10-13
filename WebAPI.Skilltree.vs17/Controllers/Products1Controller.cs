using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Skilltree.vs17.Models;

/// <summary>
/// 
/// </summary>
namespace WebAPI.Skilltree.vs17.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class Products1Controller : ApiController
    {
        /// <summary>
        /// The database
        /// </summary>
        private Northwind db = new Northwind();


        /// <summary>
        /// MIMEs the test.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MIME")]
        public HttpResponseMessage MIMETest()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "ok");
            response.Content = new StringContent("res string test");
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //response.Content = new ByteArrayContent(imgdata);
            //response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");

            return response;
        }
        /// <summary>
        /// Authentications this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("login")]
        public HttpResponseMessage Auth()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            return response;
        }
        // GET: api/Products1
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

        // GET: api/Products1/5
        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products1/5
        /// <summary>
        /// Puts the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // PATCH: api/Products1/5
        /// <summary>
        /// Patches the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="patchData">The patch data.</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PatchProduct(int id, Product patchData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patchData.ProductID)
            {
                return BadRequest();
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            // 異動 Product 物件部分欄位
            product.ProductName = patchData.ProductName;

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products1
        /// <summary>
        /// Posts the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products1/5
        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        /// <summary>
        /// Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Products the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}