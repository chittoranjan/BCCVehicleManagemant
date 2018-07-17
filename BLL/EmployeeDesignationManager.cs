using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.BLL.Contract;
using BCCVehicleRequisitionManagementSystem.Models.Contracts;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using BCCVehicleRequisitionManagementSystem.Repository.Contracts;
using BLL.Base;
using Repository;

namespace BLL
{

    public class EmployeeDesignationManager:Manager<EmployeeDesignation>,IEmployeeDesignationManager
    {
        readonly IEmployeeDesignationRepository _employeeDesignationRepository;
        public EmployeeDesignationManager(IEmployeeDesignationRepository employeeDesignationRepository) : base(employeeDesignationRepository)
        {
            this._employeeDesignationRepository = employeeDesignationRepository;
        }
        public override bool Add(EmployeeDesignation employeeDesignation)
        {
            if (string.IsNullOrEmpty(employeeDesignation.Designation))
            {
                throw new Exception("Designation is not provided!");
            }
            if (employeeDesignation.DepartmentId==0)
            {
                throw new Exception("Department is not proveded!");
            }
            return _employeeDesignationRepository.Add(employeeDesignation);
        }

        public override bool Update(EmployeeDesignation employeeDesignation)
        {
            if (string.IsNullOrEmpty(employeeDesignation.Designation))
            {
                throw new Exception("Designation is not provided!");
            }
            if (employeeDesignation.Id == 0)
            {
                throw new Exception("Department is not proveded!");
            }
            return _employeeDesignationRepository.Update(employeeDesignation);
        }

        public override EmployeeDesignation GetById(int id)
        {
            if (id==0)
            {
                throw new Exception("Employee designation is not provided!");
            }
            return _employeeDesignationRepository.GetById(id);
        }

        public ICollection<EmployeeDesignation> GetByDepartmentId(int departmentId)
        {
            if (departmentId==0)
            {
                throw new Exception("Department id is not provided!");
            }
            return _employeeDesignationRepository.GetByDepartmentId(departmentId);
        }
        
    }
}
