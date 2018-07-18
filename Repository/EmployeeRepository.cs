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
    public class EmployeeRepository:Repository<Employee>,IEmployeeRepository
    {
        readonly VehicleDbContext db=new VehicleDbContext();


        public override ICollection<Employee> GetAll(bool withDeleted = false)
        {
            return db.Employees.Where(c => c.IsDeleted == withDeleted).Include(c=>c.Department).Include(c=>c.EmployeeDesignation).ToList();
            
        }

        public override Employee GetById(int id)
        {
            return db.Employees.Include(c=>c.Department).Include(c=>c.EmployeeDesignation).FirstOrDefault(c => c.Id == id);
        }

        public Employee GetByUserId(string userId)
        {
            return db.Employees.Where(c=>c.IsDeleted==false).Include(c => c.EmployeeDesignation).Include(c => c.Department).FirstOrDefault(c => c.UserId == userId);
        }

        public EmployeeRepository(DbContext db) : base(db)
        {
        }
    }
}
