using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admin_Page;

namespace Admin_Page.Controllers
{
    public class StoresController : Controller
    {
        private AEW_DEVEntities db = new AEW_DEVEntities();

        // GET: Stores
        public ActionResult Index()
        {
            var stores = db.Stores.Include(s => s.Brand);
            return View(stores.ToList());
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName");
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,Lat,Lon,isAvailable,Email,Phone,Fax,CreateDate,Type,RoomRentMode,ReportDate,ShortName,GroupId,OpenTime,CloseTime,DefaultAdminPassword,HasProducts,HasNews,HasImageCollections,HasMultipleLanguage,HasWebPages,HasCustomerFeedbacks,BrandId,HasOrder,HasBlogEditCollections,LogoUrl,FbAccessToken,StoreFeatureFilter,RunReport,AttendanceStoreFilter,StoreCode,PosId,StoreConfig,DefaultDashBoard,District,Province,Active,PaymentTypeApply")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", store.BrandId);
            return View(store);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", store.BrandId);
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,Lat,Lon,isAvailable,Email,Phone,Fax,CreateDate,Type,RoomRentMode,ReportDate,ShortName,GroupId,OpenTime,CloseTime,DefaultAdminPassword,HasProducts,HasNews,HasImageCollections,HasMultipleLanguage,HasWebPages,HasCustomerFeedbacks,BrandId,HasOrder,HasBlogEditCollections,LogoUrl,FbAccessToken,StoreFeatureFilter,RunReport,AttendanceStoreFilter,StoreCode,PosId,StoreConfig,DefaultDashBoard,District,Province,Active,PaymentTypeApply")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "BrandName", store.BrandId);
            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
            db.SaveChanges();
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
