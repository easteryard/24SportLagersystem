﻿using System;
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
    public class OrderLinesController : ApiController
    {
        private _24SportDBContext db = new _24SportDBContext();

        // GET: api/OrderLines
        public IQueryable<OrderLine> GetOrderLines()
        {
            return db.OrderLines;
        }

        // GET: api/OrderLines/5
        [ResponseType(typeof(OrderLine))]
        public IHttpActionResult GetOrderLine(int id)
        {
            OrderLine orderLine = db.OrderLines.Find(id);
            if (orderLine == null)
            {
                return NotFound();
            }

            return Ok(orderLine);
        }

        // PUT: api/OrderLines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderLine(int id, OrderLine orderLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderLine.OrderLine_Id)
            {
                return BadRequest();
            }

            db.Entry(orderLine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderLineExists(id))
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

        // POST: api/OrderLines
        [ResponseType(typeof(OrderLine))]
        public IHttpActionResult PostOrderLine(OrderLine orderLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderLines.Add(orderLine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderLine.OrderLine_Id }, orderLine);
        }

        // DELETE: api/OrderLines/5
        [ResponseType(typeof(OrderLine))]
        public IHttpActionResult DeleteOrderLine(int id)
        {
            OrderLine orderLine = db.OrderLines.Find(id);
            if (orderLine == null)
            {
                return NotFound();
            }

            db.OrderLines.Remove(orderLine);
            db.SaveChanges();

            return Ok(orderLine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderLineExists(int id)
        {
            return db.OrderLines.Count(e => e.OrderLine_Id == id) > 0;
        }
    }
}