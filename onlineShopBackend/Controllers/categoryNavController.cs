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
    public class categoryNavController : ApiController
    {
        // GET: api/categoryNav
        private dataModel db = new dataModel();
        public async Task<IEnumerable<categoryNavVM>> Get()
        {
            string query = @"Select categoryModels.cat_id as 'cat_id',
                            cat_name,catImageName from categoryModels
                            Inner join categoryImages 
                            on categoryImages.cat_id=categoryModels.cat_id";
            var res =await db.Database.SqlQuery<Viewmodels.categoryNavVM>(query).ToListAsync();
            return res;
        }

    }
}
