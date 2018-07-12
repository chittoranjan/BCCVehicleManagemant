using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCCVehicleRequisitionManagementSystem.Models.DatabaseContext;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using Repository.Base;

namespace Repository
{
    public class VehiclesTypeRepository
    {
        readonly VehicleDbContext db = new VehicleDbContext();
        public bool Add(VehicleType vehicleType)
        {
            db.VehicleTypes.Add(vehicleType);
            return db.SaveChanges() > 0;
        }

        public bool Update(VehicleType vehicleType)
        {
            db.VehicleTypes.Attach(vehicleType);
            db.Entry(vehicleType).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Remove(VehicleType vehicleType)
        {
            vehicleType.IsDeleted = true;
            return Update(vehicleType);
        }

        public ICollection<VehicleType> GetAll(bool withDeleted = false)
        {
            return db.VehicleTypes.Where(c => c.IsDeleted == withDeleted).ToList();
        }

        public VehicleType GetById(int id)
        {
            return db.VehicleTypes.FirstOrDefault(c => c.Id == id);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
