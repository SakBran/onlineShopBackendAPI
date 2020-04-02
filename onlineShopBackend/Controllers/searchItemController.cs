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
    public class searchItemController : ApiController
    {
        private dataModel db = new dataModel();
      
        [ResponseType(typeof(mainItemModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
        List<mainItemModel> mainItemModel = await (from x in db.MainItemModels
                                                   where x.sub_category_id == id select x).Take(6).ToListAsync<mainItemModel>();
            if (mainItemModel == null)
            {
                return NotFound();
            }

            return Ok(mainItemModel);
        }

        public async Task<IHttpActionResult> Get(String name) {
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
            Left Join categoryModels as d 
            on d.cat_id=c.cat_id 
            where cat_name like '{name}%' or cat_name like '%{name}' or cat_name like '%{name}%' or sub_cat_name like '{name}%' or sub_cat_name like '%{name}' or sub_cat_name like '%{name}%' or main_item_name like '{name}%' or main_item_name like '%{name}' or main_item_name like '%{name}%'";
            List<mainItemModel> mainItemModel = await db.Database.SqlQuery<mainItemModel>(query).ToListAsync();
            if (mainItemModel == null)      
            {
                return NotFound();
            }

            return Ok(mainItemModel);
        }
        public async Task<IHttpActionResult> Get(int id,int page)
        {
            List<mainItemModel> mainItemModel = null;
            if (id != 0)
            {
               mainItemModel = await (from x in db.MainItemModels
                                                           where
                                                           x.sub_category_id == id
                                      orderby x.main_item_id descending
                                      select x).Skip(6 * page).Take(6).ToListAsync<mainItemModel>();
            }
            else
            {
               mainItemModel = await (from x in db.MainItemModels
                                      orderby x.main_item_id descending
                                      select x).Skip(6 * page).Take(6).ToListAsync<mainItemModel>();
            }
            if (mainItemModel == null)
            {
                return NotFound();
            }

            return Ok(mainItemModel);
        }
    }
}
