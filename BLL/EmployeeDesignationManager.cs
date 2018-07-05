using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using Repository;

namespace BLL
{

    public class EmployeeDesignationManager
    {
        readonly EmployeeDesignationRepository _repository = new EmployeeDesignationRepository();

        public bool Add(EmployeeDesignation employeeDesignation)
        {
            if (string.IsNullOrEmpty(employeeDesignation.Designation))
            {
                throw new Exception("Designation is not provided!");
            }
            if (employeeDesignation.DepartmentId==0)
            {
                throw new Exception("Department is not proveded!");
            }
            return _repository.Add(employeeDesignation);
        }

        public bool Update(EmployeeDesignation employeeDesignation)
        {
            if (string.IsNullOrEmpty(employeeDesignation.Designation))
            {
                throw new Exception("Designation is not provided!");
            }
            if (employeeDesignation.Id == 0)
            {
                throw new Exception("Department is not proveded!");
            }
            return _repository.Update(employeeDesignation);
        }

        public bool Remove(EmployeeDesignation employeeDesignation)
        {
            if (employeeDesignation.Id == 0)
            {
                throw new Exception("Removable Designation is not selected!");
            }
            employeeDesignation.IsDeleted = true;
            return _repository.Remove(employeeDesignation);
        }

        public List<EmployeeDesignation> GetAll(bool withDeleted = false)
        {
            return _repository.GetAll(withDeleted);
        }

        public EmployeeDesignation GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
