using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.DatabaseContext;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;

namespace Repository
{
    public class EmployeeDesignationRepository
    {
        readonly VehicleDbContext db=new VehicleDbContext();
        public bool Add(EmployeeDesignation employeeDesignation)
        {
            db.EmployeeDesignations.Add(employeeDesignation);
            return db.SaveChanges()>0;
        }

        public bool Update(EmployeeDesignation employeeDesignation)
        {
            db.EmployeeDesignations.Attach(employeeDesignation);
            db.Entry(employeeDesignation).State=EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Remove(EmployeeDesignation employeeDesignation)
        {
            employeeDesignation.IsDeleted = true;
            return Update(employeeDesignation);
        }

        public List<EmployeeDesignation> GetAll(bool withDeleted = false)
        {
            return db.EmployeeDesignations.Where(c => c.IsDeleted == withDeleted).Include(c=>c.Department).ToList();
        }

        public EmployeeDesignation GetById(int id)
        {
            return db.EmployeeDesignations.Include(c=>c.Department).FirstOrDefault(c => c.Id == id);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
