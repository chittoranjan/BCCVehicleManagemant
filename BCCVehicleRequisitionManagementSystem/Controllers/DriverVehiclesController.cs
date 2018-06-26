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
    public class DriverVehiclesController : Controller
    {
        private VehicleDbContext db = new VehicleDbContext();

        // GET: DriverVehicles
        public ActionResult Index()
        {
            var driverVehicles = db.DriverVehicles.Include(d => d.Driver).Include(d => d.Vehicle);
            return View(driverVehicles.ToList());
        }

        // GET: DriverVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverVehicle driverVehicle = db.DriverVehicles.Find(id);
            if (driverVehicle == null)
            {
                return HttpNotFound();
            }
            return View(driverVehicle);
        }

        // GET: DriverVehicles/Create
        public ActionResult Create()
        {
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id","Name");
            return View();
        }

        // POST: DriverVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DriverId,VehicleId")] DriverVehicle driverVehicle)
        {
            if (ModelState.IsValid)
            {
                db.DriverVehicles.Add(driverVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", driverVehicle.DriverId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "RegistrationNo", driverVehicle.VehicleId);
            return View(driverVehicle);
        }

        // GET: DriverVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverVehicle driverVehicle = db.DriverVehicles.Find(id);
            if (driverVehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", driverVehicle.DriverId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "RegistrationNo", driverVehicle.VehicleId);
            return View(driverVehicle);
        }

        // POST: DriverVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DriverId,VehicleId")] DriverVehicle driverVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driverVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "Name", driverVehicle.DriverId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "RegistrationNo", driverVehicle.VehicleId);
            return View(driverVehicle);
        }

        // GET: DriverVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverVehicle driverVehicle = db.DriverVehicles.Find(id);
            if (driverVehicle == null)
            {
                return HttpNotFound();
            }
            return View(driverVehicle);
        }

        // POST: DriverVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DriverVehicle driverVehicle = db.DriverVehicles.Find(id);
            db.DriverVehicles.Remove(driverVehicle);
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
