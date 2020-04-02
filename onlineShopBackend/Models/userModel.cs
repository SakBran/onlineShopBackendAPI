using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Models
{
    public class userModel
    {
        [Key]
        public int userID { get; set; }
        [Display(Name ="Name")]
        [Required]
        public string userName { get; set; }
        public string password { get; set; }
        [Display(Name = "Permission Level")]
        [Required]
        public UserType userType { get; set; }

        [Display(Name = "Phone")]
        [Required]
        public string userPhone { get; set; }
        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        [Display(Name = "Address")]
        public string userAddress { get; set; }

    }
}

public enum UserType {
    User,Employee,Admin
}

