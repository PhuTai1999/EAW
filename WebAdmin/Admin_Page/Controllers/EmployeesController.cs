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
    public class EmployeesController : Controller
    {
        private AEW_DEVEntities db = new AEW_DEVEntities();

        // GET: Employees
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
            var employees = db.Employees.Include(e => e.EmployeeGroup).Where(s => s.MainStoreId == storeId);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeGroupId = new SelectList(db.EmployeeGroups, "Id", "CodeGroup");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Role,EmpEnrollNumber,MainStoreId,Address,Phone,Active,BrandId,Salary,Status,DateStartWork,EmployeeGroupId,EmployeeCode,EmployeeRegency,DateOfBirth,EmployeeSex,PersonalCardId,DatePersonalCard,PlaceOfPersonalCard,PhoneNumber,Email,MainAddress,EmployeeHometown,EmployeePlaceBorn,DateQuitWork,ReasonQuit,PersonalIncomTax,MaritalStatus,SocialInsuranceNumber,BankNumber,Bank,EducationType,EducationStatus,EducationQualify,Specialized,SchoolName,CourseYear,FormOfTraining,ContactOne,ContactTwo,Image")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeGroupId = new SelectList(db.EmployeeGroups, "Id", "CodeGroup", employee.EmployeeGroupId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeGroupId = new SelectList(db.EmployeeGroups, "Id", "CodeGroup", employee.EmployeeGroupId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Role,EmpEnrollNumber,MainStoreId,Address,Phone,Active,BrandId,Salary,Status,DateStartWork,EmployeeGroupId,EmployeeCode,EmployeeRegency,DateOfBirth,EmployeeSex,PersonalCardId,DatePersonalCard,PlaceOfPersonalCard,PhoneNumber,Email,MainAddress,EmployeeHometown,EmployeePlaceBorn,DateQuitWork,ReasonQuit,PersonalIncomTax,MaritalStatus,SocialInsuranceNumber,BankNumber,Bank,EducationType,EducationStatus,EducationQualify,Specialized,SchoolName,CourseYear,FormOfTraining,ContactOne,ContactTwo,Image")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeGroupId = new SelectList(db.EmployeeGroups, "Id", "CodeGroup", employee.EmployeeGroupId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
