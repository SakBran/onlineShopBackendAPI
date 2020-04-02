using onlineShopBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace onlineShopBackend.Controllers
{
    public class userAuthenicationController : ApiController
    {
        dataModel db = new dataModel();
        stringChecklist chk = new stringChecklist();
        // GET: api/userModels/5
        [ResponseType(typeof(userModel))]
        public async Task<HttpResponseMessage> GetuserModel(string username,string password)
        {
            HttpResponseMessage response  = Request.CreateResponse(HttpStatusCode.OK, "Success");


            foreach (var i in chk.sqlCheckList)
            {
                if (username.Contains(i)==true || password.Contains(i) == true)
                {
                    response = Request.CreateResponse(HttpStatusCode.Ambiguous, "Please don't enter ambiguous character");
                    return response;
                }
            }
            
            int id = (from x in db.UserModels
                      where (x.UserEmail == username || 
                             x.userName == username || 
                             x.userPhone == username) 
                            select x.userID).FirstOrDefault();
            if (id == 0)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, "Don't have account");
                return response;
            }
            userModel userModel = await db.UserModels.FindAsync(id);
            if (userModel.password != password) {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, "Username  and Password does not match");
                return response;
            }
            if (userModel == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, "Username  and Password does not exist");
                return response;
            }
            response = Request.CreateResponse(HttpStatusCode.OK, userModel);

            return response;
        }
    }


}
