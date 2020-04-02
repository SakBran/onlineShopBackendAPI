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
    public class categorySettingModelsController : Controller
    {
        private dataModel db = new dataModel();

        // GET: categorySettingModels
        public async Task<ActionResult> Index()
        {
            return View(await db.CategoryModels.ToListAsync());
        }

        // GET: categorySettingModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoryModel categoryModel = await db.CategoryModels.FindAsync(id);
            if (categoryModel == null)
            {
                return HttpNotFound();
            }
            return View(categoryModel);
        }

        // GET: categorySettingModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: categorySettingModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "cat_id,cat_name")] categoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                db.CategoryModels.Add(categoryModel);
                categoryImage x = new categoryImage();
                x.cat_id = categoryModel.cat_id;
                x.catImageName = categoryModel.cat_name;
                db.CategoryImages.Add(x);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(categoryModel);
        }

        // GET: categorySettingModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoryModel categoryModel = await db.CategoryModels.FindAsync(id);
            if (categoryModel == null)
            {
                return HttpNotFound();
            }
            return View(categoryModel);
        }

        // POST: categorySettingModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "cat_id,cat_name")] categoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoryModel);
        }

        // GET: categorySettingModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoryModel categoryModel = await db.CategoryModels.FindAsync(id);
            if (categoryModel == null)
            {
                return HttpNotFound();
            }
            return View(categoryModel);
        }

        // POST: categorySettingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            categoryModel categoryModel = await db.CategoryModels.FindAsync(id);
            db.CategoryModels.Remove(categoryModel);
            categoryImage x = new categoryImage();
            x.catImageID = (from d in db.CategoryImages where d.cat_id == id select x.catImageID).FirstOrDefault();
            x.cat_id = categoryModel.cat_id;
            x.catImageName = categoryModel.cat_name;
            if (x != null) {
                db.CategoryImages.Remove(x);
            }
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
