using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineShopBackend.Models
{
    public class deliveryModel
    {
        [Key]
        public int deliveryID { get; set; }
        public int orderID { get; set; }
        public statusType status { get; set; }
        public string deliveryMan { get; set; }
        public string deliveryMan_phone { get; set; }


    }
}
//Status
//Reject
//Pending
//Complete