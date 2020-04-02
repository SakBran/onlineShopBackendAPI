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
    public class categorySettingImagesController : Controller
    {
        private dataModel db = new dataModel();

      
        // GET: categorySettingImages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoryImage categoryImage = await (from x in db.CategoryImages where x.cat_id==id select x).FirstOrDefaultAsync<categoryImage>();

         
            ;
            if (categoryImage == null)
            {
                return HttpNotFound();
            }
            return View(categoryImage);
        }

        // POST: categorySettingImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "catImageID,catImageName,cat_id")] categoryImage categoryImage, HttpPostedFileBase catImageName)
        {
           

                uploadController uplCtrl = new uploadController();
                var postedFile = catImageName;
                if (postedFile != null && postedFile.ContentLength > 0)
                {

                    int MaxContentLength = 1024 * 1024 * 10; //Size = 1 MB  

                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png", ".jpeg", ".svg" };
                    var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (!AllowedFileExtensions.Contains(extension))
                    {

                        var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                    return HttpNotFound();
                }
                    else if (postedFile.ContentLength > MaxContentLength)
                    {

                        var message = string.Format("Please Upload a file upto 1 mb.");

                    return HttpNotFound();
                }
                    else
                    {

                        var filePath = Server.MapPath("~/images/" + catImageName.FileName.ToString());

                        postedFile.SaveAs(filePath);

                    }
                }

                var message1 = string.Format("Image Updated Successfully.");
                categoryImage.catImageName = catImageName.FileName;
                    db.Entry(categoryImage).State = EntityState.Modified;
                    await db.SaveChangesAsync();
               
            return View(categoryImage);
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
