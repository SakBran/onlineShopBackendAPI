using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Models
{
    public class orderQtyModel
    {
        [Key]
        public int orderQty_ID { get; set; }
        public int outputQty { get; set; }
        public int sub_item_id { get; set; }
        public int main_item_id { get; set; }
        public decimal output_price { get; set; }
        public int orderID { get; set; }
        public statusType status { get; set; }
        public int userID { get; set; }
    }
}

public enum statusType {
Pending,
Reject,
Approve
}
//Status
//Reject
//Pending
//Complete