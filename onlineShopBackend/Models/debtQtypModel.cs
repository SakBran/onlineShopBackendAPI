using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Models
{
    public class debtQtypModel
    {
        [Key]
        public int debtQty_ID { get; set; }
        public int outputQty { get; set; }
        public int sub_item_id { get; set; }
        public int main_item_id { get; set; }
        public decimal output_price { get; set; }
        public int orderID { get; set; }
        public DateTime outputDate { get; set; }
        public int userID { get; set; }
    }
}