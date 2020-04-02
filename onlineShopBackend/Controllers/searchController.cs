using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using onlineShopBackend.Models;
using onlineShopBackend.Viewmodels;

namespace onlineShopBackend.Controllers
{
    public class searchController : ApiController
    {
        private dataModel db = new dataModel();
        // GET: api/search
        public async Task<IEnumerable<searchVM>> Get()
        {
            List<searchVM> res = new List<searchVM>();
            var query = $@"Select b.main_item_id,main_item_name,'' as sub_item_name,
                        cat_name,sub_cat_name from mainItemModels as b 
                        Left Join  subCategoryModels as c on c.sub_cat_id=b.sub_category_id 
                        Left Join categoryModels as d on d.cat_id=c.cat_id 
                        ";
            res = await(db.Database.SqlQuery<searchVM>(query).ToListAsync());
            return res;
        }

        // GET: api/search/5
        public async Task<IHttpActionResult> Get(string id)
        {
            List<searchVM> res = new List<searchVM>();
            var query=$@"Select b.main_item_id,main_item_name,sub_item_name,cat_name,sub_cat_name 
                        from subItemModels as a 
                        Inner join mainItemModels as b on b.main_item_id=a.main_item_id 
                        Left Join  subCategoryModels as c on c.sub_cat_id=b.sub_category_id 
                        Left Join categoryModels as d on d.cat_id=c.cat_id 
                        where cat_name like '{id}%' or cat_name like '%{id}' or 
                        cat_name like '%{id}%' or sub_cat_name like '{id}%' or 
                        sub_cat_name like '%{id}' or sub_cat_name like '%{id}%' 
                        or main_item_name like '{id}%' or main_item_name like '%{id}'
                        or main_item_name like '%{id}%' 
                        Group by b.main_item_id,main_item_name,a.sub_item_id,sub_item_name, cat_name,sub_cat_name";
            res = await (db.Database.SqlQuery<searchVM>(query).ToListAsync());

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        // POST: api/search
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/search/5
        public void Delete(int id)
        {
        }
    }
}
