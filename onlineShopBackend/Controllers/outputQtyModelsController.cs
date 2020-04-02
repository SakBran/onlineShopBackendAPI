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
    public class outputQtyModelsController : ApiController
    {
        private dataModel db = new dataModel();
        // GET: api/outputQtyModels
        public IQueryable<outputQtyModel> GetOutputQtyModels()
        {
            return db.OutputQtyModels;
        }
        // GET: api/outputQtyModels/5
        [ResponseType(typeof(outputQtyModel))]
        public async Task<IHttpActionResult> GetoutputQtyModel(int id)
        {
            outputQtyModel outputQtyModel = await db.OutputQtyModels.FindAsync(id);
            if (outputQtyModel == null)
            {
                return NotFound();
            }

            return Ok(outputQtyModel);
        }

        // PUT: api/outputQtyModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutoutputQtyModel(int id, outputQtyModel outputQtyModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != outputQtyModel.outputQty_ID)
            {
                return BadRequest();
            }

            db.Entry(outputQtyModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!outputQtyModelExists(id))
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

        // POST: api/outputQtyModels
        [ResponseType(typeof(outputQtyModel))]
        public async Task<IHttpActionResult> PostoutputQtyModel(List<outputQtyModel> outputQtyModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OutputQtyModels.AddRange(outputQtyModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = outputQtyModel }, outputQtyModel);
        }

        // DELETE: api/outputQtyModels/5
        [ResponseType(typeof(outputQtyModel))]
        public async Task<IHttpActionResult> DeleteoutputQtyModel(int id)
        {
            outputQtyModel outputQtyModel = await db.OutputQtyModels.FindAsync(id);
            if (outputQtyModel == null)
            {
                return NotFound();
            }

            db.OutputQtyModels.Remove(outputQtyModel);
            await db.SaveChangesAsync();

            return Ok(outputQtyModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool outputQtyModelExists(int id)
        {
            return db.OutputQtyModels.Count(e => e.outputQty_ID == id) > 0;
        }
    }
}