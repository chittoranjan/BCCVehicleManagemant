using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using Repository;

namespace BLL
{

    public class EmployeeManager
    {
        readonly EmployeeRepository _repository = new EmployeeRepository();

        public bool Add(Employee employee)
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
            return _repository.Add(employee);
        }

        public bool Update(Employee employee)
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
            return _repository.Update(employee);
        }

        public bool Remove(Employee employee)
        {
            if (employee.Id == 0)
            {
                throw new Exception("Removable Employee is not selected!");
            }
            employee.IsDeleted = true;
            return _repository.Remove(employee);
        }

        public ICollection<Employee> GetAll(bool withDeleted = false)
        {
            return _repository.GetAll(withDeleted);
        }

        public Employee GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Employee GetByUserId(string userId)
        {
            return _repository.GetByUserId(userId);
        }
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
