using onlineShopBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace onlineShopBackend.Controllers
{
    public class generalSearchController : ApiController
    {
        // GET: api/generalSearch
        private dataModel db = new dataModel();

        // GET: api/generalSearch/5
        public async Task<IHttpActionResult> Get(string item)
        {
            var query = $@"Select TOP 30 b.main_item_id
                      ,b.main_item_name
                      ,b.sub_category_id
                      ,b.price
                      ,b.image_url
                      ,b.brand
                      ,b.Descriptions from
            mainItemModels as b 
            Left Join  subCategoryModels as c 
            on c.sub_cat_id=b.sub_category_id 
            Left Join categoryModels as d on d.cat_id=c.cat_id 
Where main_item_name like '%{item}' or main_item_name like '%{item}%' or main_item_name like '{item}%' or
sub_cat_name like '%{item}' or sub_cat_name like '%{item}%' or sub_cat_name like '{item}%' or
Descriptions like '%{item}' or Descriptions like '%{item}%' or Descriptions like '{item}%' or
brand like '%{item}' or brand like '%{item}%' or brand like '{item}%'";
            List<mainItemModel> mainItemModel = await db.Database.SqlQuery<mainItemModel>(query).ToListAsync();
            if (mainItemModel == null)
            {
                return NotFound();
            }

            return Ok(mainItemModel);
        }

        // POST: api/generalSearch
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/generalSearch/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/generalSearch/5
        public void Delete(int id)
        {
        }
    }
}
