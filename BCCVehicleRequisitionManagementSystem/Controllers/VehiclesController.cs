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
using BCCVehicleRequisitionManagementSystem.ViewModels;
using BLL;

namespace BCCVehicleRequisitionManagementSystem.Controllers
{
    public class VehiclesController : Controller
    {
        readonly VehicleManager _vehicleManager=new VehicleManager();
        VehicleDbContext db=new VehicleDbContext();

        // GET: Vehicles
        public ActionResult Index()
        {
            
            return View(_vehicleManager.GetAll());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = _vehicleManager.GetById((int)id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            VehicleViewModel vehicleVm=new VehicleViewModel();
            vehicleVm.Name = vehicle.Name;
            vehicleVm.RegistrationNo = vehicle.RegistrationNo;
            vehicleVm.VehicleTypeId = vehicle.VehicleTypeId;
            vehicleVm.Description = vehicle.Description;

            return View(vehicleVm);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "TypeName");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,VehicleTypeId,RegistrationNo,Description")] VehicleViewModel vehicleVm)
        {
            if (ModelState.IsValid)
            {
                Vehicle vehicle=new Vehicle();
                vehicle.Name = vehicleVm.Name;
                vehicle.RegistrationNo = vehicleVm.RegistrationNo;
                vehicle.VehicleTypeId = vehicleVm.VehicleTypeId;
                vehicle.Description = vehicleVm.Description;

                _vehicleManager.Add(vehicle);
                return RedirectToAction("Index");
            }

            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "TypeName", vehicleVm.VehicleTypeId);
            return View(vehicleVm);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = _vehicleManager.GetById((int)id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            VehicleViewModel vehicleVm = new VehicleViewModel();
            vehicleVm.Name = vehicle.Name;
            vehicleVm.RegistrationNo = vehicle.RegistrationNo;
            vehicleVm.VehicleTypeId = vehicle.VehicleTypeId;
            vehicleVm.Description = vehicle.Description;

            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "TypeName", vehicleVm.VehicleTypeId);
            return View(vehicleVm);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleTypeId,RegistrationNo,Description")] VehicleViewModel vehicleVm)
        {
            if (ModelState.IsValid)
            {
                Vehicle vehicle = new Vehicle();
                vehicle.Name = vehicleVm.Name;
                vehicle.RegistrationNo = vehicleVm.RegistrationNo;
                vehicle.VehicleTypeId = vehicleVm.VehicleTypeId;
                vehicle.Description = vehicleVm.Description;

                _vehicleManager.Update(vehicle);
                return RedirectToAction("Index");
            }
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "TypeName", vehicleVm.VehicleTypeId);
            return View(vehicleVm);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = _vehicleManager.GetById((int)id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            VehicleViewModel vehicleVm = new VehicleViewModel();
            vehicleVm.Id = vehicle.Id;
            vehicleVm.Name = vehicle.Name;
            vehicleVm.RegistrationNo = vehicle.RegistrationNo;
            vehicleVm.VehicleTypeId = vehicle.VehicleTypeId;
            vehicleVm.Description = vehicle.Description;

            return View(vehicleVm);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = _vehicleManager.GetById(id);
            _vehicleManager.Remove(vehicle);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                _vehicleManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
