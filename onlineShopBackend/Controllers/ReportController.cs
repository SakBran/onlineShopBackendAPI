using onlineShopBackend.Models;
using onlineShopBackend.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace onlineShopBackend.Controllers
{
    public class ReportController : ApiController
    {
        private dataModel db = new dataModel();
        // GET: api/outputQtyModels


        [Route("~/api/Report/Report1")]
        public IEnumerable<qtyBalanceReportModel> GetReport1(int qtyLevel)
        {
            List<qtyBalanceReportModel> resList = new List<qtyBalanceReportModel>();
            string query = "Select sub_item_id,main_item_name,sub_item_name,total as 'balance' from [dbo].[balance] ";
            if (qtyLevel > 0)
            {
                query = query + $" where total<'{qtyLevel}'";
            }
            resList = db.Database.SqlQuery<qtyBalanceReportModel>(query).
                ToList<qtyBalanceReportModel>();


            return resList;
        }

        [Route("~/api/Report/Report2")]
        public IEnumerable<qtyBalanceReportModel> GetOutputQtyModels(int qtyLevel)
        {
            List<qtyBalanceReportModel> resList = new List<qtyBalanceReportModel>();
            string query = "Select sub_item_id,main_item_name,sub_item_name,total as 'balance' from [dbo].[balance] ";
            if (qtyLevel > 0)
            {
                 query = query+$" where total<'{qtyLevel}'";
            }
            resList = db.Database.SqlQuery<qtyBalanceReportModel>(query).
                ToList<qtyBalanceReportModel>();
            
            
            return resList;
        }
    }
}
