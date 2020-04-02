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
using onlineShopBackend.Viewmodels;

namespace onlineShopBackend.Controllers
{
    public class userModelsController : ApiController
    {
        private dataModel db = new dataModel();
        private userValidation validate = new userValidation();

        // GET: api/userModels
        public IQueryable<userModel> GetUserModels()
        {
            return db.UserModels;
        }

        // GET: api/userModels/5
        [ResponseType(typeof(userModel))]
        public async Task<IHttpActionResult> GetuserModel(int id)
        {
            userModel userModel = await db.UserModels.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel);
        }

        // PUT: api/userModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutuserModel(int id, userModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userModel.userID)
            {
                return BadRequest();
            }

            if (this.validate.checkValidation(userModel) != "OK") {
                return BadRequest(this.validate.checkValidation(userModel));
            }

            db.Entry(userModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!validate.userModelExists(id))
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

        // POST: api/userModels
        [ResponseType(typeof(userModel))]
        [HttpPost]
        public async Task<IHttpActionResult> PostuserModel(userModel userModel)
        {
            userModel.userType = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (this.validate.checkValidation(userModel) != "OK")
            {
                return BadRequest(this.validate.checkValidation(userModel));
            }
            db.UserModels.Add(userModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userModel.userID }, userModel);
        }

        // DELETE: api/userModels/5
        [ResponseType(typeof(userModel))]
        public async Task<IHttpActionResult> DeleteuserModel(int id)
        {
            userModel userModel = await db.UserModels.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            db.UserModels.Remove(userModel);
            await db.SaveChangesAsync();

            return Ok(userModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        
    }
}