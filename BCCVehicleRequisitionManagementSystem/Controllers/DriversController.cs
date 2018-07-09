using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BCCVehicleRequisitionManagementSystem.Models;
using BCCVehicleRequisitionManagementSystem.Models.DatabaseContext;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using BCCVehicleRequisitionManagementSystem.ViewModels;
using BLL;

namespace BCCVehicleRequisitionManagementSystem.Controllers
{
    public class DriversController : Controller
    {
         readonly DriverManager _driverManager=new DriverManager();

        // GET: Drivers
        public ActionResult Index()
        {
            ICollection<Driver> driver = _driverManager.GetAll();
            IEnumerable<DriverViewModel> driverViewModel = Mapper.Map<IEnumerable<DriverViewModel>>(driver);
            return View(driverViewModel);
        }

        // GET: Drivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = _driverManager.GetById((int)id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            DriverViewModel driverViewModel = Mapper.Map<DriverViewModel>(driver);
            return View(driverViewModel);
        }

        // GET: Drivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MobileNo,LicenceNo,NID,Address")] DriverViewModel driverViewModel)
        {
            if (ModelState.IsValid)
            {
                Driver driver = Mapper.Map<Driver>(driverViewModel);
                _driverManager.Add(driver);

                TempData["Message"] = "Driver info is save successfully!";
                return RedirectToAction("Index");
            }

            return View(driverViewModel);
        }

        // GET: Drivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = _driverManager.GetById((int)id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            DriverViewModel driverViewModel = Mapper.Map<DriverViewModel>(driver);
            return View(driverViewModel);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MobileNo,LicenceNo,NID,Address")] DriverViewModel driverViewModel)
        {
            if (ModelState.IsValid)
            {
                Driver driver = Mapper.Map<Driver>(driverViewModel);
                _driverManager.Update(driver);
                TempData["Message"] = "Driver update successfully!";
                return RedirectToAction("Index");
            }
            return View(driverViewModel);
        }

        // GET: Drivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver driver = _driverManager.GetById((int)id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            DriverViewModel driverViewModel = Mapper.Map<DriverViewModel>(driver);
            return View(driverViewModel);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Driver driver = _driverManager.GetById(id);
            _driverManager.Remove(driver);
            TempData["Message"] = "Driver remove successfully!";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _driverManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
