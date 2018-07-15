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
    public class RequisitionRepository
    {
        readonly VehicleDbContext db = new VehicleDbContext();
        public bool Add(Requisition requisition)
        {
            db.Requisitions.Add(requisition);
            return db.SaveChanges() > 0;
        }

        public bool Update(Requisition requisition)
        {
            db.Requisitions.Attach(requisition);
            db.Entry(requisition).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Remove(Requisition requisition)
        {
            requisition.IsDeleted = true;
            return Update(requisition);
        }

        public ICollection<Requisition> GetAll(bool withDeleted = false)
        {
            return db.Requisitions.Where(c => c.IsDeleted == withDeleted).Include(r => r.Employee).ToList();
        }

        public Requisition GetById(int id)
        {
            return db.Requisitions.Include(c=>c.Employee).First(c => c.Id == id);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
