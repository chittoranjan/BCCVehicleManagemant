﻿using System;
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

namespace BCCVehicleRequisitionManagementSystem.Controllers
{
    public class VehicleTypesController : Controller
    {
        readonly VehicleTypeManager _vehicleTypeManager=new VehicleTypeManager();

        // GET: VehicleTypes
        public ActionResult Index()
        {
            ICollection<VehicleType> vehicleType = _vehicleTypeManager.GetAll();
            IEnumerable<VehicleTypeViewModel> vehicleList = Mapper.Map<IEnumerable<VehicleTypeViewModel>>(vehicleType);
            return View(vehicleList);
        }

        // GET: VehicleTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = _vehicleTypeManager.GetById((int)id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            VehicleTypeViewModel vehicleTypeViewModel = Mapper.Map<VehicleTypeViewModel>(vehicleType);
            return View(vehicleTypeViewModel);
        }

        // GET: VehicleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeName,Description")] VehicleTypeViewModel vehicleTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                VehicleType vehicleType = Mapper.Map<VehicleType>(vehicleTypeViewModel);
                _vehicleTypeManager.Add(vehicleType);

                TempData["Message"] = "Vehicle Type info save successfully!";
                return RedirectToAction("Index");
            }

            return View(vehicleTypeViewModel);
        }

        // GET: VehicleTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = _vehicleTypeManager.GetById((int)id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            VehicleTypeViewModel vehicleTypeViewModel = Mapper.Map<VehicleTypeViewModel>(vehicleType);
            return View(vehicleTypeViewModel);
        }

        // POST: VehicleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeName,Description")] VehicleTypeViewModel vehicleTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                VehicleType vehicleType = Mapper.Map<VehicleType>(vehicleTypeViewModel);
                _vehicleTypeManager.Update(vehicleType);

                TempData["Message"] = "Vehicle Type info save successfully!";
                return RedirectToAction("Index");
            }
            return View(vehicleTypeViewModel);
        }

        // GET: VehicleTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = _vehicleTypeManager.GetById((int)id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            VehicleTypeViewModel vehicleTypeViewModel = Mapper.Map<VehicleTypeViewModel>(vehicleType);
            return View(vehicleTypeViewModel);
        }

        // POST: VehicleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleType vehicleType = _vehicleTypeManager.GetById(id);
            _vehicleTypeManager.Remove(vehicleType);

            TempData["Message"] = "Vehicle Type info remove successfully!";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _vehicleTypeManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
