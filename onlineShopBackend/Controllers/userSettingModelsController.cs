using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using onlineShopBackend.Models;
using onlineShopBackend.Controllers;

namespace onlineShopBackend.Controllers
{
    public class userSettingModelsController : Controller
    {
        private dataModel db = new dataModel();
        private userValidation validate = new userValidation();

        // GET: userSettingModels
        public async Task<ActionResult> Index()
        {
            return View(await db.UserModels.ToListAsync());
        }

        // GET: userSettingModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userModel userModel = await db.UserModels.FindAsync(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        // GET: userSettingModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userSettingModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "userID,userName,password,userType,userPhone,UserEmail,userAddress")] userModel userModel)
        {
           
            if (validate.checkValidation(userModel) != "OK")
            {
                return Content(validate.checkValidation(userModel));
            }
            if (ModelState.IsValid)
            {
                db.UserModels.Add(userModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(userModel);
        }

        // GET: userSettingModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            userModel userModel = await db.UserModels.FindAsync(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(userModel);
        }

        // POST: userSettingModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "userID,userName,password,userType,userPhone,UserEmail,userAddress")] userModel userModel)
        {
          
            if (validate.checkValidation(userModel) != "OK")
            {
                return Content(validate.checkValidation(userModel));
            }
            if (ModelState.IsValid)
            {
                db.Entry(userModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userModel);
        }

        // GET: userSettingModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userModel userModel = await db.UserModels.FindAsync(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        // POST: userSettingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            userModel userModel = await db.UserModels.FindAsync(id);
            db.UserModels.Remove(userModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
