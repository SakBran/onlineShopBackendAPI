using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Models
{
    public class priceModel
    {
        [Key]
        public int priceID { get; set; }
        public int main_item_id { get; set; }
        public float price { get; set; }
        public int qty { get; set; }
        public string unitName { get; set; }

    }
}