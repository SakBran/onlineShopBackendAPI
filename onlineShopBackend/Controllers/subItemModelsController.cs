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
    public class subItemModelsController : ApiController
    {
        private dataModel db = new dataModel();

        // GET: api/subItemModels
        public async Task<IEnumerable<subItemModel>> GetsubItemModel()
        {
            var res = await (from x in db.SubItemModels select x).ToListAsync<subItemModel>();
            return res;
        }

        // GET: api/subItemModels/5
        [ResponseType(typeof(subItemModel))]
        public async Task<IEnumerable<subItemModel>> GetsubItemModel(int id)
        {
            var subItemModel =await (from x in db.SubItemModels where x.main_item_id==id select x).ToListAsync();
            if (subItemModel == null)
            {
                List<subItemModel> x = new List<subItemModel>();
                return x;
            }

            return subItemModel;
        }

        // PUT: api/subItemModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutsubItemModel(int id, subItemModel subItemModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subItemModel.sub_item_id)
            {
                return BadRequest();
            }

            db.Entry(subItemModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!subItemModelExists(id))
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

        // POST: api/subItemModels
        [ResponseType(typeof(subItemModel))]
        public async Task<IHttpActionResult> PostsubItemModel(subItemModel subItemModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubItemModels.Add(subItemModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subItemModel.sub_item_id }, subItemModel);
        }

        // DELETE: api/subItemModels/5
        [ResponseType(typeof(subItemModel))]
        public async Task<IHttpActionResult> DeletesubItemModel(int main,string sub,string img)
        {
            var Qry = @"Select * from subItemModels
                        where main_item_id = '"+ main
                        +"' and sub_item_name = '"+ sub
                        +"'and sub_item_image = '"+img+"'";
            subItemModel subItemModel = await db.SubItemModels.SqlQuery(Qry).FirstOrDefaultAsync();
             
            if (subItemModel == null)
            {
                return NotFound();
            }

            db.SubItemModels.Remove(subItemModel);
            await db.SaveChangesAsync();
            return Ok(subItemModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool subItemModelExists(int id)
        {
            return db.SubItemModels.Count(e => e.sub_item_id == id) > 0;
        }
    }
}