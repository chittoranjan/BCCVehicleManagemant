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
    public class DriverRepository
    {
        readonly VehicleDbContext db=new VehicleDbContext();
        public bool Add(Driver driver)
        {
            db.Drivers.Add(driver);
            return db.SaveChanges()>0;
        }

        public bool Update(Driver driver)
        {
            db.Drivers.Attach(driver);
            db.Entry(driver).State=EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Remove(Driver driver)
        {
            driver.IsDeleted = true;
            return Update(driver);
        }

        public List<Driver> GetAll(bool withDeleted = false)
        {
            return db.Drivers.Where(c => c.IsDeleted == withDeleted).ToList();
        }

        public Driver GetById(int id)
        {
            return db.Drivers.FirstOrDefault(c => c.Id == id);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
