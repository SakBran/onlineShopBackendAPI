using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using onlineShopBackend.Models;


namespace onlineShopBackend.Controllers
{
    public class mainItemModelsController : ApiController
    {
        private dataModel db = new dataModel();
        uploadController uploadFunction = new uploadController();
   

        // GET: api/mainItemModels
        public IQueryable<mainItemModel> GetMainItemModels()
        {
            return db.MainItemModels;
        }

       
        // GET: api/mainItemModels/5
        [ResponseType(typeof(mainItemModel))]
        public async Task<IHttpActionResult> GetmainItemModel(int id)
        {
            mainItemModel mainItemModel = await db.MainItemModels.FindAsync(id);
            if (mainItemModel == null)
            {
                return NotFound();
            }

            return Ok(mainItemModel);
        }

        // PUT: api/mainItemModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutmainItemModel(int id, mainItemModel mainItemModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mainItemModel.main_item_id)
            {
                return BadRequest();
            }

            db.Entry(mainItemModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mainItemModelExists(id))
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

        // POST: api/mainItemModels
        [ResponseType(typeof(mainItemModel))]
        public async Task<IHttpActionResult> PostmainItemModel(mainItemModel mainItemModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //filename

            db.MainItemModels.Add(mainItemModel);
            await db.SaveChangesAsync();

         
            return CreatedAtRoute("DefaultApi", new { id = mainItemModel.main_item_id }, mainItemModel);
        }

        // DELETE: api/mainItemModels/5
        [ResponseType(typeof(mainItemModel))]
        public async Task<IHttpActionResult> DeletemainItemModel(int id)
        {
            mainItemModel mainItemModel = await db.MainItemModels.FindAsync(id);
            if (mainItemModel == null)
            {
                return NotFound();
            }
            db.MainItemModels.Remove(mainItemModel);
            await db.SaveChangesAsync();
            return Ok(mainItemModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool mainItemModelExists(int id)
        {
            return db.MainItemModels.Count(e => e.main_item_id == id) > 0;
        }
    }
}