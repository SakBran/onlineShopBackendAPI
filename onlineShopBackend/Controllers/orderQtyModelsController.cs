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
    public class orderQtyModelsController : ApiController
    {
        private dataModel db = new dataModel();

        // GET: api/orderQtyModels
        public IQueryable<orderQtyModel> GetOrderQtyModels()
        {
            var res = (from x in db.OrderQtyModels
                       where x.status == 0
                       select x);
            return res;
        }

        // GET: api/orderQtyModels/5
        [ResponseType(typeof(orderQtyModel))]
        public async Task<IHttpActionResult> GetorderQtyModel(int id)
        {
            orderQtyModel orderQtyModel = await db.OrderQtyModels.FindAsync(id);
            if (orderQtyModel == null)
            {
                return NotFound();
            }

            return Ok(orderQtyModel);
        }

        // PUT: api/orderQtyModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutorderQtyModel(int id, orderQtyModel orderQtyModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderQtyModel.orderQty_ID)
            {
                return BadRequest();
            }

            db.Entry(orderQtyModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!orderQtyModelExists(id))
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

        // POST: api/orderQtyModels
        [ResponseType(typeof(orderQtyModel))]
        public async Task<IHttpActionResult> PostorderQtyModel(List<orderQtyModel> orderQtyModel)
        {
            OrderModelsController ormc = new OrderModelsController();
            OrderModel orderModel = new OrderModel();
            orderModel.userID = (from x in orderQtyModel select x.userID).FirstOrDefault();
            orderModel.orderDate = DateTime.Now;
            orderModel.clientID = orderModel.userID;
            var invoiceID = await ormc.PostOrderModel(orderModel);
            foreach (var x in orderQtyModel)
            {
                x.orderID = invoiceID;
                x.status = 0;
            }
            if (orderQtyModel.Count>0)
            {
                db.OrderQtyModels.AddRange(orderQtyModel);

                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = orderQtyModel }, orderQtyModel);
            }
            else
            {
                return BadRequest(ModelState);
            }
           
           
        }

     

        // DELETE: api/orderQtyModels/5
        [ResponseType(typeof(orderQtyModel))]
        public async Task<IHttpActionResult> DeleteorderQtyModel(int id)
        {
            orderQtyModel orderQtyModel = await db.OrderQtyModels.FindAsync(id);
            if (orderQtyModel == null)
            {
                return NotFound();
            }

            db.OrderQtyModels.Remove(orderQtyModel);
            await db.SaveChangesAsync();

            return Ok(orderQtyModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool orderQtyModelExists(int id)
        {
            return db.OrderQtyModels.Count(e => e.orderQty_ID == id) > 0;
        }
    }
}