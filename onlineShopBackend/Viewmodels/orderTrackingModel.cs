using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Viewmodels
{
    public class orderTrackingModel
    {
        public int orderQty_ID { get; set; }
        public int outputQty { get; set; }
        public int sub_item_id { get; set; }
        public string sub_item_name { get; set; }
        public string sub_item_image { get; set; }

        public int main_item_id { get; set; }
        public string main_item_name { get; set; }
        public decimal output_price { get; set; }
        public int orderID { get; set; }
        public statusType status { get; set; }
        public int userID { get; set; }
    }
}