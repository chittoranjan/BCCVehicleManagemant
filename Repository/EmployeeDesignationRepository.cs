using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.DatabaseContext;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using BCCVehicleRequisitionManagementSystem.Repository.Contracts;
using Repository.Base;

namespace Repository
{
    public class EmployeeDesignationRepository:Repository<EmployeeDesignation>,IEmployeeDesignationRepository
    {
        public ICollection<EmployeeDesignation> GetByDepartmentId(int departmentId)
        {

            return Get(c => c.DepartmentId == departmentId).ToList();
        }

        public EmployeeDesignationRepository(DbContext db) : base(db)
        {
        }
    }
}
