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
using BCCVehicleRequisitionManagementSystem.Models.Migrations;
using BCCVehicleRequisitionManagementSystem.ViewModels;
using BLL;

namespace BCCVehicleRequisitionManagementSystem.Controllers
{
    public class DepartmentsController : Controller
    {
        readonly DepartmentManager _departmentManager=new DepartmentManager();

        // GET: Departments
        public ActionResult Index()
        {
            List<Department> department = _departmentManager.GetAll();
            List<DepartmentViewModel> departmentViewModels = Mapper.Map<List<DepartmentViewModel>>(department);
            return View(departmentViewModels);
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentManager.GetById((int)id);
            if (department == null)
            {
                return HttpNotFound();
            }
            DepartmentViewModel departmentViewModel = Mapper.Map<DepartmentViewModel>(department);
            return View(departmentViewModel);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                Department department = Mapper.Map<Department>(departmentViewModel);
                _departmentManager.Add(department);

                TempData["Message"] = "Department is save successfully!";
                return RedirectToAction("Index");
            }

            return View(departmentViewModel);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentManager.GetById((int)id);
            if (department == null)
            {
                return HttpNotFound();
            }
            DepartmentViewModel departmentViewModel = Mapper.Map<DepartmentViewModel>(department);
            return View(departmentViewModel);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                Department department = Mapper.Map<Department>(departmentViewModel);
                _departmentManager.Update(department);

                TempData["Message"] = "Department is update successfully!";
                return RedirectToAction("Index");
            }
            return View(departmentViewModel);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentManager.GetById((int)id);
            if (department == null)
            {
                return HttpNotFound();
            }
            DepartmentViewModel departmentViewModel = Mapper.Map<DepartmentViewModel>(department);
            return View(departmentViewModel);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = _departmentManager.GetById(id);
            _departmentManager.Remove(department);

            TempData["Message"] = "Department remove successfully!";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _departmentManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
