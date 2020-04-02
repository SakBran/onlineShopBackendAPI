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
using onlineShopBackend.Models;

namespace onlineShopBackend.Controllers
{
    public class priceModelsController : ApiController
    {
        private dataModel db = new dataModel();

        // GET: api/priceModels
        public IQueryable<priceModel> GetPriceModels()
        {
            return db.PriceModels;
        }

        // GET: api/priceModels/5
        [ResponseType(typeof(priceModel))]
        public async Task<IHttpActionResult> GetpriceModel(int id)
        {
            var priceModel = await (from x in db.PriceModels where x.main_item_id==id select x).ToListAsync();
            if (priceModel == null)
            {
                return NotFound();
            }

            return Ok(priceModel);
        }

        // PUT: api/priceModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutpriceModel(int id, priceModel priceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != priceModel.priceID)
            {
                return BadRequest();
            }

            db.Entry(priceModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!priceModelExists(id))
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

        // POST: api/priceModels
        [ResponseType(typeof(priceModel))]
        public async Task<IHttpActionResult> PostpriceModel(priceModel priceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PriceModels.Add(priceModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = priceModel.priceID }, priceModel);
        }

        // DELETE: api/priceModels/5
        [ResponseType(typeof(priceModel))]
        public async Task<IHttpActionResult> DeletepriceModel(int id)
        {
            priceModel priceModel = await db.PriceModels.FindAsync(id);
            if (priceModel == null)
            {
                return NotFound();
            }

            db.PriceModels.Remove(priceModel);
            await db.SaveChangesAsync();

            return Ok(priceModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool priceModelExists(int id)
        {
            return db.PriceModels.Count(e => e.priceID == id) > 0;
        }
    }
}