using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Models
{
    public class subItemModel
    {
        [Key]
        public int sub_item_id { get; set; }
        public string sub_item_name { get; set; }
        public string sub_item_image { get; set; }
        public int main_item_id { get; set; }
    }
}