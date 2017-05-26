using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using _24SportWS;

namespace _24SportWS.Controllers
{
    public class ProductPartsController : ApiController
    {
        private SportDBContext db = new SportDBContext();

        // GET: api/ProductParts
        public IQueryable<ProductPart> GetProductParts()
        {
            return db.ProductParts;
        }

        // GET: api/ProductParts/5
        [ResponseType(typeof(ProductPart))]
        public IHttpActionResult GetProductPart(int id)
        {
            ProductPart productPart = db.ProductParts.Find(id);
            if (productPart == null)
            {
                return NotFound();
            }

            return Ok(productPart);
        }

        // PUT: api/ProductParts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductPart(int id, ProductPart productPart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productPart.ProductPartId)
            {
                return BadRequest();
            }

            db.Entry(productPart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPartExists(id))
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

        // POST: api/ProductParts
        [ResponseType(typeof(ProductPart))]
        public IHttpActionResult PostProductPart(ProductPart productPart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductParts.Add(productPart);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productPart.ProductPartId }, productPart);
        }

        // DELETE: api/ProductParts/5
        [ResponseType(typeof(ProductPart))]
        public IHttpActionResult DeleteProductPart(int id)
        {
            ProductPart productPart = db.ProductParts.Find(id);
            if (productPart == null)
            {
                return NotFound();
            }

            db.ProductParts.Remove(productPart);
            db.SaveChanges();

            return Ok(productPart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductPartExists(int id)
        {
            return db.ProductParts.Count(e => e.ProductPartId == id) > 0;
        }
    }
}