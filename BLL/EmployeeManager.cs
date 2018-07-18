using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.BLL.Contract;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using BCCVehicleRequisitionManagementSystem.Repository.Contracts;
using BLL.Base;
using Repository;

namespace BLL
{

    public class EmployeeManager:Manager<Employee>,IEmployeeManager
    {
        readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public override bool Add(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
            {
                throw new Exception("Name is not provided!");
            }
            if (employee.DepartmentId==0)
            {
                throw new Exception("Department is not proveded!");
            }
            if (employee.EmployeeDesignationId == 0)
            {
                throw new Exception("Designation is not proveded!");
            }
            if (string.IsNullOrEmpty(employee.ContactNo))
            {
                throw new Exception("Contact no is not proveded!");
            }
            if (string.IsNullOrEmpty(employee.Address))
            {
                throw new Exception("Address is not provided!");
            }
            return _employeeRepository.Add(employee);
        }

        public override bool Update(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
            {
                throw new Exception("Name is not provided!");
            }
            if (employee.DepartmentId == 0)
            {
                throw new Exception("Department is not proveded!");
            }
            if (employee.EmployeeDesignationId == 0)
            {
                throw new Exception("Designation is not proveded!");
            }
            if (string.IsNullOrEmpty(employee.ContactNo))
            {
                throw new Exception("Contact no is not proveded!");
            }
            if (string.IsNullOrEmpty(employee.Address))
            {
                throw new Exception("Address is not provided!");
            }
            return _employeeRepository.Update(employee);
        }

        public override Employee GetById(int id)
        {
            if (id==0)
            {
                throw new Exception("Employee id is not proviede!");
            }
            return _employeeRepository.GetById(id);
        }

        public Employee GetByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new Exception("User id is not provided!");
            }
            return _employeeRepository.GetByUserId(userId);
        }
        
    }
}
