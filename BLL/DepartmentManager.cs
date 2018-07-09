using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using Repository;

namespace BLL
{

    public class DepartmentManager  
    {
        readonly DepartmentRepository _repository = new DepartmentRepository();

        public bool Add(Department department)
        {
            if (string.IsNullOrEmpty(department.Name))
            {
                throw new Exception("Department Name is not provided!");
            }
            return _repository.Add(department);
        }

        public bool Update(Department department)
        {
            if (string.IsNullOrEmpty(department.Name))
            {
                throw new Exception("Department Name is not provided!");
            }
            return _repository.Update(department);
        }

        public bool Remove(Department department)
        {
            if (department.Id == 0)
            {
                throw new Exception("Removable Department is not selected!");
            }
            department.IsDeleted = true;
            return _repository.Remove(department);
        }

        public ICollection<Department> GetAll(bool withDeleted = false)
        {
            return _repository.GetAll(withDeleted);
        }

        public Department GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
