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
    public class categoryModelsController : ApiController
    {
        private dataModel db = new dataModel();

        // GET: api/categoryModels
        public IQueryable<categoryModel> GetCategoryModels()
        {
            return db.CategoryModels;
        }

        // GET: api/categoryModels/5
        [ResponseType(typeof(categoryModel))]
        public async Task<IHttpActionResult> GetcategoryModel(int id)
        {
            categoryModel categoryModel = await db.CategoryModels.FindAsync(id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return Ok(categoryModel);
        }

        // PUT: api/categoryModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutcategoryModel(int id, categoryModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryModel.cat_id)
            {
                return BadRequest();
            }

            db.Entry(categoryModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoryModelExists(id))
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

        // POST: api/categoryModels
        [ResponseType(typeof(categoryModel))]
        public async Task<IHttpActionResult> PostcategoryModel(categoryModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoryModels.Add(categoryModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categoryModel.cat_id }, categoryModel);
        }

        // DELETE: api/categoryModels/5
        [ResponseType(typeof(categoryModel))]
        public async Task<IHttpActionResult> DeletecategoryModel(int id)
        {
            categoryModel categoryModel = await db.CategoryModels.FindAsync(id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            db.CategoryModels.Remove(categoryModel);
            await db.SaveChangesAsync();

            return Ok(categoryModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool categoryModelExists(int id)
        {
            return db.CategoryModels.Count(e => e.cat_id == id) > 0;
        }
    }
}