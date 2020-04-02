using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Models
{
    public class OrderModel
    {
        [Key]
        public int orderID { get; set; }
        public int clientID { get; set; }
        public DateTime orderDate { get; set; }
        public int userID { get; set; }
    }
}