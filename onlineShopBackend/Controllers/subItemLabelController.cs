using onlineShopBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using onlineShopBackend.Viewmodels;
using System.Threading.Tasks;
using System.Data.Entity;

namespace onlineShopBackend.Controllers
{
    public class subItemLabelController : ApiController
    {
        private dataModel db = new dataModel();
        private balanceCount bc = new balanceCount();
        // GET: api/subItemLabel
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/subItemLabel/5
        public async Task<IEnumerable<subItemLabelModel>> Get(int id)
        {
            List<subItemLabelModel> res =new List<subItemLabelModel>();
            List<subItemModel> tempList=await (from x in db.SubItemModels where x.main_item_id == id select x).ToListAsync();
            tempList.ForEach( x =>  res.Add(objAdd(x)));
            return res;
        }


        public subItemLabelModel objAdd(subItemModel x) {
            subItemLabelModel y = new subItemLabelModel();
            y.subItemImage = x.sub_item_image;
            y.subItemName = x.sub_item_name;
            var qty = bc.BalanceCount(x.sub_item_id);
            y.quantity = qty.ToString();
            return y;
        }
        // POST: api/subItemLabel
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/subItemLabel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/subItemLabel/5
        public void Delete(int id)
        {
        }
    }
}
