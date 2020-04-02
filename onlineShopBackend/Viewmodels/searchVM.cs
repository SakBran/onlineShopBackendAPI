using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Viewmodels
{
    public class searchVM
    {
        public int main_item_id { get; set; }

        public string main_item_name { get; set; }
        public string sub_item_name { get; set; }
        public string cat_name { get; set; }
        public string sub_cat_name { get; set; }

        public static implicit operator List<object>(searchVM v)
        {
            throw new NotImplementedException();
        }
    }
}