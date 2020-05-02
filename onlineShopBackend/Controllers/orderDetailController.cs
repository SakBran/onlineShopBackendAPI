using System;
using System.Collections.Generic;
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
    public class orderDetailController : ApiController
    {
        private dataModel db = new dataModel();

        // GET: api/OrderModels
        [ResponseType(typeof(orderDetialModel))]
        public async Task<IEnumerable<orderDetialModel>> Get(int id)
        {
            string query = $@"Select 
                            a.orderQty_ID,
                            a.outputQty,
                            c.sub_item_id,
                            c.sub_item_name,
                            b.main_item_id,
                            b.main_item_name,
                            a.output_price,
                            a.orderID,
                            a.status,
                            a.userID
                            from orderQtyModels as a
                            Left join mainItemModels as b on b.main_item_id=a.main_item_id
                            Left Join subItemModels as c on c.sub_item_id=a.sub_item_id
                            Where
                            orderID='{id.ToString()}'";
           
            return await db.Database.SqlQuery<orderDetialModel>(query).ToListAsync();
        }

     

        // PUT: api/OrderModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(int id,orderQtyModel[] orderQtyModels)
        {
            var statusTemp = statusType.Pending;
            statusTemp = (from x in orderQtyModels select x.status).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            List<orderQtyModel> orderDetialModel =await (from x in db.OrderQtyModels where x.orderID == id select x).ToListAsync<orderQtyModel>();
            orderDetialModel.ForEach(a => 
            {
                a.status = statusTemp;
                db.Entry(a).State = EntityState.Modified;
            });
          

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
        private bool OrderModelExists(int id)
        {
            return db.OrderQtyModels.Count(e => e.orderID == id) > 0;
        }
    }
}
