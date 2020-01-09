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
using BankApp1.Models;

namespace BankApp1.Controllers
{
    public class ChequeRequests1Controller : ApiController
    {
        private BankAppEntities9 db = new BankAppEntities9();

        // GET: api/ChequeRequests1
        public IQueryable<ChequeRequest> GetChequeRequests()
        {
            return db.ChequeRequests;
        }

        // GET: api/ChequeRequests1/5
        [ResponseType(typeof(ChequeRequest))]
        public async Task<IHttpActionResult> GetChequeRequest(int id)
        {
            ChequeRequest chequeRequest = await db.ChequeRequests.FindAsync(id);
            if (chequeRequest == null)
            {
                return NotFound();
            }

            return Ok(chequeRequest);
        }

        // PUT: api/ChequeRequests1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChequeRequest(int id, ChequeRequest chequeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chequeRequest.ChequeNumber)
            {
                return BadRequest();
            }

            db.Entry(chequeRequest).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChequeRequestExists(id))
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

        // POST: api/ChequeRequests1
        [ResponseType(typeof(ChequeRequest))]
        public async Task<IHttpActionResult> PostChequeRequest(ChequeRequest chequeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChequeRequests.Add(chequeRequest);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChequeRequestExists(chequeRequest.ChequeNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = chequeRequest.ChequeNumber }, chequeRequest);
        }

        // DELETE: api/ChequeRequests1/5
        [ResponseType(typeof(ChequeRequest))]
        public async Task<IHttpActionResult> DeleteChequeRequest(int id)
        {
            ChequeRequest chequeRequest = await db.ChequeRequests.FindAsync(id);
            if (chequeRequest == null)
            {
                return NotFound();
            }

            db.ChequeRequests.Remove(chequeRequest);
            await db.SaveChangesAsync();

            return Ok(chequeRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChequeRequestExists(int id)
        {
            return db.ChequeRequests.Count(e => e.ChequeNumber == id) > 0;
        }
    }
}