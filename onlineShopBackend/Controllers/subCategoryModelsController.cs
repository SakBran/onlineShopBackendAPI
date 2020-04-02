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
    public class subCategoryModelsController : ApiController
    {
        private dataModel db = new dataModel();

        // GET: api/subCategoryModels
        public IQueryable<subCategoryModel> GetSubCategoryModels()
        {
            return db.SubCategoryModels;
        }

        // GET: api/subCategoryModels/5
        [ResponseType(typeof(subCategoryModel))]
        public async Task<IHttpActionResult> GetsubCategoryModel(int id)
        {
            subCategoryModel subCategoryModel = await db.SubCategoryModels.FindAsync(id);
            if (subCategoryModel == null)
            {
                return NotFound();
            }

            return Ok(subCategoryModel);
        }

        // PUT: api/subCategoryModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutsubCategoryModel(int id, subCategoryModel subCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subCategoryModel.sub_cat_id)
            {
                return BadRequest();
            }

            db.Entry(subCategoryModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!subCategoryModelExists(id))
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

        // POST: api/subCategoryModels
        [ResponseType(typeof(subCategoryModel))]
        public async Task<IHttpActionResult> PostsubCategoryModel(subCategoryModel subCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubCategoryModels.Add(subCategoryModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subCategoryModel.sub_cat_id }, subCategoryModel);
        }

        // DELETE: api/subCategoryModels/5
        [ResponseType(typeof(subCategoryModel))]
        public async Task<IHttpActionResult> DeletesubCategoryModel(int id)
        {
            subCategoryModel subCategoryModel = await db.SubCategoryModels.FindAsync(id);
            if (subCategoryModel == null)
            {
                return NotFound();
            }

            db.SubCategoryModels.Remove(subCategoryModel);
            await db.SaveChangesAsync();

            return Ok(subCategoryModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool subCategoryModelExists(int id)
        {
            return db.SubCategoryModels.Count(e => e.sub_cat_id == id) > 0;
        }
    }
}