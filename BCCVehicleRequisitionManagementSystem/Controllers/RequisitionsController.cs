using System;
using System.Collections;
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
using Microsoft.AspNet.Identity;

namespace BCCVehicleRequisitionManagementSystem.Controllers
{
    public class RequisitionsController : Controller
    {
         readonly RequisitionManager _requisitionManager = new RequisitionManager();
        readonly EmployeeManager _employeeManager=new EmployeeManager();

        // GET: Requisitions
        public ActionResult Index()
        {
            ICollection < Requisition >requisitions= _requisitionManager.GetAll();
            IEnumerable<RequisitionViewModel> requisitionViewModels = Mapper.Map<IEnumerable<RequisitionViewModel>>(requisitions);
            return View(requisitionViewModels);
        }

        // GET: Requisitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = _requisitionManager.GetById((int)id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            RequisitionViewModel requisitionViewModel = Mapper.Map<RequisitionViewModel>(requisition);
            return View(requisitionViewModel);
        }

        // GET: Requisitions/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();

            RequisitionViewModel requisitionViewModel=new RequisitionViewModel();
            requisitionViewModel.Employee = _employeeManager.GetByUserId(userId);

            return View(requisitionViewModel);
        }

        // POST: Requisitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,JourneyStartDateTime,JourneyEndDateTime,PlaceFrom,PlaceTo,Seat,Description")] RequisitionViewModel requisitionViewModel)
        {
            if (ModelState.IsValid)
            {
                Requisition requisition = Mapper.Map<Requisition>(requisitionViewModel);
                _requisitionManager.Add(requisition);
                return RedirectToAction("Index");
            }
            var userId = User.Identity.GetUserId();
            Employee employee = _employeeManager.GetByUserId(userId);
            requisitionViewModel.Employee = employee;
            return View(requisitionViewModel);
        }

        // GET: Requisitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = _requisitionManager.GetById((int)id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            RequisitionViewModel requisitionViewModel = Mapper.Map<RequisitionViewModel>(requisition);
            var userId = User.Identity.GetUserId();
            Employee employee = _employeeManager.GetByUserId(userId);
            requisitionViewModel.Employee = employee;

            return View(requisitionViewModel);
        }

        // POST: Requisitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,JourneyStartDateTime,JourneyEndDateTime,PlaceFrom,PlaceTo,Seat,Description")] RequisitionViewModel requisitionViewModel)
        {
            if (ModelState.IsValid)
            {
                Requisition requisition = Mapper.Map<Requisition>(requisitionViewModel);
                _requisitionManager.Update(requisition);
                return RedirectToAction("Index");
            }
            var userId = User.Identity.GetUserId();
            Employee employee = _employeeManager.GetByUserId(userId);
            requisitionViewModel.Employee = employee;
            return View(requisitionViewModel);
        }

        // GET: Requisitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = _requisitionManager.GetById((int)id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            RequisitionViewModel requisitionViewModel = Mapper.Map<RequisitionViewModel>(requisition);
            return View(requisitionViewModel);
        }

        // POST: Requisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requisition requisition = _requisitionManager.GetById(id);
            _requisitionManager.Remove(requisition);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _requisitionManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
