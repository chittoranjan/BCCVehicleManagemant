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
    public class EmployeeRepository 
    {
        readonly VehicleDbContext db=new VehicleDbContext();
        public bool Add(Employee employee)
        {
            db.Employees.Add(employee);
            return db.SaveChanges()>0;
        }

        public bool Update(Employee employee)
        {
            db.Employees.Attach(employee);
            db.Entry(employee).State=EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Remove(Employee employee)
        {
            employee.IsDeleted = true;
            return Update(employee);
        }

        public ICollection<Employee> GetAll(bool withDeleted = false)
        {
            return db.Employees.Where(c => c.IsDeleted == withDeleted).Include(c=>c.Department).Include(c=>c.EmployeeDesignation).ToList();
        }

        public Employee GetById(int id)
        {
            return db.Employees.Include(c=>c.Department).Include(c=>c.EmployeeDesignation).FirstOrDefault(c => c.Id == id);
        }

        public Employee GetByUserId(string userId)
        {
            return db.Employees.Where(c=>c.IsDeleted==false).Include(c => c.EmployeeDesignation).Include(c => c.Department).FirstOrDefault(c => c.UserId == userId);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
