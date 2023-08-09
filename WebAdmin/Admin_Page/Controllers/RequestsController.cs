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
    public class RequestsController : Controller
    {
        private AEW_DEVEntities db = new AEW_DEVEntities();

        // GET: Requests
        public ActionResult Index()
        {
            var idStr = Request.QueryString["Stores"];
            var statusStr = Request.QueryString["Status"];

            // Lấy data
            // Lấy toàn bộ thể loại:
            List<Store> stores = db.Stores.ToList();
            List<CheckFace> checks = db.CheckFaces.ToList();
            var storeId = stores.FirstOrDefault<Store>().ID;
            var status = 1;
            if (idStr != null && statusStr != null)
            {
                storeId = int.Parse(idStr);
                status = int.Parse(statusStr);
            }
            // Tạo SelectList
            SelectList storesList = new SelectList(stores, "ID", "NAME");
            SelectList statusList = new SelectList(checks, "Statuts", "Statuts");
            // Set vào ViewBag
            ViewBag.Statuts = statusList;
            ViewBag.CategoryList = storesList;
            var checkFaces = db.CheckFaces.Include(c => c.Employee).Include(c => c.FaceScanMachine).Include(c => c.WorkingShift).Where(s => s.StoreId == storeId).Where(c => c.Statuts == status);
            return View(checkFaces.ToList());
        }

        // GET: Requests/Details/5
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

        // GET: Requests/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            ViewBag.FaceScanMachineId = new SelectList(db.FaceScanMachines, "Id", "MachineCode");
            ViewBag.WorkShiftId = new SelectList(db.WorkingShifts, "Id", "UpdatePerson");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FaceScanMachineId,EmployeeId,CreateTime,Mode,Active,StoreId,IsUpdated,Image,IpWifi,GPS,WorkShiftId,Content,Statuts")] CheckFace checkFace)
        {
            if (ModelState.IsValid)
            {
                db.CheckFaces.Add(checkFace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", checkFace.EmployeeId);
            ViewBag.FaceScanMachineId = new SelectList(db.FaceScanMachines, "Id", "MachineCode", checkFace.FaceScanMachineId);
            ViewBag.WorkShiftId = new SelectList(db.WorkingShifts, "Id", "UpdatePerson", checkFace.WorkShiftId);
            return View(checkFace);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            var statusStr = Request.QueryString["Status"];
            //[Bind(Include = "Id,Statuts")] CheckFace checkFace
            if (ModelState.IsValid)
            {
                var data = db.CheckFaces.Find(id);
                data.Statuts = int.Parse(statusStr);
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var checkFaces = db.CheckFaces.Include(c => c.Employee).Include(c => c.FaceScanMachine).Include(c => c.WorkingShift).Where(s => s.StoreId == 3).Where(c => c.Statuts == 1);
            return View(checkFaces);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FaceScanMachineId,EmployeeId,CreateTime,Mode,Active,StoreId,IsUpdated,Image,IpWifi,GPS,WorkShiftId,Content,Statuts")] CheckFace checkFace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkFace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", checkFace.EmployeeId);
            ViewBag.FaceScanMachineId = new SelectList(db.FaceScanMachines, "Id", "MachineCode", checkFace.FaceScanMachineId);
            ViewBag.WorkShiftId = new SelectList(db.WorkingShifts, "Id", "UpdatePerson", checkFace.WorkShiftId);
            return View(checkFace);
        }*/

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            var idStr = Request.QueryString["ID"];
            var statusStr = Request.QueryString["Status"];
            //[Bind(Include = "Id,Statuts")] CheckFace checkFace
            if (ModelState.IsValid)
            {
                var data = db.CheckFaces.Find(int.Parse(idStr));
                data.Statuts = int.Parse(statusStr);
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var checkFaces = db.CheckFaces.Include(c => c.Employee).Include(c => c.FaceScanMachine).Include(c => c.WorkingShift).Where(s => s.StoreId == 3).Where(c => c.Statuts == 1);
            return View(checkFaces);
        }*/

        // GET: Requests/Delete/5
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

        // POST: Requests/Delete/5
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
