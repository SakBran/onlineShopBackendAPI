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
    public class categoryImagesController : ApiController
    {
        private dataModel db = new dataModel();

        // GET: api/categoryImages
        public IQueryable<categoryImage> GetCategoryImages()
        {
            return db.CategoryImages;
        }

        // GET: api/categoryImages/5
        [ResponseType(typeof(categoryImage))]
        public async Task<IHttpActionResult> GetcategoryImage(int id)
        {
            categoryImage categoryImage = await db.CategoryImages.FindAsync(id);
            if (categoryImage == null)
            {
                return NotFound();
            }

            return Ok(categoryImage);
        }

        // PUT: api/categoryImages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutcategoryImage(int id, categoryImage categoryImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryImage.catImageID)
            {
                return BadRequest();
            }

            db.Entry(categoryImage).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoryImageExists(id))
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

        // POST: api/categoryImages
        [ResponseType(typeof(categoryImage))]
        public async Task<IHttpActionResult> PostcategoryImage(categoryImage categoryImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoryImages.Add(categoryImage);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categoryImage.catImageID }, categoryImage);
        }

        // DELETE: api/categoryImages/5
        [ResponseType(typeof(categoryImage))]
        public async Task<IHttpActionResult> DeletecategoryImage(int id)
        {
            categoryImage categoryImage = await db.CategoryImages.FindAsync(id);
            if (categoryImage == null)
            {
                return NotFound();
            }

            db.CategoryImages.Remove(categoryImage);
            await db.SaveChangesAsync();

            return Ok(categoryImage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool categoryImageExists(int id)
        {
            return db.CategoryImages.Count(e => e.catImageID == id) > 0;
        }
    }
}