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
    public class OrderModelsController : ApiController
    {
        private dataModel db = new dataModel();

        // GET: api/OrderModels
        public IEnumerable<OrderModel> GetOrderModels()
        {
            string query = @"Select * from OrderModels
                            where orderID in(
                            Select distinct(orderID) 
                            from orderQtyModels
                            where status=0
                            )";
           
            var res = db.Database.SqlQuery<OrderModel>(query).ToList<OrderModel>();
            return res;
        }

        // GET: api/OrderModels/5
        [ResponseType(typeof(OrderModel))]
        public async Task<IHttpActionResult> GetOrderModel(int id)
        {
            OrderModel orderModel = await db.OrderModels.FindAsync(id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return Ok(orderModel);
        }

        // PUT: api/OrderModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrderModel(int id, OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderModel.orderID)
            {
                return BadRequest();
            }

            db.Entry(orderModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderModelExists(id))
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

        // POST: api/OrderModels
        [ResponseType(typeof(Int32))]
        public async Task<Int32> PostOrderModel(OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            db.OrderModels.Add(orderModel);
            await db.SaveChangesAsync();

            return orderModel.orderID;
        }

        // DELETE: api/OrderModels/5
        [ResponseType(typeof(OrderModel))]
        public async Task<IHttpActionResult> DeleteOrderModel(int id)
        {
            OrderModel orderModel = await db.OrderModels.FindAsync(id);
            if (orderModel == null)
            {
                return NotFound();
            }

            db.OrderModels.Remove(orderModel);
            await db.SaveChangesAsync();

            return Ok(orderModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderModelExists(int id)
        {
            return db.OrderModels.Count(e => e.orderID == id) > 0;
        }
    }
}