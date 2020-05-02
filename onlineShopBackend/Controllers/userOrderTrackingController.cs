using onlineShopBackend.Models;
using onlineShopBackend.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace onlineShopBackend.Controllers
{
    public class userOrderTrackingController : ApiController
    {
        private dataModel db = new dataModel();
        // GET: api/OrderModels
        [ResponseType(typeof(orderTrackingModel))]
        public async Task<IEnumerable<orderTrackingModel>> Get(int id)
        {
            string query = $@"Select 
                            a.orderQty_ID,
                            a.outputQty,
                            c.sub_item_id,
                            c.sub_item_name,
                            c.sub_item_image,
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
                            a.userID='{id.ToString()}'
                            and a.orderID not in (Select orderID from deliveryModels)";

            return await db.Database.SqlQuery<orderTrackingModel>(query).ToListAsync();
        }
    }
}
