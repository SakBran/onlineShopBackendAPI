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

namespace onlineShopBackend.Controllers
{
    public class subCategorySettingModelsController : Controller
    {
        private dataModel db = new dataModel();

        private List<categoryModel> catList = new List<categoryModel>();
        public subCategorySettingModelsController()
        {
            catList = (from x in db.CategoryModels select x).ToList<categoryModel>();
        }

        // GET: subCategorySettingModels
        public async Task<ActionResult> Index()
        {
            ViewBag.catList = this.catList;
            return View(await db.SubCategoryModels.ToListAsync());
        }

        // GET: subCategorySettingModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subCategoryModel subCategoryModel = await db.SubCategoryModels.FindAsync(id);
            ViewBag.catList = this.catList;
            if (subCategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryModel);
        }

        // GET: subCategorySettingModels/Create
        public ActionResult Create()
        {
            ViewBag.catList = this.catList;
            return View();
        }

        // POST: subCategorySettingModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "sub_cat_id,sub_cat_name,cat_id")] subCategoryModel subCategoryModel)
        {
          
            if (ModelState.IsValid)
            {
                db.SubCategoryModels.Add(subCategoryModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(subCategoryModel);
        }

        // GET: subCategorySettingModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.catList = this.catList;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subCategoryModel subCategoryModel = await db.SubCategoryModels.FindAsync(id);
            if (subCategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryModel);
        }

        // POST: subCategorySettingModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "sub_cat_id,sub_cat_name,cat_id")] subCategoryModel subCategoryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategoryModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(subCategoryModel);
        }

        // GET: subCategorySettingModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            ViewBag.catList = this.catList;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subCategoryModel subCategoryModel = await db.SubCategoryModels.FindAsync(id);
            if (subCategoryModel == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryModel);
        }

        // POST: subCategorySettingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            subCategoryModel subCategoryModel = await db.SubCategoryModels.FindAsync(id);
            db.SubCategoryModels.Remove(subCategoryModel);
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
