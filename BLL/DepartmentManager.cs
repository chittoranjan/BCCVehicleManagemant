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

    public class DepartmentManager:Manager<Department>,IDepartmentManager
    {
        readonly IDepartmentRepository _repository;
        public DepartmentManager(IDepartmentRepository repository) : base(repository)
        {
            this._repository = repository;
        }
        public override bool Add(Department department)
        {
            if (string.IsNullOrEmpty(department.Name))
            {
                throw new Exception("Department Name is not provided!");
            }
            return _repository.Add(department);
        }

        public override bool Update(Department department)
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

        public override Department GetById(int id)
        {
            if (id==0)
            {
                throw new Exception("Department id is not provided!");
            }
            return _repository.GetById(id);
        }
        
    }
}
