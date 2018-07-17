using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BCCVehicleRequisitionManagementSystem.BLL.Contract;
using BCCVehicleRequisitionManagementSystem.Models.DatabaseContext;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using BCCVehicleRequisitionManagementSystem.ViewModels;
using BLL;

namespace BCCVehicleRequisitionManagementSystem.Controllers
{
    public class EmployeeDesignationsController : Controller
    {
        readonly EmployeeDesignationManager _employeeDesignationManager=new EmployeeDesignationManager();
        private readonly IDepartmentManager _departmentManager;

        public EmployeeDesignationsController(IDepartmentManager departmentManager)
        {
            this._departmentManager = departmentManager;
        }

        // GET: EmployeeDesignations
        public ActionResult Index()
        {
            ICollection<EmployeeDesignation> employeeDesignation = _employeeDesignationManager.GetAll();
            IEnumerable<EmployeeDesignationViewModel> employeeDesignationViewModel =
                Mapper.Map<IEnumerable<EmployeeDesignationViewModel>>(employeeDesignation);
            return View(employeeDesignationViewModel);
        }

        // GET: EmployeeDesignations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDesignation employeeDesignation = _employeeDesignationManager.GetById((int)id);
            if (employeeDesignation == null)
            {
                return HttpNotFound();
            }
            EmployeeDesignationViewModel employeeDesignationViewModel =
                Mapper.Map<EmployeeDesignationViewModel>(employeeDesignation);
            return View(employeeDesignationViewModel);
        }

        // GET: EmployeeDesignations/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: EmployeeDesignations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Designation,DepartmentId")] EmployeeDesignationViewModel employeeDesignationVmViewModel)
        {
            if (ModelState.IsValid)
            {
                EmployeeDesignation employeeDesignation = Mapper.Map<EmployeeDesignation>(employeeDesignationVmViewModel);
                _employeeDesignationManager.Add(employeeDesignation);

                TempData["Message"] = "Designation save successfully!";
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Designation");
            return View(employeeDesignationVmViewModel);
        }

        // GET: EmployeeDesignations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDesignation employeeDesignation = _employeeDesignationManager.GetById((int)id);
            if (employeeDesignation == null)
            {
                return HttpNotFound();
            }
            EmployeeDesignationViewModel employeeDesignationViewModel =
                Mapper.Map<EmployeeDesignationViewModel>(employeeDesignation);
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", employeeDesignationViewModel.DepartmentId);
            return View(employeeDesignationViewModel);
        }

        // POST: EmployeeDesignations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Designation,DepartmentId")] EmployeeDesignationViewModel employeeDesignationVm)
        {
            if (ModelState.IsValid)
            {
                EmployeeDesignation employeeDesignation = Mapper.Map<EmployeeDesignation>(employeeDesignationVm);
                _employeeDesignationManager.Update(employeeDesignation);

                TempData["Message"] = "Designation update successfully!";
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name",employeeDesignationVm.DepartmentId);
            return View(employeeDesignationVm);
        }

        // GET: EmployeeDesignations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDesignation employeeDesignation = _employeeDesignationManager.GetById((int) id);
            if (employeeDesignation == null)
            {
                return HttpNotFound();
            }

            EmployeeDesignationViewModel employeeDesignationViewModel =
                Mapper.Map<EmployeeDesignationViewModel>(employeeDesignation);
            return View(employeeDesignationViewModel);
        }

        // POST: EmployeeDesignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDesignation employeeDesignation = _employeeDesignationManager.GetById(id);
            _employeeDesignationManager.Remove(employeeDesignation);

            TempData["Message"] = "Designation remove successfully!";
            return RedirectToAction("Index");
        }

        //JSON data call for dropdown....
        public JsonResult GetByDepartment(int? departmentId)
        {
            if (departmentId == null)
            {
                return null;
            }

            var designation =_employeeDesignationManager.GetByDepartmentId((int)departmentId);
            return Json(designation, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _employeeDesignationManager.Dispose();
                _departmentManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
