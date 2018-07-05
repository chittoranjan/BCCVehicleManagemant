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
    public class DepartmentRepository   
    {
        readonly VehicleDbContext db=new VehicleDbContext();
        public bool Add(Department department)
        {
            db.Departments.Add(department);
            return db.SaveChanges()>0;
        }

        public bool Update(Department department)
        {
            db.Departments.Attach(department);
            db.Entry(department).State=EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Remove(Department department)
        {
            department.IsDeleted = true;
            return Update(department);
        }

        public List<Department> GetAll(bool withDeleted = false)
        {
            return db.Departments.Where(c => c.IsDeleted == withDeleted).ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(c => c.Id == id);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
