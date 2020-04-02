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
    public class inputQtyModelsController : ApiController
    {
        private dataModel db = new dataModel();

        // GET: api/inputQtyModels
        public IQueryable<inputQtyModel> GetInputQtyModels()
        {
            return db.InputQtyModels;
        }

        // GET: api/inputQtyModels/5
        [ResponseType(typeof(inputQtyModel))]
        public async Task<IHttpActionResult> GetinputQtyModel(int id)
        {
            inputQtyModel inputQtyModel = await db.InputQtyModels.FindAsync(id);
            if (inputQtyModel == null)
            {
                return NotFound();
            }

            return Ok(inputQtyModel);
        }

        // PUT: api/inputQtyModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutinputQtyModel(int id, inputQtyModel inputQtyModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inputQtyModel.inputQty_ID)
            {
                return BadRequest();
            }

            db.Entry(inputQtyModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!inputQtyModelExists(id))
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

        // POST: api/inputQtyModels
        [ResponseType(typeof(inputQtyModel))]
        public async Task<IHttpActionResult> PostinputQtyModel(inputQtyModel inputQtyModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InputQtyModels.Add(inputQtyModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = inputQtyModel.inputQty_ID }, inputQtyModel);
        }

        // DELETE: api/inputQtyModels/5
        [ResponseType(typeof(inputQtyModel))]
        public async Task<IHttpActionResult> DeleteinputQtyModel(int id)
        {
            inputQtyModel inputQtyModel = await db.InputQtyModels.FindAsync(id);
            if (inputQtyModel == null)
            {
                return NotFound();
            }

            db.InputQtyModels.Remove(inputQtyModel);
            await db.SaveChangesAsync();

            return Ok(inputQtyModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool inputQtyModelExists(int id)
        {
            return db.InputQtyModels.Count(e => e.inputQty_ID == id) > 0;
        }
    }
}