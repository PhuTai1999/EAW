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
    public class WorkingShiftsController : Controller
    {
        private AEW_DEVEntities db = new AEW_DEVEntities();

        // GET: WorkingShifts
        public ActionResult Index()
        {
            var idStr = Request.QueryString["Stores"];
            
            // Lấy data
            // Lấy toàn bộ thể loại:
            List<Store> stores = db.Stores.ToList();
            var storeId = stores.FirstOrDefault<Store>().ID;
            if (idStr != null)
            {
                storeId = int.Parse(idStr);
            }
            // Tạo SelectList
            SelectList storesList = new SelectList(stores, "ID", "NAME");
            // Set vào ViewBag
            ViewBag.CategoryList = storesList;
            var workingShifts = db.WorkingShifts.Include(w => w.Employee).Include(w => w.Store).Where(w => w.Store.ID == storeId);
            return View(workingShifts.ToList());

        }

        // GET: WorkingShifts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingShift workingShift = db.WorkingShifts.Find(id);
            if (workingShift == null)
            {
                return HttpNotFound();
            }
            return View(workingShift);
        }

        // GET: WorkingShifts/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            ViewBag.StoreId = new SelectList(db.Stores, "ID", "Name");
            return View();
        }

        // POST: WorkingShifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,Active,CheckMin,CheckMax,TotalWorkTime,Status,ShiftStart,ShiftEnd,CheckInTime,UpdatePerson,ProcessingStatus,Note,StoreId,TimeFramId,BreakTime,RequestedCheckOut,RequestedCheckIn,IsRequested,ApprovePerson,NoteRequest,LastCheckBeforeShift,FirstCheckAfterShift,IsOverTime,InMode,OutMode,BreakCount,CheckInExpandTime,CheckOutExpandTime,ComeLateExpandTime,LeaveEarlyExpandTime")] WorkingShift workingShift)
        {
            if (ModelState.IsValid)
            {
                db.WorkingShifts.Add(workingShift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", workingShift.EmployeeId);
            ViewBag.StoreId = new SelectList(db.Stores, "ID", "Name", workingShift.StoreId);
            return View(workingShift);
        }

        // GET: WorkingShifts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingShift workingShift = db.WorkingShifts.Find(id);
            if (workingShift == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", workingShift.EmployeeId);
            ViewBag.StoreId = new SelectList(db.Stores, "ID", "Name", workingShift.StoreId);
            return View(workingShift);
        }

        // POST: WorkingShifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,Active,CheckMin,CheckMax,TotalWorkTime,Status,ShiftStart,ShiftEnd,CheckInTime,UpdatePerson,ProcessingStatus,Note,StoreId,TimeFramId,BreakTime,RequestedCheckOut,RequestedCheckIn,IsRequested,ApprovePerson,NoteRequest,LastCheckBeforeShift,FirstCheckAfterShift,IsOverTime,InMode,OutMode,BreakCount,CheckInExpandTime,CheckOutExpandTime,ComeLateExpandTime,LeaveEarlyExpandTime")] WorkingShift workingShift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workingShift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", workingShift.EmployeeId);
            ViewBag.StoreId = new SelectList(db.Stores, "ID", "Name", workingShift.StoreId);
            return View(workingShift);
        }

        // GET: WorkingShifts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingShift workingShift = db.WorkingShifts.Find(id);
            if (workingShift == null)
            {
                return HttpNotFound();
            }
            return View(workingShift);
        }

        // POST: WorkingShifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkingShift workingShift = db.WorkingShifts.Find(id);
            db.WorkingShifts.Remove(workingShift);
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
