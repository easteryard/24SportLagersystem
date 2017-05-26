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
    public class ProductLinesController : ApiController
    {
        private SportDBContext db = new SportDBContext();

        // GET: api/ProductLines
        public IQueryable<ProductLine> GetProductLines()
        {
            return db.ProductLines;
        }

        // GET: api/ProductLines/5
        [ResponseType(typeof(ProductLine))]
        public IHttpActionResult GetProductLine(int id)
        {
            ProductLine productLine = db.ProductLines.Find(id);
            if (productLine == null)
            {
                return NotFound();
            }

            return Ok(productLine);
        }

        // PUT: api/ProductLines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductLine(int id, ProductLine productLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productLine.ProductLineId)
            {
                return BadRequest();
            }

            db.Entry(productLine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductLineExists(id))
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

        // POST: api/ProductLines
        [ResponseType(typeof(ProductLine))]
        public IHttpActionResult PostProductLine(ProductLine productLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductLines.Add(productLine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productLine.ProductLineId }, productLine);
        }

        // DELETE: api/ProductLines/5
        [ResponseType(typeof(ProductLine))]
        public IHttpActionResult DeleteProductLine(int id)
        {
            ProductLine productLine = db.ProductLines.Find(id);
            if (productLine == null)
            {
                return NotFound();
            }

            db.ProductLines.Remove(productLine);
            db.SaveChanges();

            return Ok(productLine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductLineExists(int id)
        {
            return db.ProductLines.Count(e => e.ProductLineId == id) > 0;
        }
    }
}