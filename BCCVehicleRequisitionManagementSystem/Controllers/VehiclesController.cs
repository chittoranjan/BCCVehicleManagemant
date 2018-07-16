using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BCCVehicleRequisitionManagementSystem.Models.DatabaseContext;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using BCCVehicleRequisitionManagementSystem.ViewModels;
using BLL;
using Repository;

namespace BCCVehicleRequisitionManagementSystem.Controllers
{
    public class VehiclesController : Controller
    {
        readonly VehicleManager _vehicleManager=new VehicleManager();
        readonly VehicleTypeManager _vehicleTypeManager=new VehicleTypeManager(new VehiclesTypeRepository());

        // GET: Vehicles
        public ActionResult Index()
        {
            ICollection<Vehicle> vehicles = _vehicleManager.GetAll();
            IEnumerable<VehicleViewModel> vehicleList = Mapper.Map<List<VehicleViewModel>>(vehicles);
            return View(vehicleList);
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
            VehicleViewModel vehicleVm = Mapper.Map<VehicleViewModel>(vehicle);

            return View(vehicleVm);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.VehicleTypeId = new SelectList(_vehicleTypeManager.GetAll(), "Id", "TypeName");
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
                Vehicle vehicle = Mapper.Map<Vehicle>(vehicleVm);

                _vehicleManager.Add(vehicle);

                TempData["Message"] = "Vehicle info save successfully!";
                return RedirectToAction("Index");
            }
            
            ViewBag.VehicleTypeId = new SelectList(_vehicleTypeManager.GetAll(), "Id", "TypeName", vehicleVm.VehicleTypeId);
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

            VehicleViewModel vehicleVm = Mapper.Map<VehicleViewModel>(vehicle);


            ViewBag.VehicleTypeId = new SelectList(_vehicleTypeManager.GetAll(), "Id", "TypeName", vehicleVm.VehicleTypeId);
            return View(vehicleVm);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,VehicleTypeId,RegistrationNo,Description")] VehicleViewModel vehicleVm)
        {
            if (ModelState.IsValid)
            {
                Vehicle vehicle = Mapper.Map<Vehicle>(vehicleVm);

                _vehicleManager.Update(vehicle);

                TempData["Message"] = "Vehicle info update successfully!";
                return RedirectToAction("Index");
            }
            
            ViewBag.VehicleTypeId = new SelectList(_vehicleTypeManager.GetAll(), "Id", "TypeName", vehicleVm.VehicleTypeId);
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
            VehicleViewModel vehicleVm = Mapper.Map<VehicleViewModel>(vehicle);


            return View(vehicleVm);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = _vehicleManager.GetById(id);
            _vehicleManager.Remove(vehicle);

            TempData["Message"] = "Vehicle info remove successfully!";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _vehicleManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
