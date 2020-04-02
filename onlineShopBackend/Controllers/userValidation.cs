using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using onlineShopBackend.Models;
using onlineShopBackend.Viewmodels;

namespace onlineShopBackend.Controllers
{
    public class userValidation
    {
        private dataModel db = new dataModel();

        public bool userModelExists(int id)
        {
            return db.UserModels.Count(e => e.userID == id) > 0;
        }


        public string checkValidation(userModel user)
        {
            string res = "OK";

            checkDuplicateUser x = this.checkExistedUser(user);
            if (x.email != true || x.username != true || x.phone != true)
            {
                res = "";
            }
            if (x.username != true)
            {
                res = res + "Username already existed</br>";
            }
            if (x.email != true)
            {
                res = res + "Email already existed</br>";
            }
            if (x.phone != true)
            {
                res = res + "Phone number already existed</br>";
            }
            return res;

        }
        private checkDuplicateUser checkExistedUser(userModel user)
        {
            checkDuplicateUser res = new checkDuplicateUser();
            res.username = true;
            res.email = true;
            res.phone = true;
            var temp = (from x in db.UserModels
                        where
               (x.userName == user.userName
            || x.userPhone == user.userPhone
            || x.UserEmail == user.UserEmail)
            && (x.userID != user.userID)
                        select x).ToList<userModel>();
            foreach (var i in temp)
            {
                if (i.UserEmail ==user.UserEmail )
                {
                    res.email = false;
                }
                if (i.userName ==user.userName)
                {
                    res.username = false;
                }
                if (i.userPhone ==user.userPhone )
                {
                    res.phone = false;
                }
            }
            return res;

        }

    }
}