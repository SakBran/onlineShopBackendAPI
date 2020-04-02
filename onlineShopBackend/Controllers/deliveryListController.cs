using onlineShopBackend.Models;
using onlineShopBackend.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace onlineShopBackend.Controllers
{
    public class deliveryListController : ApiController
    {
        private dataModel db = new dataModel();
        // GET: api/deliveryList
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
                            Where a.status=1 and
                            orderID='{id.ToString()}'";

            return await db.Database.SqlQuery<orderDetialModel>(query).ToListAsync();
        }

        // GET: api/deliveryList/5

        // POST: api/deliveryList
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/deliveryList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/deliveryList/5
        public void Delete(int id)
        {
        }
    }
}
