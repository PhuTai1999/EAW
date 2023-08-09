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
    public class HistoryController : Controller
    {
        private AEW_DEVEntities db = new AEW_DEVEntities();

        // GET: History
        public ActionResult Index()
        {
            DateTime now = DateTime.Now;
            var idStr = Request.QueryString["Stores"];
            var selectDate = Request.QueryString["selectDate"];

            // Lấy data
            // Lấy toàn bộ thể loại:
            List<Store> stores = db.Stores.ToList();
            var storeId = stores.FirstOrDefault<Store>().ID;
            DateTime createDate = DateTime.Now;
            if (idStr != null || selectDate != null)
            {
                storeId = int.Parse(idStr);
                createDate = DateTime.Parse(selectDate);
            }
            // Tạo SelectList
            SelectList storesList = new SelectList(stores, "ID", "NAME");
            // Set vào ViewBag
            ViewBag.CategoryList = storesList;
            var checkFaces = db.CheckFaces.Include(c => c.Employee).Include(c => c.FaceScanMachine).Where(c => c.StoreId == storeId).Where(c => c.CreateTime >= createDate);
            return View(checkFaces.ToList());
        }

        // GET: History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckFace checkFace = db.CheckFaces.Find(id);
            if (checkFace == null)
            {
                return HttpNotFound();
            }
            return View(checkFace);
        }

        // GET: History/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            ViewBag.FaceScanMachineId = new SelectList(db.FaceScanMachines, "Id", "MachineCode");
            return View();
        }

        // POST: History/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FaceScanMachineId,EmployeeId,CreateTime,Mode,Active,StoreId,IsUpdated,Image,IpWifi,GPS")] CheckFace checkFace)
        {
            if (ModelState.IsValid)
            {
                db.CheckFaces.Add(checkFace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", checkFace.EmployeeId);
            ViewBag.FaceScanMachineId = new SelectList(db.FaceScanMachines, "Id", "MachineCode", checkFace.FaceScanMachineId);
            return View(checkFace);
        }

        // GET: History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckFace checkFace = db.CheckFaces.Find(id);
            if (checkFace == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", checkFace.EmployeeId);
            ViewBag.FaceScanMachineId = new SelectList(db.FaceScanMachines, "Id", "MachineCode", checkFace.FaceScanMachineId);
            return View(checkFace);
        }

        // POST: History/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FaceScanMachineId,EmployeeId,CreateTime,Mode,Active,StoreId,IsUpdated,Image,IpWifi,GPS")] CheckFace checkFace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkFace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", checkFace.EmployeeId);
            ViewBag.FaceScanMachineId = new SelectList(db.FaceScanMachines, "Id", "MachineCode", checkFace.FaceScanMachineId);
            return View(checkFace);
        }

        // GET: History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckFace checkFace = db.CheckFaces.Find(id);
            if (checkFace == null)
            {
                return HttpNotFound();
            }
            return View(checkFace);
        }

        // POST: History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckFace checkFace = db.CheckFaces.Find(id);
            db.CheckFaces.Remove(checkFace);
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
