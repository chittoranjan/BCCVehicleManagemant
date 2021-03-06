﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BCCVehicleRequisitionManagementSystem.BLL.Contract;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using BCCVehicleRequisitionManagementSystem.ViewModels;
using BLL;
using Microsoft.AspNet.Identity;

namespace BCCVehicleRequisitionManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentManager _departmentManager;
        private readonly IEmployeeDesignationManager _employeeDesignationManager;

        public EmployeesController(IEmployeeManager employeeManager,IDepartmentManager departmentManager,IEmployeeDesignationManager employeeDesignationManager)
        {
            this._employeeManager = employeeManager;
            this._departmentManager = departmentManager;
            this._employeeDesignationManager = employeeDesignationManager;
        }
        // GET: Employees
        public ActionResult Index()
        {
            ICollection<Employee> employees = _employeeManager.GetAll();
            IEnumerable<EmployeeViewModel> employeeViewModels = Mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            return View(employeeViewModels);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int) id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            EmployeeViewModel employeeViewModel = Mapper.Map<EmployeeViewModel>(employee);
            return View(employeeViewModel);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
            ViewBag.EmployeeDesignationId = new SelectList(new[] { new SelectListItem() { Value = "", Text = "Select Designation" } }, "Value", "Text");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EmployeeDesignationId,DepartmentId,ContactNo,Address")] EmployeeViewModel employeeVm)   
        {
            if (ModelState.IsValid)
            {
                Employee employee = Mapper.Map<Employee>(employeeVm);
                _employeeManager.Add(employee);

                TempData["Message"] = "Employee save successfully!";
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
            ViewBag.EmployeeDesignationId = new SelectList(new[] { new SelectListItem() { Value = "", Text = "Select Designation" } }, "Value", "Text");
            return View(employeeVm);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int) id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            EmployeeViewModel employeeViewModel = Mapper.Map<EmployeeViewModel>(employee);
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", employeeViewModel.DepartmentId);
            if(ViewBag.DepartmentId != null)
            {
                ViewBag.EmployeeDesignationId = new SelectList(_employeeDesignationManager.GetByDepartmentId(employeeViewModel.DepartmentId), "Id", "Designation", employeeViewModel.EmployeeDesignationId);
            }
            
            return View(employeeViewModel);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EmployeeDesignationId,DepartmentId,ContactNo,Address,UserId")] EmployeeViewModel employeeVm) 
        {
            if (ModelState.IsValid)
            {
                Employee employee = Mapper.Map<Employee>(employeeVm);
                //var userId = User.Identity.GetUserId();
                //employee.UserId = userId;
                _employeeManager.Update(employee);
                 
                TempData["Message"] = "Employee update successfully!";
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", employeeVm.DepartmentId);
            if (ViewBag.DepartmentId!=null)
            {
                ViewBag.EmployeeDesignationId = new SelectList(_employeeDesignationManager.GetByDepartmentId(employeeVm.DepartmentId), "Id", "Designation", employeeVm.EmployeeDesignationId);
            }
            
            return View(employeeVm);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int) id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            EmployeeViewModel employeeViewModel = Mapper.Map<EmployeeViewModel>(employee);
            return View(employeeViewModel);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _employeeManager.GetById(id);
            _employeeManager.Remove(employee);

            TempData["Message"] = "Employee remove successfully!";

            return RedirectToAction("Index");
        }

        // GET: EmployeeProfile
        public ActionResult EmployeeProfile()
        {

            var userId = User.Identity.GetUserId();
            Employee employee = _employeeManager.GetByUserId(userId);
            if (employee==null)
            {
                return HttpNotFound();
            }
            EmployeeProfileViewModel employeeProfile = Mapper.Map<EmployeeProfileViewModel>(employee);
            return View(employeeProfile);
        }

        // GET: Employees/ProfileEdit/5
        public ActionResult EmployeeProfileEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            EmployeeProfileViewModel employeeProfileViewModel = Mapper.Map<EmployeeProfileViewModel>(employee);

            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", employeeProfileViewModel.DepartmentId);
            if (ViewBag.DepartmentId!=null)
            {
                ViewBag.EmployeeDesignationId = new SelectList(_employeeDesignationManager.GetByDepartmentId(employeeProfileViewModel.DepartmentId), "Id", "Designation", employeeProfileViewModel.EmployeeDesignationId);
            }
            
            return View(employeeProfileViewModel);
        }

        // POST: Employees/ProfileEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeProfileEdit([Bind(Include = "Id,Name,EmployeeDesignationId,DepartmentId,ContactNo,Address")] EmployeeProfileViewModel employeeProfileViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee employee = Mapper.Map<Employee>(employeeProfileViewModel);
                var userId = User.Identity.GetUserId();
                employee.UserId = userId;
                _employeeManager.Update(employee);

                TempData["Message"] = "Profile update successfully!";
                return RedirectToAction("EmployeeProfile","Employees");
            }
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", employeeProfileViewModel.DepartmentId);
            if (ViewBag.DepartmentId != null)
            {
                ViewBag.EmployeeDesignationId = new SelectList(_employeeDesignationManager.GetByDepartmentId(employeeProfileViewModel.DepartmentId), "Id", "Designation", employeeProfileViewModel.EmployeeDesignationId);
            }
            return View(employeeProfileViewModel);
        }

        // GET: Employees/ProfileDelete/5
        public ActionResult EmployeeProfileDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.GetById((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            EmployeeProfileViewModel employeeProfileViewModel = Mapper.Map<EmployeeProfileViewModel>(employee);
            return View(employeeProfileViewModel);
        }

        // POST: Employees/ProfileDelete/5
        [HttpPost, ActionName("EmployeeProfileDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeProfileDeleteConfirmed(int id)
        {
            Employee employee = _employeeManager.GetById(id);
            _employeeManager.Remove(employee);

            TempData["Message"] = "Profile remove successfully!";

            return RedirectToAction("EmployeeProfile","Employees");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _employeeManager.Dispose();
                _departmentManager.Dispose();
                _employeeDesignationManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
