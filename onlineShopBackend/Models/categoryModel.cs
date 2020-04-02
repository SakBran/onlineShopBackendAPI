using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Models
{
    public class categoryModel
    {
        [Key]
        [Display(Name = "cat_id")]
        public int cat_id { get; set; }
        [Display(Name = "Category List")]
        public string  cat_name { get; set; }
    }
}