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
    public class qtyBalanceController : ApiController
    {
        private dataModel db = new dataModel();
        private balanceCount balanceCount=new balanceCount();

        // GET: api/qtyBalance/5
        [ResponseType(typeof(int))]
        public  IHttpActionResult GetinputQtyModel(int id)
        {
            return Ok(balanceCount.BalanceCount(id));
        }


      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool inputQtyModelExists(int id)
        {
            return db.InputQtyModels.Count(e => e.inputQty_ID == id) > 0;
        }
    }
}