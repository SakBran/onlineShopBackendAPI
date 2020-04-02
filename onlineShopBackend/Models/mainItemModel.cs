using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Models
{
	public class mainItemModel
	{
        [Key]
        public int main_item_id { get; set; }
        public string main_item_name { get; set; }
        public int sub_category_id { get; set; }
        public int price { get; set; }
        public string image_url { get; set; }
        public string brand { get; set; }
        public string Descriptions { get; set; }
    }
}