using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BCCVehicleRequisitionManagementSystem.Models.DatabaseContext;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;

namespace BCCVehicleRequisitionManagementSystem.Controllers
{
    public class EmployeeDesignationsController : Controller
    {
        private VehicleDbContext db = new VehicleDbContext();

        // GET: EmployeeDesignations
        public ActionResult Index()
        {
            var employeeDesignations = db.EmployeeDesignations.Include(e => e.Department);
            return View(employeeDesignations.ToList());
        }

        // GET: EmployeeDesignations/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDesignation employeeDesignation = db.EmployeeDesignations.Find(id);
            if (employeeDesignation == null)
            {
                return HttpNotFound();
            }
            return View(employeeDesignation);
        }

        // GET: EmployeeDesignations/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        // POST: EmployeeDesignations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Designation,DepartmentId")] EmployeeDesignation employeeDesignation)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeDesignations.Add(employeeDesignation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employeeDesignation.DepartmentId);
            return View(employeeDesignation);
        }

        // GET: EmployeeDesignations/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDesignation employeeDesignation = db.EmployeeDesignations.Find(id);
            if (employeeDesignation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employeeDesignation.DepartmentId);
            return View(employeeDesignation);
        }

        // POST: EmployeeDesignations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Designation,DepartmentId")] EmployeeDesignation employeeDesignation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDesignation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employeeDesignation.DepartmentId);
            return View(employeeDesignation);
        }

        // GET: EmployeeDesignations/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDesignation employeeDesignation = db.EmployeeDesignations.Find(id);
            if (employeeDesignation == null)
            {
                return HttpNotFound();
            }
            return View(employeeDesignation);
        }

        // POST: EmployeeDesignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            EmployeeDesignation employeeDesignation = db.EmployeeDesignations.Find(id);
            db.EmployeeDesignations.Remove(employeeDesignation);
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
