using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Models
{
    public class subCategoryModel
    {
        [Key]
        public int sub_cat_id { get; set; }
        [Display(Name ="Sub Category Name")]
        public string sub_cat_name { get; set; }

        [Display(Name = "Category Name")]
        public int cat_id { get; set; }
    }
}