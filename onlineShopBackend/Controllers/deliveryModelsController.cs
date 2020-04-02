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
    public class deliveryModelsController : ApiController
    {
        private dataModel db = new dataModel();

        // GET: api/deliveryModels
        public IEnumerable<OrderModel> GetDeliveryModels()
        {
            string query = @"Select * from OrderModels
                            where orderID in(
                            Select distinct(orderID) 
                            from orderQtyModels
                            where status=1
                            ) and 
                            orderID not in(
                            Select distinct(orderID) 
                            from deliveryModels
                            )
                            ";

            var res = db.Database.SqlQuery<OrderModel>(query).ToList<OrderModel>();
            return res;
        }

        // GET: api/deliveryModels/5
        [ResponseType(typeof(deliveryModel))]
        public async Task<IHttpActionResult> GetdeliveryModel(int id)
        {
            deliveryModel deliveryModel = await db.DeliveryModels.FindAsync(id);
            if (deliveryModel == null)
            {
                return NotFound();
            }

            return Ok(deliveryModel);
        }

        // PUT: api/deliveryModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutdeliveryModel(int id, deliveryModel deliveryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliveryModel.deliveryID)
            {
                return BadRequest();
            }

            db.Entry(deliveryModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!deliveryModelExists(id))
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

        // POST: api/deliveryModels
        [ResponseType(typeof(deliveryModel))]
        public async Task<IHttpActionResult> PostdeliveryModel( int id,int userid,statusType status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            OrderModel OrderModel = (from x in db.OrderModels where 
                                     x.orderID == id select x).FirstOrDefault();
            deliveryModel deliveryModel = new deliveryModel();
            deliveryModel.orderID = OrderModel.orderID;
            deliveryModel.deliveryMan = userid.ToString();
            deliveryModel.status = status;
            deliveryModel.deliveryMan_phone = (from x in db.UserModels where
                                               x.userID == userid select x.userPhone)
                                               .FirstOrDefault();
           


            db.DeliveryModels.Add(deliveryModel);
            
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = deliveryModel.deliveryID }, deliveryModel);
        }

        // DELETE: api/deliveryModels/5
        [ResponseType(typeof(deliveryModel))]
        public async Task<IHttpActionResult> DeletedeliveryModel(int id)
        {
            deliveryModel deliveryModel = await db.DeliveryModels.FindAsync(id);
            if (deliveryModel == null)
            {
                return NotFound();
            }

            db.DeliveryModels.Remove(deliveryModel);
            await db.SaveChangesAsync();

            return Ok(deliveryModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool deliveryModelExists(int id)
        {
            return db.DeliveryModels.Count(e => e.deliveryID == id) > 0;
        }
    }
}