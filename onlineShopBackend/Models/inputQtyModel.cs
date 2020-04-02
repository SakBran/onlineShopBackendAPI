using System;
using System.ComponentModel.DataAnnotations;

namespace onlineShopBackend.Models
{
    public class inputQtyModel
    {
        [Key]
        public int inputQty_ID { get; set; }
        public int inputQty { get; set; }
        public int sub_item_id { get; set; }
        public int main_item_id { get; set; }
        public decimal input_price { get; set; }
        public DateTime inputDate { get; set; }
        public int userID { get; set; }
    }
}