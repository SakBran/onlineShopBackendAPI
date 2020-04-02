using System;
using System.ComponentModel.DataAnnotations;


namespace onlineShopBackend.Models
{
    public class outputQtyModel
    {
        [Key]
        public int outputQty_ID { get; set; }
        public int outputQty { get; set; }
        public int sub_item_id { get; set; }
        public int main_item_id { get; set; }
        public decimal output_price { get; set; }
        public DateTime outputDate { get; set; }
        public int userID { get; set; }
    }
}