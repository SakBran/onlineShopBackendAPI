using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Viewmodels
{
    public class qtyBalanceReportModel
    {
        public int  sub_item_id { get; set; }
        public string main_item_name { get; set; }
        public string sub_item_name { get; set; }
        public int balance { get; set; }
    }
}