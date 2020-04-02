using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Models
{
    public class categoryImage
    {
        [Key]
        public int catImageID { get; set; }

        [Display(Name ="Category Image")]
        public string catImageName { get; set; }
        public int cat_id { get; set; }
   
    }
}